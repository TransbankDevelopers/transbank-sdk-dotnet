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

        public Websocket(string Ott)
        {
            Credentials = FetchCredentials();

            string requestUrl = Sigv4util.getSignedurl(Credentials);

            string clientId = Guid.NewGuid().ToString();

            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            mqttClientOptions = new MqttClientOptionsBuilder().
                WithWebSocketServer(requestUrl).Build();

            mqttClient.ConnectAsync(mqttClientOptions);
            mqttClient.SubscribeAsync(Ott);
        }

        private WebsocketCredentials FetchCredentials()
        {
            var request = (HttpWebRequest)WebRequest.Create(OnepayIotEndpoint);

            using var responseStream = request.GetResponse().GetResponseStream();
            using var streamReader = new StreamReader(responseStream);
            var credentialsAsJson = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<WebsocketCredentials>(credentialsAsJson);
        }
    }
}
