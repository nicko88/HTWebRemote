using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTWebRemote.RemoteFile
{
    public class RemoteItem
    {
        public enum RemoteItemType
        {
            Group = 1,
            Button = 2,
            Blank = 3,
            NewRow = 4,
        }

        public RemoteItemType ItemType { get; set; }
        public string Label { get; set; }
        public int RelativeSize { get; set; }
        public string Color { get; set; }
        public bool ConfirmPopup { get; set; }
        public List<Command> Commands { get; set; }

        //create new group
        public RemoteItem(string groupName, string textColor)
        {
            ItemType = RemoteItemType.Group;
            Label = groupName;
            Color = textColor;
        }

        //create new button
        public RemoteItem(string buttonLabel, int buttonRelativeSize, string buttonColor, bool buttonConfirmPopup)
        {
            ItemType = RemoteItemType.Button;
            Label = buttonLabel;
            RelativeSize = buttonRelativeSize;
            Color = buttonColor;
            ConfirmPopup = buttonConfirmPopup;
            Commands = new List<Command>();
        }

        //create new blank
        public RemoteItem(int blankWeightWidth)
        {
            ItemType = RemoteItemType.Blank;
            RelativeSize = blankWeightWidth;
        }

        //create new row
        public RemoteItem()
        {
            ItemType = RemoteItemType.NewRow;
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

        public override string ToString()
        {
            switch (ItemType)
            {
                case RemoteItemType.Group:
                    return $"Group={Label}";
                case RemoteItemType.Button:
                    string confirm = "";
                    if(ConfirmPopup)
                    {
                        confirm = ",Popup";
                    }
                    return $"  Button={RelativeSize},{Label}{confirm}";
                case RemoteItemType.Blank:
                    return $"  BLANK={RelativeSize}";
                case RemoteItemType.NewRow:
                    return "  ----------------------------------------------------------------------";
                default:
                    return "";
            }
        }
    }
}