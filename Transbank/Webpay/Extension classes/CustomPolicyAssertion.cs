using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Transbank.Webpay
{
    public class CustomPolicyAssertion : PolicyAssertion
    {
        private String issuerNameCertificate = null;
        Configuration config;

        public CustomPolicyAssertion(Configuration config) : base()
        {
            this.issuerNameCertificate = config.CommerceCode;
            this.config = config;
        }

        public override SoapFilter CreateClientInputFilter(FilterCreationContext context)
        {
            return new ClientInputFilter(this.config);
        }

        public override SoapFilter CreateClientOutputFilter(FilterCreationContext context)
        {
            return new ClientOutputFilter(this.issuerNameCertificate, this.config);
        }

        public override SoapFilter CreateServiceInputFilter(FilterCreationContext context)
        {
            return null;
        }

        public override SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
        {
            return null;
        }

        public override IEnumerable<KeyValuePair<string, Type>> GetExtensions()
        {
            return new KeyValuePair<string, Type>[] { new KeyValuePair<string, Type>("CustomPolicyAssertion", this.GetType()) };
        }

        public override void ReadXml(XmlReader reader, IDictionary<string, Type> extensions)
        {
            reader.ReadStartElement("CustomPolicyAssertion");
        }
    }
}
