using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;

namespace HTWebRemote.Forms
{
    public partial class DeviceIPManager : Form
    {
        public DeviceIPManager()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            cmbDeviceType.SelectedIndexChanged -= cmbDeviceType_SelectedIndexChanged;
            cmbDeviceType.DataSource = Devices.DeviceSelector.DeviceTypes;
            cmbDeviceType.SelectedIndex = -1;
            cmbDeviceType.SelectedIndexChanged += cmbDeviceType_SelectedIndexChanged;

            try
            {
                foreach (string device in File.ReadLines(Util.ConfigHelper.DeviceFile))
                {
                    lbDevices.Items.Add(device);
                }
            }
            catch { }
        }

        private void lbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] values = lbDevices.SelectedItem.ToString().Split(',');

                tbDevName.Text = values[1];

                if(values[2].Contains("COM"))
                {
                    cmbCOMport.DataSource = SerialPort.GetPortNames();
                    tbIP.Visible = false;
                    cmbCOMport.Visible = true;
                    lblIP.Text = "COM:";
                    cmbCOMport.SelectedItem = values[2];
                }
                else if (values[2].Contains("http"))
                {
                    tbIP.Visible = true;
                    cmbCOMport.Visible = false;
                    lblIP.Text = "URL:";
                    tbIP.Text = values[2];
                }
                else
                {
                    tbIP.Visible = true;
                    cmbCOMport.Visible = false;
                    lblIP.Text = "IP:";
                    tbIP.Text = values[2];
                }

                cmbDeviceType.SelectedIndexChanged -= cmbDeviceType_SelectedIndexChanged;
                cmbDeviceType.SelectedItem = values[0];
                cmbDeviceType.SelectedIndexChanged += cmbDeviceType_SelectedIndexChanged;

            }
            catch { }
        }

        private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbIP.Visible = true;
            cmbCOMport.Visible = false;
            lblIP.Text = "IP:";
            lbDevices.ClearSelected();

            if (cmbDeviceType.SelectedItem != null)
            {
                if (cmbDeviceType.SelectedItem.ToString() == "mpc")
                {
                    tbIP.Text = "127.0.0.1:13579";
                }
                else if (cmbDeviceType.SelectedItem.ToString() == "lirc")
                {
                    tbIP.Text = "127.0.0.1:8765";
                }
                else if (cmbDeviceType.SelectedItem.ToString() == "rs232")
                {
                    tbIP.Visible = false;
                    cmbCOMport.Visible = true;
                    lblIP.Text = "COM:";
                    cmbCOMport.DataSource = SerialPort.GetPortNames();
                }
                else if (cmbDeviceType.SelectedItem.ToString() == "httpget")
                {
                    lblIP.Text = "URL:";
                    tbIP.Text = "http://";
                }
                else
                {
                    tbIP.Text = "";
                }
                tbDevName.Text = "";
            }
        }

        private void IPManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(Util.ConfigHelper.DeviceFile);

            foreach (string line in lbDevices.Items)
            {
                string[] values = line.Split(',');
                if (!string.IsNullOrEmpty(values[1]) && !string.IsNullOrEmpty(values[2]))
                {
                    File.AppendAllText(Util.ConfigHelper.DeviceFile, line + Environment.NewLine);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbDeviceType.SelectedIndex > -1)
            {
                if (tbIP.Visible)
                {
                    lbDevices.Items.Add(cmbDeviceType.SelectedItem.ToString() + "," + tbDevName.Text + "," + tbIP.Text);
                }
                else
                {
                    lbDevices.Items.Add(cmbDeviceType.SelectedItem.ToString() + "," + tbDevName.Text + "," + cmbCOMport.SelectedItem.ToString());
                }
                cmbDeviceType.SelectedIndex = -1;
                tbDevName.Text = "";
                tbIP.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lbDevices.SelectedIndex > -1)
            {
                if (tbIP.Visible)
                {
                    lbDevices.Items[lbDevices.SelectedIndex] = cmbDeviceType.SelectedItem.ToString() + "," + tbDevName.Text + "," + tbIP.Text;
                }
                else
                {
                    lbDevices.Items[lbDevices.SelectedIndex] = cmbDeviceType.SelectedItem.ToString() + "," + tbDevName.Text + "," + cmbCOMport.SelectedItem.ToString();
                }
                cmbDeviceType.SelectedIndex = -1;
                tbDevName.Text = "";
                tbIP.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbDevices.SelectedIndex > -1)
            {
                lbDevices.Items.RemoveAt(lbDevices.SelectedIndex);
                cmbDeviceType.SelectedIndex = -1;
                tbDevName.Text = "";
                tbIP.Text = "";
            }
        }
    }
}