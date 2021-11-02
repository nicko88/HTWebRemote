using System;
using System.Net.Http;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class ZappitiControl
    {
        public static void RunCmd(string IP, string cmd, bool showErrors)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(3);

            HttpResponseMessage result;
            try
            {
                result = httpClient.GetAsync($"http://{IP}:8080/remoteCmd?command={cmd}").Result;

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show($"Error sending command to Zappiti: http://{IP}:8080/remoteCmd?command={cmd}\n\n{e.Message}", "Error");
                }
            }
        }
    }
}