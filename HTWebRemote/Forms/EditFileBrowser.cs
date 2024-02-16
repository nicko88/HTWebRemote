using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HTWebRemote.Util;
using Microsoft.Win32;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace HTWebRemote.Forms
{
    public partial class EditFileBrowser : Form
    {
        public EditFileBrowser()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillRemoteNumDropDown();
            FillGroupDropDown();
            LoadPaths();
            LoadSettings();
        }

        private void LoadPaths()
        {
            lbPaths.Items.Clear();

            if (File.Exists(ConfigHelper.browsePaths))
            {
                List<string> paths = File.ReadLines(ConfigHelper.browsePaths).ToList();

                foreach (string path in paths)
                {
                    lbPaths.Items.Add(path);
                }
            }
        }

        private void LoadSettings()
        {
            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowFileBrowser"))
            {
                cbShowFileBrowser.Checked = true;
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "EnableYoutube"))
            {
                cbEnableYoutube.Checked = true;
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "YoutubeUseWebBrowser"))
            {
                cbYoutubeUseWebBrowser.Checked = true;
            }

            cmbFileBrowserRemote.SelectedItem = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserRemote");
            cmbFileBrowserGroup.SelectedItem = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserGroup");

            string FBMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserMediaPlayer");
            if (!string.IsNullOrEmpty(FBMediaPlayerPath))
            {
                lblFBMediaPlayerPath.Text = FBMediaPlayerPath;
            }

            string YTMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "YoutubeMediaPlayer");
            if (!string.IsNullOrEmpty(YTMediaPlayerPath))
            {
                lblYTMediaPlayerPath.Text = YTMediaPlayerPath;
            }

            tbYoutubeAPIKey.Text = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "YoutubeAPIKey");
            tbItemRowHeight.Text = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "ItemRowHeight");

            if (cmbFileBrowserRemote.SelectedIndex == -1)
            {
                cmbFileBrowserRemote.SelectedIndex = 0;
            }
        }

        private void FillRemoteNumDropDown()
        {
            int remoteNum = 1;
            cmbFileBrowserRemote.Items.Clear();

            try
            {
                string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();
                JObject oRemote = JObject.Parse(File.ReadAllText(remoteFiles[remoteFiles.Length - 1]));
                remoteNum = Convert.ToInt32(oRemote.SelectToken("RemoteID"));
            }
            catch { }

            cmbFileBrowserRemote.Items.Add("None");
            for (int i = 1; i < remoteNum + 1; i++)
            {
                cmbFileBrowserRemote.Items.Add(i.ToString());
            }
        }

        private void FillGroupDropDown()
        {
            cmbFileBrowserGroup.Items.Clear();

            string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();
            List<string> groups = new List<string>();

            foreach (string file in remoteFiles)
            {
                if (file.Contains(".json"))
                {
                    JObject oRemote = JObject.Parse(File.ReadAllText(file));
                    string remoteGroup = (string)oRemote.SelectToken("RemoteGroup");

                    if (!string.IsNullOrEmpty(remoteGroup) && !groups.Contains(remoteGroup))
                    {
                        groups.Add(remoteGroup);
                    }
                }
            }

            cmbFileBrowserGroup.DataSource = groups;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectPath = new FolderBrowserDialog();
            DialogResult result = selectPath.ShowDialog();

            if(result == DialogResult.OK)
            {
                File.AppendAllText(ConfigHelper.browsePaths, selectPath.SelectedPath + Environment.NewLine);
            }

            LoadPaths();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> paths = File.ReadLines(ConfigHelper.browsePaths).ToList();

                paths.Remove(lbPaths.SelectedItem.ToString());

                File.Delete(ConfigHelper.browsePaths);

                foreach (string path in paths)
                {
                    File.AppendAllText(ConfigHelper.browsePaths, path + Environment.NewLine);
                }
            }
            catch { }

            LoadPaths();
        }

        private void btnAddManual_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(tbManualPath.Text))
            {
                File.AppendAllText(ConfigHelper.browsePaths, tbManualPath.Text + Environment.NewLine);
                tbManualPath.Clear();
            }
            else
            {
                MessageBox.Show("The path you entered cannot be found.","Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadPaths();
        }

        private void cmbFileBrowserRemote_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("FileBrowserRemote", cmbFileBrowserRemote.SelectedItem.ToString());
        }

        private void cbShowFileBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowFileBrowser.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("ShowFileBrowser", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("ShowFileBrowser", false);
            }
        }

        private void btnChooseFBMediaPlayer_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                lblFBMediaPlayerPath.Text = openFileDialog.FileName;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("FileBrowserMediaPlayer", openFileDialog.FileName);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("FileBrowserMediaPlayer", false);
                lblFBMediaPlayerPath.Text = "Default Media Player";
            }
        }

        private void btnChooseYTMediaPlayer_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblYTMediaPlayerPath.Text = openFileDialog.FileName;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("YoutubeMediaPlayer", openFileDialog.FileName);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("YoutubeMediaPlayer", false);
                lblYTMediaPlayerPath.Text = "Default Web Browser";
            }
        }

        private void cbEnableYoutube_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableYoutube.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("EnableYoutube", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("EnableYoutube", false);
            }
        }

        private void cbYoutubeUseWebBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbYoutubeUseWebBrowser.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("YoutubeUseWebBrowser", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("YoutubeUseWebBrowser", false);
            }
        }

        private void lblYoutubePlayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ys.3dyd.com");
        }

        private void tbNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void EditFileBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("YoutubeAPIKey", tbYoutubeAPIKey.Text);
            key.SetValue("ItemRowHeight", tbItemRowHeight.Text);
            key.SetValue("FileBrowserGroup", cmbFileBrowserGroup.SelectedItem);
        }

        private void lblAPIHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://developers.google.com/youtube/v3/getting-started");
        }

        private void btnAddAlias_Click(object sender, EventArgs e)
        {
            if(lbPaths.SelectedIndex > -1)
            {
                string[] vals = lbPaths.SelectedItem.ToString().Split(',');
                if(!string.IsNullOrEmpty(tbAlias.Text))
                {
                    lbPaths.Items[lbPaths.SelectedIndex] = vals[0] + "," + tbAlias.Text.Replace(",", "");
                }
                else
                {
                    lbPaths.Items[lbPaths.SelectedIndex] = vals[0];
                }

                File.Delete(ConfigHelper.browsePaths);
                foreach (string path in lbPaths.Items)
                {
                    File.AppendAllText(ConfigHelper.browsePaths, path + Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show("Please select a folder path to add an alias to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lbPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPaths.SelectedIndex > -1)
            {
                string[] vals = lbPaths.SelectedItem.ToString().Split(',');
                if (vals.Length > 1)
                {
                    tbAlias.Text = vals[1];
                }
                else
                {
                    tbAlias.Text = "";
                }
            }
        }
    }
}