using System.Net;
using Transbank.Webpay;
using Transbank.Webpay.Wsdl.Normal;

namespace Transbank.PatPass
{
    public class PatPassByWebpayNormal : WebpayNormal
    {
        public enum Currency
        {
            DEFAULT, // CLP o USD
            UF
        }

        public PatPassByWebpayNormal (Configuration config) : base (config) =>
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        /**
         * Permite inicializar una transacción en PatPass. Como respuesta a la invocación se genera un token que representa en forma única una transacción.
         *
         * */
        public wsInitTransactionOutput initTransaction(decimal amount, string buyOrder, string sessionId, string returnUrl, string finalUrl, PatPassInfo info)
        {
            var initTransactionInput = new wsInitTransactionInput
            {
                wSTransactionType = wsTransactionType.TR_NORMAL_WS_WPM,

                buyOrder = buyOrder,
                sessionId = sessionId,
                returnURL = returnUrl,
                finalURL = finalUrl
            };

            var details = new wsTransactionDetail
            {
                commerceCode = this.config.CommerceCode,
                buyOrder = buyOrder,
                amount = amount
            };

            wsTransactionDetail[] wsTransactionDetail = { details };

            initTransactionInput.transactionDetails = wsTransactionDetail;

            var wpmDetailInput = new wpmDetailInput
            {
                serviceId = info.ServiceId,
                cardHolderId = info.CardHolderId,
                cardHolderName = info.CardHolderName,
                cardHolderLastName1 = info.CardHolderLastName1,
                cardHolderLastName2 = info.CardHolderLastName2,
                cardHolderMail = info.CardHolderMail,
                cellPhoneNumber = info.CellPhoneNumber,
                expirationDate = info.ExpirationDate,
                commerceMail = this.config.CommerceMail,
                ufFlag = Currency.UF.Equals(this.config.PatPassCurrency)
            };

            initTransactionInput.wPMDetail = wpmDetailInput;

            using (var proxy = new WSWebpayServiceImplService())
            {
                PrepareProxy(proxy);
                return proxy.initTransaction(initTransactionInput);
            }
        }
    }
}
