using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class EpsonControl
    {
        //initialize connection: ESC/VP.net\x10\x03\x00\x00\x00\x00
        private static byte[] init = new byte[] { 0x45, 0x53, 0x43, 0x2F, 0x56, 0x50, 0x2E, 0x6E, 0x65, 0x74, 0x10, 0x03, 0x00, 0x00, 0x00, 0x00 };

        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection EpsonSocket = new SocketConnection(IP, "3629", SocketType.Stream, ProtocolType.Tcp);

            if (EpsonSocket.Connect())
            {
                EpsonSocket.SendData(init);
                Thread.Sleep(100);

                EpsonSocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));
                EpsonSocket.CloseSocket();
            }
        }

        public static string query(string IP, string cmd)
        {
            SocketConnection EpsonSocket = new SocketConnection(IP, "3629", SocketType.Stream, ProtocolType.Tcp);
            string dataResponse = "Error getting value";

            if (EpsonSocket.Connect())
            {
                EpsonSocket.SendData(init);
                Thread.Sleep(100);

                EpsonSocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));

                _ = EpsonSocket.ReceiveData();
                dataResponse = EpsonSocket.ReceiveData();

                EpsonSocket.CloseSocket();
            }

            try
            {
                dataResponse = dataResponse.Substring(dataResponse.LastIndexOf('=') + 1, dataResponse.Length - dataResponse.LastIndexOf(':') + 2);
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error parsing data: {dataResponse}\n\n{e.AllMessages()}");
            }

            return dataResponse;
        }
    }
}