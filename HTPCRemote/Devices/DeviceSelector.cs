using System;
using System.Collections.Generic;
using System.IO;
using HTPCRemote.Util;
using HTPCRemote.Devices.Controllers;

namespace HTPCRemote.Devices
{
    class DeviceSelector
    {
        public static List<string> DeviceTypes = new List<string> { "mpc", "lirc", "wemo", "dm", "yamaha", "emotiva", "jvc", "benq", "oppo", "dbox" };

        public static string FindDevice(string devName, string cmd, string param)
        {
            bool showErrors = ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "ShowErrors");

            string returnQuery = "";
            bool query = cmd.StartsWith("query:");

            if (devName == "win")
            {
                if (!query)
                {
                    WinControl.RunCmd(cmd, showErrors);
                }
                else
                {
                    string[] values = cmd.Split(':');
                    try
                    {
                        returnQuery = (string)Type.GetType("HTPCRemote.Devices.Controllers.WinControl").GetMethod(values[1]).Invoke(null, new object[] { showErrors });
                    }
                    catch { }
                }
            }
            else if (devName == "keys")
            {
                KeysControl.RunCmd(cmd, param, showErrors);
            }
            else
            {
                foreach (string device in File.ReadLines(ConfigHelper.DeviceFile))
                {
                    string[] values = device.Split(',');

                    if(values[1] == devName)
                    {
                        if (!query)
                        {
                            CommandDevice(values[2], values[0], cmd, param);
                        }
                        else
                        {
                            returnQuery = QueryDevice(values[2], values[0], cmd, param);
                        }
                        break;
                    }
                }
            }

            return returnQuery;
        }

        public static void CommandDevice(string IP, string devType, string cmd, string param)
        {
            bool showErrors = ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "ShowErrors");

            switch (devType)
            {
                case "dm":
                    DMControl.RunCmd(IP, cmd, param);
                    break;
                case "jvc":
                    JVCControl.RunCmd(IP, cmd, param);
                    break;
                case "benq":
                    BenQControl.RunCmd(IP, cmd);
                    break;
                case "emotiva":
                    EmotivaControl.RunCmd(IP, cmd, param);
                    break;
                case "dbox":
                    DBOXControl.RunCmd(IP, cmd, param);
                    break;
                case "mpc":
                    MPCControl.RunCmd(IP, cmd, param, showErrors);
                    break;
                case "lirc":
                    LIRCControl.RunCmd(IP, cmd, param);
                    break;
                case "wemo":
                    WemoPlugControl.RunCmd(IP, cmd, showErrors);
                    break;
                default:
                    break;
            }
        }

        public static string QueryDevice(string IP, string devType, string cmd, string param)
        {
            bool showErrors = ConfigHelper.CheckRegKey("SOFTWARE\\HTPCRemote", "ShowErrors");

            string returnQuery = "";
            string[] values = cmd.Split(':');

            try
            {
                switch (devType)
                {
                    case "dm":
                        returnQuery = (string)Type.GetType("HTPCRemote.Devices.Controllers.DMControl").GetMethod(values[1]).Invoke(null, new object[] { IP, showErrors });
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
            deviceNames.Add("win");
            deviceNames.Add("keys");

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