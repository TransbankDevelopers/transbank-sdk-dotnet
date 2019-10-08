namespace Transbank.Onepay.Model
{
    public class WebsocketCredentials
    {
        public string iotEndpoint;
        public string region;
        public string accessKey;
        public string secretKey;
        public string sessionToken;

        public override string ToString()
        {
            return "Endpoint: " + iotEndpoint + "\n" +
                   "Region: " + region + "\n" +
                   "Acces Key: " + accessKey + "\n" +
                   "SecretKey: " + secretKey + "\n" +
                   "SessionToken: " + sessionToken;
        }
    }
}