using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class SamsungTizenControl
    {
        private static string _remoteCMD = @"{""method"": ""ms.remote.control"", ""params"": {""Cmd"": ""Click"", ""DataOfCmd"": ""{key}"", ""Option"": ""false"", ""TypeOfRemote"": ""SendRemoteKey""}}";

        public static void RunCmd(string IP, string cmd, string param)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //check for previons connection
            string[] samsungCFG = null;
            try
            {
                samsungCFG = File.ReadAllLines(Path.Combine(Util.ConfigHelper.WorkingPath, "samsung.cfg"));
            }
            catch { }

            //get new token
            if(samsungCFG is null)
            {
                samsungCFG = GetSamsungConfig(IP);
            }

            //send command
            using (ClientWebSocket samsungTizenSocket = new ClientWebSocket())
            {
                if (cmd.StartsWith("KEY_"))
                {
                    string remoteEndpoint = null;
                    if (samsungCFG[0] == "8001")
                    {
                        remoteEndpoint = $"ws://{IP}:8001/api/v2/channels/samsung.remote.control?name=SFRXZWJSZW1vdGU=";
                    }
                    else
                    {
                        remoteEndpoint = $"wss://{IP}:8002/api/v2/channels/samsung.remote.control?token={samsungCFG[1]}";
                    }

                    string msg = _remoteCMD.Replace("{key}", cmd);
                    ArraySegment<byte> payload = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));

                    try
                    {
                        samsungTizenSocket.ConnectAsync(new Uri(remoteEndpoint), new CancellationTokenSource().Token).Wait();
                        samsungTizenSocket.SendAsync(payload, WebSocketMessageType.Text, true, new CancellationTokenSource().Token).Wait();
                        samsungTizenSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "CloseConnection", new CancellationTokenSource().Token).Wait();
                    }
                    catch (Exception e)
                    {
                        Util.ErrorHandler.SendError($"Failed sending command to Samsung TizenOS at {IP}\n\n{e.Message}");
                    }
                }
                else if (cmd.Contains("openapp"))
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(3);

                        try
                        {
                            _ = httpClient.PostAsync($"http://{IP}:8001/api/v2/applications/{param}", null).Result;
                        }
                        catch (Exception e)
                        {
                            Util.ErrorHandler.SendError($"Failed sending command to Samsung TizenOS at {IP}\n\n{e.Message}");
                        }
                    }
                }
                else if (cmd.Contains("closeapp"))
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.Timeout = TimeSpan.FromSeconds(3);

                        try
                        {
                            _ = httpClient.DeleteAsync($"http://{IP}:8001/api/v2/applications/{param}").Result;
                        }
                        catch(Exception e)
                        {
                            Util.ErrorHandler.SendError($"Failed sending command to Samsung TizenOS at {IP}\n\n{e.Message}");
                        }
                    }
                }
            }
        }

        private static string[] GetSamsungConfig(string IP)
        {
            bool saveConfig = true;
            string[] config = new string[2];

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                string jsonInfo = "";
                try
                {
                    jsonInfo = httpClient.GetStringAsync($"http://{IP}:8001/api/v2/").Result;
                }
                catch { }

                bool TokenAuthSupport = false;
                try
                {
                    JObject status = JObject.Parse(jsonInfo);
                    TokenAuthSupport = (bool)status.SelectToken("device").SelectToken("TokenAuthSupport");
                }
                catch
                {
                    saveConfig = false;
                }

                if (TokenAuthSupport)
                {
                    config[0] = "8002";

                    using (ClientWebSocket samsungTizenSocket = new ClientWebSocket())
                    {
                        try
                        {
                            byte[] rcvBytes = new byte[1024];
                            ArraySegment<byte> tokenResponse = new ArraySegment<byte>(rcvBytes);

                            samsungTizenSocket.ConnectAsync(new Uri($"wss://{IP}:8002/api/v2/channels/samsung.remote.control?name=SFRXZWJSZW1vdGU="), new CancellationTokenSource().Token).Wait();
                            WebSocketReceiveResult rcvTokenResult = samsungTizenSocket.ReceiveAsync(tokenResponse, new CancellationTokenSource().Token).Result;
                            string tokenResponseJSON = Encoding.UTF8.GetString(rcvBytes, 0, rcvTokenResult.Count);

                            JObject tokenJSON = JObject.Parse(tokenResponseJSON);
                            string token = (string)tokenJSON.SelectToken("data").SelectToken("token");

                            if (string.IsNullOrEmpty(token))
                            {
                                saveConfig = false;
                            }
                            else
                            {
                                config[1] = token;
                            }

                            samsungTizenSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "CloseConnection", new CancellationTokenSource().Token).Wait();
                        }
                        catch (Exception e)
                        {
                            Util.ErrorHandler.SendError($"Failed getting token from {IP}\n\n{e.Message}");
                            saveConfig = false;
                        }
                    }
                }
                else
                {
                    config[0] = "8001";
                }

                try
                {
                    if (saveConfig)
                    {
                        File.WriteAllLines(Path.Combine(Util.ConfigHelper.WorkingPath, "samsung.cfg"), config);
                    }
                    else
                    {
                        Util.ErrorHandler.SendError($"Failed to get auth token, send another command to try again.");
                    }
                }
                catch { }

                return config;
            }
        }
    }
}