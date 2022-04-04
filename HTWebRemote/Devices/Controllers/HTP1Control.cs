using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class HTP1Control
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            if(cmd.ToLower() == "ir")
            {
                SendCmd(IP, param);
            }
            else if (cmd.Equals("vol"))
            {
                string result = getvol(IP);

                try
                {
                    string[] vals = param.Split(',');

                    int currentVol = Convert.ToInt32(result);
                    int targetVol = Convert.ToInt32(vals[0]);
                    int adjustAmount = Math.Abs(currentVol - targetVol);

                    string commandDirection = "0bf4";
                    if(currentVol > targetVol)
                    {
                        commandDirection = "09f6";
                    }

                    int delay = 300;
                    try
                    {
                        delay = Convert.ToInt32(vals[1]);
                    }
                    catch { }

                    for(int i = 0; i < adjustAmount; i++)
                    {
                        SendCmd(IP, commandDirection);
                        Thread.Sleep(delay);
                    }
                }
                catch { }
            }
        }

        private static void SendCmd(string IP, string cmd)
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
                    Util.ErrorHandler.SendError($"Error sending command to HTP-1: http://{IP}/ircmd?code={cmd}\n\n{e.Message}");
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
                    Util.ErrorHandler.SendError($"Error querying HTP-1 at: http://{IP}\n\n{e.Message}");
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