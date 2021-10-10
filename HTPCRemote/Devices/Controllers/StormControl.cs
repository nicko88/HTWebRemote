using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HTPCRemote.Devices.Controllers
{
    class StormControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection Stormsocket = new SocketConnection(IP, "23", SocketType.Stream, ProtocolType.Tcp);

            if (Stormsocket.Connect())
            {
                Stormsocket.SendData(Encoding.ASCII.GetBytes(cmd + "\r"));
                Stormsocket.CloseSocket();
            }
        }

        public static string getvol(string IP, bool showErrors)
        {
            string vol;
            Util.TelnetConnection conn = null;

            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(IP, 100);

                if (reply.Status == IPStatus.Success)
                {
                    conn = new Util.TelnetConnection(IP, 23);

                    conn.Write("ssp.vol");
                    Thread.Sleep(100);

                    string strVol = conn.Read();
                    vol = strVol.Substring(strVol.IndexOf("ssp.vol") + 9, 5).TrimEnd(']');

                    conn.Close();

                    return vol;
                }
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show($"Cannot connect to Stormaudio at {IP}:23\n\n{e.Message}", "Error");
                }
            }
            finally
            {
                conn?.Close();
            }

            return "??";
        }
    }
}