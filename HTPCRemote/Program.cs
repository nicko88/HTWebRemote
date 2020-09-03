using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HTPCRemote
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    if (IPAddress.TryParse(args[0], out _))
                    {
                        string param = null;
                        try
                        {
                            param = args[3];
                        }
                        catch { }

                        Devices.DeviceSelector.CommandDevice(args[0], args[1], args[2], param);
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
                    MessageBox.Show($"Incorrect Parameters\n\n{e.Message}", "Error");
                }
            }
            else
            {
                if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new HTPCRemote());
                }
            }
        }
    }
}