using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class EISCPControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection eISCPSocket = new SocketConnection(IP, "60128", SocketType.Stream, ProtocolType.Tcp);

            byte[] cmdArray = Encoding.ASCII.GetBytes($"!1{cmd}\r");
            byte[] eISCPpacket = new byte[16 + cmdArray.Length];

            //eISCP header
            byte[] magic = Encoding.ASCII.GetBytes("ISCP");
            byte[] headerSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(16));
            byte[] messageSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(cmdArray.Length));
            byte[] versionAndReserved = { 1, 0, 0, 0 };

            magic.CopyTo(eISCPpacket, 0);
            headerSize.CopyTo(eISCPpacket, 4);
            messageSize.CopyTo(eISCPpacket, 8);
            versionAndReserved.CopyTo(eISCPpacket, 12);

            //eISCP cmd
            cmdArray.CopyTo(eISCPpacket, 16);

            if (eISCPSocket.Connect())
            {
                Thread.Sleep(100);
                eISCPSocket.SendData(eISCPpacket);
                eISCPSocket.CloseSocket();
            }
        }
    }
}