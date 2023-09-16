using HTWebRemote.RemoteFile;
using HTWebRemote.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class HotkeyManager : Form
    {
        private IntPtr _hWnd;
        public List<HotKey> Hotkeys;

        public HotkeyManager(IntPtr hWnd)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            _hWnd = hWnd;

            LoadHotKeys();
        }

        private void LoadHotKeys()
        {
            lbHotkeys.DataSource = null;
            lbHotkeys.Items.Clear();

            Hotkeys = JSONLoader.LoadHotkeyJSON();

            lbHotkeys.DataSource = Hotkeys;
            lbHotkeys.DisplayMember = "KeyName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CaptureKey captureKey = new CaptureKey();
            DialogResult result = captureKey.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (Hotkeys is null)
                {
                    Hotkeys = new List<HotKey>();
                }

                if (captureKey.CapturedHotkey != null && !captureKey.CapturedHotkey.KeyName.EndsWith("+"))
                {
                    bool success = KeyboardHook.Register(captureKey.CapturedHotkey.KeyValue, captureKey.CapturedHotkey.ModifierValue, _hWnd);

                    if(success)
                    {
                        Hotkeys.Add(captureKey.CapturedHotkey);
                        JSONLoader.SaveHotkeyJSON(Hotkeys);
                        LoadHotKeys();
                    }
                    else
                    {
                        MessageBox.Show($"There was an error trying to register hotkey:\n\n{captureKey.CapturedHotkey.KeyName}\n\nPlease try a different hotkey.", "Error Registering Hotkey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HotKey hotKey = (HotKey)lbHotkeys.SelectedItem;

            if (hotKey != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete Hotkey:\n\n{hotKey.KeyName}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Hotkeys.Remove(hotKey);
                    KeyboardHook.Unregister(hotKey.KeyValue, hotKey.ModifierValue, _hWnd);

                    JSONLoader.SaveHotkeyJSON(Hotkeys);
                    LoadHotKeys();
                }
            }
        }

        private void lbHotkeys_DoubleClick(object sender, EventArgs e)
        {
            if (lbHotkeys.SelectedItem is HotKey hotKey)
            {
                int index = lbHotkeys.SelectedIndex;
                CommandEditor commandEditor = new CommandEditor(this, hotKey.Commands, hotKey.KeyName, index, 0);
                commandEditor.ShowDialog();

                JSONLoader.SaveHotkeyJSON(Hotkeys);
            }
        }
    }
}