using HTPCRemote.Util;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace HTPCRemote
{
    public partial class DocReader : Form
    {
        public DocReader(string baseIP)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            string docPage = ConfigHelper.GetEmbeddedResource("doc.html");
            docPage = docPage.Replace("{BASEIP}", baseIP);
            webBrowser.DocumentText = docPage;
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().Contains("about:blank"))
            {
                e.Cancel = true;
                Process.Start(e.Url.ToString());
            }
        }
    }
}