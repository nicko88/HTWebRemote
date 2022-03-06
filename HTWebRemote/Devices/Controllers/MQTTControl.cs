using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;

namespace HTWebRemote.Devices.Controllers
{
    class MQTTControl
    {
        public static void RunCmd(string IP, string cmd, string param, string auth)
        {
            MqttFactory factory = new MqttFactory();
            IMqttClient mqttClient = factory.CreateMqttClient();

            string strIP = IP.Split(':')[0];
            int port = 1883;
            try
            {
                port = Convert.ToInt32(IP.Split(':')[1]);
            }
            catch { }

            string user = auth.Split(':')[0];
            string pass = "";
            try
            {
                pass = auth.Split(':')[1];
            }
            catch { }

            try
            {
                IMqttClientOptions options = new MqttClientOptionsBuilder()
                    .WithTcpServer(strIP, port)
                    .WithCredentials(user, pass)
                    .Build();

                IAsyncResult result = mqttClient.ConnectAsync(options);
                result.AsyncWaitHandle.WaitOne(5000);
            }
            catch
            {
                Util.ErrorHandler.SendError($"Failed to connect to MQTT broker at: {IP}");
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
                    Util.ErrorHandler.SendError($@"Failed sending Topic: ""{cmd}"" and Payload: ""{param}"" to MQTT broker at: {IP}");
                }
            }
            else
            {
                Util.ErrorHandler.SendError($"Failed to connect to MQTT broker at: {IP}");
            }
        }
    }
}