using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace HTPCRemote
{
    public partial class DocReader : Form
    {
        public DocReader(string baseIP)
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("doc.html"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                result = result.Replace("{BASEIP}", baseIP);
                webBrowser.DocumentText = result;
            }
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