using System.Net;
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

    public class PatPassByWebpayNormal : WebpayNormal
    {
        readonly Configuration config;

        public PatPassByWebpayNormal(Configuration config) : base (config.BaseConfig())
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
        public wsInitTransactionOutput initTransaction(decimal amount, string buyOrder, string sessionId, string returnUrl, string finalUrl, PatPassInfo info)
        {
            var initTransactionInput = new wsInitTransactionInput
            {
                /** Indica el tipo de transacción, su valor debe ser siempre TR_NORMAL_WS_WPM */
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
                ufFlag = this.config.UfFlag
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
