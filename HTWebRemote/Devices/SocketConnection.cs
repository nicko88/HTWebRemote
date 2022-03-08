using System;
using System.Net.Sockets;
using System.Net;

namespace HTWebRemote.Devices
{
    class SocketConnection
    {
        private Socket socket;
        private IPEndPoint remoteEndPoint;

        public SocketConnection(string IP, string defaultPort, SocketType socketType, ProtocolType protocolType)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, socketType, protocolType);

                string[] IPport = IP.Split(':');

                int iPort;
                if (IPport.Length > 1)
                {
                    iPort = Convert.ToInt32(IPport[1], 10);
                }
                else
                {
                    iPort = Convert.ToInt32(defaultPort, 10);
                }

                IPAddress remoteIPAddress = IPAddress.Parse(IPport[0]);
                remoteEndPoint = new IPEndPoint(remoteIPAddress, iPort);
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot setup connection for {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}");
            }
        }

        public bool Connect()
        {
            try
            {
                socket.Connect(remoteEndPoint);
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to device at {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}");
            }

            return socket.Connected;
        }

        public void SendData(byte[] data)
        {
            try
            {
                socket.Send(data);
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot send Command: {data} to device at {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}");
            }
        }

        public string ReceiveData()
        {
            string reply = "";
            try
            {
                byte[] buffer = new byte[100];
                socket.Receive(buffer);
                reply = System.Text.Encoding.UTF8.GetString(buffer).TrimEnd('\0');
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Failed to recieve expected data from device at {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}");
            }

            return reply;
        }

        public void CloseSocket()
        {
            socket?.Close();
        }
    }
}