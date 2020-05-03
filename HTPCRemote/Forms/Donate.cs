using System;
using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Forms
{
    public partial class Donate : Form
    {
        public Donate()
        {
            InitializeComponent();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Thank you for using HTPCRemote!");
            sb.AppendLine();
            sb.AppendLine("I developed this in my spare time for my own use and for the use of other HTPC enthusiasts.");
            sb.AppendLine();
            sb.AppendLine("If you like the program and find it useful and would like to support me with a few bucks that would very appreciated :)");
            sb.AppendLine();
            sb.AppendLine("If you would like to contact me, you can e-mail me here:");

            lblMsg.Text = sb.ToString();
        }

        private void pbDonateLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=NHTWA7JUCHJFG&item_name=HTPCRemote&currency_code=USD&source=url");
        }

        private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:sirmasterboy@gmail.com");
        }
    }
}
