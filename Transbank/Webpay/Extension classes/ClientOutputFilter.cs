
using Transbank.Webpay.Security;
using Microsoft.Web.Services3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Transbank.Webpay
{
    public class ClientOutputFilter : SoapFilter
    {

        private String issuerNameCertificate = null;
        Configuration config;

        public ClientOutputFilter(String issuerNameCertificate, Configuration config)
            : base()
        {
            this.issuerNameCertificate = issuerNameCertificate;
            this.config = config;
        }

        public override SoapFilterResult ProcessMessage(SoapEnvelope envelope)
        {

            WSSecuritySignature<SoapEnvelope, X509Certificate2> signed = new WSSecuritySignature<SoapEnvelope, X509Certificate2>();

            X509Certificate2 certificate = new X509Certificate2(this.config.CommercePfxPath, this.config.Password, X509KeyStorageFlags.MachineKeySet);


            signed.Signature(envelope, certificate);
            return SoapFilterResult.Continue;
        }
    }
}
