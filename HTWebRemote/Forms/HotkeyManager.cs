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
        public List<HotKey> Hotkeys;
        private HTWebRemote MainForm;

        public HotkeyManager(HTWebRemote form)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            MainForm = form;

            LoadHotKeys();
        }

        public void RegisterHotkeys()
        {
            Hotkeys = JSONLoader.LoadHotkeyJSON();

            try
            {
                foreach (HotKey hotkey in Hotkeys)
                {
                    KeyboardHook.Register(hotkey.KeyValue, hotkey.ModifierValue, MainForm.Handle);
                }
            }
            catch { }
        }

        public void UnregisterHotkeys()
        {
            Hotkeys = JSONLoader.LoadHotkeyJSON();

            try
            {
                foreach (HotKey hotkey in Hotkeys)
                {
                    KeyboardHook.Unregister(hotkey.KeyValue, hotkey.ModifierValue, MainForm.Handle);
                }
            }
            catch { }
        }

        public void ProcessHotkey(int KeyValue, int ModifierValue)
        {
            foreach (HotKey hotKey in Hotkeys)
            {
                if (hotKey.KeyValue == KeyValue && hotKey.ModifierValue == ModifierValue)
                {
                    hotKey.RunButtonCommands();
                }
            }
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
                    bool success = true;
                    if (MainForm.cbxHotkeys.Checked)
                    {
                        success = KeyboardHook.Register(captureKey.CapturedHotkey.KeyValue, captureKey.CapturedHotkey.ModifierValue, MainForm.Handle);
                    }

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

                    if (MainForm.cbxHotkeys.Checked)
                    {
                        KeyboardHook.Unregister(hotKey.KeyValue, hotKey.ModifierValue, MainForm.Handle);
                    }

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