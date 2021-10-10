using System;
using System.Net.Http;

namespace HTPCRemote.Devices.Controllers
{
    class ZappitiControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(3);
            httpClient.GetAsync($"http://{IP}:8080/remoteCmd?command={cmd}");
        }
    }
}