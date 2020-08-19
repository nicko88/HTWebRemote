using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;

namespace HTPCRemote.Util
{
    class ConfigHelper
    {
        public static string WorkingPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string DeviceFile = $@"{WorkingPath}\HTPCRemoteDevices.txt";
        public static string browsePaths = $@"{WorkingPath}\HTPCRemoteBrowsePaths.txt";
        public static string jsonButtonFiles = $@"{WorkingPath}\HTPCRemoteButtons";

        public static void Setup()
        {
            string adminCMD = null;
            string firewall = RunCmd("netsh", "advfirewall firewall show rule name=HTPCRemote", false);
            if (!firewall.Contains("HTPCRemote"))
            {
                adminCMD = @"netsh advfirewall firewall add rule name=""HTPCRemote"" protocol=TCP dir=in localport=5000 action=allow";
            }

            string urlacl = RunCmd("netsh", "http show urlacl url=http://*:5000/", false);
            if (!urlacl.Contains("http://*:5000/"))
            {
                if (adminCMD != null)
                {
                    adminCMD += " && ";
                }
                adminCMD += "netsh http add urlacl url=http://*:5000/ user=" + Environment.UserName;
            }

            if (adminCMD != null)
            {
                RunCmd("cmd", $"/C {adminCMD}", true);
            }
        }

        public static string RunCmd(string filename, string arguments, bool admin)
        {
            Process process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.CreateNoWindow = true;

            if(admin)
            {
                process.StartInfo.Verb = "runas";
            }
            else
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
            }

            string output = null;
            try
            {
                process.Start();
                if (!admin)
                {
                    output = process.StandardOutput.ReadToEnd();
                }
                process.WaitForExit();
            }
            catch(Exception e)
            {
                MessageBox.Show($"Error setting up networking permissions.\n\n{e.Message}", "Error");
            }

            return output;
        }

        public static bool CheckRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return (regKey.GetValueNames().Contains(key));
            }
            catch
            {
                return false;
            }
        }

        public static string GetRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return regKey.GetValue(key).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "error";
        }
    }
}