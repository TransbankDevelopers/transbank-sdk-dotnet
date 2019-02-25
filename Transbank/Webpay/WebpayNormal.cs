using Transbank.Webpay.Wsdl.Normal;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace Transbank.Webpay
{

    /**
     * TRANSACCIÓN DE AUTORIZACIÓN NORMAL:
     * Una transacción de autorización normal (o transacción normal),corresponde a una solicitud de 
     * autorización financiera de un pago con tarjetas de crédito o débito, en donde quién realiza el pago
     * ingresa al sitio del comercio, selecciona productos o servicio, y el ingreso asociado a los datos de la
     * tarjeta de crédito o débito lo realiza en forma segura en Webpay
     * 
     *  Respuestas WebPay: 
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
     *  0  Transacción aprobada.
     *  -1 Rechazo de transacción.
     *  -2 Transacción debe reintentarse.
     *  -3 Error en transacción.
     *  -4 Rechazo de transacción.
     *  -5 Rechazo por error de tasa.
     *  -6 Excede cupo máximo mensual.
     *  -7 Excede límite diario por transacción.
     *  -8 Rubro no autorizado.
     * */

    public class WebpayNormal
    {


        protected internal Configuration config;

        protected internal string WSDL;


        /** Configuración de URL según Ambiente */
        protected internal static string wsdlUrl(string environment)
        {
            var wsdl = new Dictionary<string, string>
            {
                { "INTEGRACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" },
                { "CERTIFICACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" },
                { "PRODUCCION", "https://webpay3g.transbank.cl/WSWebpayTransaction/cxf/WSWebpayService?wsdl" }
            };
            return wsdl[environment];
        }

        public WebpayNormal(Configuration config)
        {
            /** Configuración para ser consultado desde cualquier metodo de la clase */
            this.config = config;

            /** Obtiene URL de WSDL según parametro desde Configuración (INTEGRACION, CERTIFICACION, PRODUCCION) */
            string url = this.config.GetEnvironmentDefault();
            WSDL = wsdlUrl(url);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        /**
         * Permite inicializar una transacción en Webpay. Como respuesta a la invocación se genera un token que representa en forma única una transacción.
         * 
         * */
        public wsInitTransactionOutput initTransaction(decimal amount, string buyOrder, string sessionId, string urlReturn, string urlFinal)
        {
            wsInitTransactionInput initTransaction = new wsInitTransactionInput();

            /** Indica el tipo de transacción, su valor debe ser siempre TR_NORMAL_WS */
            initTransaction.wSTransactionType = wsTransactionType.TR_NORMAL_WS;

            initTransaction.buyOrder = buyOrder;
            initTransaction.sessionId = sessionId;
            initTransaction.returnURL = urlReturn;
            initTransaction.finalURL = urlFinal;

            wsTransactionDetail details = new wsTransactionDetail();
            details.commerceCode = this.config.CommerceCode; ;
            details.buyOrder = buyOrder;
            details.amount = amount;

            wsTransactionDetail[] wsTransactionDetail = new wsTransactionDetail[] { details };

            initTransaction.transactionDetails = wsTransactionDetail;

            using (WSWebpayServiceImplService proxy = new WSWebpayServiceImplService())
            {
                PrepareProxy(proxy);
                wsInitTransactionOutput wsInitTransactionOutput = proxy.initTransaction(initTransaction);
                return wsInitTransactionOutput;
            }
        }

        /**
         * Permite obtener el resultado de la transacción una vez que 
         * Webpay ha resuelto su autorización financiera.
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
            using (WSWebpayServiceImplService proxy = new WSWebpayServiceImplService())
            {
                PrepareProxy(proxy);
                transactionResultOutput transactionResultOutput = proxy.getTransactionResult(token);
                acknowledgeTransaction(token); // Indica a Webpay que se ha recibido conforme el resultado de la transacción
                return transactionResultOutput;
            }
        }

        /**
         * Indica  a Webpay que se ha recibido conforme el resultado de la transacción
         * */
        public bool acknowledgeTransaction(string token)
        {
            using (WSWebpayServiceImplService proxy = new WSWebpayServiceImplService())
            {
                PrepareProxy(proxy);
                proxy.acknowledgeTransaction(token);
            }
            return true;
        }

        protected internal void PrepareProxy(WSWebpayServiceImplService proxy)
        {
            /*Define el ENDPOINT del Web Service Webpay*/
            proxy.Url = WSDL;

            Policy myPolicy = new Policy();
            myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

            proxy.SetPolicy(myPolicy);
            proxy.Timeout = 60000;
            proxy.UseDefaultCredentials = false;
        }
    }
}
