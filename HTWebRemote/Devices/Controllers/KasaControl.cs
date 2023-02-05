using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Net.Sockets;
using TPLinkSmartDevices.Data;
using TPLinkSmartDevices.Devices;

namespace HTWebRemote.Devices.Controllers
{
    class KasaControl
    {
        public static void RunCmd(string IP, string cmd, string param, string deviceType)
        {
            if (cmd.StartsWith("{"))
            {
                string msg = "";
                try
                {
                    msg = SendRawCommand(IP, cmd);
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error sending command:\n\n{cmd}\n\nTo IP: {IP}\n\n{e.Message}");
                }

                if (msg.Contains("err_msg"))
                {
                    Util.ErrorHandler.SendError($"Device at: {IP} returned error:\n\n{msg}");
                }
            }
            else
            {
                switch (deviceType)
                {
                    case "Plug":
                        ControlPlug(IP, cmd);
                        break;
                    case "Bulb":
                        ControlBulb(IP, cmd, param);
                        break;
                    case "Dimmer":
                        ControlDimmer(IP, cmd, param);
                        break;
                    case "PowerStrip":
                        ControlPowerStrip(IP, cmd, param);
                        break;
                    default:
                        Util.ErrorHandler.SendError($"Unrecognized device type: {cmd}");
                        break;
                }
            }
        }

        private static async void ControlPlug(string IP, string cmd)
        {
            try
            {
                TPLinkSmartPlug plug = await TPLinkSmartPlug.Create(IP);

                switch (cmd)
                {
                    case "on":
                        await plug.SetPoweredOn(true);
                        break;
                    case "off":
                        await plug.SetPoweredOn(false);
                        break;
                    case "toggle":
                        await plug.Refresh();
                        await plug.SetPoweredOn(!plug.OutletPowered);
                        break;
                    default:
                        Util.ErrorHandler.SendError($"Unrecognized command: {cmd}");
                        break;
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command:\n\n{cmd}\n\nTo IP: {IP}\n\n{e.Message}");
            }
        }

        private static async void ControlBulb(string IP, string cmd, string param)
        {
            try
            {
                TPLinkSmartBulb bulb = await TPLinkSmartBulb.Create(IP);

                string[] values = new string[0];
                if (!string.IsNullOrEmpty(param))
                {
                    values = param.Split(',');
                }

                switch (cmd)
                {
                    case "on":
                        await bulb.SetPoweredOn(true);
                        break;
                    case "off":
                        await bulb.SetPoweredOn(false);
                        break;
                    case "toggle":
                        await bulb.Refresh();
                        await bulb.SetPoweredOn(!bulb.PoweredOn);
                        break;
                    case "brightness":
                        await bulb.SetBrightness(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                        break;
                    case "colortemp":
                        await bulb.SetColorTemp(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]));
                        break;
                    case "hsv":
                        BulbHSV hsv = new BulbHSV();
                        hsv.Hue = Convert.ToInt32(values[0]);
                        hsv.Saturation = Convert.ToInt32(values[1]);
                        hsv.Value = Convert.ToInt32(values[2]);
                        await bulb.SetHSV(hsv, Convert.ToInt32(values[3]));
                        break;
                    default:
                        Util.ErrorHandler.SendError($"Unrecognized command: {param}");
                        break;
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command:\n\n{param}\n\nTo IP: {IP}\n\n{e.Message}");
            }
        }

        private static async void ControlDimmer(string IP, string cmd, string param)
        {
            try
            {
                TPLinkSmartDimmer dimmer = await TPLinkSmartDimmer.Create(IP);

                string[] values = new string[0];
                if (!string.IsNullOrEmpty(param))
                {
                    values = param.Split(',');
                }

                switch (cmd)
                {
                    case "on":
                        await dimmer.SetPoweredOn(true);
                        break;
                    case "off":
                        await dimmer.SetPoweredOn(false);
                        break;
                    case "toggle":
                        await dimmer.Refresh();
                        await dimmer.SetPoweredOn(!dimmer.PoweredOn);
                        break;
                    case "brightness":
                        await dimmer.SetBrightness(Convert.ToInt32(values[0]));
                        break;
                    case "transition":
                        await dimmer.TransitionBrightness(Convert.ToInt32(values[0]), null, Convert.ToInt32(values[1]));
                        break;
                    default:
                        Util.ErrorHandler.SendError($"Unrecognized command: {param}");
                        break;
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command:\n\n{param}\n\nTo IP: {IP}\n\n{e.Message}");
            }
        }

        private static async void ControlPowerStrip(string IP, string cmd, string param)
        {
            try
            {
                TPLinkSmartMultiPlug powerStrip = await TPLinkSmartMultiPlug.Create(IP);

                string[] values = new string[0];
                if (!string.IsNullOrEmpty(param))
                {
                    values = param.Split(',');
                }

                switch (cmd)
                {
                    case "on":
                        await powerStrip.SetPoweredOn(true, Convert.ToInt32(values[0]));
                        break;
                    case "off":
                        await powerStrip.SetPoweredOn(false, Convert.ToInt32(values[0]));
                        break;
                    case "toggle":
                        await powerStrip.Refresh();
                        await powerStrip.SetPoweredOn(!powerStrip.Outlets[Convert.ToInt32(values[0])].OutletPowered);
                        break;
                    default:
                        Util.ErrorHandler.SendError($"Unrecognized command: {param}");
                        break;
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command:\n\n{param}\n\nTo IP: {IP}\n\n{e.Message}");
            }
        }

        private static string SendRawCommand(string host, string payload)
        {
            string result;

            using (TcpClient client = new TcpClient())
            {
                client.Connect(host, 9999);

                using (NetworkStream stream = client.GetStream())
                {
                    byte[] encrypted = Encrypt(payload);
                    stream.Write(encrypted, 0, encrypted.Length);

                    byte[] lenBuffer = new byte[4];
                    stream.Read(lenBuffer, 0, lenBuffer.Length);
                    int len = BinaryPrimitives.ReadInt32BigEndian(lenBuffer);

                    byte[] readBuffer = new byte[len];

                    int bytesRead = 0;
                    while (bytesRead < len)
                    {
                        bytesRead += stream.Read(readBuffer, bytesRead, len - bytesRead);
                    }

                    result = Decrypt(readBuffer);
                }
            }

            return result;
        }

        private static byte[] Encrypt(string source)
        {
            byte[] arr = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(arr, source.Length);
            List<byte> bytes = new List<byte>(arr);

            int key = 171;
            for (int i = 0; i < source.Length; i++)
            {
                int a = key ^ source[i];
                key = a;
                bytes.Add((byte)a);
            }

            return bytes.ToArray();
        }

        private static string Decrypt(byte[] source)
        {
            string str = String.Empty;

            int key = 171;
            for (int i = 0; i < source.Length; i++)
            {
                int a = key ^ source[i];
                key = source[i];
                str += (char)a;
            }

            return str;
        }
    }
}