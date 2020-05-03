using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class WinControl
    {
        public static void RunCmd(string fileName, bool showErrors)
        {
            if (fileName.StartsWith("setvol") || fileName.StartsWith("editvol") || fileName.StartsWith("mutevol"))
            {
                VolControl(fileName, showErrors);
            }
            else
            {
                Process process = new Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                try
                {
                    process.StartInfo.FileName = Util.ConfigHelper.WorkingPath + "\\" + fileName;
                }
                catch
                {
                    if (showErrors)
                    {
                        MessageBox.Show("Cannot find file to open: \n\n" + Util.ConfigHelper.WorkingPath + "\\" + fileName, "Error");
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
                        MessageBox.Show("Cannot run file: \n\n" + Util.ConfigHelper.WorkingPath + "\\" + fileName + "\n\n" + e.Message, "Error");
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