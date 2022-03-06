using System;
using System.Net.Http;

namespace HTWebRemote.Devices.Controllers
{
    class HTP1Control
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            if(cmd.ToLower() == "ir")
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(3);

                    HttpResponseMessage result;
                    try
                    {
                        result = httpClient.GetAsync($"http://{IP}/ircmd?code={param}").Result;

                        if (!result.IsSuccessStatusCode)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        Util.ErrorHandler.SendError($"Error sending command to HTP-1: http://{IP}/ircmd?code={param}\n\n{e.Message}");
                    }
                }
            }
        }
    }
}