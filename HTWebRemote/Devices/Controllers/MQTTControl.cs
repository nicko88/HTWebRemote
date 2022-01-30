using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;

namespace HTWebRemote.Devices.Controllers
{
    class MQTTControl
    {
        public static void RunCmd(string IP, string cmd, string param)
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