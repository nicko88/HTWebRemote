using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class EmotivaControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection Emosocket = new SocketConnection(IP, "7002", SocketType.Dgram, ProtocolType.Udp);

            if (Emosocket.Connect())
            {
                Thread.Sleep(250);
                if (string.IsNullOrEmpty(param))
                {
                    param = "0";
                }

                StringBuilder emotivaCMD = new StringBuilder();
                emotivaCMD.AppendFormat("<?xml version=\"1.0\" encoding=\"utf-8\"?><emotivaControl><{0} value=\"{1}\" ack=\"no\" /></emotivaControl>", cmd, param);

                Emosocket.SendData(Encoding.ASCII.GetBytes(emotivaCMD.ToString()));
                Emosocket.CloseSocket();
            }
        }
    }
}