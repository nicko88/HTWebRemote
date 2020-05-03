using HTPCRemote.RemoteFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class CommandEditor : Form
    {
        private List<Command> Commands;

        public CommandEditor(List<Command> commands)
        {
            InitializeComponent();
            Commands = commands;

            cmbDevices.DataSource = Devices.DeviceSelector.GetDeviceNames();
            LoadCommands();
        }

        private void cmbAddCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetControls();

            try
            {
                if(cmbAddCommand.SelectedItem.ToString() == "Command")
                {
                    panelCommand.Visible = true;
                }
                else if(cmbAddCommand.SelectedItem.ToString() == "Wait Time")
                {
                    panelWaitTime.Visible = true;
                }
            }
            catch { }
        }

        private void lbCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAddCommand.SelectedIndex = -1;
            ResetControls();

            if (lbCommands.SelectedItem is Command)
            {
                Command currentCommand = (Command)lbCommands.SelectedItem;

                if(currentCommand.WaitTimeMS > 0)
                {
                    panelWaitTime.Visible = true;
                    tbWaitTime.Text = currentCommand.WaitTimeMS.ToString();
                    btnAddWait.Visible = false;
                    btnSaveWait.Visible = true;
                    btnDeleteWait.Visible = true;
                }
                else
                {
                    panelCommand.Visible = true;
                    cmbDevices.SelectedItem = currentCommand.DeviceName;
                    tbCommand.Text = currentCommand.Cmd;
                    tbParam.Text = currentCommand.Param;
                    btnAddCmd.Visible = false;
                    btnSaveCmd.Visible = true;
                    btnDeleteCmd.Visible = true;
                }
            }
        }

        private void ResetControls()
        {
            panelCommand.Visible = false;
            cmbDevices.SelectedIndex = -1;
            lblDevice.ForeColor = Color.Black;
            tbCommand.Text = "";
            tbParam.Text = "";
            btnAddCmd.Visible = true;
            btnSaveCmd.Visible = false;
            btnDeleteCmd.Visible = false;

            panelWaitTime.Visible = false;
            tbWaitTime.Text = "";
            tbWaitTime.BackColor = Color.White;
            btnAddWait.Visible = true;
            btnSaveWait.Visible = false;
            btnDeleteWait.Visible = false;
        }

        private void LoadCommands()
        {
            ResetControls();
            cmbAddCommand.SelectedIndex = -1;

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
            if(cmbDevices.SelectedIndex == -1)
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
    }
}