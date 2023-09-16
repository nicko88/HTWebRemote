using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class MiniDSPrsControl
    {
        private static Dictionary<string, string> _commands;
        private static Dictionary<string, string> Commands
        {
            get
            {
                _commands = new Dictionary<string, string>
                {
                    { "config1", @"{""master_status"":{""preset"":0}}" },
                    { "config2", @"{""master_status"":{""preset"":1}}" },
                    { "config3", @"{""master_status"":{""preset"":2}}" },
                    { "config4", @"{""master_status"":{""preset"":3}}" },
                    { "analog", @"{""master_status"":{""source"": ""Analog""}}" },
                    { "toslink", @"{""master_status"":{""source"": ""Toslink""}}" },
                    { "usb", @"{""master_status"":{""source"": ""Usb""}}" },
                    { "mute", @"{""master_status"":{""mute"": true}}" },
                    { "unmute", @"{""master_status"":{""mute"": false}}" },
                    { "volume", @"{""master_status"":{""volume"": xx}}" },
                    { "volup", @"{""master_status"":{""volume"": xx}}" },
                    { "voldown", @"{""master_status"":{""volume"": xx}}" },
                    { "input_mute", @"{""inputs"":[{""index"":xx,""mute"":true}]}" },
                    { "input_unmute", @"{""inputs"":[{""index"":xx,""mute"":false}]}" },
                    { "input_gain", @"{""inputs"":[{""index"":xx,""gain"":yy}]}" },
                    { "output_mute", @"{""outputs"":[{""index"":xx,""mute"":true}]}" },
                    { "output_unmute", @"{""outputs"":[{""index"":xx,""mute"":false}]}" },
                    { "output_gain", @"{""outputs"":[{""index"":xx,""gain"":yy}]}" }
                };

                return _commands;
            }
        }
        public static void RunCmd(string IP, string cmd, string param, string devID)
        {
            if(string.IsNullOrEmpty(devID))
            {
                devID = "0";
            }

            try
            {
                bool valid = Commands.TryGetValue(cmd, out string jsonCmd);

                try
                {
                    if (cmd == "volume")
                    {
                        jsonCmd = jsonCmd.Replace("xx", param);
                    }
                    else if (cmd == "volup")
                    {
                        double newVol = Convert.ToDouble(getvol(IP, devID)) + Convert.ToDouble(param);
                        if (newVol > 0)
                        {
                            newVol = 0;
                        }
                        jsonCmd = jsonCmd.Replace("xx", newVol.ToString());
                    }
                    else if (cmd == "voldown")
                    {
                        double newVol = Convert.ToDouble(getvol(IP, devID)) - Convert.ToDouble(param);
                        if (newVol < -127.5)
                        {
                            newVol = -127.5;
                        }
                        jsonCmd = jsonCmd.Replace("xx", newVol.ToString());
                    }
                    else if (cmd.Contains("_"))
                    {
                        if(param.Contains(","))
                        {
                            string[] vals = param.Split(',');
                            jsonCmd = jsonCmd.Replace("xx", (Convert.ToInt32(vals[0]) - 1).ToString());
                            jsonCmd = jsonCmd.Replace("yy", vals[1]);
                        }
                        else
                        {
                            jsonCmd = jsonCmd.Replace("xx", (Convert.ToInt32(param) - 1).ToString());
                        }
                    }
                }
                catch { }

                if (valid)
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(5);
                        StringContent jsonContent = new StringContent(jsonCmd, Encoding.UTF8, "application/json");
                        _ = httpClient.PostAsync($"http://{IP}:5380/devices/{devID}/config", jsonContent).Result;
                    }
                }
                else
                {
                    Util.ErrorHandler.SendError($@"Command: ""{cmd}"" not found.");
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot send command to to minidsp-rs at {IP}\n\n{e.AllMessages()}");
            }
        }

        public static string getvol(string IP, string devID)
        {
            string volume = "??";
            string jsonStatus = "";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                try
                {
                    jsonStatus = httpClient.GetStringAsync($"http://{IP}:5380/devices/{devID}").Result;
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error querying minidsp-rs at: http://{IP}\n\n{e.AllMessages()}");
                }
            }

            try
            {
                JObject status = JObject.Parse(jsonStatus);
                volume = (string)status.SelectToken("master.volume");
            }
            catch { }

            return volume;
        }
    }
}