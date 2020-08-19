using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Devices.Controllers
{
    class MPCControl
    {
        public static void RunCmd(string IP, string command_id, string param, bool showErrors)
        {
            try
            {
                WebRequest request = WebRequest.Create($"http://{IP}/command.html");
                string postData = "wm_command=" + command_id;

                if (command_id == "-2")
                {
                    postData += "&volume=" + param;
                }
                if (command_id == "-1")
                {
                    postData += "&position=" + param;
                }

                byte[] data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show($"Cannot connect to MPC at {IP}\n\n{e.Message}", "Error");
                }
            }
        }
    }
}