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
                Util.ErrorHandler.SendError($"Cannot send command to to Kodi at {IP}\n\n{e.Message}");
            }
        }
    }
}