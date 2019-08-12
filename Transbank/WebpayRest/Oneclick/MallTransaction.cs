using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class MallTransaction
    {
        public static AuthorizeResponse Authorize(string userName, string email, string responseUrl)
        {
            return Authorize(userName, email, responseUrl, Oneclick.DefaultOptions());
        }

        public static AuthorizeResponse Authorize(string userName, string email,
            string responseUrl, Options options)
        {
            return ExceptionHandler.Perform<AuthorizeResponse, MallTransactionAuthorizeException>(() =>
            {
                var startRequest = new StartRequest(userName, email, responseUrl);
                var response = RequestService.Perform<MallTransactionAuthorizeException>(
                    startRequest, options);

                return JsonConvert.DeserializeObject<AuthorizeResponse>(response);
            });
        }
    }
}
