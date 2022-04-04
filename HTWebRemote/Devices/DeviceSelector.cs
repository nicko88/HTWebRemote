using System;
using System.Collections.Generic;
using System.IO;
using HTWebRemote.Util;
using HTWebRemote.Devices.Controllers;

namespace HTWebRemote.Devices
{
    class DeviceSelector
    {
        public static List<string> DeviceTypes = new List<string> { "mpc",
                                                                    "kodi",
                                                                    "zoom",
                                                                    "nvshield",
                                                                    "roku",
                                                                    "zappiti",
                                                                    "lirc",
                                                                    "wemo",
                                                                    "kasa",
                                                                    "dm",
                                                                    "yamaha",
                                                                    "emotiva",
                                                                    "storm",
                                                                    "htp1",
                                                                    "anthem",
                                                                    "jvc",
                                                                    "epson",
                                                                    "benq",
                                                                    "christie",
                                                                    "panaproj",
                                                                    "oppo",
                                                                    "dbox",
                                                                    "hdfury",
                                                                    "minidsp-rs",
                                                                    "rs232",
                                                                    "httpget",
                                                                    "mqtt" };

        public static string FindDevice(string devName, string cmd, string param)
        {
            string returnQuery = "";
            bool query = cmd.StartsWith("query:");

            if (devName == "win")
            {
                if (!query)
                {
                    WinControl.RunCmd(cmd, param);
                }
                else
                {
                    string[] values = cmd.Split(':');
                    try
                    {
                        returnQuery = (string)Type.GetType("HTWebRemote.Devices.Controllers.WinControl").GetMethod(values[1]).Invoke(null, new object[] { });
                    }
                    catch { }
                }
            }
            else if (devName == "keys")
            {
                KeysControl.RunCmd(cmd, param);
            }
            else if (devName == "wol")
            {
                WOLControl.RunCmd(cmd);
            }
            else if (devName == "Comment") { }
            else
            {
                foreach (string device in File.ReadLines(ConfigHelper.DeviceFile))
                {
                    string[] values = device.Split(',');

                    string specialData = null;
                    if(values.Length == 4)
                    {
                        specialData = values[3];
                    }

                    if(values[1] == devName)
                    {
                        if (!query)
                        {
                            CommandDevice(values[2], values[0], cmd, param, specialData);
                        }
                        else
                        {
                            returnQuery = QueryDevice(values[2], values[0], cmd);
                        }
                        break;
                    }
                }
            }

            return returnQuery;
        }

        public static void CommandDevice(string IP, string devType, string cmd, string param, string specialData)
        {
            switch (devType)
            {
                case "mpc":
                    MPCControl.RunCmd(IP, cmd, param);
                    break;
                case "kodi":
                    KodiControl.RunCmd(IP, cmd, specialData);
                    break;
                case "zoom":
                    ZoomControl.RunCmd(IP, cmd);
                    break;
                case "nvshield":
                    NVShieldControl.RunCmd(IP, cmd, param);
                    break;
                case "roku":
                    RokuControl.RunCmd(IP, cmd);
                    break;
                case "zappiti":
                    ZappitiControl.RunCmd(IP, cmd);
                    break;
                case "lirc":
                    LIRCControl.RunCmd(IP, cmd, param);
                    break;
                case "wemo":
                    WemoPlugControl.RunCmd(IP, cmd);
                    break;
                case "kasa":
                    KasaControl.RunCmd(IP, cmd);
                    break;
                case "dm":
                    DMControl.RunCmd(IP, cmd, param);
                    break;
                case "yamaha":
                    YamahaControl.RunCmd(IP, cmd);
                    break;
                case "emotiva":
                    EmotivaControl.RunCmd(IP, cmd, param);
                    break;
                case "storm":
                    StormControl.RunCmd(IP, cmd);
                    break;
                case "htp1":
                    HTP1Control.RunCmd(IP, cmd, param);
                    break;
                case "anthem":
                    AnthemControl.RunCmd(IP, cmd);
                    break;
                case "jvc":
                    JVCControl.RunCmd(IP, cmd, param, specialData);
                    break;
                case "epson":
                    EpsonControl.RunCmd(IP, cmd);
                    break;
                case "benq":
                    BenQControl.RunCmd(IP, cmd);
                    break;
                case "christie":
                    ChristieControl.RunCmd(IP, cmd);
                    break;
                case "panaproj":
                    PanaProjControl.RunCmd(IP, cmd, param);
                    break;
                case "oppo":
                    OppoControl.RunCmd(IP, cmd, param);
                    break;
                case "dbox":
                    DBOXControl.RunCmd(IP, cmd, param);
                    break;
                case "hdfury":
                    HDFuryControl.RunCmd(IP, cmd);
                    break;
                case "minidsp-rs":
                    MiniDSPrsControl.RunCmd(IP, cmd, param);
                    break;
                case "rs232":
                    RS232Control.RunCmd(IP, cmd);
                    break;
                case "httpget":
                    HttpGetControl.RunCmd(IP, cmd, specialData);
                    break;
                case "mqtt":
                    MQTTControl.RunCmd(IP, cmd, param, specialData);
                    break;
                default:
                    break;
            }
        }

        public static string QueryDevice(string IP, string devType, string cmd)
        {
            string returnQuery = "";
            string[] values = cmd.Split(':');

            try
            {
                switch (devType)
                {
                    case "dm":
                        returnQuery = (string)Type.GetType("HTWebRemote.Devices.Controllers.DMControl").GetMethod(values[1]).Invoke(null, new object[] { IP });
                        break;
                    case "storm":
                        returnQuery = (string)Type.GetType("HTWebRemote.Devices.Controllers.StormControl").GetMethod(values[1]).Invoke(null, new object[] { IP });
                        break;
                    case "htp1":
                        returnQuery = (string)Type.GetType("HTWebRemote.Devices.Controllers.HTP1Control").GetMethod(values[1]).Invoke(null, new object[] { IP });
                        break;
                    case "minidsp-rs":
                        returnQuery = (string)Type.GetType("HTWebRemote.Devices.Controllers.MiniDSPrsControl").GetMethod(values[1]).Invoke(null, new object[] { IP });
                        break;
                    default:
                        break;
                }
            }
            catch { }

            return returnQuery;
        }

        public static List<string> GetDeviceNames()
        {
            List<string> deviceNames = new List<string>();
            deviceNames.Add("Comment");
            deviceNames.Add("keys");
            deviceNames.Add("win");
            deviceNames.Add("wol");

            try
            {
                foreach (string device in File.ReadLines(ConfigHelper.DeviceFile))
                {
                    string[] values = device.Split(',');
                    deviceNames.Add(values[1]);
                }
            }
            catch { }

            return deviceNames;
        }
    }
}