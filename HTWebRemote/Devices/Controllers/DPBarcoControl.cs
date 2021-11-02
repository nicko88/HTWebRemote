using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace HTPCRemote.Devices.Controllers
{
    class DPBarcoControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection DPBarcosocket = new SocketConnection(IP, "1025", SocketType.Stream, ProtocolType.Tcp);

            if (DPBarcosocket.Connect())
            {
                Thread.Sleep(100);
                DPBarcosocket.SendData(Encoding.ASCII.GetBytes($":{cmd}".ToUpper() + "\r"));
                DPBarcosocket.CloseSocket();
            }
        }
    }
}