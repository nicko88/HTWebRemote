using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTWebRemote.Util;
using Newtonsoft.Json.Linq;

namespace HTWebRemote.Forms
{
    public partial class ManageRemoteHost : Form
    {
        private string errors;
        public ManageRemoteHost()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            tbIP.Text = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "RemoteHostIP");

            CheckGitVersion();

            if (Regex.IsMatch(tbIP.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                CheckAppVersion();
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            errors = "";
            bool success = false;

            //delete remote files
            using (HttpClient httpClient = new HttpClient())
            {
                _ = httpClient.GetStringAsync($"http://{tbIP.Text}:5000/deleteremotes").Result;
                Thread.Sleep(1000);
            }

            if (File.Exists(ConfigHelper.DeviceFile))
            {
                string deviceConfigFile = File.ReadAllText(ConfigHelper.DeviceFile);
                success = SendFile("HTWebRemoteDevices.txt", deviceConfigFile);
            }
            else
            {
                errors += "No device configuration found to sync.\n\n";
            }

            if (success)
            {
                string[] files = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        string remoteFile = File.ReadAllText(file);
                        success = SendFile(Path.GetFileName(file), remoteFile);
                    }
                }
                else
                {
                    errors += "No remotes found to sync.\n\n";
                }
            }

            if(success)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"BottomTabs={ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs")}");

                SendFile("HTWebRemoteSettings.txt", sb.ToString());
            }

            if(success)
            {
                MessageBox.Show("All remotes were synced successfully!", "Sync Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The following errors were encountered while syncing:\n\n" + errors, "Sync Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SendFile(string fileName, string fileData)
        {
            bool success = true;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("filename", fileName);
                    HttpContent httpContent = new StringContent(fileData);

                    HttpResponseMessage httpResponse = httpClient.PostAsync($"http://{tbIP.Text}:5000/syncfile", httpContent).Result;

                    if(!httpResponse.IsSuccessStatusCode)
                    {
                        errors += $"HTTP Code: {httpResponse.StatusCode} - {httpResponse.ReasonPhrase}\n\n";
                        success = false;
                    }
                }
            }
            catch(Exception e)
            {
                errors += e.AllMessages() + "\n\n" + e.InnerException + "\n\n";
                success = false;
            }

            return success;
        }

        private async void CheckAppVersion()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    lblHostVersion.Text = await httpClient.GetStringAsync($"http://{tbIP.Text}:5000/version");

                    if (lblHostVersion.Text.StartsWith("v"))
                    {
                        lblHostVersion.Visible = true;
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "CONNECTED";
                        btnSync.Enabled = true;
                        btnErrorlog.Enabled = true;
                        btnUpdate.Text = "Update Host App";
                        lblRemoteUI.Enabled = true;
                        toolsToolStripMenuItem.Enabled = true;

                        if (lblHostVersion.Text != lblLatestVersion.Text && (lblHostVersion.Visible && lblLatestVersion.Visible))
                        {
                            btnUpdate.Enabled = true;
                        }
                        else
                        {
                            btnUpdate.Enabled = false;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    lblHostVersion.Visible = false;
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "NOT CONNECTED";
                    btnSync.Enabled = false;
                    btnErrorlog.Enabled = false;
                    lblRemoteUI.Enabled = false;
                    btnUpdate.Enabled = false;
                    toolsToolStripMenuItem.Enabled = false;

                }
            }
        }

        private async void CheckGitVersion()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("User-Agent", ".netapp");
                    string releaseJSON = await httpClient.GetStringAsync("https://api.github.com/repos/nicko88/htwebremotehost/releases/latest");
                    JObject data = JObject.Parse(releaseJSON);
                    string latest = (string)data["tag_name"];

                    lblLatestVersion.Text = latest;
                    lblLatestVersion.Visible = true;

                    if (lblHostVersion.Text != lblLatestVersion.Text && (lblHostVersion.Visible && lblLatestVersion.Visible))
                    {
                        btnUpdate.Enabled = true;
                    }
                    else
                    {
                        btnUpdate.Enabled = false;
                    }
                }
                catch
                {
                    lblLatestVersion.Visible = false;
                    btnUpdate.Enabled = false;
                }
            }
        }

        private void SyncRemotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("RemoteHostIP", tbIP.Text);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnUpdate.Text = "Updating...";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    await httpClient.GetStringAsync($"http://{tbIP.Text}:5000/update");

                    await Task.Delay(10000);
                    CheckAppVersion();
                }
                catch { }
            }
        }

        private void btnErrorlog_Click(object sender, EventArgs e)
        {
            Process.Start($"http://{tbIP.Text}:5000/errorlog");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(tbIP.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                CheckAppVersion();
            }
        }

        private void lblRemoteUI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://{tbIP.Text}:5000");
        }

        private void transferNVShieldAuthorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.android\adbkey"))
            {
                errors = "";
                string adbkeyFile = File.ReadAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\.android\adbkey");
                bool success = SendFile("adbkey", adbkeyFile);

                if (success)
                {
                    MessageBox.Show($"adbkey transfered successfully.\n\nTry controlling your NVShield now.","Key transfered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"{errors}", "Error sending adbkey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Your computer is missing the adbkey file:\n\n" +
                    $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\.android\\adbkey\n\n" +
                    $"Please setup, connect to, and control your NVShield at least once from this Windows PC before attempting to transfer the key to your Remote Host.", "Missing adbkey file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void rebootRasPiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to reboot the HTWebRemoteHost PC?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await httpClient.GetStringAsync($"http://{tbIP.Text}:5000/rebootpc");
                    }
                }
                catch { }
            }
        }
    }
}