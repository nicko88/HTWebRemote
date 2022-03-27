using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Net.Sockets;

namespace HTWebRemote.Devices.Controllers
{
    class KasaControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            string msg = "";
            try
            {
                msg = SendCommand(IP, cmd);
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command:\n\n{cmd}\n\nTo IP: {IP}\n\n{e.Message}");
            }

            if(msg.Contains("err_msg"))
            {
                Util.ErrorHandler.SendError($"Device at: {IP} returned error:\n\n{msg}");
            }
        }

        public static string SendCommand(string host, string msg)
        {
            string result;

            using (TcpClient client = new TcpClient())
            {
                client.Connect(host, 9999);

                using (NetworkStream stream = client.GetStream())
                {
                    byte[] encrypted = Encrypt(msg);
                    stream.Write(encrypted, 0, encrypted.Length);

                    byte[] lenBuffer = new byte[4];
                    stream.Read(lenBuffer, 0, lenBuffer.Length);
                    int len = BinaryPrimitives.ReadInt32BigEndian(lenBuffer);

                    byte[] readBuffer = new byte[len];

                    int bytesRead = 0;
                    while (bytesRead < len)
                    {
                        bytesRead += stream.Read(readBuffer, bytesRead, len - bytesRead);
                    }

                    result = Decrypt(readBuffer);
                }
            }

            return result;
        }

        private static byte[] Encrypt(string source)
        {
            byte[] arr = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(arr, source.Length);
            List<byte> bytes = new List<byte>(arr);

            int key = 171;
            for (int i = 0; i < source.Length; i++)
            {
                int a = key ^ source[i];
                key = a;
                bytes.Add((byte)a);
            }

            return bytes.ToArray();
        }

        private static string Decrypt(byte[] source)
        {
            string str = String.Empty;

            int key = 171;
            for (int i = 0; i < source.Length; i++)
            {
                int a = key ^ source[i];
                key = source[i];
                str += (char)a;
            }

            return str;
        }
    }
}