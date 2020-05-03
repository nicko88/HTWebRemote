using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class EmotivaControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
        {
            Socket socket = null;

            if(string.IsNullOrEmpty(param))
            {
                param = "0";
            }

            string emotivaCMD = "<?xml version=\"1.0\" encoding=\"utf-8\"?><emotivaControl><commandName value=\"commandValue\" ack=\"no\" /></emotivaControl>";
            emotivaCMD = emotivaCMD.Replace("commandName", cmd);
            emotivaCMD = emotivaCMD.Replace("commandValue", param);

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress serverAddr = IPAddress.Parse(IP);
                IPEndPoint endPoint = new IPEndPoint(serverAddr, 7002);

                byte[] send_buffer = Encoding.ASCII.GetBytes(emotivaCMD);

                socket.SendTo(send_buffer, endPoint);
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to Emotiva at " + IP + ":" + "7002" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                socket?.Close();
            }
        }
    }
}