﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Linq;

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
            tbIP.Visible = true;
            cmbCOMport.Visible = false;
            cmbLinuxSerial.Visible = false;
            cmbTPLinkDevices.Visible = false;
            lblIP.Text = "IP:(port optional):";
            lblSpecial.Visible = false;
            tbSpecial.Visible = false;
            cbLGssl.Visible = false;

            try
            {
                string[] values = lbDevices.SelectedItem.ToString().Split(',');

                tbDevName.Text = values[1];
                tbIP.Text = values[2];

                cmbDeviceType.SelectedIndexChanged -= cmbDeviceType_SelectedIndexChanged;
                cmbDeviceType.SelectedItem = values[0];
                cmbDeviceType.SelectedIndexChanged += cmbDeviceType_SelectedIndexChanged;

                switch (values[0])
                {
                    case "rs232":
                        cmbCOMport.DataSource = SerialPort.GetPortNames();
                        tbIP.Visible = false;
                        cmbCOMport.Visible = true;
                        lblIP.Text = "Windows Port:";
                        cmbCOMport.SelectedItem = values[2];
                        lblSpecial.Text = "RasPi/Linux Port:";
                        lblSpecial.Visible = true;
                        cmbLinuxSerial.Visible = true;
                        GetLinuxSerial();
                        cmbLinuxSerial.SelectedItem = values[3];
                        break;
                    case "httpget":
                        lblIP.Text = "URL:";
                        lblSpecial.Text = "auth (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "httppost":
                        lblIP.Text = "URL:";
                        lblSpecial.Text = "auth (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "kodi":
                        lblSpecial.Text = "user:pass";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "mqtt":
                        lblSpecial.Text = "user:pass";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "tcp":
                        lblIP.Text = "IP:port";
                        break;
                    case "udp":
                        lblIP.Text = "IP:port";
                        break;
                    case "jvc":
                        lblSpecial.Text = "Password (NZ):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "sonyproj":
                        lblSpecial.Text = "Pass (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values[3];
                        break;
                    case "lgwebos":
                        cbLGssl.Visible = true;
                        try
                        {
                            cbLGssl.Checked = Convert.ToBoolean(values[3]);
                        }
                        catch { }
                        break;
                    case "minidsp-rs":
                        lblSpecial.Text = "Device ID:";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = values.ElementAtOrDefault(3) ?? "0";
                        break;
                    case "kasa":
                        lblSpecial.Text = "Device Type:";
                        lblSpecial.Visible = true;
                        cmbTPLinkDevices.Visible = true;
                        try
                        {
                            if(string.IsNullOrEmpty(values[3]))
                            {
                                cmbTPLinkDevices.SelectedIndex = -1;
                            }
                            cmbTPLinkDevices.SelectedItem = values[3];
                        }
                        catch
                        {
                            cmbTPLinkDevices.SelectedIndex = -1;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }

        private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbIP.Visible = true;
            tbIP.Text = "";
            cmbCOMport.Visible = false;
            cmbLinuxSerial.Visible = false;
            cmbTPLinkDevices.Visible = false;
            lblIP.Text = "IP:(port optional):";
            lblSpecial.Visible = false;
            tbSpecial.Visible = false;
            lbDevices.ClearSelected();
            cbLGssl.Visible = false;

            if (cmbDeviceType.SelectedItem != null)
            {
                switch (cmbDeviceType.SelectedItem.ToString())
                {
                    case "mpc":
                        tbIP.Text = "127.0.0.1:13579";
                        break;
                    case "lirc":
                        tbIP.Text = "127.0.0.1:8765";
                        break;
                    case "rs232":
                        tbIP.Visible = false;
                        cmbCOMport.Visible = true;
                        lblIP.Text = "Windows Port:";
                        cmbCOMport.DataSource = SerialPort.GetPortNames();
                        lblSpecial.Text = "RasPi/Linux Port:";
                        lblSpecial.Visible = true;
                        cmbLinuxSerial.Visible = true;
                        GetLinuxSerial();
                        break;
                    case "httpget":
                        lblIP.Text = "URL:";
                        tbIP.Text = "http://";
                        lblSpecial.Text = "auth (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "httppost":
                        lblIP.Text = "URL:";
                        tbIP.Text = "http://";
                        lblSpecial.Text = "auth (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "kodi":
                        lblSpecial.Text = "user:pass";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "mqtt":
                        lblSpecial.Text = "user:pass";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "tcp":
                        lblIP.Text = "IP:port";
                        break;
                    case "udp":
                        lblIP.Text = "IP:port";
                        break;
                    case "jvc":
                        lblSpecial.Text = "Password (NZ):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "sonyproj":
                        lblSpecial.Text = "Pass (optional):";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        break;
                    case "lgwebos":
                        cbLGssl.Visible = true;
                        break;
                    case "minidsp-rs":
                        lblSpecial.Text = "Device ID:";
                        lblSpecial.Visible = true;
                        tbSpecial.Visible = true;
                        tbSpecial.Text = "0";
                        break;
                    case "kasa":
                        lblSpecial.Text = "Device Type:";
                        lblSpecial.Visible = true;
                        cmbTPLinkDevices.Visible = true;
                        break;
                    default:
                        break;
                }

                tbDevName.Text = "";
                tbSpecial.Text = "";
            }
        }

        private async void GetLinuxSerial()
        {
            try
            {
                cmbLinuxSerial.Items.Clear();
            }
            catch
            {
                cmbLinuxSerial.DataSource = null;
            }
            string hostIP = Util.ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "RemoteHostIP");

            if (Regex.IsMatch(hostIP, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(3);
                    try
                    {
                        string strPorts = await httpClient.GetStringAsync($"http://{hostIP}:5000/serial");

                        cmbLinuxSerial.DataSource = strPorts.Split(',');
                    }
                    catch
                    {
                        cmbLinuxSerial.Items.Add("Error getting serial ports");
                    }
                }
            }
            else
            {
                cmbLinuxSerial.Items.Add("Remote Host IP not found");
            }
        }

        private void IPManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
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
            catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbDeviceType.SelectedIndex > -1)
            {
                if (tbIP.Visible)
                {
                    string dev = $"{cmbDeviceType.SelectedItem},{tbDevName.Text},{tbIP.Text}";
                    if(tbSpecial.Visible)
                    {
                        dev += $",{tbSpecial.Text}";
                    }
                    if(cmbTPLinkDevices.Visible)
                    {
                        dev += $",{cmbTPLinkDevices.SelectedItem}";
                    }
                    if(cbLGssl.Visible)
                    {
                        dev += $",{cbLGssl.Checked}";
                    }
                    lbDevices.Items.Add(dev);
                }
                else
                {
                    string dev = $"{cmbDeviceType.SelectedItem},{tbDevName.Text},{cmbCOMport.SelectedItem}";
                    try
                    {
                        if (!string.IsNullOrEmpty(cmbLinuxSerial.SelectedItem.ToString()))
                        {
                            dev += $",{cmbLinuxSerial.SelectedItem}";
                        }
                    }
                    catch { }
                    lbDevices.Items.Add(dev);
                }
                cmbDeviceType.SelectedIndex = -1;
                tbDevName.Text = "";
                tbIP.Text = "";
                tbSpecial.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lbDevices.SelectedIndex > -1)
            {
                if (tbIP.Visible)
                {
                    string dev = $"{cmbDeviceType.SelectedItem},{tbDevName.Text},{tbIP.Text}";
                    if (tbSpecial.Visible)
                    {
                        dev += $",{tbSpecial.Text}";
                    }
                    if (cmbTPLinkDevices.Visible)
                    {
                        dev += $",{cmbTPLinkDevices.SelectedItem}";
                    }
                    if (cbLGssl.Visible)
                    {
                        dev += $",{cbLGssl.Checked}";
                    }
                    lbDevices.Items[lbDevices.SelectedIndex] = dev;
                }
                else
                {
                    string dev = $"{cmbDeviceType.SelectedItem},{tbDevName.Text},{cmbCOMport.SelectedItem}";
                    try
                    {
                        if (!string.IsNullOrEmpty(cmbLinuxSerial.SelectedItem.ToString()))
                        {
                            dev += $",{cmbLinuxSerial.SelectedItem}";
                        }
                    }
                    catch { }
                    lbDevices.Items[lbDevices.SelectedIndex] = dev;
                }
                cmbDeviceType.SelectedIndex = -1;
                tbDevName.Text = "";
                tbIP.Text = "";
                tbSpecial.Text = "";
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
                tbSpecial.Text = "";
            }
        }
    }
}