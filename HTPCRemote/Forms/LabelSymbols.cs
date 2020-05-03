using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class LabelSymbols : Form
    {
        public LabelSymbols()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("In addition to normal letters, you can also use special \"unicode\" characters and emojis if you want to use some basic symbols for your buttons labels.");
            sb.AppendLine();
            sb.AppendLine("A good example of this would be for putting arrow symbols on your buttons.");
            sb.AppendLine();
            sb.AppendLine("In order to do this, you must paste the hex code or decimal code for the symbol into the button label box.");
            sb.AppendLine();
            sb.AppendLine("Decimal code looks like this: &#8592");
            sb.AppendLine("Hex code looks like this: &#x2190");
            sb.AppendLine();
            sb.AppendLine("Arrow symbols for example are as follows:");
            sb.AppendLine("← = &&#x2190");
            sb.AppendLine("→ = &&#x2192");
            sb.AppendLine("↑  = &&#x2191");
            sb.AppendLine("↓  = &&#x2193");
            sb.AppendLine();
            sb.AppendLine("Click Here for a list of symbols and their hex and dec codes.");

            lblMsg.Text = sb.ToString();
        }

        private void lblSymbolsPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.w3schools.com/charsets/ref_utf_arrows.asp");
        }
    }
}
