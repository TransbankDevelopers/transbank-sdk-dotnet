using System;
namespace Transbank.Webpay.WebpayPlus.Responses
{
    public class CreateResponse
    {
        public string Token { get; private set; }
        public string Url { get; private set; } 

        public CreateResponse(string token, string url)
        {
            Token = token;
            Url = url;
        }

        public override string ToString()
        {
            return $"Token={Token}, Url={Url}";
        }
    }
}
