using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
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
                 WithWebSocketServer(requestUrl).
                 WithKeepAlivePeriod(TimeSpan.FromMinutes(10)).Build();

        }

        public async Task ConnectAsync(IOnepayPayment obj)
        {
            mqttClient.UseConnectedHandler(e => {
                obj.Connected();
            });

            mqttClient.UseApplicationMessageReceivedHandler(e => {
                obj.NewMessage(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
            });

            mqttClient.UseDisconnectedHandler(e => {
                obj.Disconnected();
            });

            _ = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            _ = await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(obj.Ott).Build());
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
