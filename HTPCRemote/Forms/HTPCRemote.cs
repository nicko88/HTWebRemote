using HTPCRemote.RemoteFile;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using HTPCRemote.Util;

namespace HTPCRemote
{
    public partial class HTPCRemote : Form
    {
        private string IP;
        private Thread httpThread;

        public HTPCRemote()
        {
            InitializeComponent();

            Setup();

            httpThread = new Thread(StartListen);
            httpThread.Start();
        }

        public void Setup()
        {
            ConfigHelper.Setup();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            IP = ConfigHelper.GetLocalIPAddress();
            Text = "HTPCRemote v" + version + "   (IP: " + IP + ":5000)";

            if(ConfigHelper.CheckRegKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", "HTPCRemote"))
            {
                cbStartAutomatically.Checked = true;
            }

            if (ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "StartMinimized"))
            {
                cbStartMinimized.Checked = true;

                Hide();
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }

            if (ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "ShowErrors"))
            {
                cbxShowErrors.Checked = true;
            }

        }

        public void StartListen()
        {
            while (true)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://*:5000/");

                try
                {
                    listener.Start();
                }
                catch
                {
                    Invoke(new Action(() => { MessageBox.Show("Cannot open Port: 5000\n\nTry running as Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }));
                    trayIcon.Visible = false;
                    Environment.Exit(0);
                }

                HttpListenerContext context = listener.GetContext();
                ProcessRequest(context);

                Thread.Sleep(250);
                listener.Stop();
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            byte[] buffer = System.Text.Encoding.ASCII.GetBytes("");
            string htmlPage = "";
            string RemoteID = "";

            if(request.RawUrl.Contains("/FB"))
            {

                buffer = FileBrowserV2.LoadFileBrowser(context);
            }
            else
            {
                if (request.RawUrl == "/")
                {
                    RemoteID = "1";
                }
                else
                {
                    RemoteID = request.RawUrl.Trim('/');
                }

                string rID = "";
                try
                {
                    rID = request.QueryString["rID"];
                }
                catch { }

                if(!string.IsNullOrEmpty(rID))
                {
                    RemoteID = rID;
                }

                if (File.Exists(ConfigHelper.jsonButtonFiles + RemoteID + ".html"))
                {
                    htmlPage = File.ReadAllText(ConfigHelper.jsonButtonFiles + RemoteID + ".html");
                }
                else
                {
                    htmlPage = RemoteParser.GetRemoteHTML(RemoteID, true);
                }

                htmlPage = htmlPage.Replace("{IP}", IP);
   
                string devIP = "";
                try
                {
                    devIP = request.QueryString["ip"];
                }
                catch { }

                string devName = "";
                try
                {
                    devName = request.QueryString["devname"];
                }
                catch { }

                if (!string.IsNullOrEmpty(devIP))
                {
                    string devType = "";
                    string cmd = "";
                    string param = "";
                    try
                    {
                        devType = request.QueryString["dev"];
                        cmd = request.QueryString["cmd"];
                        param = request.QueryString["param"];
                    }
                    catch { }

                    Devices.DeviceSelector.CommandDevice(devIP, devType, cmd, param);
                }
                else if(!string.IsNullOrEmpty(devName))
                {
                    string cmd = "";
                    string param = "";
                    try
                    {
                        cmd = request.QueryString["cmd"];
                        param = request.QueryString["param"];
                    }
                    catch { }

                    string queryData = Devices.DeviceSelector.FindDevice(devName, cmd, param);

                    if(!string.IsNullOrEmpty(queryData))
                    {
                        htmlPage = htmlPage.Replace("null;", "alert('" + queryData + "')");
                    }
                }
                else
                {
                    string remoteID = "";
                    string btnIndex = "";
                    try
                    {
                        remoteID = request.QueryString["remoteID"];
                        btnIndex = request.QueryString["btnIndex"];
                        if (!string.IsNullOrEmpty(remoteID) && !string.IsNullOrEmpty(btnIndex))
                        {
                            Remote remote = RemoteJSONLoader.LoadRemoteJSON(remoteID);

                            Thread commandThread = new Thread(remote.RemoteItems[Convert.ToInt32(btnIndex)].RunButtonCommands);
                            commandThread.Start();
                        }
                    }
                    catch { }
                }

                buffer = System.Text.Encoding.ASCII.GetBytes(htmlPage);
            }

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            try
            {
                output.Write(buffer, 0, buffer.Length);
            }
            catch { }
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void HTPCRemote_FormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void LblDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DocReader reader = new DocReader(IP);
            reader.Show();
        }

        private void LblOpenFileBrowser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://" + IP + ":5000/FB");
        }

        private void LblRemoteUI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://" + IP + ":5000");
        }

        private void btnEditRemoteUI_Click(object sender, EventArgs e)
        {
            Forms.RemoteEditor editRemoteUI = new Forms.RemoteEditor();
            editRemoteUI.Show();
        }

        private void btnEditFileBrowser_Click(object sender, EventArgs e)
        {
            Forms.EditFileBrowser editFileBrowser = new Forms.EditFileBrowser();
            editFileBrowser.Show();
        }

        private void cbStartAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            if(cbStartAutomatically.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue("HTPCRemote", Application.ExecutablePath);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.DeleteValue("HTPCRemote", false);
            }
        }

        private void cbStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartMinimized.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\HTPCRemote", true);
                key.SetValue("StartMinimized", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\HTPCRemote", true);
                key.DeleteValue("StartMinimized", false);
            }
        }

        private void cbxShowErrors_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowErrors.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\HTPCRemote", true);
                key.SetValue("ShowErrors", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\HTPCRemote", true);
                key.DeleteValue("ShowErrors", false);
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
    }
}