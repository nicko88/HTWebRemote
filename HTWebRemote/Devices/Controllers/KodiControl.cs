using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class KodiControl
    {
        private static Dictionary<string, string> _commands;
        private static Dictionary<string, string> Commands
        {
            get
            {
                _commands = new Dictionary<string, string>
                {
                    { "up", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Up"", ""id"": 1}" },
                    { "down", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Down"", ""id"": 1}" },
                    { "left", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Left"", ""id"": 1}" },
                    { "right", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Right"", ""id"": 1}" },
                    { "select", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Select"", ""id"": 1}" },
                    { "back", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Back"", ""id"": 1}" },
                    { "home", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Home"", ""id"": 1}" },
                    { "contextmenu", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.ContextMenu"", ""id"": 1}" },
                    { "info", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.Info"", ""id"": 1}" },
                    { "osd", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.ShowOSD"", ""id"": 1}" },
                    { "playerstats", @"{""jsonrpc"": ""2.0"", ""method"": ""Input.ShowPlayerProcessInfo"", ""id"": 1}" },
                    { "playpause", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.PlayPause"", ""params"": { ""playerid"": xx }, ""id"": 1}" },
                    { "smallforward", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Seek"", ""params"": { ""playerid"": xx, ""value"": { ""step"": ""smallforward"" } }, ""id"": 1}" },
                    { "smallbackward", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Seek"", ""params"": { ""playerid"": xx, ""value"": { ""step"": ""smallbackward"" } }, ""id"": 1}" },
                    { "bigforward", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Seek"", ""params"": { ""playerid"": xx, ""value"": { ""step"": ""bigforward"" } }, ""id"": 1}" },
                    { "bigbackward", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Seek"", ""params"": { ""playerid"": xx, ""value"": { ""step"": ""bigbackward"" } }, ""id"": 1}" },
                    { "subson", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetSubtitle"", ""params"": { ""playerid"": xx, ""subtitle"": ""on"" }, ""id"": 1}"},
                    { "subsoff", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetSubtitle"", ""params"": { ""playerid"": xx, ""subtitle"": ""off"" }, ""id"": 1}"},
                    { "nextsub", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetSubtitle"", ""params"": { ""playerid"": xx, ""subtitle"": ""next"", ""enable"": true }, ""id"": 1}"},
                    { "prevsub", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetSubtitle"", ""params"": { ""playerid"": xx, ""subtitle"": ""previous"", ""enable"": true }, ""id"": 1}"},
                    { "nextaudio", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetAudioStream"", ""params"": { ""playerid"": xx, ""stream"": ""next"" }, ""id"": 1}"},
                    { "prevaudio", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.SetAudioStream"", ""params"": { ""playerid"": xx, ""stream"": ""previous"" }, ""id"": 1}"},
                    { "next", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GoTo"", ""params"": { ""playerid"": xx, ""to"": ""next"" }, ""id"": 1}" },
                    { "prev", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GoTo"", ""params"": { ""playerid"": xx, ""to"": ""previous"" }, ""id"": 1}" },
                    { "stop", @"{""jsonrpc"": ""2.0"", ""method"": ""Player.Stop"", ""params"": { ""playerid"": xx }, ""id"": 1}" },
                    { "quit", @"{""jsonrpc"": ""2.0"", ""method"": ""Application.Quit"", ""id"": 1}" }
                };

                return _commands;
            }
        }
        public static void RunCmd(string IP, string cmd, string auth)
        {
            try
            {
                bool valid = Commands.TryGetValue(cmd, out string jsonCmd);

                if (valid)
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(3);

                        if (!string.IsNullOrEmpty(auth))
                        {
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(auth)));
                        }

                        StringContent getPlayerID = new StringContent(@"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetActivePlayers"", ""id"": 1}", Encoding.UTF8, "application/json");
                        string playerIDresult = httpClient.PostAsync($"http://{IP}:8080/jsonrpc", getPlayerID).Result.Content.ReadAsStringAsync().Result;

                        JObject json = JObject.Parse(playerIDresult);
                        string playerid = (string)json.SelectToken("result[0].playerid");

                        StringContent playerCmd = new StringContent(jsonCmd.Replace("xx", playerid), Encoding.UTF8, "application/json");
                        _ = httpClient.PostAsync($"http://{IP}:8080/jsonrpc", playerCmd).Result;
                    }
                }
                else
                {
                    Util.ErrorHandler.SendError($@"Command: ""{cmd}"" not found.");
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot send command to to Kodi at {IP}\n\n{e.AllMessages()}");
            }
        }

        public static string getinfo(string IP, string auth)
        {
            string getInfoCmd = @"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetProperties"", ""params"": {""properties"": [""time"", ""totaltime"", ""currentaudiostream"", ""currentsubtitle""], ""playerid"": xx}, ""id"": 1}";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                if (!string.IsNullOrEmpty(auth))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(auth)));
                }

                StringContent getPlayerID = new StringContent(@"{""jsonrpc"": ""2.0"", ""method"": ""Player.GetActivePlayers"", ""id"": 1}", Encoding.UTF8, "application/json");
                string playerIDresult = httpClient.PostAsync($"http://{IP}:8080/jsonrpc", getPlayerID).Result.Content.ReadAsStringAsync().Result;

                JObject json = JObject.Parse(playerIDresult);
                string playerid = (string)json.SelectToken("result[0].playerid");

                StringContent playerCmd = new StringContent(getInfoCmd.Replace("xx", playerid), Encoding.UTF8, "application/json");
                string getInfoJsonResult = httpClient.PostAsync($"http://{IP}:8080/jsonrpc", playerCmd).Result.Content.ReadAsStringAsync().Result;

                JObject json2 = JObject.Parse(getInfoJsonResult);
                string audiolang = (string)json2.SelectToken("result.currentaudiostream.language");
                string audioname = (string)json2.SelectToken("result.currentaudiostream.name");
                string sublang = (string)json2.SelectToken("result.currentsubtitle.language");
                string subname = (string)json2.SelectToken("result.currentsubtitle.name");

                int dur_hour = (int)json2.SelectToken("result.totaltime.hours");
                int dur_min = (int)json2.SelectToken("result.totaltime.minutes");
                int dur_second = (int)json2.SelectToken("result.totaltime.seconds");

                int pos_hour = (int)json2.SelectToken("result.time.hours");
                int pos_min = (int)json2.SelectToken("result.time.minutes");
                int pos_second = (int)json2.SelectToken("result.time.seconds");

                TimeSpan duration = TimeSpan.Parse($"{dur_hour}:{dur_min}:{dur_second}");
                TimeSpan position = TimeSpan.Parse($"{pos_hour}:{pos_min}:{pos_second}");
                TimeSpan remaining = duration.Subtract(position);

                DateTime endTime = DateTime.Now.AddMinutes(remaining.TotalMinutes);

                StringBuilder output = new StringBuilder();
                output.Append($"Length: {duration.ToString("G").Substring(2, 5)}");
                output.Append("\\n");
                output.Append($"Position: {position.ToString("G").Substring(2, 5)}");
                output.Append("\\n");
                output.Append($"Remaining: {remaining.ToString("G").Substring(2, 5)}");
                output.Append("\\n\\n");
                output.Append($"End Time: {endTime:H:mm tt}");
                output.Append("\\n\\n");
                output.Append($"Audio: {audioname} ({audiolang})");
                output.Append("\\n");
                output.Append($"Subtitle: {subname} ({sublang})");

                return output.ToString();
            }
        }
    }
}