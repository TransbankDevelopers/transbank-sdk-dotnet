using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Oneclick.Exceptions;

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
            try
            {
                var startRequest = new StartRequest(userName, email, responseUrl);
                var response = RequestService.Perform(startRequest, options);

                return JsonConvert.DeserializeObject<AuthorizeResponse>(response);
            }
            catch (Exception e)
            {
                int code = e.GetType().Equals(typeof(TransbankException)) ?
                    ((TransbankException)e).Code : -1;
                throw new MallTransactionAuthorizeException(code, e.Message, e);
            }
        }
    }
}
