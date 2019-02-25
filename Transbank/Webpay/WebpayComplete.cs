using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security.Tokens;
using Transbank.Webpay.Wsdl.Complete;

namespace Transbank.Webpay
{
    public class WebpayComplete
    {

        /**
         * 
         * Una transacción completa de Webpay corresponde a una solicitud de autorización financiera de 
         * un pago con tarjetas de crédito, en donde quién realiza el pago ingresa al sitio del comercio, 
         * selecciona productos o servicio, y el ingreso asociado a los datos de la tarjeta de crédito lo realiza 
         * directamente en el sitio del comercio. Es responsabilidad del comercio proveer de un ambiente 
         * seguro para realizar la captura de la información asociada a la tarjeta de crédito, y eliminar dicha 
         * información una vez finalizada la transacción.
         * 
         * */

        Configuration config;

        string WSDL;

        /** Configuración de URL según Ambiente */
        private static string wsdlUrl(string environment)
        {

            Dictionary<string, string> wsdl = new Dictionary<string, string>();
            wsdl.Add("INTEGRACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSCompleteWebpayService?wsdl");
            wsdl.Add("CERTIFICACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSCompleteWebpayService?wsdl");
            wsdl.Add("PRODUCCION", "https://webpay3g.transbank.cl/WSWebpayTransaction/cxf/WSCompleteWebpayService?wsdl");

            return wsdl[environment];

        }

        public WebpayComplete(Configuration config)
        {

            /** Configuración para ser consultado desde cualquier metodo de la clase */
            this.config = config;

            /** Obtiene URL de WSDL según parametro desde Configuración (INTEGRACION, CERTIFICACION, PRODUCCION) */
            string url = this.config.GetEnvironmentDefault();
            WSDL = wsdlUrl(url);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        }

        /**
        * Permite inicializar una transacción en Webpay, como respuesta a la invocación se genera un token que representa en  forma única una transacción
        * */
        public wsCompleteInitTransactionOutput initCompleteTransaction(decimal amount, string buyOrder, string sessionId, string cardExpirationDate, int cvv, string cardNumber)
        {

            wsCompleteInitTransactionInput wsCompleteInitTransactionInput = new wsCompleteInitTransactionInput();

            completeCardDetail completeCardDetail = new completeCardDetail();

            wsCompleteInitTransactionInput.transactionType = wsCompleteTransactionType.TR_COMPLETA_WS;
            wsCompleteInitTransactionInput.sessionId = sessionId;
            wsCompleteInitTransactionInput.buyOrder = buyOrder;
            wsCompleteInitTransactionInput.commerceId = this.config.CommerceCode;

            completeCardDetail.cardExpirationDate = cardExpirationDate;
            completeCardDetail.cvv = cvv;
            completeCardDetail.cardNumber = cardNumber;

            wsCompleteInitTransactionInput.cardDetail = completeCardDetail;

            wsCompleteInitTransactionInput.transactionDetails = new wsCompleteTransactionDetail[] { new wsCompleteTransactionDetail() };
            wsCompleteTransactionDetail transactionDetail = wsCompleteInitTransactionInput.transactionDetails[0] as wsCompleteTransactionDetail;
            transactionDetail.amount = amount;
            transactionDetail.buyOrder = buyOrder;
            transactionDetail.commerceCode = this.config.CommerceCode; ;

            using (WSCompleteWebpayServiceImplService proxy = new WSCompleteWebpayServiceImplService())
            {

                /** Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                wsCompleteInitTransactionOutput wsCompleteInitTransactionOutput = proxy.initCompleteTransaction(wsCompleteInitTransactionInput);
                return wsCompleteInitTransactionOutput;

            }

        }

        /**
        * Permite realizar consultas del valor de cuotas
        * */
        public wsCompleteQuerySharesOutput queryShare(string token, string buyOrder, string shareNumber)
        {

            using (WSCompleteWebpayServiceImplService proxy = new WSCompleteWebpayServiceImplService())
            {

                /** Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                wsCompleteQuerySharesOutput wsCompleteQuerySharesOutput = proxy.queryShare(token, buyOrder, Int32.Parse(shareNumber));
                return wsCompleteQuerySharesOutput;

            }

        }

        /**
        * Ejecuta la solicitud de autorización, esta puede ser realizada con o sin cuotas. La respuesta entrega el resultado de la transacción
        * */
        public wsCompleteAuthorizeOutput authorize(string token, string buyOrder, bool gracePeriod, long queryShare, int deferredPeriodIndex)
        {

            wsCompletePaymentTypeInput paymentType = new wsCompletePaymentTypeInput();
            paymentType.buyOrder = buyOrder;
            paymentType.commerceCode = this.config.CommerceCode;

            wsCompleteQueryShareInput queryShareInput = new   wsCompleteQueryShareInput();
            queryShareInput.idQueryShare = queryShare;

            if (deferredPeriodIndex != 0 )
            {
                queryShareInput.deferredPeriodIndex = deferredPeriodIndex;
            }

            paymentType.queryShareInput = queryShareInput;

            wsCompletePaymentTypeInput[] paymentTipeList = new wsCompletePaymentTypeInput[] { paymentType };

            using (WSCompleteWebpayServiceImplService proxy = new WSCompleteWebpayServiceImplService())
            {

                /** Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                wsCompleteAuthorizeOutput wsCompleteAuthorizeOutput = proxy.authorize(token, paymentTipeList);
                acknowledgeCompleteTransaction(token); // Indica a Webpay que se ha recibido conforme el resultado de la transacción
                return wsCompleteAuthorizeOutput;

            }

        }

        /**
         * Indica  a Webpay que se ha recibido conforme el resultado de la transacción
         * */
        public bool acknowledgeCompleteTransaction(string token)
        {

            using (WSCompleteWebpayServiceImplService proxy = new WSCompleteWebpayServiceImplService())
            {

                /*Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                CustomPolicyAssertion customPolicty = new CustomPolicyAssertion(this.config);
                myPolicy.Assertions.Add(customPolicty);

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;
                
                proxy.acknowledgeCompleteTransaction(token);
                
            }

            return true;

        }


    }

}
