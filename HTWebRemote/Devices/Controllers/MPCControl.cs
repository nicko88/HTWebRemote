using System;
using System.Net.Http;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class MPCControl
    {
        public static void RunCmd(string IP, string command_id, string param)
        {
            try
            {
                string postData = $"wm_command={command_id}";
                if (command_id == "-2")
                {
                    postData += $"&volume={param}";
                }
                if (command_id == "-1")
                {
                    postData += $"&position={param}";
                }

                using (HttpClient httpClient = new HttpClient())
                {
                    StringContent postContent = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                    _ = httpClient.PostAsync($"http://{IP}/command.html", postContent).Result;
                }

            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to MPC at {IP}\n\n{e.Message}");
            }
        }
    }
}