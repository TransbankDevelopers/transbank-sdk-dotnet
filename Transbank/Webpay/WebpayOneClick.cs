using Microsoft.Web.Services3.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Transbank.Webpay.Wsdl.OneClick;

/**
  * @brief      Ecommerce Plugin for chilean Webpay
  * @category   Plugins/SDK
  * @author     Allware Ltda. (http://www.allware.cl)
  * @copyright  2015 Transbank S.A. (http://www.tranbank.cl)
  * @date       Jan 2015
  * @license    GNU LGPL
  * @version    2.0.1
  * @link       http://transbankdevelopers.cl/
  *
  * This software was created for easy integration of ecommerce
  * portals with Transbank Webpay solution.
  *
  * Required:
  *  - .NET Framework 4.5
  *
  * See documentation and how to install at link site
  *
  * */

namespace Transbank.Webpay
{
    public class WebpayOneClick
    {

        Configuration config;

        string WSDL;

        /** Configuración de URL según Ambiente */
        private static string wsdlUrl(string environment)
        {

            Dictionary<string, string> wsdl = new Dictionary<string, string>();
            wsdl.Add("INTEGRACION", "https://webpay3gint.transbank.cl/webpayserver/wswebpay/OneClickPaymentService?wsdl");
            wsdl.Add("CERTIFICACION", "https://webpay3gint.transbank.cl/webpayserver/wswebpay/OneClickPaymentService?wsdl");
            wsdl.Add("PRODUCCION", "https://webpay3g.transbank.cl/webpayserver/wswebpay/OneClickPaymentService?wsdl");

            return wsdl[environment];

        }


        public WebpayOneClick(Configuration config)
        {

            /** Configuración para ser consultado desde cualquier metodo de la clase */
            this.config = config;

            /** Obtiene URL de WSDL según parametro desde Configuración (INTEGRACION, CERTIFICACION, PRODUCCION) */
            string url = this.config.getEnvironmentDefault();
            WSDL = wsdlUrl(url);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        }

        /* *
         * Permite realizar la inscripción del tarjetahabiente e información de su tarjeta de crédito
         * */
        public oneClickInscriptionOutput initInscription(string username, string email, string urlReturn)
        {

            oneClickInscriptionInput oneClickInscriptionInput = new oneClickInscriptionInput();

            oneClickInscriptionInput.username = username;
            oneClickInscriptionInput.email = email;
            oneClickInscriptionInput.responseURL = urlReturn;

            using (OneClickPaymentServiceImplService proxy = new OneClickPaymentServiceImplService())
            {

                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                oneClickInscriptionOutput oneClickInscriptionOutput = proxy.initInscription(oneClickInscriptionInput);
                return oneClickInscriptionOutput;

            }

        }

        /* *
         * Permite finalizar el proceso de inscripción del tarjetahabiente en Oneclick
         * */
        public oneClickFinishInscriptionOutput finishInscription(string token)
        {

            oneClickFinishInscriptionInput oneClickFinishInscriptionInput = new oneClickFinishInscriptionInput();

            oneClickFinishInscriptionInput.token = token;

            using (OneClickPaymentServiceImplService proxy = new OneClickPaymentServiceImplService())
            {

                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                oneClickFinishInscriptionOutput oneClickFinishInscriptionOutput = proxy.finishInscription(oneClickFinishInscriptionInput);
                return oneClickFinishInscriptionOutput;

            }

        }

        /* *
        * Permite  realizar  transacciones  de  pago
        * */
        public oneClickPayOutput authorize(string buyOrder, string tbkUser, string username, string amount)
        {

            oneClickPayInput oneClickPayInput = new oneClickPayInput();

            oneClickPayInput.buyOrder = Convert.ToInt64(buyOrder);
            oneClickPayInput.tbkUser  = tbkUser;
            oneClickPayInput.username = username;
            oneClickPayInput.amount   = decimal.Parse(amount);
            oneClickPayInput.amountSpecified = true;
            oneClickPayInput.buyOrderSpecified = true;

            using (OneClickPaymentServiceImplService proxy = new OneClickPaymentServiceImplService())
            {

                /*Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                oneClickPayOutput oneClickPayOutput = proxy.authorize(oneClickPayInput);
                return oneClickPayOutput;

            }
        }

        /* *
        * Permite reversar una transacción de venta autorizada con anterioridad
        * */
        public oneClickReverseOutput reverseTransaction(string buyOrder)
        {

            oneClickReverseInput oneClickReverseInput = new oneClickReverseInput();

            oneClickReverseInput.buyorder = Int64.Parse(buyOrder);
            oneClickReverseInput.buyorderSpecified = true;

            using (OneClickPaymentServiceImplService proxy = new OneClickPaymentServiceImplService())
            {

                /*Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                oneClickReverseOutput oneClickReverseOutput = proxy.codeReverseOneClick(oneClickReverseInput);
                return oneClickReverseOutput;

            }

        }

        public bool RemoveUser(string tbkUser, string username)
        {
            return oneClickremoveUserOutput(tbkUser, username);
        }

        /* *
        * Permite eliminar la inscripción de un usuario en Webpay OneClick
        * */
        public bool oneClickremoveUserOutput(string tbkUser, string username)
        {

            oneClickRemoveUserInput oneClickRemoveUserInput  = new oneClickRemoveUserInput();

            oneClickRemoveUserInput.tbkUser = tbkUser;
            oneClickRemoveUserInput.username = username;

            using (OneClickPaymentServiceImplService proxy = new OneClickPaymentServiceImplService())
            {

                /*Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                return proxy.removeUser(oneClickRemoveUserInput);

            }

        }

    }

}


