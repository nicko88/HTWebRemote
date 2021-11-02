using System;
using System.Net.Http;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class RokuControl
    {
        public static void RunCmd(string IP, string cmd, bool showErrors)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(3);

            HttpResponseMessage result;
            try
            {
                result = httpClient.PostAsync($"http://{IP}:8060/{cmd}", null).Result;

                if(!result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                if(showErrors)
                {
                    MessageBox.Show($"Error sending command to Roku: http://{IP}:8060{cmd}\n\n{e.Message}", "Error");
                }
            }
        }
    }
}