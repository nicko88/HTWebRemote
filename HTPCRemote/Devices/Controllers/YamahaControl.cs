using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class YamahaControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection YamahaSocket = new SocketConnection(IP, "50000", SocketType.Stream, ProtocolType.Tcp);

            if (YamahaSocket.Connect())
            {
                Thread.Sleep(100);
                YamahaSocket.SendData(Encoding.ASCII.GetBytes($"@{cmd}\r\n"));
                YamahaSocket.CloseSocket();
            }
        }
    }
}