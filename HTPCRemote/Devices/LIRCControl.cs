using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class LIRCControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
        {
            Socket socket = null;

            try
            {
                string[] conn = IP.Split(':');

                TcpClient tcpSocket = new TcpClient();
                tcpSocket = new TcpClient(conn[0], Convert.ToInt32(conn[1]));
                Thread.Sleep(250);

                byte[] buf = Encoding.ASCII.GetBytes("SEND_ONCE " + cmd + " " + param + Environment.NewLine);
                tcpSocket.GetStream().Write(buf, 0, buf.Length);
                tcpSocket.Close();
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to LIRC at " + IP + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                socket?.Close();
            }
        }
    }
}