using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace HTWebRemote.Devices.Controllers
{
    class WOLControl
    {
        public static void RunCmd(string mac)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    // enable UDP broadcasting for UdpClient
                    udpClient.EnableBroadcast = true;

                    byte[] dgram = new byte[1024];

                    // 6 magic bytes
                    for (int i = 0; i < 6; i++)
                    {
                        dgram[i] = 255;
                    }

                    // convert MAC-address to bytes
                    byte[] address_bytes = new byte[6];
                    for (int i = 0; i < 6; i++)
                    {
                        address_bytes[i] = byte.Parse(mac.Substring(3 * i, 2), NumberStyles.HexNumber);
                    }

                    // repeat MAC-address 16 times in the datagram
                    Span<byte> macaddress_block = dgram.AsSpan(6, 16 * 6);
                    for (int i = 0; i < 16; i++)
                    {
                        address_bytes.CopyTo(macaddress_block.Slice(6 * i));
                    }

                    // send datagram using UDP and port 0
                    udpClient.Send(dgram, dgram.Length, new IPEndPoint(IPAddress.Broadcast, 0));
                    udpClient.Close();
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending WOL packet to: {mac}\n\n{e.Message}");
            }
        }
    }
}