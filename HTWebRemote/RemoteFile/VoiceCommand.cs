using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTWebRemote.RemoteFile
{
    public class VoiceCommand
    {
        public string Phrase { get; set; }
        public int Confidence { get; set; }
        public List<Command> Commands { get; set; }

        public VoiceCommand(string phrase, int confidence)
        {
            Phrase = phrase;
            Confidence = confidence;
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