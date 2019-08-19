using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompleta.Requests;
using Transbank.Webpay.TransaccionCompleta.Responses;

namespace Transbank.Webpay.TransaccionCompleta
{
    public static class FullTransaction
    {
        
        public static CreateResponse Create(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate)
        {
            return Create(buyOrder, sessionId, amount, cvv, cardNumber, cardExpirationDate, TransaccionCompleta.DefaultOptions());
        }

        public static CreateResponse Create(
            string buyOrder,
            string sessionId,
            int amount,
            int cvv,
            string cardNumber,
            string cardExpirationDate,
            Options options)
        {
            return ExceptionHandler.Perform<CreateResponse, TransactionCreateException>(() =>
            {
                var createRequest = new CreateRequest(
                    buyOrder,
                    sessionId,
                    amount,
                    cvv,
                    cardNumber,
                    cardExpirationDate);
                var response = RequestService.Perform<TransactionCreateException>(createRequest, options);

                return JsonConvert.DeserializeObject<CreateResponse>(response);

            });

        }
    }
}
