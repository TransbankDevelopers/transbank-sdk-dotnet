using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Responses;
using Newtonsoft.Json;

namespace Transbank.Webpay.Oneclick
{
    public static class Inscription
    {
        public static StartResponse Start(string userName, string email,
            string responseUrl)
        {
            return Start(userName, email, responseUrl, Oneclick.DefaultOptions());
        }

        public static StartResponse Start(string userName, string email,
            string responseUrl, Options options)
        {
            var startRequest = new StartRequest(userName, email, responseUrl);
            var response = RequestService.Perform(startRequest, options);

            return JsonConvert.DeserializeObject<StartResponse>(response);
        }
    }
}
