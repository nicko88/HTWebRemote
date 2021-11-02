using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class BenQControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection BenQsocket = new SocketConnection(IP, "8000", SocketType.Stream, ProtocolType.Tcp);

            if (BenQsocket.Connect())
            {
                Thread.Sleep(100);
                BenQsocket.SendData(Encoding.ASCII.GetBytes($"*{cmd}#"));
                BenQsocket.CloseSocket();
            }
        }
    }
}