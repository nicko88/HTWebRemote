using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using HTWebRemote.Util;
using HTWebRemote.RemoteFile;
using System.Drawing;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HTWebRemote
{
    public partial class HTWebRemote : Form
    {
        private string IP;
        private string port;
        private readonly Thread httpThread;
        private bool startFail = false;

        public HTWebRemote(string port)
        {
            this.port = port;
            ConfigHelper.ConvertLegacyFiles();

            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            trayIcon.Icon = Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            ConfigHelper.Setup(port);
            Setup(true);

            httpThread = new Thread(StartListen);
            httpThread.Start();
        }

        public async void Setup(bool full)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd(new char[] { '.', '0' });
            IP = ConfigHelper.LocalIPAddress;
            Text = $"HTWebRemote v{version}   (IP: {IP}:{port})";

            if(ConfigHelper.CheckRegKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "HTWebRemote"))
            {
                cbStartAutomatically.Checked = true;
            }

            if (full)
            {
                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "StartMinimized"))
                {
                    cbStartMinimized.Checked = true;

                    Hide();
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                }
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowErrors"))
            {
                cbxShowErrors.Checked = true;
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs"))
            {
                cbxBottomTabs.Checked = true;
            }

            await CheckNewVersion();
        }

        public void StartListen()
        {
            bool running = false;

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add($"http://*:{port}/");

            while (!running)
            {
                try
                {
                    listener.Start();
                    running = true;
                }
                catch (Exception e)
                {
                    if (!startFail)
                    {
                        startFail = true;
                        Thread.Sleep(10000);
                        Setup(false);
                        StartListen();
                    }
                    else
                    {
                        Invoke(new Action(() => { MessageBox.Show($"Cannot open Port: {port}\n\nTry running as Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }));
                        Environment.Exit(0);
                    }
                }
            }

            while (true)
            {
                IAsyncResult result = listener.BeginGetContext(new AsyncCallback(ProcessRequest), listener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        private void ProcessRequest(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            HttpListenerContext context = listener.EndGetContext(result);
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string queryData = ProcessCommand(request);
            string htmlPage = ProcessResponse(request);

            if (!string.IsNullOrEmpty(queryData))
            {
                htmlPage = htmlPage.Replace("null;", "alert('" + queryData + "')");
            }

            byte[] buffer = new byte[0];
            if (htmlPage != null)
            {
                buffer = System.Text.Encoding.UTF8.GetBytes(htmlPage);
            }

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            try
            {
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
            catch { }
        }

        private string ProcessCommand(HttpListenerRequest request)
        {
            string queryData = null;

            string devtype = request.QueryString["devtype"];
            string devname = request.QueryString["devname"];
            string btnIndex = request.QueryString["btnIndex"];

            if (!string.IsNullOrEmpty(devtype))
            {
                string IP = request.QueryString["ip"];
                string cmd = request.QueryString["cmd"];
                string param = request.QueryString["param"];
                string specialData = request.QueryString["special"];

                Devices.DeviceSelector.CommandDevice(IP, devtype, cmd, param, specialData);
            }
            else if (!string.IsNullOrEmpty(devname))
            {
                string cmd = request.QueryString["cmd"];
                string param = request.QueryString["param"];

                queryData = Devices.DeviceSelector.FindDevice(devname, cmd, param);
            }
            else if (!string.IsNullOrEmpty(btnIndex))
            {
                string remoteID = request.QueryString["remoteID"];
                Remote remote = RemoteJSONLoader.LoadRemoteJSON(remoteID);

                remote.RemoteItems[Convert.ToInt32(btnIndex)].RunButtonCommands();
            }

            return queryData;
        }

        private string ProcessResponse(HttpListenerRequest request)
        {
            string htmlPage = null;
            string RemoteID = null;

            if (request.RawUrl.Contains("/FB") && !request.RawUrl.Contains("remoteID"))
            {
                htmlPage = FileBrowser.LoadFileBrowser(request);
            }

            if (request.RawUrl.Contains("/doc"))
            {
                htmlPage = ConfigHelper.GetEmbeddedResource("doc.html");
                htmlPage = htmlPage.Replace("{BASEIP}", IP);
                htmlPage = htmlPage.Replace("{port}", port);
            }

            if (request.RawUrl.Contains("closeyt"))
            {
                YoutubeSearch._searchQ = null;
            }

            if (request.RawUrl == "/")
            {
                RemoteID = "1";
            }
            else if(request.RawUrl.Length == 2 || request.RawUrl.Length == 3 && !request.RawUrl.Contains("/FB"))
            {
                RemoteID = request.RawUrl.Trim('/');
            }

            if(!string.IsNullOrEmpty(request.QueryString["rID"]))
            {
                RemoteID = request.QueryString["rID"];
            }

            if (RemoteID != null)
            {
                htmlPage = RemoteParser.GetRemoteHTML(RemoteID, true);
            }

            return htmlPage;
        }

        private async Task CheckNewVersion()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".netapp");
                    string releaseJSON = await httpClient.GetStringAsync("https://api.github.com/repos/nicko88/htwebremote/releases/latest");
                    JObject data = JObject.Parse(releaseJSON);
                    string latest = (string)data["tag_name"];

                    string version = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd(new char[] { '.', '0' });

                    if (version != latest)
                    {
                        lnkNewVersion.Text = latest;
                        lnkNewVersion.Visible = true;
                        lblNewVersion.Visible = true;
                    }
                }
                catch { }
            }
        }

        private async void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            await CheckNewVersion();
        }

        private void HTWebRemote_FormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            try
            {
                Process.GetProcessesByName("adb")[0].Kill();
            }
            catch { }
            Environment.Exit(0);
        }

        private void LblDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://{IP}:{port}/doc");
        }

        private void LblOpenFileBrowser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://{IP}:{port}/FB");
        }

        private void LblRemoteUI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://{IP}:{port}");
        }

        private void btnEditRemoteUI_Click(object sender, EventArgs e)
        {
            Forms.RemoteEditor editRemoteUI = new Forms.RemoteEditor();
            editRemoteUI.ShowDialog();
        }

        private void btnEditFileBrowser_Click(object sender, EventArgs e)
        {
            Forms.EditFileBrowser editFileBrowser = new Forms.EditFileBrowser();
            editFileBrowser.ShowDialog();
        }

        private void cbStartAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            if(cbStartAutomatically.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue("HTWebRemote", Application.ExecutablePath);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.DeleteValue("HTWebRemote", false);
            }
        }

        private void cbStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartMinimized.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("StartMinimized", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("StartMinimized", false);
            }
        }

        private void cbxShowErrors_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowErrors.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("ShowErrors", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("ShowErrors", false);
            }
        }

        private void cbxBottomTabs_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBottomTabs.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("BottomTabs", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("BottomTabs", false);
            }
        }

        private void btnConfigureIPs_Click(object sender, EventArgs e)
        {
            Forms.DeviceIPManager IPs = new Forms.DeviceIPManager();
            IPs.ShowDialog();
        }

        private void btnMinimizeToTray_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Forms.Donate donate = new Forms.Donate();
            donate.ShowDialog();
        }

        private void btnSyncRemotes_Click(object sender, EventArgs e)
        {
            Forms.ManageRemoteHost sync = new Forms.ManageRemoteHost();
            sync.ShowDialog();
        }

        private void lnkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"https://github.com/nicko88/HTWebRemote/releases/latest");
        }
    }
}