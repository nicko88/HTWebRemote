using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class TrinnovControl
    {

        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection TrinnovSocket = new SocketConnection(IP, "44100", SocketType.Stream, ProtocolType.Tcp);

            if (TrinnovSocket.Connect())
            {
                //recieve welcome message
                TrinnovSocket.ReceiveData();

                //send id
                TrinnovSocket.SendData(Encoding.ASCII.GetBytes($"id HTWebRemote\r"));

                TrinnovSocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));
                TrinnovSocket.CloseSocket();
            }
        }
    }
}