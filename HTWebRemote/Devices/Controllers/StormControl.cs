using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
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

        public static string getvol(string IP)
        {
            string vol;
            Util.TelnetConnection conn = null;

            try
            {
                conn = new Util.TelnetConnection(IP, 23);
                conn.Write("ssp.vol");
                Thread.Sleep(100);

                string strVol = conn.Read();
                vol = strVol.Substring(strVol.IndexOf("ssp.vol") + 9, 5).TrimEnd(']');

                conn.Close();

                return vol;
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to Stormaudio at {IP}:23\n\n{e.AllMessages()}");
            }
            finally
            {
                conn?.Close();
            }

            return "??";
        }
    }
}