using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class BenQControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection BenQsocket = new SocketConnection(IP, "8000", SocketType.Stream, ProtocolType.Tcp);

            if (BenQsocket.Connect())
            {
                Thread.Sleep(250);
                BenQsocket.SendData(Encoding.ASCII.GetBytes($"*{cmd}#"));
                BenQsocket.CloseSocket();
            }
        }
    }
}