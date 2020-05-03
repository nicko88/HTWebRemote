namespace HTPCRemote.RemoteFile
{
    public class Command
    {
        public string DeviceName { get; set; }
        public string Cmd { get; set; }
        public string Param { get; set; }
        public int WaitTimeMS { get; set; }

        public Command() { }

        //new wait command
        public Command(int waitTimeMS)
        {
            DeviceName = "wait";
            WaitTimeMS = waitTimeMS;
        }

        //new command
        public Command(string commandDevice, string commandText, string commandParameter)
        {
            DeviceName = commandDevice;
            Cmd = commandText;
            if (!string.IsNullOrEmpty(commandParameter))
            {
                Param = commandParameter;
            }
        }

        public void SendCommand()
        {
            if (DeviceName == "wait")
            {
                System.Threading.Thread.Sleep(WaitTimeMS);
            }
            else
            {
                Devices.DeviceSelector.FindDevice(DeviceName, Cmd, Param);
            }
        }

        public override string ToString()
        {
            if (WaitTimeMS > 0)
            {
                return "wait=" + WaitTimeMS + "ms";
            }
            else if (string.IsNullOrEmpty(Param))
            {
                return "DevName=" + DeviceName + ",cmd=" + Cmd;
            }
            else
            {
                return "DevName=" + DeviceName + ",cmd=" + Cmd + ",param=" + Param;
            }
        }
    }
}