using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace HTWebRemote.Devices.Controllers
{
    class WOLControl
    {
        public static void RunCmd(string mac)
        {
            try
            {
                PhysicalAddress physicalAddress = PhysicalAddress.Parse(mac.Replace(":","-").ToUpper());

                IEnumerable<byte> header = Enumerable.Repeat(byte.MaxValue, 6);
                IEnumerable<byte> data = Enumerable.Repeat(physicalAddress.GetAddressBytes(), 16).SelectMany(m => m);

                byte[] magicPacket = header.Concat(data).ToArray();

                using (UdpClient client = new UdpClient())
                {
                    client.Send(magicPacket, magicPacket.Length, new IPEndPoint(IPAddress.Broadcast, 9));
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending WOL packet to: {mac}\n\n{e.Message}");
            }
        }
    }
}