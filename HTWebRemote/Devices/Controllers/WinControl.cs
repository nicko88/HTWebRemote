using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class WinControl
    {
        public static void RunCmd(string path, string param, bool showErrors)
        {
            if (path.StartsWith("setvol") || path.StartsWith("editvol") || path.StartsWith("mutevol"))
            {
                VolControl(path, showErrors);
            }
            else
            {
                Process process = new Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;

                if(!string.IsNullOrEmpty(param))
                {
                    process.StartInfo.Arguments = param;
                }

                try
                {
                    if (File.Exists(path))
                    {
                        process.StartInfo.FileName = path;
                    }
                    else
                    {
                        process.StartInfo.FileName = $"{Util.ConfigHelper.WorkingPath}\\{path}";
                    }
                }
                catch
                {
                    if (showErrors)
                    {
                        MessageBox.Show($"Cannot find file to open or run: \n\n{process.StartInfo.FileName}", "Error");
                    }
                }
                try
                {
                    process.Start();
                }
                catch (Exception e)
                {
                    if (showErrors)
                    {
                        MessageBox.Show($"Cannot open or run file: \n\n{process.StartInfo.FileName}", "Error");
                    }
                }
            }
        }

        private static void VolControl(string volCmd, bool showErrors)
        {
            if(volCmd == "mutevol")
            {
                Util.WindowsAudioControl.MuteVolume(showErrors);
            }
            else
            {
                string[] volInfo = volCmd.Split('=');

                if(volInfo[0] == "setvol")
                {
                    Util.WindowsAudioControl.SetVolume(Convert.ToInt32(volInfo[1]), showErrors);
                }
                else if(volInfo[0] == "editvol")
                {
                    Util.WindowsAudioControl.AddSubtractVolume(Convert.ToInt32(volInfo[1]), showErrors);
                }
            }
        }

        public static string getvol(bool showErrors)
        {
            return Util.WindowsAudioControl.GetVolume(showErrors).ToString() + "%";
        }
    }
}