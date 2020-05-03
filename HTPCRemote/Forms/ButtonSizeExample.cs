using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class ButtonSizeExample : Form
    {
        public ButtonSizeExample()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Button size is meant to be small numbers, typically 1-5 or so.");
            sb.AppendLine();
            sb.AppendLine("The way it works is the numbers are relative sizes compared to the other buttons in the same row only.");
            sb.AppendLine();
            sb.AppendLine("The same sizing rule applies to blank spaces as if they were invisible buttons.");
            sb.AppendLine();
            sb.AppendLine("A trick to make things line up better is to make the button sizes in each row add up to the same number as you can see in row 1 and 2.");
            sb.AppendLine();
            sb.AppendLine("See the image below for some basic examples of how button sizes can be used to create a simple remote layout.");

            lblText.Text = sb.ToString();
        }
    }
}