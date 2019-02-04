using System;
using System.Xml;
using Microsoft.Web.Services3;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Security
{
    public class XmlWSSecurity
    {

        protected XmlNode GetSecurity(SoapEnvelope soap)
        {
            return (XmlNode)soap.DocumentElement.GetElementsByTagName(Constants.SECURITY, Constants.WSSECURITY_SECEXT)[0];
        }

        protected XmlElement GetEnvelopeHeader(SoapEnvelope soap, XmlNamespaceManager nsmanager)
        {
            return (XmlElement)soap.DocumentElement.SelectNodes(Constants.ENVELOPE_SOAP_HEADER, nsmanager)[0];
        }

        protected XmlNode CreateNode(XmlElement element, String data)
        {
            return element.OwnerDocument.CreateNode(XmlNodeType.Element, Constants.SIGNATURE, data, Constants.XMLDSIG);
        }

        protected XmlNode CreateNode(XmlNode node, String data)
        {
            return node.OwnerDocument.CreateNode(XmlNodeType.Element, Constants.SIGNATURE, data, Constants.XMLDSIG);
        }

    }
}
