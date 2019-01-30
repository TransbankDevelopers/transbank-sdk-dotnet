
using Transbank.Webpay.Security;
using Microsoft.Web.Services3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Transbank.Webpay
{
    public class ClientInputFilter : SoapFilter
    {

        Configuration config;

        public ClientInputFilter(Configuration config)
            : base()
        {
            this.config = config;
        }

        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {

            WSSecuritySignature<SoapEnvelope, X509Certificate2> signed = new WSSecuritySignature<SoapEnvelope, X509Certificate2>();

            X509Certificate2 certificate = new X509Certificate2(this.config.TbkPublicCertPath);

            if (signed.CheckSignature(envelope, certificate))
            {
                return SoapFilterResult.Continue;
            }

            return SoapFilterResult.Terminate;

        }
    }
}
