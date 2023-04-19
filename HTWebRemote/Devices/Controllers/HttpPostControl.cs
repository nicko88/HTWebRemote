using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class HttpPostControl
    {
        public static void RunCmd(string IP, string cmd, string param, string auth)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);

                if (!string.IsNullOrEmpty(auth))
                {
                    if (auth.Contains("bearer"))
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Substring(7));
                    }
                    else
                    {
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(auth)));
                    }
                }

                HttpResponseMessage result;
                try
                {
                    StringContent postData = null;

                    if (!string.IsNullOrEmpty(param))
                    {
                        postData = new StringContent(param, Encoding.UTF8, "application/json");
                    }

                    result = httpClient.PostAsync($"{IP}{cmd}", postData).Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error sending http POST request to: {IP}{cmd}\n\n{e.Message}");
                }
            }
        }
    }
}