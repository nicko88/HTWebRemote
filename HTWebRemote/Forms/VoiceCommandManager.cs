using HTWebRemote.RemoteFile;
using HTWebRemote.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class VoiceCommandManager : Form
    {
        public List<VoiceCommand> VoiceCommands;
        private SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        private HTWebRemote MainForm;

        public VoiceCommandManager(HTWebRemote form)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            MainForm = form;

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "LogVoiceMatches"))
            {
                cbxLogMatches.Checked = true;
            }
            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "VoiceAutoReload"))
            {
                cbxAutoReload.Checked = true;
            }

            recognizer.SpeechRecognized += recognizer_SpeechRecognized;
            recognizer.RecognizeCompleted += recognizer_RecognizeCompleted;

            LoadVoiceCommands();
        }

        public void StartListen()
        {
            LoadPhrases();

            if (recognizer.Grammars.Count > 0)
            {
                try
                {
                    recognizer.SetInputToDefaultAudioDevice();
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    MainForm.cbxVoiceControl.Checked = true;

                    if(cbxAutoReload.Checked)
                    {
                        autoReloadTimer.Start();
                    }
                }
                catch { }
            }
            else
            {
                MainForm.cbxVoiceControl.Checked = false;
            }
        }

        public void StopListen()
        {
            autoReloadTimer.Stop();
            recognizer.RecognizeAsyncCancel();
        }

        private void LoadVoiceCommands()
        {
            lbVoiceCommands.DataSource = null;
            lbVoiceCommands.Items.Clear();

            VoiceCommands = JSONLoader.LoadVoiceCommandJSON();

            lbVoiceCommands.DataSource = VoiceCommands;
            lbVoiceCommands.DisplayMember = "Phrase";

            lbVoiceCommands.SelectedIndex = -1;
        }

        private void LoadPhrases()
        {
            recognizer.UnloadAllGrammars();

            foreach (VoiceCommand voiceCommand in VoiceCommands)
            {
                GrammarBuilder gb = new GrammarBuilder(voiceCommand.Phrase);
                Grammar g = new Grammar(gb);
                recognizer.LoadGrammar(g);
            }
        }

        protected void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (VoiceCommand voiceCommand in VoiceCommands)
            {
                if (e.Result.Text == voiceCommand.Phrase)
                {
                    if (cbxTestMode.Checked)
                    {
                        MessageBox.Show($"{e.Result.Text}\n\nConfidence: {e.Result.Confidence*100}", "Voice Command Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        bool match = e.Result.Confidence * 100 > voiceCommand.Confidence;
                        if (match)
                        {
                            voiceCommand.RunButtonCommands();
                        }

                        if (cbxLogMatches.Checked)
                        {
                            File.AppendAllText(Path.Combine(ConfigHelper.WorkingPath, "VoiceCommandLog.txt"), $"[{DateTime.Now:hh:mm:ss tt}]: {e.Result.Text} ({e.Result.Confidence * 100}) Triggered={match}" + Environment.NewLine);
                        }
                    }
                }
            }
        }

        protected void recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                MainForm.cbxVoiceControl.Checked = false;
                //recognizerBrokeTimer.Start();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPhrase.Text))
            {
                if (btnAdd.Text == "Add")
                {
                    if (VoiceCommands is null)
                    {
                        VoiceCommands = new List<VoiceCommand>();
                    }

                    VoiceCommand voiceCommand = new VoiceCommand(tbPhrase.Text, Convert.ToInt32(tbConfidence.Text));
                    VoiceCommands.Add(voiceCommand);
                }
                else
                {
                    VoiceCommand voiceCommand = (VoiceCommand)lbVoiceCommands.SelectedItem;
                    voiceCommand.Phrase = tbPhrase.Text;
                    voiceCommand.Confidence = Convert.ToInt32(tbConfidence.Text);
                }

                JSONLoader.SaveVoiceCommandJSON(VoiceCommands);
                LoadVoiceCommands();
                LoadPhrases();

                tbPhrase.Clear();
                tbConfidence.Text = "80";
                btnAdd.Text = "Add";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            VoiceCommand voiceCommand = (VoiceCommand)lbVoiceCommands.SelectedItem;

            if (voiceCommand != null)
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete Voice Command:\n\n{voiceCommand.Phrase}", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    VoiceCommands.Remove(voiceCommand);

                    JSONLoader.SaveVoiceCommandJSON(VoiceCommands);
                    LoadVoiceCommands();
                    LoadPhrases();
                }
            }
        }

        private void lbVoiceCommands_DoubleClick(object sender, EventArgs e)
        {
            if (lbVoiceCommands.SelectedItem is VoiceCommand voiceCommand)
            {
                int index = lbVoiceCommands.SelectedIndex;
                CommandEditor commandEditor = new CommandEditor(this, voiceCommand.Commands, voiceCommand.Phrase, index, 0);
                commandEditor.ShowDialog();

                JSONLoader.SaveVoiceCommandJSON(VoiceCommands);
            }
        }

        private void cbxTestMode_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxTestMode.Checked)
            {
                MessageBox.Show("When Test Mode is enabled, a popup will be shown when a voice command is detected.  The confidence value will also be shown.\n\nNo commands will be executed when Test Mode is enabled.", "Enabling Test Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);

                StartListen();
            }
        }

        private void lbVoiceCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbVoiceCommands.SelectedIndex > -1)
            {
                VoiceCommand voiceCommand = (VoiceCommand)lbVoiceCommands.SelectedItem;

                tbPhrase.Text = voiceCommand.Phrase;
                tbConfidence.Text = voiceCommand.Confidence.ToString();
                btnAdd.Text = "Save";
            }
        }

        private void VoiceCommandManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbxTestMode.Checked = false;
        }

        private void VoiceCommandManager_Click(object sender, EventArgs e)
        {
            lbVoiceCommands.SelectedIndex = -1;
            tbPhrase.Text = "";
            tbConfidence.Text = "80";
            btnAdd.Text = "Add";
        }

        private void VoiceCommandManager_Shown(object sender, EventArgs e)
        {
            lbVoiceCommands.SelectedIndex = -1;
            tbPhrase.Text = "";
            tbConfidence.Text = "80";
            btnAdd.Text = "Add";
        }

        private void tbConfidence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbxLogMatches_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLogMatches.Checked)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("LogVoiceMatches", true);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("LogVoiceMatches", false);
            }
        }

        private void cbxAutoReload_Click(object sender, EventArgs e)
        {
            if (cbxAutoReload.Checked)
            {
                MessageBox.Show("When this is enabled, the voice control system will automatically try to restart itself every 5 minutes.\n\nOnly use this option if you find that your voice control randomly stops working after awhile.", "Enabling Auto Reload", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.SetValue("VoiceAutoReload", true);

                autoReloadTimer.Start();
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                key.DeleteValue("VoiceAutoReload", false);

                autoReloadTimer.Stop();
            }
        }

        private void recognizerBrokeTimer_Tick(object sender, EventArgs e)
        {
            if (!MainForm.cbxVoiceControl.Checked)
            {
                StartListen();
                recognizerBrokeTimer.Stop();
            }
        }

        private void autoReloadTimer_Tick(object sender, EventArgs e)
        {
            StopListen();
            StartListen();
        }
    }
}