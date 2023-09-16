using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTWebRemote.RemoteFile
{
    public class HotKey
    {
        public string KeyName { get; set; }
        public int KeyValue { get; set; }
        public int ModifierValue { get; set; }
        public List<Command> Commands { get; set; }

        public HotKey(int keyValue, int modifierValue, string keyName)
        {
            KeyValue = keyValue;
            ModifierValue = modifierValue;
            KeyName = keyName;
            Commands = new List<Command>();
        }

        public void RunButtonCommands()
        {
            if (Commands != null)
            {
                Task.Run(() =>
                {
                    foreach (Command cmd in Commands)
                    {
                        cmd.SendCommand();
                    }
                });
            }
        }
    }
}