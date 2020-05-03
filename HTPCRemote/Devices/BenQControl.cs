using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class BenQControl
    {
        public static void RunCmd(string IP, string cmd, bool showErrors)
        {
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                int alPort = Convert.ToInt16("8000", 10);

                System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(IP);
                System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);

                socket.Connect(remoteEndPoint);
                System.Threading.Thread.Sleep(250);

                socket.Send(Encoding.ASCII.GetBytes("*" + cmd + "#"));
            }
            catch(Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to BenQ at " + IP + ":" + "8000" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                socket?.Close();
            }
        }
    }
}