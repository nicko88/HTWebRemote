using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class HttpGetControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
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
                if (showErrors)
                {
                    MessageBox.Show($"Error sending http GET request: {IP}{cmd}\n\n{e.Message}", "Error");
                }
            }
        }
    }
}