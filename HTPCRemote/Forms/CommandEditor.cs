using HTPCRemote.RemoteFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class CommandEditor : Form
    {
        private List<Command> Commands;
        public int LastDeviceIndex;

        public CommandEditor(List<Command> commands, int lastDeviceIndex)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            Commands = commands;
            LoadCommands();

            cmbDevices.DataSource = Devices.DeviceSelector.GetDeviceNames();
            try
            {
                LastDeviceIndex = lastDeviceIndex;
                cmbDevices.SelectedIndex = lastDeviceIndex;
            }
            catch { }

            cmbAddCommand.SelectedIndex = 0;
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

            if (lbCommands.SelectedItem is Command)
            {
                Command currentCommand = (Command)lbCommands.SelectedItem;

                if(currentCommand.WaitTimeMS > 0)
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
        }

        private void btnDoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start($"http://{Util.ConfigHelper.GetLocalIPAddress()}:5000/doc");
        }
    }
}