using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HTWebRemote.Devices.Controllers
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

            HttpResponseMessage result;
            try
            {
                result = httpClient.GetAsync($"{IP}{cmd}").Result;

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending http GET request: {IP}{cmd}\n\n{e.Message}");
            }
        }
    }
}