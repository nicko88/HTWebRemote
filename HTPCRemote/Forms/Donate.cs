using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace HTPCRemote.Forms
{
    public partial class Donate : Form
    {
        private string em = "c2lybWFzdGVyYm95QGdtYWlsLmNvbQ==";
        public Donate()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Thank you for using HTPCRemote!");
            sb.AppendLine();
            sb.AppendLine("I developed this in my spare time for my own use and for the use of other HTPC enthusiasts.");
            sb.AppendLine();
            sb.AppendLine("If you like the program and find it useful and would like to support me with a few bucks that would very appreciated :)");
            sb.AppendLine();
            sb.AppendLine("If you would like to contact me, you can e-mail me here:");

            lblMsg.Text = sb.ToString();

            toolTipEmail.SetToolTip(linkEmail, Encoding.UTF8.GetString(Convert.FromBase64String(em)));
        }

        private void pbDonateLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/donate?business=NHTWA7JUCHJFG&item_name=HTPCRemote&currency_code=USD");
        }

        private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start($"mailto:{Encoding.UTF8.GetString(Convert.FromBase64String(em))}");
        }
    }
}