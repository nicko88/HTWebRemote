using HTWebRemote.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class ReorderRemotes : Form
    {
        public ReorderRemotes()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            LoadRemotes();
        }

        private void LoadRemotes()
        {
            int remoteNum = 1;
            lbRemotes.Items.Clear();

            try
            {
                string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();
                JObject oRemote = JObject.Parse(File.ReadAllText(remoteFiles[remoteFiles.Length - 1]));
                remoteNum = Convert.ToInt32(oRemote.SelectToken("RemoteID"));
            }
            catch { }

            for (int i = 1; i < remoteNum + 1; i++)
            {
                lbRemotes.Items.Add(i);
            }

            AddRemoteNames();
        }

        private void AddRemoteNames()
        {
            for (int i = 1; i <= lbRemotes.Items.Count; i++)
            {
                if (File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{i}.json")))
                {
                    JObject oRemote = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{i}.json")));
                    lbRemotes.Items[i - 1] = i + $" - {oRemote.SelectToken("RemoteName")}";
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            bool temp = false;
            int selectedIndex = lbRemotes.SelectedIndex;

            //if not the top remote and selected remote exists
            if (lbRemotes.SelectedIndex > 0 && File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json")))
            {
                //if remote exists above, add 1 to its remoteID and rename it to .jsontemp
                if (File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.json")))
                {
                    temp = true;
                    JObject oRemoteAbove = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.json")));
                    oRemoteAbove["RemoteID"] = Convert.ToInt32(oRemoteAbove["RemoteID"]) + 1;
                    File.WriteAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.jsontemp"), oRemoteAbove.ToString());
                    File.Delete(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.json"));
                }

                //lower remoteID and filename of selected remote by 1
                JObject oRemoteSelected = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json")));
                oRemoteSelected["RemoteID"] = Convert.ToInt32(oRemoteSelected["RemoteID"]) - 1;
                File.WriteAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.json"), oRemoteSelected.ToString());
                File.Delete(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json"));

                //rename jsontemp to final name
                if (temp)
                {
                    File.Move(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex}.jsontemp"), Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json"));
                }

                Thread.Sleep(100);
                LoadRemotes();
                lbRemotes.SelectedIndex = selectedIndex - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            bool temp = false;
            int selectedIndex = lbRemotes.SelectedIndex;

            //if not the bottom remote and selected remote exists
            if (lbRemotes.SelectedIndex < lbRemotes.Items.Count - 1 && File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json")))
            {
                //if remote exists below, subtract 1 from its remoteID and rename it to .jsontemp
                if (File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.json")))
                {
                    temp = true;
                    JObject oRemoteBelow = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.json")));
                    oRemoteBelow["RemoteID"] = Convert.ToInt32(oRemoteBelow["RemoteID"]) - 1;
                    File.WriteAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.jsontemp"), oRemoteBelow.ToString());
                    File.Delete(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.json"));
                }

                //raise remoteID and filename of selected remote by 1
                JObject oRemoteSelected = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json")));
                oRemoteSelected["RemoteID"] = Convert.ToInt32(oRemoteSelected["RemoteID"]) + 1;
                File.WriteAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.json"), oRemoteSelected.ToString());
                File.Delete(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json"));

                //rename jsontemp to final name
                if (temp)
                {
                    File.Move(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 2}.jsontemp"), Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{lbRemotes.SelectedIndex + 1}.json"));
                }

                Thread.Sleep(100);
                LoadRemotes();
                lbRemotes.SelectedIndex = selectedIndex + 1;
            }
        }
    }
}