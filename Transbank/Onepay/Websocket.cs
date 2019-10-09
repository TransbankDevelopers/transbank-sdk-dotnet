using System;
using System.IO;
using System.Net;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using Transbank.Onepay.Model;
using Transbank.Onepay.Utils;

namespace Transbank.Onepay
{
    public class Websocket
    {
        private static readonly string OnepayIotEndpoint = "https://qml1wjqokl.execute-api.us-east-1.amazonaws.com/prod/onepayjs/auth/keys";
        internal WebsocketCredentials Credentials;

        public IMqttClient mqttClient;
        public IMqttClientOptions mqttClientOptions;

        public Websocket(long Ott)
        {
            Credentials = FetchCredentials();

            string requestUrl = Sigv4util.getSignedurl(Credentials);

            string clientId = Guid.NewGuid().ToString();

            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            mqttClientOptions = new MqttClientOptionsBuilder().
                WithWebSocketServer(requestUrl).Build();

            mqttClient.Connected +=
                    (sender, e) => Console.WriteLine("Connected :D");

            mqttClient.ApplicationMessageReceived +=
                (sender, e) => MqttClient_ApplicationMessageReceived(sender, e, new TransactionCreateResponse());

            mqttClient.Disconnected +=
                (sender, e) => Console.WriteLine("Conection Lost :(");

            mqttClient.ConnectAsync(mqttClientOptions);
            mqttClient.SubscribeAsync(Ott.ToString());
        }

        private WebsocketCredentials FetchCredentials()
        {
            var request = (HttpWebRequest)WebRequest.Create(OnepayIotEndpoint);

            var responseStream = request.GetResponse().GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var credentialsAsJson = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<WebsocketCredentials>(credentialsAsJson);
        }

        private void MqttClient_ApplicationMessageReceived
            (object sender, MqttApplicationMessageReceivedEventArgs e, TransactionCreateResponse response)
        {
            string payload = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload, 0, e.ApplicationMessage.Payload.Length);


            WebsocketMessage message = JsonConvert.DeserializeObject<WebsocketMessage>(payload);
            Console.WriteLine(message);

            switch (message.status)
            {
                case "OTT_ASSIGNED":
                    break;

                case "AUTHORIZED":
                    //Commit(response);
                    mqttClient.DisconnectAsync();
                    break;

                case "REJECTED_BY_USER":
                    break;

                case "AUTHORIZATION_ERROR":
                    break;

                default:
                    Console.WriteLine("No action found");
                    break;
            }
        }
    }
}
