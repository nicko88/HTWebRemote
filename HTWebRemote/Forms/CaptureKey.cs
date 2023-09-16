using HTWebRemote.RemoteFile;
using System;
using System.Windows.Forms;

namespace HTWebRemote.Forms
{
    public partial class CaptureKey : Form
    {
        public HotKey CapturedHotkey;

        public CaptureKey()
        {
            InitializeComponent();
        }

        private async void CaptureKey_KeyDown(object sender, KeyEventArgs e)
        {
            string keyName = "";
            int modifierValue = 0;

            if(e.Control)
            {
                keyName += "Ctrl+";
                modifierValue += 2;
            }
            if (e.Alt)
            {
                keyName += "Alt+";
                modifierValue += 1;
            }
            if (e.Shift)
            {
                keyName += "Shift+";
                modifierValue += 4;
            }

            if (e.KeyValue != 16 && e.KeyValue != 17 && e.KeyValue != 18)
            {
                keyName += e.KeyCode;
            }

            lblKey.Text = keyName;

            CapturedHotkey = new HotKey(e.KeyValue, modifierValue, keyName);

            e.SuppressKeyPress = true;
        }

        private void CaptureKey_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}