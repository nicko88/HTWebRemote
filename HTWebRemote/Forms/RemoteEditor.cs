using HTWebRemote.RemoteFile;
using HTWebRemote.Util;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class RemoteEditor : Form
    {
        public Remote currentRemote;
        private int _lastDeviceIndex = 0;
        private int _selectedIndex = 0;
        private List<RemoteItem> _copiedItems = new List<RemoteItem>();

        public RemoteEditor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", false);
                int[] size = (regKey.GetValue("RemoteEditorSize") as string[]).Select(int.Parse).ToArray();
                if(size[0] < 944)
                {
                    Width = 944;
                }
                else
                {
                    Width = size[0];
                }
                Height = size[1];
            }
            catch { }

            FillRemoteNumDropDown();
            cmbRemoteID.SelectedIndex = 0;
        }

        private void cmbRemoteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRemote();
        }

        private void FillRemoteNumDropDown()
        {
            int currentRemoteID = cmbRemoteID.SelectedIndex;
            int remoteNum = 1;

            cmbRemoteID.Items.Clear();

            try
            {
                string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();
                JObject oRemote = JObject.Parse(File.ReadAllText(remoteFiles[remoteFiles.Length - 1]));
                remoteNum = Convert.ToInt32(oRemote.SelectToken("RemoteID"));
            }
            catch { }

            for(int i = 1; i < remoteNum+2; i++)
            {
                cmbRemoteID.Items.Add(i);
            }

            if(currentRemoteID == -1)
            {
                currentRemoteID = 0;
            }

            AddRemoteNames();

            try
            {
                cmbRemoteID.SelectedIndex = currentRemoteID;
            }
            catch
            {
                cmbRemoteID.SelectedIndex = cmbRemoteID.Items.Count - 1;
            }
        }

        private void AddRemoteNames()
        {
            for(int i = 1; i < cmbRemoteID.Items.Count; i++)
            {
                if (File.Exists(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{i}.json")))
                {
                    JObject oRemote = JObject.Parse(File.ReadAllText(Path.Combine(ConfigHelper.WorkingPath, $"HTWebRemoteButtons{i}.json")));
                    cmbRemoteID.Items[i - 1] = i + $" - {oRemote.SelectToken("RemoteName")}";
                }
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
            pnlGroupColor.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            btnAddGroup.Visible = true;
            btnSaveGroup.Visible = false;
            btnDeleteGroup.Visible = false;

            panelButton.Visible = false;
            tbButtonLabel.Text = "";
            pnlButtonColor.BackColor = ColorTranslator.FromHtml("#007BFF");
            tbButtonSize.Text = "";
            tbButtonHeight.Text = "";
            cbButtonConfirm.Checked = false;
            cbHoldable.Checked = false;
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
                currentRemote = JSONLoader.LoadRemoteJSON((cmbRemoteID.SelectedIndex + 1).ToString());
                currentRemote.RemoteID = cmbRemoteID.SelectedIndex + 1;

                if (currentRemote.ButtonHeight > 0)
                {
                    tbGlobalButtonHeight.Text = currentRemote.ButtonHeight.ToString();
                }
                else
                {
                    tbGlobalButtonHeight.Text = "";
                }

                if(currentRemote.RemoteBackColor != null)
                {
                    pnlBackColor.BackColor = ColorTranslator.FromHtml(currentRemote.RemoteBackColor);
                }
                else
                {
                    pnlBackColor.BackColor = Color.Black;
                }

                if(currentRemote.RemoteShadingStrength is null)
                {
                    tbShadingStrength.Text = "1";
                }
                else
                {
                    tbShadingStrength.Text = currentRemote.RemoteShadingStrength.ToString();
                }

                tbRemoteName.Text = currentRemote.RemoteName;
                tbRemoteGroup.Text = currentRemote.RemoteGroup;
                cbHideRemote.Checked = currentRemote.HideRemote;

                lbRemoteItems.DataSource = currentRemote.RemoteItems;
                lbRemoteItems.DisplayMember = currentRemote.RemoteItems.ToString();
                lbRemoteItems.SelectedIndex = -1;
                btnDeleteRemote.Visible = true;
            }
            catch
            {
                lbRemoteItems.DataSource = null;
                lbRemoteItems.Items.Clear();
                lbRemoteItems.Items.Add($"No remote found for Remote #{cmbRemoteID.SelectedItem}");
                lbRemoteItems.Items.Add("Please add items to create this remote.");
                btnDeleteRemote.Visible = false;

                currentRemote = new Remote(cmbRemoteID.SelectedIndex + 1);
                List<RemoteItem> items = new List<RemoteItem>();
                currentRemote.RemoteItems = items;
            }

            string remoteHTML = RemoteParser.GetRemoteHTML((cmbRemoteID.SelectedIndex + 1).ToString(), false);
            remoteHTML = remoteHTML.Replace("overflow: hidden;", "");
            webBrowser.DocumentText = remoteHTML;
        }

        private void lbRemoteItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbAddItem.SelectedIndex = -1;
            ResetControls();

            if (lbRemoteItems.SelectedItem is RemoteItem currentItem)
            {
                switch (currentItem.ItemType)
                {
                    case RemoteItem.RemoteItemType.Group:
                        panelGroup.Visible = true;
                        tbGroupLabel.Text = currentItem.Label;
                        pnlGroupColor.BackColor = ColorTranslator.FromHtml(ConfigHelper.ConvertLegacyColor(currentItem.Color));
                        btnAddGroup.Visible = false;
                        btnSaveGroup.Visible = true;
                        btnDeleteGroup.Visible = true;
                        break;
                    case RemoteItem.RemoteItemType.Button:
                        panelButton.Visible = true;
                        tbButtonLabel.Text = currentItem.Label;
                        tbButtonSize.Text = currentItem.RelativeSize.ToString();
                        if (currentItem.Height > 0)
                        {
                            tbButtonHeight.Text = currentItem.Height.ToString();
                        }
                        pnlButtonColor.BackColor = ColorTranslator.FromHtml(ConfigHelper.ConvertLegacyColor(currentItem.Color));
                        cbButtonConfirm.Checked = currentItem.ConfirmPopup;
                        cbHoldable.Checked = currentItem.Holdable;
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

        public void SaveRemote(int selectedIndexOffset)
        {
            int topIndex = lbRemoteItems.TopIndex;

            _selectedIndex = lbRemoteItems.SelectedIndex;

            JSONLoader.SaveRemoteJSON(currentRemote);
            LoadRemote();

            try
            {
                lbRemoteItems.SelectedIndex = _selectedIndex + selectedIndexOffset;
            }
            catch { }

            FillRemoteNumDropDown();

            lbRemoteItems.TopIndex = topIndex;

            //make sure file browser group is set to something
            string fileBrowserGroup = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserGroup");
            if (currentRemote.RemoteID == 1 && string.IsNullOrEmpty(fileBrowserGroup) && !string.IsNullOrEmpty(tbRemoteGroup.Text))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("FileBrowserGroup", tbRemoteGroup.Text);
            }
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbButtonSize.Text))
            {
                tbButtonSize.Text = "1";
            }

            int? btnHeight = null;
            if (!string.IsNullOrEmpty(tbButtonHeight.Text))
            {
                btnHeight = Convert.ToInt32(tbButtonHeight.Text);
            }

            int insertIndex = lbRemoteItems.Items.Count;
            if(lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem(tbButtonLabel.Text, Convert.ToInt32(tbButtonSize.Text), btnHeight, $"#{pnlButtonColor.BackColor.R:X2}{pnlButtonColor.BackColor.G:X2}{pnlButtonColor.BackColor.B:X2}", cbButtonConfirm.Checked, cbHoldable.Checked);
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }

            SaveRemote(1);
            try
            {
                lbRemoteItems.SelectedIndex = insertIndex;
            }
            catch { }

            cmbAddItem.SelectedItem = "Button";
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
            if (string.IsNullOrEmpty(tbButtonHeight.Text))
            {
                selectedItem.Height = 0;
            }
            else
            {
                selectedItem.Height = Convert.ToInt32(tbButtonHeight.Text);
            }
            selectedItem.Color = $"#{pnlButtonColor.BackColor.R:X2}{pnlButtonColor.BackColor.G:X2}{pnlButtonColor.BackColor.B:X2}";
            selectedItem.ConfirmPopup = cbButtonConfirm.Checked;
            selectedItem.Holdable = cbHoldable.Checked;
            SaveRemote(0);
        }

        private void btnDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete Button:\n\n{lbRemoteItems.SelectedItem}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
                SaveRemote(-1);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            int insertIndex = lbRemoteItems.Items.Count;
            if (lbRemoteItems.SelectedIndex > -1)
            {
                insertIndex = lbRemoteItems.SelectedIndex + 1;
            }
            RemoteItem remoteItem = new RemoteItem(tbGroupLabel.Text, $"#{pnlGroupColor.BackColor.R:X2}{pnlGroupColor.BackColor.G:X2}{pnlGroupColor.BackColor.B:X2}");
            try
            {
                currentRemote.RemoteItems.Insert(insertIndex, remoteItem);
            }
            catch
            {
                currentRemote.RemoteItems.Add(remoteItem);
            }

            SaveRemote(1);
            try
            {
                lbRemoteItems.SelectedIndex = insertIndex;
            }
            catch { }

            cmbAddItem.SelectedItem = "Group";
        }

        private void btnSaveGroup_Click(object sender, EventArgs e)
        {
            RemoteItem selectedItem = (RemoteItem)lbRemoteItems.SelectedItem;
            selectedItem.Label = tbGroupLabel.Text;
            selectedItem.Color = $"#{pnlGroupColor.BackColor.R:X2}{pnlGroupColor.BackColor.G:X2}{pnlGroupColor.BackColor.B:X2}";
            SaveRemote(0);
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote(-1);
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

            SaveRemote(1);
            try
            {
                lbRemoteItems.SelectedIndex = insertIndex;
            }
            catch { }

            cmbAddItem.SelectedItem = "Blank Space";
        }

        private void btnSaveBlank_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBlankSize.Text))
            {
                tbBlankSize.Text = "1";
            }

            RemoteItem selectedItem = (RemoteItem)lbRemoteItems.SelectedItem;
            selectedItem.RelativeSize = Convert.ToInt32(tbBlankSize.Text);
            SaveRemote(0);
        }

        private void btnDeleteBlank_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote(-1);
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

            SaveRemote(1);
            try
            {
                lbRemoteItems.SelectedIndex = insertIndex;
            }
            catch { }

            cmbAddItem.SelectedItem = "New Line";
        }

        private void btnDeleteNewRow_Click(object sender, EventArgs e)
        {
            currentRemote.RemoteItems.Remove((RemoteItem)lbRemoteItems.SelectedItem);
            SaveRemote(-1);
        }

        private void btnRemoteSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbGlobalButtonHeight.Text))
            {
                tbGlobalButtonHeight.Text = "0";
            }
            currentRemote.ButtonHeight = Convert.ToInt32(tbGlobalButtonHeight.Text);

            currentRemote.RemoteBackColor = $"#{pnlBackColor.BackColor.R:X2}{pnlBackColor.BackColor.G:X2}{pnlBackColor.BackColor.B:X2}";

            if (string.IsNullOrEmpty(tbShadingStrength.Text))
            {
                tbShadingStrength.Text = "1";
            }
            currentRemote.RemoteShadingStrength = Convert.ToInt32(tbShadingStrength.Text);

            if (string.IsNullOrEmpty(tbRemoteName.Text))
            {
                currentRemote.RemoteName = null;
            }
            else
            {
                currentRemote.RemoteName = tbRemoteName.Text;
            }
            if (string.IsNullOrEmpty(tbRemoteGroup.Text))
            {
                currentRemote.RemoteGroup = null;
            }
            else
            {
                currentRemote.RemoteGroup = tbRemoteGroup.Text;
            }

            currentRemote.HideRemote = cbHideRemote.Checked;

            SaveRemote(0);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedIndices.Count > 0 && lbRemoteItems.SelectedIndices[0] > 0)
            {
                List<int> updatedSelections = new List<int>();

                foreach (int selectedIndex in lbRemoteItems.SelectedIndices)
                {
                    if (lbRemoteItems.Items[selectedIndex] is RemoteItem)
                    {
                        if (selectedIndex > 0)
                        {
                            RemoteItem item = currentRemote.RemoteItems[selectedIndex];
                            currentRemote.RemoteItems.RemoveAt(selectedIndex);
                            currentRemote.RemoteItems.Insert(selectedIndex - 1, item);

                            updatedSelections.Add(selectedIndex - 1);
                        }
                    }
                }

                SaveRemote(0);

                lbRemoteItems.ClearSelected();
                foreach (int i in updatedSelections)
                {
                    lbRemoteItems.SetSelected(i, true);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedIndices.Count > 0 && lbRemoteItems.SelectedIndices[lbRemoteItems.SelectedIndices.Count - 1] < lbRemoteItems.Items.Count - 1)
            {
                List<int> updatedSelections = new List<int>();

                for (int i = lbRemoteItems.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int selectedIndex = lbRemoteItems.SelectedIndices[i];

                    if (lbRemoteItems.Items[selectedIndex] is RemoteItem)
                    {
                        if (selectedIndex < lbRemoteItems.Items.Count - 1)
                        {
                            RemoteItem item = currentRemote.RemoteItems[selectedIndex];
                            currentRemote.RemoteItems.RemoveAt(selectedIndex);
                            currentRemote.RemoteItems.Insert(selectedIndex + 1, item);

                            updatedSelections.Add(selectedIndex + 1);
                        }
                    }
                }

                SaveRemote(0);

                lbRemoteItems.ClearSelected();
                foreach (int i in updatedSelections)
                {
                    lbRemoteItems.SetSelected(i, true);
                }
            }
        }

        private void lbRemoteItems_DoubleClick(object sender, EventArgs e)
        {
            if (lbRemoteItems.SelectedItem is RemoteItem currentItem)
            {
                if (currentItem.ItemType == RemoteItem.RemoteItemType.Button)
                {
                    int index = lbRemoteItems.SelectedIndex;
                    CommandEditor commandEditor = new CommandEditor(this, currentItem.Commands, currentItem.Label, index, _lastDeviceIndex);
                    commandEditor.ShowDialog();
                    _lastDeviceIndex = commandEditor.LastDeviceIndex;

                    SaveRemote(0);

                    lbRemoteItems.SelectedIndex = index;
                }
            }
        }

        private void btnDeleteRemote_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete remote #{cmbRemoteID.SelectedItem}?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete($"{ConfigHelper.jsonButtonFiles}{cmbRemoteID.SelectedIndex + 1}.json");
                }
            }
            catch { }

            ResetControls();
            LoadRemote();

            FillRemoteNumDropDown();
        }

        private void lbRemoteItems_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lbRemoteItems.SelectedItem != null)
                {
                    lbRemoteItems.DoDragDrop(lbRemoteItems.SelectedItem, DragDropEffects.Move);
                }
            }
        }

        private void lbRemoteItems_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbRemoteItems_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbRemoteItems.PointToClient(new Point(e.X, e.Y));
            int index = lbRemoteItems.IndexFromPoint(point);
            if (index < 0) index = lbRemoteItems.Items.Count - 1;

            RemoteItem item = currentRemote.RemoteItems[lbRemoteItems.SelectedIndex];
            currentRemote.RemoteItems.RemoveAt(lbRemoteItems.SelectedIndex);
            currentRemote.RemoteItems.Insert(index, item);

            SaveRemote(0);

            lbRemoteItems.SelectedIndex = index;
        }

        private void tbNumOnly_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pnlBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                pnlBackColor.BackColor = colorDialog.Color;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCopy.Text == "Copy Selected")
                {
                    btnCopy.Text = "Paste Selected";
                    lblClearCopy.Visible = true;

                    foreach (int itemIndex in lbRemoteItems.SelectedIndices)
                    {
                        _copiedItems.Add(currentRemote.RemoteItems[itemIndex]);
                    }
                }
                else
                {
                    btnCopy.Text = "Copy Selected";
                    lblClearCopy.Visible = false;

                    currentRemote.RemoteItems.InsertRange(lbRemoteItems.SelectedIndex+1, _copiedItems);
                    _copiedItems.Clear();

                    SaveRemote(1);
                }
            }
            catch { }
        }

        private void pnlButtonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;

            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\HTWebRemote", false);
                colorDialog.CustomColors = (regKey.GetValue("CustomColors") as string[]).Select(int.Parse).ToArray();
            }
            catch
            {
                colorDialog.CustomColors = new int[] { 16743168, 4564776, 4535772, 508415, 13148695, 8222060, 16447992, 4209204 };
            }

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlButtonColor.BackColor = colorDialog.Color;
            }

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("CustomColors", colorDialog.CustomColors.Select(x => x.ToString()).ToArray());
        }

        private void pnlGroupColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                pnlGroupColor.BackColor = colorDialog.Color;
            }
        }

        private void RemoteEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
            key.SetValue("RemoteEditorSize", new string[] { Width.ToString(), Height.ToString() });
        }

        private void lbRemoteItems_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    btnUp.PerformClick();
                    break;
                case Keys.PageDown:
                    btnDown.PerformClick();
                    break;
                case Keys.Delete:
                    btnDeleteItems.PerformClick();
                    break;
                default:
                    break;
            }

            e.Handled = true;
        }

        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to delete selected items?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                List<RemoteItem> itemsToDelete = new List<RemoteItem>();

                foreach (int itemIndex in lbRemoteItems.SelectedIndices)
                {
                    itemsToDelete.Add(currentRemote.RemoteItems[itemIndex]);
                }

                foreach (RemoteItem item in itemsToDelete)
                {
                    currentRemote.RemoteItems.Remove(item);
                }

                SaveRemote(-1);
            }
        }

        private void RemoteEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void lblClearCopy_Click(object sender, EventArgs e)
        {
            lblClearCopy.Visible = false;
            btnCopy.Text = "Copy Selected";
            _copiedItems.Clear();
        }

        private void btnReorderRemotes_Click(object sender, EventArgs e)
        {
            int selectedIndex = cmbRemoteID.SelectedIndex;

            ReorderRemotes reorderRemotes = new ReorderRemotes();
            reorderRemotes.ShowDialog();

            FillRemoteNumDropDown();
            cmbRemoteID.SelectedIndex = selectedIndex;
        }
    }
}