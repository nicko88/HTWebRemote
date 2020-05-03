using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class EditFileBrowser : Form
    {
        public EditFileBrowser()
        {
            InitializeComponent();

            LoadPaths();

            if (Util.ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "ShowFileBrowser"))
            {
                cbShowFileBrowser.Checked = true;
            }

            cmbFileBrowserRemote.SelectedItem = Util.ConfigHelper.GetRegKey("SOFTWARE\\HTPCRemote", "FileBrowserRemote");

            if(cmbFileBrowserRemote.SelectedIndex == -1)
            {
                cmbFileBrowserRemote.SelectedIndex = 0;
            }
        }

        private void LoadPaths()
        {
            lbPaths.Items.Clear();

            if (File.Exists(Util.ConfigHelper.browsePaths))
            {
                List<string> paths = File.ReadLines(Util.ConfigHelper.browsePaths).ToList();

                foreach (string path in paths)
                {
                    lbPaths.Items.Add(path);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectPath = new FolderBrowserDialog();
            DialogResult result = selectPath.ShowDialog();

            if(result == DialogResult.OK)
            {
                File.AppendAllText(Util.ConfigHelper.browsePaths, selectPath.SelectedPath + Environment.NewLine);
            }

            LoadPaths();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> paths = File.ReadLines(Util.ConfigHelper.browsePaths).ToList();

                paths.Remove(lbPaths.SelectedItem.ToString());

                File.Delete(Util.ConfigHelper.browsePaths);

                foreach (string path in paths)
                {
                    File.AppendAllText(Util.ConfigHelper.browsePaths, path + Environment.NewLine);
                }
            }
            catch { }

            LoadPaths();
        }

        private void cmbFileBrowserRemote_SelectedIndexChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\HTPCRemote", true);
            key.SetValue("FileBrowserRemote", cmbFileBrowserRemote.SelectedItem.ToString());
        }

        private void cbShowFileBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowFileBrowser.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\HTPCRemote", true);
                key.SetValue("ShowFileBrowser", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\HTPCRemote", true);
                key.DeleteValue("ShowFileBrowser", false);
            }
        }
    }
}