using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    static class DMControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection DMsocket = new SocketConnection(IP, "23", SocketType.Stream, ProtocolType.Tcp);

            if (DMsocket.Connect())
            {
                DMsocket.SendData(Encoding.ASCII.GetBytes((cmd + param).ToUpper() + "\r"));
                DMsocket.CloseSocket();
            }
        }

        public static string getvol(string IP)
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

                    return $"{vol}dB";
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to Denon/Marantz at {IP}:23\n\n{e.Message}");
            }
            finally
            {
                conn?.Close();
            }

            return "??dB";
        }
    }
}