using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class WemoPlugControl
    {
		private static bool _showErrors;
		private static string _IP;

		public static void RunCmd(string IP, string cmd, bool showErrors)
        {
			_showErrors = showErrors;
			_IP = IP;

			SendRequest(cmd);
		}

		private static void SendRequest(string action)
		{
			try
			{
				string TARGETSTATUS = "0";
				if (action == "on")
				{
					TARGETSTATUS = "1";
				}

				HttpWebRequest req = WebRequest.Create($"http://{_IP}:{49153}/upnp/control/basicevent1") as HttpWebRequest;
				string reqContent = @"<?xml version=""1.0"" encoding=""utf-8""?>";
				reqContent += @"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">";
				reqContent += "<s:Body>";


				if (action != "toggle")
				{
					reqContent += @"<u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1"">";
					reqContent += $"<BinaryState>{TARGETSTATUS}</BinaryState>";
					reqContent += "</u:SetBinaryState>";
					req.Headers.Add(@"SOAPACTION:""urn:Belkin:service:basicevent:1#SetBinaryState""");
				}
				else
				{
					reqContent += @"<u:GetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1"">";
					reqContent += "<BinaryState>1</BinaryState>";
					reqContent += "</u:GetBinaryState>";
					req.Headers.Add(@"SOAPACTION:""urn:Belkin:service:basicevent:1#GetBinaryState""");
				}

				reqContent += "</s:Body>";
				reqContent += "</s:Envelope>";
				UTF8Encoding encoding = new UTF8Encoding();

				req.ContentType = @"text/xml; charset=""utf-8""";
				req.Method = "POST";

				using (Stream requestStream = req.GetRequestStream())
				{
					requestStream.Write(encoding.GetBytes(reqContent), 0, encoding.GetByteCount(reqContent));
				}
			
				HttpWebResponse response = req.GetResponse() as HttpWebResponse;
				using (Stream rspStm = response.GetResponseStream())
				{
					using (StreamReader reader = new StreamReader(rspStm))
					{
						string body = reader.ReadToEnd();
						if (action == "toggle")
						{
							if (body.Contains(">1<"))
							{
								SendRequest("off");
							}
							else
							{
								SendRequest("on");
							}
						}
					}
				}
			}
			catch (WebException e)
			{
				if (_showErrors)
				{
					MessageBox.Show($"Failed to send command to Wemo plug at {_IP}\n\n{e.Message}", "Error");
				}
			}
		}
	}
}