using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    static class DMControl
    {
        public static void RunCmd(string IP, string cmd, bool showErrors)
        {
            TcpClient tcpSocket = new TcpClient();
            try
            {
                tcpSocket = new TcpClient(IP, 23);
                Thread.Sleep(100);

                byte[] buf = System.Text.Encoding.ASCII.GetBytes(cmd.ToUpper() + "\r");
                tcpSocket.GetStream().Write(buf, 0, buf.Length);
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to Denon/Marantz at " + IP + ":" + "23" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                tcpSocket?.Close();
            }
        }

        public static string getvol(string IP, bool showErrors)
        {
            double vol;
            Util.TelnetConnection conn = null;

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(IP, 100);

                if (reply.Status == IPStatus.Success)
                {
                    conn = new Util.TelnetConnection(IP, 23);

                    conn.Write("MV?");
                    Thread.Sleep(100);

                    string strVol = conn.Read();
                    if (strVol.Substring(4, 1) == "5")
                    {
                        vol = Convert.ToInt32(strVol.Substring(2, 2)) - 80 + 0.5;
                    }
                    else
                    {
                        vol = Convert.ToInt32(strVol.Substring(2, 2)) - 80;
                    }

                    conn.Close();

                    return vol.ToString() + "dB";
                }
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to Denon/Marantz at " + IP + ":" + "23" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                conn?.Close();
            }

            return "??dB";
        }
    }
}