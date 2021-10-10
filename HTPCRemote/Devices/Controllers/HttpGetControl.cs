using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HTPCRemote.Devices.Controllers
{
    class HttpGetControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(3);

            if (!string.IsNullOrEmpty(param))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(param)));
            }

            httpClient.GetAsync($"{IP}{cmd}");
        }
    }
}