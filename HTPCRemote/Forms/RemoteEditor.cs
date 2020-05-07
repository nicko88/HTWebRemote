using HTPCRemote.RemoteFile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class RemoteEditor : Form
    {
        Remote currentRemote;
        private string IP = Util.ConfigHelper.GetLocalIPAddress();

        public RemoteEditor()
        {
            InitializeComponent();
            cmbRemoteID.SelectedIndex = 0;
        }

        private void cmbRemoteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRemote();

            if (cmbRemoteID.SelectedIndex == 0)
            {
                lblRemoteURL.Text = "http://" + IP + ":5000";
            }
            else
            {
                lblRemoteURL.Text = "http://" + IP + ":5000/" + cmbRemoteID.SelectedItem.ToString();
            }
        }

        private void cmbAddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetControls();

            try
            {
                switch (cmbAddItem.SelectedItem.ToString())
                {
                    case "Group":
                        panelGroup.Visible = true;
                        break;
                    case "Button":
                        panelButton.Visible = true;
                        break;
                    case "Blank Space":
                        panelBlank.Visible = true;
                        break;
                    case "New Line":
                        panelNewRow.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void ResetControls()
        {
            panelGroup.Visible = false;
            tbGroupLabel.Text = "";
            btnAddGroup.Visible = true;
            btnSaveGroup.Visible = false;
            btnDeleteGroup.Visible = false;

            panelButton.Visible = false;
            tbButtonLabel.Text = "";
            cmbButtonColor.SelectedIndex = 0;
            tbButtonSize.Text = "";
            cbButtonConfirm.Checked = false;
            btnAddButton.Visible = true;
            btnSaveButton.Visible = false;
            btnDeleteButton.Visible = false;

            panelBlank.Visible = false;
            tbBlankSize.Text = "";
            btnAddBlank.Visible = true;
            btnSaveBlank.Visible = false;
            btnDeleteBlank.Visible = false;

            panelNewRow.Visible = false;
            btnAddNewRow.Visible = true;
            btnDeleteNewRow.Visible = false;
        }

        private void LoadRemote()
        {
            lbRemoteItems.DataSource = null;
            lbRemoteItems.Items.Clear();

            try
            {
                currentRemote = RemoteJSONLoader.LoadRemoteJSON(cmbRemoteID.SelectedItem.ToString());
                currentRemote.RemoteID = Convert.ToInt32(cmbRemoteID.SelectedItem.ToString());

                if (currentRemote.ButtonHeight > 0)
                {
                    tbButtonHeight.Text = currentRemote.ButtonHeight.ToString();
                }
                else
                {
                    tbButtonHeight.Text = "";
                }

                tbRemoteName.Text = currentRemote.RemoteName;

                lbRemoteItems.DataSource = currentRemote.RemoteItems;
                lbRemoteItems.DisplayMember = currentRemote.RemoteItems.ToString();
                lbRemoteItems.SelectedIndex = -1;
                btnDeleteRemote.Visible = true;
            }
            catch
            {
                lbRemoteItems.DataSource = null;
                lbRemoteItems.Items.Clear();
                lbRemoteItems.Items.Add("No remote found for Remote #" + cmbRemoteID.SelectedItem.ToString());
                lbRemoteItems.Items.Add("Please add items to create this remote.");
                btnDeleteRemote.Visible = false;

                currentRemote = new Remote(Convert.ToInt32(cmbRemoteID.SelectedItem.ToString()));
                List<RemoteItem> items = new List<RemoteItem>();
                currentRemote.RemoteItems = items;
            }

            webBrowser.DocumentText = Util.RemoteParser.GetRemoteHTML(cmbRemoteID.SelectedItem.ToString(), false);
        }

        private void lbRemoteItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAddItem.SelectedIndex = -1;
            ResetControls();

            if (lbRemoteItems.SelectedItem is RemoteItem)
            {
                RemoteItem currentItem = (RemoteItem)lbRemoteItems.SelectedItem;

                switch (currentItem.ItemType)
                {
                    case RemoteItem.RemoteItemType.Group:
                        panelGroup.Visible = true;
                        tbGroupLabel.Text = currentItem.Label;
                        btnAddGroup.Visible = false;
                        btnSaveGroup.Visible = true;
                        btnDeleteGroup.Visible = true;
                        break;
                    case RemoteItem.RemoteItemType.Button:
                        panelButton.Visible = true;
                        tbButtonLabel.Text = currentItem.Label;
                        tbButtonSize.Text = currentItem.RelativeSize.ToString();
                        cmbButtonColor.SelectedItem = currentItem.Color;
                        cbButtonConfirm.Checked = currentItem.ConfirmPopup;
                        btnAddButton.Visible = false;
                        btnSaveButton.Visible = true;
                        btnDeleteButton.Visible = true;
                        break;
                    case RemoteItem.RemoteItemType.Blank:
                        panelBlank.Visible = true;
                        tbBlankSize.Text = currentItem.RelativeSize.ToString();
                        btnAddBlank.Visible = false;
                        btnSaveBlank.Visible = true;
                        btnDeleteBlank.Visible = true;
                        break;
                    case RemoteItem.RemoteItemType.NewRow:
                        panelNewRow.Visible = true;
                        btnAddNewRow.Visible = false;
                        btnDeleteNewRow.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SaveRemote()
        {
            RemoteJSONLoader.SaveRemoteJSON(currentRemote);
            LoadRemote();
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbButtonSize.Text))
            {
                tbButtonSize.Text = "1";
            }

            int insertIndex = lbRemoteItems.Items.Count;
            if(lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem(tbButtonLabel.Text, Convert.ToInt32(tbButtonSize.Text), cmbButtonColor.SelectedItem.ToString(), cbButtonConfirm.Checked);
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }
            SaveRemote();
        }

        private void btnSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbButtonSize.Text))
            {
                tbButtonSize.Text = "1";
            }

            RemoteItem selectedItem = (RemoteItem)lbRemoteItems.SelectedItem;
            selectedItem.Label = tbButtonLabel.Text;
            selectedItem.RelativeSize = Convert.ToInt32(tbButtonSize.Text);
            selectedItem.Color = cmbButtonColor.SelectedItem.ToString();
            selectedItem.ConfirmPopup = cbButtonConfirm.Checked;
            SaveRemote();
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            int insertIndex = lbRemoteItems.Items.Count;
            if (lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem(tbGroupLabel.Text);
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }
            SaveRemote();
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            RemoteItem selectedItem = (RemoteItem)lbRemoteItems.SelectedItem;
            selectedItem.Label = tbGroupLabel.Text;
            SaveRemote();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote();
        }

        private void btnAddBlank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBlankSize.Text))
            {
                tbBlankSize.Text = "1";
            }

            int insertIndex = lbRemoteItems.Items.Count;
            if (lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem(Convert.ToInt32(tbBlankSize.Text));
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }
            SaveRemote();
        }

        private void btnSaveBlank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBlankSize.Text))
            {
                tbBlankSize.Text = "1";
            }

            RemoteItem selectedItem = (RemoteItem)lbRemoteItems.SelectedItem;
            selectedItem.RelativeSize = Convert.ToInt32(tbBlankSize.Text);
            SaveRemote();
        }

        private void btnDeleteBlank_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote();
        }

        private void btnAddNewRow_Click(object sender, EventArgs e)
        {
            int insertIndex = lbRemoteItems.Items.Count;
            if (lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem();
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }
            SaveRemote();
        }

        private void btnDeleteNewRow_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote();
        }

        private void btnRemoteSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbButtonHeight.Text))
            {
                tbButtonHeight.Text = "0";
            }
            currentRemote.ButtonHeight = Convert.ToInt32(tbButtonHeight.Text);

            if(string.IsNullOrEmpty(tbRemoteName.Text))
            {
                currentRemote.RemoteName = null;
            }
            else
            {
                currentRemote.RemoteName = tbRemoteName.Text;
            }
            SaveRemote();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedItem is RemoteItem)
            {
                int index = lbRemoteItems.SelectedIndex;
                if (index > 0)
                {
                    RemoteItem item = currentRemote.RemoteItems[index];
                    currentRemote.RemoteItems.RemoveAt(index);
                    currentRemote.RemoteItems.Insert(index - 1, item);
                    SaveRemote();

                    lbRemoteItems.SelectedIndex = index - 1;
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedItem is RemoteItem)
            {
                int index = lbRemoteItems.SelectedIndex;
                if (index < lbRemoteItems.Items.Count - 1)
                {
                    RemoteItem item = currentRemote.RemoteItems[index];
                    currentRemote.RemoteItems.RemoveAt(index);
                    currentRemote.RemoteItems.Insert(index + 1, item);
                    SaveRemote();

                    lbRemoteItems.SelectedIndex = index + 1;
                }
            }
        }

        private void lbRemoteItems_DoubleClick(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedItem is RemoteItem)
            {
                RemoteItem currentItem = (RemoteItem)lbRemoteItems.SelectedItem;

                if (currentItem.ItemType == RemoteItem.RemoteItemType.Button)
                {
                    int index = lbRemoteItems.SelectedIndex;
                    CommandEditor commandEditor = new CommandEditor(currentItem.Commands);
                    commandEditor.ShowDialog();
                    SaveRemote();

                    lbRemoteItems.SelectedIndex = index;
                }
            }
        }

        private void btnDeleteRemote_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete remote #" + cmbRemoteID.SelectedItem.ToString() + "?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(Util.ConfigHelper.jsonButtonFiles + cmbRemoteID.SelectedItem.ToString() + ".json");
                }
            }
            catch { }

            ResetControls();
            LoadRemote();
        }

        private void lblRemoteURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lblRemoteURL.Text);
        }

        private void tbButtonSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbButtonHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbBlankSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSizeHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ButtonSizeExample buttonSizeExample = new ButtonSizeExample();
            buttonSizeExample.Show();
        }

        private void btnLabelTricks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LabelSymbols labelSymbols = new LabelSymbols();
            labelSymbols.Show();
        }
    }
}