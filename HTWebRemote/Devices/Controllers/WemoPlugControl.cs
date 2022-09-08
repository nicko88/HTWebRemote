using System;
using WemoNet;

namespace HTWebRemote.Devices.Controllers
{
    class WemoPlugControl
    {
		public static void RunCmd(string IP, string cmd)
        {
			Wemo wemo = new Wemo();

			bool success = false;
			try
			{
				switch (cmd)
				{
					case "on":
						success = wemo.TurnOnWemoPlugAsync($"http://{IP}").Result;
						break;
					case "off":
						success = wemo.TurnOffWemoPlugAsync($"http://{IP}").Result;
						break;
					case "toggle":
						success = wemo.ToggleWemoPlugAsync($"http://{IP}").Result;
						break;
					default:
						break;
				}
			}
			catch(Exception e)
            {
				Util.ErrorHandler.SendError($"Failed to send command to Wemo plug at {IP}\n\n{e.Message}");
			}

			if(!success)
            {
				Util.ErrorHandler.SendError($"Failed to send command to Wemo plug at {IP}");
			}
		}
	}
}