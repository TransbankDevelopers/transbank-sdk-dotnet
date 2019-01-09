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
using Transbank.Webpay.Wsdl.Nullify;

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
    public class WebpayNullify
    {

        Configuration config;

        string WSDL;

        /** Configuración de URL según Ambiente */
        private static string wsdlUrl(string environment)
        {

            Dictionary<string, string> wsdl = new Dictionary<string, string>();
            wsdl.Add("INTEGRACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSCommerceIntegrationService?wsdl");
            wsdl.Add("CERTIFICACION", "https://webpay3gint.transbank.cl/WSWebpayTransaction/cxf/WSCommerceIntegrationService?wsdl");
            wsdl.Add("PRODUCCION", "https://webpay3g.transbank.cl/WSWebpayTransaction/cxf/WSCommerceIntegrationService?wsdl");

            return wsdl[environment];

        }

        public WebpayNullify(Configuration config)
        {

            /** Configuración para ser consultado desde cualquier metodo de la clase */
            this.config = config;

            /** Obtiene URL de WSDL según parametro desde Configuración (INTEGRACION, CERTIFICACION, PRODUCCION) */
            string url = this.config.getEnvironmentDefault();
            WSDL = wsdlUrl(url);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        }

        /* *
        * Permite solicitar a  Webpay la anulación de una transacción realizada previamente y que se encuentra vigente.
        * */
        public nullificationOutput nullify(string authorizationCode, decimal authorizedAmount, string buyOrder, decimal nullifyAmount, string commercecode)
        {

            nullificationInput nullificationInput = new nullificationInput();

            nullificationInput.authorizationCode = authorizationCode;
            nullificationInput.authorizedAmount = authorizedAmount;
            nullificationInput.buyOrder = buyOrder;

            if(commercecode == null){
                nullificationInput.commerceId = Int64.Parse(this.config.CommerceCode);
            } else {
                nullificationInput.commerceId = Int64.Parse(commercecode);
            }

            nullificationInput.nullifyAmount = nullifyAmount;

            using (WSCommerceIntegrationServiceImplService proxy = new WSCommerceIntegrationServiceImplService())
            {
                
                /*Define el ENDPOINT del Web Service Webpay*/
                proxy.Url = WSDL;

                Policy myPolicy = new Policy();
                myPolicy.Assertions.Add(new CustomPolicyAssertion(this.config));

                proxy.SetPolicy(myPolicy);
                proxy.Timeout = 60000;
                proxy.UseDefaultCredentials = false;

                nullificationOutput nullificationOutput = proxy.nullify(nullificationInput);
                return nullificationOutput;

            }

        }

    }
}
