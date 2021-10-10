using System;
using System.Net.Http;

namespace HTPCRemote.Devices.Controllers
{
    class HTP1Control
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            if(cmd.ToLower() == "ir")
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(3);
                httpClient.GetAsync($"http://{IP}/ircmd?code={param}");
            }
        }
    }
}