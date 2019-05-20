using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transbank.Webpay.Common
{
    public class Constants
    {
        public static String XMLDSIG = "http://www.w3.org/2000/09/xmldsig#";
        public static String ENVELOPE = "http://schemas.xmlsoap.org/soap/envelope/";
        public static String WSSECURITY_SECEXT = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        public static String WSSECURITY_UTILITY = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        public static String ENVELOPE_TRANSBANK = "http://service.wswebpay.webpay.transbank.com/";

        public static String SOAP = "soap";
        public static String SIGNATURE = "ds";
        public static String URI_BODY = "#Body";
        public static String BODY = "Body";
        public static String SECURITY = "Security";
        public static String WSSE = "wsse";
        public static String NS_WEBSERVICE_UTILITY = "xmlns:wsu";
        public static String ID = "Id";
        public static String SOAPENV = "soapenv";
        public static String NS_SOAP = "xmlns:soap";
        public static String NS_SER = "xmlns:ser";
        public static String SOAPENV_BODY = @"//soapenv:Body";
        public static String DOMAIN_SIGNATURE = "//ds:Signature";
        public static String WSU = "wsu";
        public static String WSU_ID = "//*[@wsu:Id='{0}']";

        public static String DATA = "X509Data";
        public static String ISSUER_SERIAL = "X509IssuerSerial";
        public static String ISSUER_NAME = "X509IssuerName";
        public static String SERIAL_NUMBER = "X509SerialNumber";
        public static String ENVELOPE_SOAP_HEADER = "/soap:Envelope/soap:Header";

    }
}
