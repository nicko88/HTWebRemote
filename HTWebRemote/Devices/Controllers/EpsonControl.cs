using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class EpsonControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection EpsonSocket = new SocketConnection(IP, "3629", SocketType.Stream, ProtocolType.Tcp);

            if (EpsonSocket.Connect())
            {
                //initialize connection: ESC/VP.net\x10\x03\x00\x00\x00\x00
                byte[] message = new byte[] { 0x45, 0x53, 0x43, 0x2F, 0x56, 0x50, 0x2E, 0x6E, 0x65, 0x74, 0x10, 0x03, 0x00, 0x00, 0x00, 0x00 };
                EpsonSocket.SendData(message);
                Thread.Sleep(100);

                EpsonSocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));
                EpsonSocket.CloseSocket();
            }
        }
    }
}