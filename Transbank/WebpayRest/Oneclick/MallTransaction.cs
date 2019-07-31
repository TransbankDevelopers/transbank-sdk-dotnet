using System;
using Newtonsoft.Json;
using Transbank.Common;
using System.Collections.Generic;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Oneclick.Exceptions;


namespace Transbank.Webpay.Oneclick
{
    public static class MallTransaction
    {
        public static AuthorizeMallResponse Authorize(string userName, string tbkUser,
            string buyOrder, List<PaymentRequest> details)
        {
            return Authorize(userName, tbkUser, buyOrder, details, Oneclick.DefaultOptions());
        }

        public static AuthorizeMallResponse Authorize(string userName,
            string tbkUser, string buyOrder, List<PaymentRequest> details,
            Options options)
        {
            try
            {
                var authorizeRequest = new AuthorizeMallRequest(userName, tbkUser, buyOrder,
                    details);
                var response = RequestService.Perform(authorizeRequest, options);

                return JsonConvert.DeserializeObject<AuthorizeMallResponse>(response);
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
