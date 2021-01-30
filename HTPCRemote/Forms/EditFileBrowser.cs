using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using HTPCRemote.Util;
using Microsoft.Win32;
using System.Drawing;

namespace HTPCRemote.Forms
{
    public partial class EditFileBrowser : Form
    {
        public EditFileBrowser()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

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
            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowFileBrowser"))
            {
                cbShowFileBrowser.Checked = true;
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "EnableYoutube"))
            {
                cbEnableYoutube.Checked = true;
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "YoutubeUseWebBrowser"))
            {
                cbYoutubeUseWebBrowser.Checked = true;
            }

            cmbFileBrowserRemote.SelectedItem = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "FileBrowserRemote");

            string FBMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "FileBrowserMediaPlayer");
            if (!string.IsNullOrEmpty(FBMediaPlayerPath))
            {
                lblFBMediaPlayerPath.Text = FBMediaPlayerPath;
            }

            string YTMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "YoutubeMediaPlayer");
            if (!string.IsNullOrEmpty(YTMediaPlayerPath))
            {
                lblYTMediaPlayerPath.Text = YTMediaPlayerPath;
            }

            tbYoutubeAPIKey.Text = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "YoutubeAPIKey");

            if (cmbFileBrowserRemote.SelectedIndex == -1)
            {
                cmbFileBrowserRemote.SelectedIndex = 0;
            }
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
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
            key.SetValue("FileBrowserRemote", cmbFileBrowserRemote.SelectedItem.ToString());
        }

        private void cbShowFileBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowFileBrowser.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
                key.SetValue("ShowFileBrowser", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTPCRemote", true);
                key.DeleteValue("ShowFileBrowser", false);
            }
        }

        private void btnChooseFBMediaPlayer_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                lblFBMediaPlayerPath.Text = openFileDialog.FileName;

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
                key.SetValue("FileBrowserMediaPlayer", openFileDialog.FileName);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTPCRemote", true);
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

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
                key.SetValue("YoutubeMediaPlayer", openFileDialog.FileName);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTPCRemote", true);
                key.DeleteValue("YoutubeMediaPlayer", false);
                lblYTMediaPlayerPath.Text = "Default Web Browser";
            }
        }

        private void cbEnableYoutube_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableYoutube.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
                key.SetValue("EnableYoutube", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTPCRemote", true);
                key.DeleteValue("EnableYoutube", false);
            }
        }

        private void cbYoutubeUseWebBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbYoutubeUseWebBrowser.Checked)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
                key.SetValue("YoutubeUseWebBrowser", true);
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTPCRemote", true);
                key.DeleteValue("YoutubeUseWebBrowser", false);
            }
        }

        private void lblYoutubePlayer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ys.3dyd.com");
        }

        private void EditFileBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTPCRemote", true);
            key.SetValue("YoutubeAPIKey", tbYoutubeAPIKey.Text);
        }

        private void lblAPIHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://developers.google.com/youtube/v3/getting-started");
        }
    }
}