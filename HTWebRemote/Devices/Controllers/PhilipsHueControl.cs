using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class PhilipsHueControl
    {
        private static string _IP;
        private static string _authKey;
        private static Form _frmItemList;

        public static void RunCmd(string IP, string cmd, string param, string authKey)
        {
            _IP = IP;
            _authKey = authKey;

            try
            {
                if (cmd == "lights" || cmd == "zones" || cmd == "rooms")
                {
                    ShowItemList(cmd);
                    return;
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error getting data from Philips Hue Bridge at: {IP}\n\n{e.AllMessages()}");
            }

            try
            {
                if(cmd.Contains("light") || cmd.Contains("room") || cmd.Contains("zone"))
                {
                    LightCMD(cmd, param);
                }
                else if (cmd.Contains("scene"))
                {
                    SceneCMD(cmd, param);
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command to Philips Hue Bridge at: {IP}\n\n{e.AllMessages()}");
            }
        }

        private static void LightCMD(string cmd, string param)
        {
            string[] cmdVals = cmd.Split('=');

            string target = "light";
            if (cmdVals[0] == "zone" || cmdVals[0] == "room")
            {
                target = "grouped_light";
            }

            string API_URL = $"https://{_IP}/clip/v2/resource/{target}/{cmdVals[1]}";

            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            string[] cmds = param.Split(',');
            foreach (string s in cmds)
            {
                string[] vals = s.Split('=');

                switch (vals[0])
                {
                    case "on":
                        sb.Append(string.Format(@"""on"":{{""on"":{0}}},", vals[1]));
                        break;
                    case "br":
                        sb.Append(string.Format(@"""dimming"":{{""brightness"":{0}}},", vals[1]));
                        break;
                    case "ct":
                        sb.Append(string.Format(@"""color_temperature"":{{""mirek"": {0}}},", vals[1]));
                        break;
                    case "xy":
                        string[] xy = vals[1].Split(':');
                        sb.Append(string.Format(@"""color"":{{""xy"":{{""x"":{0},""y"":{1}}}}},", xy[0], xy[1]));
                        break;
                    case "inc":
                        sb.Append(string.Format(@"""dimming_delta"":{{""action"":""up"",""brightness_delta"":{0}}},", vals[1]));
                        break;
                    case "dec":
                        sb.Append(string.Format(@"""dimming_delta"":{{""action"":""down"",""brightness_delta"":{0}}},", vals[1]));
                        break;
                    case "tt":
                        sb.Append(string.Format(@"""dynamics"":{{""duration"":{0}}},", vals[1]));
                        break;
                    default:
                        break;
                }
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            SendHueData(API_URL, sb.ToString());
        }

        private static void SceneCMD(string cmd, string param)
        {
            string[] cmdVals = cmd.Split('=');

            string API_URL = $"https://{_IP}/clip/v2/resource/scene/{cmdVals[1]}";

            StringBuilder sb = new StringBuilder();
            sb.Append(@"{""recall"":{");

            if(param.Contains("dynamic"))
            {
                sb.Append(@"""action"":""dynamic_palette""");
            }
            else
            {
                sb.Append(@"""action"":""active""");
            }

            if(param.Contains("tt="))
            {
                string[] vals = param.Split('=');
                sb.Append(string.Format(@",""duration"":{0}", vals[1]));
            }

            sb.Append("}}");

            SendHueData(API_URL, sb.ToString());
        }

        private static string SendHueData(string URL, string payload)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);
                httpClient.DefaultRequestHeaders.Add("hue-application-key", _authKey);
                StringContent postData = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage result = httpClient.PutAsync(URL, postData).Result;

                string jsonResponse = result.Content.ReadAsStringAsync().Result;
                if (jsonResponse.Contains("unauthorized user"))
                {
                    Util.ErrorHandler.SendError("Unauthorized User\n\nPlease use the 'Get Hue Auth' button in the 'Configure Devices' screen to pair with the Hue Bridge.");
                }
                if (!result.IsSuccessStatusCode)
                {
                    Util.ErrorHandler.SendError($"Error sending command to Philips Hue Bridge at: {_IP}\n\nStatusCode: {result.StatusCode}\n\n{result.Content.ReadAsStringAsync().Result}");
                }

                return jsonResponse;
            }
        }

        private static string GetHueData(string URL)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.Timeout = TimeSpan.FromSeconds(3);
                httpClient.DefaultRequestHeaders.Add("hue-application-key", _authKey);

                HttpResponseMessage result = httpClient.GetAsync(URL).Result;

                string jsonResponse = result.Content.ReadAsStringAsync().Result;
                if (jsonResponse.Contains("unauthorized user"))
                {
                    Util.ErrorHandler.SendError("Unauthorized User\n\nPlease use the 'Get Hue Auth' button in the 'Configure Devices' screen to pair with the Hue Bridge.");
                }
                if (!result.IsSuccessStatusCode)
                {
                    Util.ErrorHandler.SendError($"Error getting data from Philips Hue Bridge at: {_IP}\n\nStatusCode: {result.StatusCode}\n\n{result.Content.ReadAsStringAsync().Result}");
                }

                return jsonResponse;
            }
        }

        private static void LoadLight(Tuple<string, string, string> light)
        {
            string json = GetHueData($"https://{_IP}/clip/v2/resource/light/{light.Item1}");
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID={jObject["data"][0]["id"]}");
            sb.AppendLine($"on={jObject["data"][0]["on"]["on"].ToString().ToLower()}");
            sb.AppendLine($"br={jObject["data"][0]["dimming"]["brightness"]}");
            sb.AppendLine($"ct={jObject["data"][0]["color_temperature"]["mirek"]}");
            sb.AppendLine($"xy={jObject["data"][0]["color"]["xy"]["x"]}:{jObject["data"][0]["color"]["xy"]["y"]}");

            ShowTextList($"Light: {light.Item2}", sb.ToString(), 5);
        }

        private static void LoadZone(Tuple<string, string, string> zone)
        {
            string json = GetHueData($"https://{_IP}/clip/v2/resource/zone/{zone.Item1}");
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {jObject["data"][0]["services"][0]["rid"]}");

            string json2 = GetHueData($"https://{_IP}/clip/v2/resource/scene");
            JObject jObject2 = JsonConvert.DeserializeObject<JObject>(json2);

            int items = 2;
            sb.AppendLine();
            sb.AppendLine("Available Scenes:");

            foreach (JToken scene in jObject2["data"])
            {
                try
                {
                    if (scene["group"]["rid"].ToString() == jObject["data"][0]["id"].ToString())
                    {
                        sb.AppendLine($"{scene["id"]}: {scene["metadata"]["name"]}");
                        items++;
                    }
                }
                catch { }
            }

            ShowTextList($"Zone: {zone.Item2}", sb.ToString(), items);
        }

        private static void LoadRoom(Tuple<string, string, string> room)
        {
            string json = GetHueData($"https://{_IP}/clip/v2/resource/room/{room.Item1}");
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {jObject["data"][0]["services"][0]["rid"]}");

            string json2 = GetHueData($"https://{_IP}/clip/v2/resource/scene");
            JObject jObject2 = JsonConvert.DeserializeObject<JObject>(json2);

            int items = 2;
            sb.AppendLine();
            sb.AppendLine("Available Scenes:");

            foreach (JToken scene in jObject2["data"])
            {
                try
                {
                    if (scene["group"]["rid"].ToString() == jObject["data"][0]["id"].ToString())
                    {
                        sb.AppendLine($"{scene["id"]}: {scene["metadata"]["name"]}");
                        items++;
                    }
                }
                catch { }
            }

            ShowTextList($"Room: {room.Item2}", sb.ToString(), items);
        }

        private static void ShowItemList(string dataType)
        {
            string json = GetHueData($"https://{_IP}/clip/v2/resource/{dataType}".TrimEnd(new char[] {'s'}));
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);

            List<Tuple<string, string, string>> items = new List<Tuple<string, string, string>>();

            foreach (JToken item in jObject["data"])
            {
                items.Add(new Tuple<string, string, string>($"{item["id"]}", $"{item["metadata"]["name"]}", $"{item["type"]}"));
            }

            System.Drawing.Size size = new System.Drawing.Size(350, 10 + 17 * items.Count);
            _frmItemList = new Form();

            _frmItemList.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (size.Height > 800)
            {
                size.Height = 800;
            }
            _frmItemList.ClientSize = size;
            _frmItemList.Text = dataType;

            ListBox lbItems = new ListBox();
            lbItems.Name = "lbItems";
            lbItems.Size = new System.Drawing.Size(size.Width - 10, 17 * items.Count);
            lbItems.Location = new System.Drawing.Point(5, 5);
            lbItems.DataSource = items.OrderBy(tuple => tuple.Item2).ToList();
            lbItems.DisplayMember = "Item2";
            lbItems.ValueMember = "Item1";

            lbItems.Click += new EventHandler(lbItems_Click);

            _frmItemList.Controls.Add(lbItems);
            _frmItemList.StartPosition = FormStartPosition.CenterParent;
            _frmItemList.ShowDialog();
        }

        private static void ShowTextList(string title, string list, int items)
        {
            System.Drawing.Size size = new System.Drawing.Size(500, 10 + 20 * items);
            Form textbox = new Form();

            textbox.FormBorderStyle = FormBorderStyle.FixedDialog;
            textbox.ClientSize = size;
            textbox.Text = title;

            RichTextBox rtb = new RichTextBox();
            rtb.Size = new System.Drawing.Size(size.Width - 10, 20 * items);
            rtb.Location = new System.Drawing.Point(5, 5);
            rtb.Font = new System.Drawing.Font("Consolas", 10);
            rtb.ReadOnly = true;
            textbox.Controls.Add(rtb);

            rtb.Text = list;

            textbox.StartPosition = FormStartPosition.CenterParent;
            textbox.ShowDialog();
        }

        private static void lbItems_Click(object sender, EventArgs e)
        {
            ListBox lbItems = (ListBox)_frmItemList.Controls.Find("lbItems", false)[0];

            Tuple<string, string, string> value = (Tuple<string, string, string>)lbItems.SelectedItem;

            switch (value.Item3)
            {
                case "light":
                    LoadLight(value);
                    break;
                case "zone":
                    LoadZone(value);
                    break;
                case "room":
                    LoadRoom(value);
                    break;
                default:
                    break;
            }
        }
    }
}