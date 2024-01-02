using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class HTP1Control
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            if (cmd.ToLower() == "ir")
            {
                SendIRCmd(IP, param);
            }
            else
            {
                using (ClientWebSocket HTP1WebSocket = new ClientWebSocket())
                {
                    try
                    {
                        string value = "";
                        if(Int32.TryParse(param, out int result) || param == "true" || param == "false")
                        {
                            value = param;
                        }
                        else
                        {
                            value = $@"""{param}""";
                        }

                        string json = @"[{""op"":""replace"", ""path"": ""X"", ""value"": Y}]";
                        json = json.Replace("X", cmd);
                        json = json.Replace("Y", value);

                        ArraySegment<byte> payload = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"changemso {json}"));

                        HTP1WebSocket.ConnectAsync(new Uri($"ws://{IP}/ws/controller"), new CancellationTokenSource().Token).Wait();
                        HTP1WebSocket.SendAsync(payload, WebSocketMessageType.Text, true, new CancellationTokenSource().Token).Wait();
                        HTP1WebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "CloseOutputConnection", new CancellationTokenSource().Token).Wait();
                        HTP1WebSocket.Dispose();
                    }
                    catch (Exception e)
                    {
                        Util.ErrorHandler.SendError($"Failed sending command to HTP-1 at {IP}\n\n{e.AllMessages()}");
                    }
                }
            }
        }

        private static void SendIRCmd(string IP, string cmd)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                HttpResponseMessage result;
                try
                {
                    result = httpClient.GetAsync($"http://{IP}/ircmd?code={cmd}").Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error sending command to HTP-1: http://{IP}/ircmd?code={cmd}\n\n{e.AllMessages()}");
                }
            }
        }

        public static string getvol(string IP)
        {
            string volume = "??";
            string jsonStatus = "";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                try
                {
                    jsonStatus = httpClient.GetStringAsync($"http://{IP}/ircmd").Result;
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error querying HTP-1 at: http://{IP}\n\n{e.AllMessages()}");
                }
            }

            try
            {
                JObject status = JObject.Parse(jsonStatus);
                volume = (string)status.SelectToken("volume");
            }
            catch { }

            return volume;
        }
    }
}