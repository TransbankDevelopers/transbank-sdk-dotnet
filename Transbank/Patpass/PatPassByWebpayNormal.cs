using System.Net;
using System.Collections.Generic;
using Microsoft.Web.Services3.Design;
using Transbank.Webpay;
using Transbank.Webpay.Wsdl.Normal;

namespace Transbank.PatPass
{
    /**
     * TRANSACCIÓN DE AUTORIZACIÓN NORMAL:
     * Una transacción de autorización normal (o transacción normal),corresponde a una solicitud de 
     * autorización financiera de un pago con tarjetas de crédito o débito, en donde quién realiza el pago
     * ingresa al sitio del comercio, selecciona productos o servicio, y el ingreso asociado a los datos de la
     * tarjeta de crédito o débito lo realiza en forma segura en PatPass by Webpay
     * 
     *  Respuestas PatPass: 
     * 
     *  TSY: Autenticación exitosa
     *  TSN: autenticación fallida.
     *  TO : Tiempo máximo excedido para autenticación.
     *  ABO: Autenticación abortada por tarjetahabiente.
     *  U3 : Error interno en la autenticación.
     *  Puede ser vacío si la transacción no se autentico.
     *
     *  Códigos Resultado
     * 
     *   0  Transacción aprobada.
     *  -1 Rechazo de transacción.
     *  -2 Transacción debe reintentarse.
     *  -3 Error en transacción.
     *  -4 Rechazo de transacción.
     *  -5 Rechazo por error de tasa.
     *  -6 Excede cupo máximo mensual.
     *  -7 Excede límite diario por transacción.
     *  -8 Rubro no autorizado.
     *  -100 Rechazo por inscripción de PatPass by Webpay
     * */

    public class PatPassByWebpayNormal
    {
        Configuration config;
        string WSDL;

        /** Configuración de URL según Ambiente */
        private static string wsdlUrl(string environment)
        {
            var wsdl = new Dictionary<string, string>
            {
                { "INTEGRACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" },
                { "CERTIFICACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" },
                { "PRODUCCION", "https://webpay3g.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" }
            };

            return wsdl[environment];
        }

        public PatPassByWebpayNormal(Configuration config)
        {
            /** Configuración para ser consultado desde cualquier metodo de la clase */
            this.config = config;

            /** Obtiene URL de WSDL según parametro desde Configuración (INTEGRACION, CERTIFICACION, PRODUCCION) */
            string url = this.config.getEnvironmentDefault();
            WSDL = wsdlUrl(url);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        /**
         * Permite inicializar una transacción en PatPass. Como respuesta a la invocación se genera un token que representa en forma única una transacción.
         * 
         * */
        public wsInitTransactionOutput initTransaction(decimal amount, string buyOrder, string sessionId, string urlReturn, string urlFinal, string serviceId, string cardHolderId, string cardHolderName, string cardHolderLastName1, string cardHolderLastName2, string cardHolderMail, string cellPhoneNumber, System.DateTime expirationDate)
        {
            var initTransaction = new wsInitTransactionInput
            {
                /** Indica el tipo de transacción, su valor debe ser siempre TR_NORMAL_WS_WPM */
                wSTransactionType = wsTransactionType.TR_NORMAL_WS_WPM,

                buyOrder = buyOrder,
                sessionId = sessionId,
                returnURL = urlReturn,
                finalURL = urlFinal
            };

            var details = new wsTransactionDetail
            {
                commerceCode = this.config.CommerceCode
            };
            details.buyOrder = buyOrder;
            details.amount = amount;

            wsTransactionDetail[] wsTransactionDetail = new wsTransactionDetail[] { details };

            initTransaction.transactionDetails = wsTransactionDetail;

            var wpmDetailInput = new wpmDetailInput
            {
                serviceId = serviceId,
                cardHolderId = cardHolderId,
                cardHolderName = cardHolderName,
                cardHolderLastName1 = cardHolderLastName1,
                cardHolderLastName2 = cardHolderLastName2,
                cardHolderMail = cardHolderMail,
                cellPhoneNumber = cellPhoneNumber,
                expirationDate = expirationDate,
                commerceMail = this.config.CommerceMail,
                ufFlag = this.config.UfFlag
            };

            initTransaction.wPMDetail = wpmDetailInput;

            using (var proxy = new WSWebpayServiceImplService())
            {
                /*Define el ENDPOINT del Web Service PatPass by Webpay*/
                proxy.Url = WSDL;

                var myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                var wsInitTransactionOutput = proxy.initTransaction(initTransaction);
                return wsInitTransactionOutput;
            }
        }

        /**
         * Permite obtener el resultado de la transacción una vez que 
         * PatPass by Webpay ha resuelto su autorización financiera.
         * 
         * Respuesta VCI:
         * 
         * TSY: Autenticación exitosa
         * TSN: autenticación fallida.
         * TO : Tiempo máximo excedido para autenticación
         * ABO: Autenticación abortada por tarjetahabiente
         * U3 : Error interno en la autenticación
         * Puede ser vacío si la transacción no se autentico
         * */
        public transactionResultOutput getTransactionResult(string token)
        {
            using (var proxy = new WSWebpayServiceImplService())
            {
                /*Define el ENDPOINT del Web Service PatPass by Webpay*/
                proxy.Url = WSDL;

                var myPolicy = new Policy();

                var customPolicty = new CustomPolicyAssertion(this.config);
                myPolicy.Assertions.Add(customPolicty);
                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                var transactionResultOutput = proxy.getTransactionResult(token);

                acknowledgeTransaction(token); // Indica a PatPass que se ha recibido conforme el resultado de la transacción

                return transactionResultOutput;
            }
        }

        /**
         * Indica a PatPass by Webpay que se ha recibido conforme el resultado de la transacción
         * */
        public bool acknowledgeTransaction(string token)
        {
            using (var proxy = new WSWebpayServiceImplService())
            {
                /*Define el ENDPOINT del Web Service PatPass by Webpay*/
                proxy.Url = WSDL;

                var myPolicy = new Policy();
                var customPolicty = new CustomPolicyAssertion(this.config);
                myPolicy.Assertions.Add(customPolicty);

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;
                proxy.acknowledgeTransaction(token);
            }

            return true;
        }
    }
}
