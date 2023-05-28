using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HTWebRemote.Util;
using Microsoft.Win32;

namespace HTWebRemote
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length <= 1)
            {
                if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    int port = 5000;
                    try
                    {
                        port = Convert.ToInt32(ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "Port"));
                    }
                    catch { }

                    try
                    {
                        port = Convert.ToInt32(args[0]);

                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\HTWebRemote", true);
                        key.SetValue("Port", port);
                    }
                    catch { }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new HTWebRemote(port.ToString()));
                }
            }
            else
            {
                try
                {
                    if (Regex.IsMatch(args[0].Split(':')[0], "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
                    {
                        string param = null;
                        string specialData = null;
                        try
                        {
                            if (args[3].StartsWith("special("))
                            {
                                specialData = args[3].Substring(8, args[3].Length - 9);
                            }
                            else
                            {
                                param = args[3];
                            }

                            specialData = args[4].Substring(8, args[4].Length - 9);
                        }
                        catch { }

                        Devices.DeviceSelector.CommandDevice(args[0], args[1], args[2], param, specialData);
                    }
                    else
                    {
                        string param = null;
                        try
                        {
                            param = args[2];
                        }
                        catch { }

                        Devices.DeviceSelector.FindDevice(args[0], args[1], param);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Incorrect Parameters.");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}