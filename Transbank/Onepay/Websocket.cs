using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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

        public Websocket()
        {
            Credentials = FetchCredentials();

            string requestUrl = Sigv4util.getSignedurl(Credentials);

            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            mqttClientOptions = new MqttClientOptionsBuilder().
                WithWebSocketServer(requestUrl).Build();

        }

        public async Task Connect(IOnepayPayment obj)
        {
            mqttClient.Connected +=
                   (sender, e) => obj.Connected();

            mqttClient.ApplicationMessageReceived +=
                (sender, e) => obj.NewMessage(
                    System.Text.Encoding.UTF8.GetString(
                        e.ApplicationMessage.Payload, 0,
                        e.ApplicationMessage.Payload.Length));

            mqttClient.Disconnected +=
                (sender, e) => obj.Disconnected();

            await mqttClient.ConnectAsync(mqttClientOptions);
            await mqttClient.SubscribeAsync(obj.Ott);
        }

        private WebsocketCredentials FetchCredentials()
        {
            var request = (HttpWebRequest)WebRequest.Create(OnepayIotEndpoint);

            var responseStream = request.GetResponse().GetResponseStream();
            var streamReader = new StreamReader(responseStream);
            var credentialsAsJson = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<WebsocketCredentials>(credentialsAsJson);
        }

    }
}
