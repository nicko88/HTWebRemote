using HTWebRemote.RemoteFile;
using HTWebRemote.Util;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class CommandEditor : Form
    {
        private Form Editor;
        private List<Command> Commands;
        public int LastDeviceIndex;
        private int ButtonIndex;

        public CommandEditor(Form editor, List<Command> commands, string buttonLabel, int buttonIndex, int lastDeviceIndex)
        {
            InitializeComponent();
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", false);
                int[] size = (regKey.GetValue("CommandEditorSize") as string[]).Select(int.Parse).ToArray();
                Width = size[0];
                Height = size[1];
            }
            catch { }
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            Editor = editor;
            Commands = commands;
            ButtonIndex = buttonIndex;
            this.Text += $" - [{buttonLabel}]";
            LoadCommands();

            cmbDevices.DataSource = Devices.DeviceSelector.GetDeviceNames();
            try
            {
                LastDeviceIndex = lastDeviceIndex;
                cmbDevices.SelectedIndex = lastDeviceIndex;
            }
            catch { }
        }

        private void cmbAddCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetControls();

            try
            {
                if(cmbAddCommand.SelectedItem.ToString() == "Command")
                {
                    panelCommand.Visible = true;
                    panelWaitTime.Visible = false;
                }
                else if(cmbAddCommand.SelectedItem.ToString() == "Wait Time")
                {
                    panelWaitTime.Visible = true;
                    panelCommand.Visible = false;
                }
            }
            catch { }
        }

        private void lbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetControls();

            if (lbCommands.SelectedItem is Command currentCommand)
            {
                if (currentCommand.WaitTimeMS > 0)
                {
                    cmbAddCommand.SelectedIndex = 1;
                    panelWaitTime.Visible = true;
                    panelCommand.Visible = false;
                    tbWaitTime.Text = currentCommand.WaitTimeMS.ToString();
                    btnAddWait.Visible = false;
                    btnSaveWait.Visible = true;
                    btnDeleteWait.Visible = true;
                }
                else
                {
                    cmbAddCommand.SelectedIndex = 0;
                    panelCommand.Visible = true;
                    panelWaitTime.Visible = false;
                    cmbDevices.SelectedItem = currentCommand.DeviceName;
                    if (currentCommand.DeviceName == "win")
                    {
                        cmbDevices.SelectedItem = "pc";
                    }
                    tbCommand.Text = currentCommand.Cmd;
                    tbParam.Text = currentCommand.Param;
                    btnAddCmd.Visible = false;
                    btnSaveCmd.Visible = true;
                    btnDeleteCmd.Visible = true;
                }
            }
            else
            {
                cmbAddCommand.SelectedIndex = 0;
                panelCommand.Visible = true;
                panelWaitTime.Visible = false;
                btnAddCmd.Visible = true;
                btnSaveCmd.Visible = true;
                btnDeleteCmd.Visible = false;
            }
        }

        private void ResetControls()
        {
            lblDevice.ForeColor = Color.Black;
            tbCommand.Text = "";
            tbParam.Text = "";
            btnAddCmd.Visible = true;
            btnSaveCmd.Visible = false;
            btnDeleteCmd.Visible = false;

            tbWaitTime.Text = "";
            tbWaitTime.BackColor = Color.White;
            btnAddWait.Visible = true;
            btnSaveWait.Visible = false;
            btnDeleteWait.Visible = false;
        }

        private void LoadCommands()
        {
            ResetControls();

            lbCommands.DataSource = null;
            lbCommands.Items.Clear();

            try
            {
                lbCommands.DataSource = Commands;
                lbCommands.DisplayMember = Commands.ToString();
                lbCommands.SelectedIndex = -1;
            }
            catch { }
        }

        private void btnAddCmd_Click(object sender, EventArgs e)
        {
            int devindex = cmbDevices.SelectedIndex;
            if (devindex == -1)
            {
                lblDevice.ForeColor = Color.Red;
                return;
            }

            int insertIndex = lbCommands.Items.Count;
            if (lbCommands.SelectedIndex > -1)
            {
                insertIndex = lbCommands.SelectedIndex + 1;
            }

            string param = tbParam.Text;
            if(string.IsNullOrEmpty(tbParam.Text))
            {
                param = null;
            }
            Command command = new Command(cmbDevices.SelectedItem.ToString(), tbCommand.Text, param);
            Commands.Insert(insertIndex, command);
            LoadCommands();
            cmbDevices.SelectedIndex = devindex;
        }

        private void btnSaveCmd_Click(object sender, EventArgs e)
        {
            Command selectedCmd = (Command)lbCommands.SelectedItem;
            selectedCmd.DeviceName = cmbDevices.SelectedItem.ToString();
            selectedCmd.Cmd = tbCommand.Text;

            if(string.IsNullOrEmpty(tbParam.Text))
            {
                selectedCmd.Param = null;
            }
            else
            {
                selectedCmd.Param = tbParam.Text;
            }
            LoadCommands();
        }

        private void btnDeleteCmd_Click(object sender, EventArgs e)
        {
            Commands.Remove((Command)lbCommands.SelectedItem);
            LoadCommands();
        }

        private void btnAddWait_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbWaitTime.Text))
            {
                tbWaitTime.BackColor = Color.Red;
                return;
            }

            int insertIndex = lbCommands.Items.Count;
            if (lbCommands.SelectedIndex > -1)
            {
                insertIndex = lbCommands.SelectedIndex + 1;
            }
            Command command = new Command(Convert.ToInt32(tbWaitTime.Text));
            Commands.Insert(insertIndex, command);
            LoadCommands();
        }

        private void btnSaveWait_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbWaitTime.Text))
            {
                tbWaitTime.BackColor = Color.Red;
                return;
            }

            Command selectedCmd = (Command)lbCommands.SelectedItem;
            selectedCmd.WaitTimeMS = Convert.ToInt32(tbWaitTime.Text);
            LoadCommands();
        }

        private void btnDeleteWait_Click(object sender, EventArgs e)
        {
            Commands.Remove((Command)lbCommands.SelectedItem);
            LoadCommands();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbCommands.SelectedItem is Command)
            {
                int index = lbCommands.SelectedIndex;
                if (index > 0)
                {
                    Command item = Commands[index];
                    Commands.RemoveAt(index);
                    Commands.Insert(index - 1, item);
                    LoadCommands();

                    lbCommands.SelectedIndex = index - 1;
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbCommands.SelectedItem is Command)
            {
                int index = lbCommands.SelectedIndex;
                if (index < lbCommands.Items.Count - 1)
                {
                    Command item = Commands[index];
                    Commands.RemoveAt(index);
                    Commands.Insert(index + 1, item);
                    LoadCommands();

                    lbCommands.SelectedIndex = index + 1;
                }
            }
        }

        private void tbWaitTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CommandEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            LastDeviceIndex = cmbDevices.SelectedIndex;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("CommandEditorSize", new string[] { Width.ToString(), Height.ToString() });
        }

        private void btnDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string port = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "Port");
            if(string.IsNullOrEmpty(port))
            {
                port = "5000";
            }

            Process.Start($"http://{ConfigHelper.LocalIPAddress}:{port}/doc");
        }

        private void btnTestCmds_Click(object sender, EventArgs e)
        {
            if (Editor is RemoteEditor remoteEditor)
            {
                remoteEditor.currentRemote.RemoteItems[ButtonIndex].RunButtonCommands();
            }
            else if (Editor is HotkeyManager hotkeyManager)
            {
                hotkeyManager.Hotkeys[ButtonIndex].RunButtonCommands();
            }
            else if (Editor is VoiceCommandManager voiceCommandManager)
            {
                voiceCommandManager.VoiceCommands[ButtonIndex].RunButtonCommands();
            }
        }

        private void CommandEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}