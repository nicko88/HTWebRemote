using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class MQTTControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
        {
            MqttFactory factory = new MqttFactory();
            IMqttClient mqttClient = factory.CreateMqttClient();

            try
            {
                IMqttClientOptions options = new MqttClientOptionsBuilder()
                    .WithTcpServer(IP.Split(':')[0], Convert.ToInt32(IP.Split(':')[1]))
                    .Build();

                IAsyncResult result = mqttClient.ConnectAsync(options);
                result.AsyncWaitHandle.WaitOne(5000);
            }
            catch
            {
                if(showErrors)
                {
                    MessageBox.Show($"Failed to connect to MQTT broker at: {IP}", "Error");
                }
            }

            if (mqttClient.IsConnected)
            {
                try
                {
                    MqttApplicationMessage message = new MqttApplicationMessageBuilder()
                        .WithTopic(cmd)
                        .WithPayload(param)
                        .Build();

                    IAsyncResult result = mqttClient.PublishAsync(message);
                    result.AsyncWaitHandle.WaitOne(5000);

                    mqttClient.DisconnectAsync();
                }
                catch
                {
                    if (showErrors)
                    {
                        MessageBox.Show($@"Failed sending Topic: ""{cmd}"" and Payload: ""{param}"" to MQTT broker at: {IP}", "Error");
                    }
                }
            }
            else
            {
                if (showErrors)
                {
                    MessageBox.Show($"Failed to connect to MQTT broker at: {IP}", "Error");
                }
            }
        }
    }
}