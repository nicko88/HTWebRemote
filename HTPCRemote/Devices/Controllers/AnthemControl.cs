using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class AnthemControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection AnthemSocket = new SocketConnection(IP, "14999", SocketType.Stream, ProtocolType.Tcp);

            if (AnthemSocket.Connect())
            {
                Thread.Sleep(100);
                AnthemSocket.SendData(Encoding.ASCII.GetBytes($"{cmd};"));
                Thread.Sleep(50);
                AnthemSocket.CloseSocket();
            }
        }
    }
}