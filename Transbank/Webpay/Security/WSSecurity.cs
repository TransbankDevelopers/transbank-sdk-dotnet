using System;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Transbank.Webpay.Common;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Security;
using System.Security.Cryptography.Xml;
using System.Numerics;
using System.Globalization;

namespace Transbank.Webpay.Security
{
    public class WSSecurity : XmlWSSecurity
    {

        protected bool VerifierSigned(SoapEnvelope envelope, X509Certificate2 certificate, XmlNamespaceManager nsmanager)
        {
            String result = envelope.DocumentElement.InnerText != null ? envelope.DocumentElement.InnerText : "";
            try
            {
                XmlNode signature = envelope.DocumentElement.SelectSingleNode(Constants.DOMAIN_SIGNATURE, nsmanager);

                var signedXml = new XmlSignature(envelope.DocumentElement);
                signedXml.LoadXml(signature as XmlElement);

                return signedXml.CheckSignature(certificate, true);
            }
            catch (Exception)
            {
                throw new Exception(result);
            }
        }

        protected void InitializeEnvelope(SoapEnvelope soap)
        {
            soap.Header.RemoveAll();
            soap.DocumentElement.Attributes.RemoveAll();
            soap.DocumentElement.SetAttribute(Constants.NS_SOAP, Constants.ENVELOPE);
            soap.DocumentElement.SetAttribute(Constants.NS_SER, Constants.ENVELOPE_TRANSBANK);
        }

        protected void InitializeNameSpace(SoapEnvelope soap)
        {
            nsmanager = new XmlNamespaceManager(soap.NameTable);
            nsmanager.AddNamespace(Constants.SIGNATURE, Constants.XMLDSIG);
            nsmanager.AddNamespace(Constants.SOAP, Constants.ENVELOPE);
        }

        protected void InitializeSoapEnv(SoapEnvelope soap)
        {
            nsmanager = new XmlNamespaceManager(soap.NameTable);
            nsmanager.AddNamespace(Constants.SOAPENV, Constants.ENVELOPE);

            XmlElement body = soap.DocumentElement.SelectSingleNode(Constants.SOAPENV_BODY, nsmanager) as XmlElement;

            if (body == null)
            {
                throw new ApplicationException("No body tag found");
            }

            body.SetAttribute(Constants.ID, Constants.BODY);

        }

        protected void RemoveSecurity(SoapEnvelope soap)
        {
            var security = GetSecurity(soap);
            var header = GetEnvelopeHeader(soap, nsmanager);
            header.RemoveChild(security);
        }

        protected Reference GetReference()
        {
            Reference reference = new Reference();
            reference.Uri = Constants.URI_BODY;
            reference.AddTransform(new XmlDsigExcC14NTransform());

            return reference;
        }

        protected void CreateToken(SoapEnvelope soap, X509Certificate2 certificateSignature, XmlElement nodeKeyInfo)
        {
            SecurityTokenReference tokenRef = new SecurityTokenReference();
            XmlElement tokenXmlReference = tokenRef.GetXml(soap);

            var nodeX509Data = CreateNode(tokenXmlReference, Constants.DATA);

            var nodeX509IssuerSerial = CreateNode(nodeX509Data, Constants.ISSUER_SERIAL);

            nodeX509Data.AppendChild(nodeX509IssuerSerial);

            var nodeX509IssuerName = CreateNode(nodeX509IssuerSerial, Constants.ISSUER_NAME);
            nodeX509IssuerName.InnerText = certificateSignature.Issuer;

            var nodeX509SerialNumber = CreateNode(nodeX509IssuerSerial, Constants.SERIAL_NUMBER);
            nodeX509SerialNumber.InnerText = BigInteger.Parse("0" + certificateSignature.SerialNumber, NumberStyles.HexNumber).ToString();

            nodeX509IssuerSerial.AppendChild(nodeX509IssuerName);
            nodeX509IssuerSerial.AppendChild(nodeX509SerialNumber);

            tokenXmlReference.AppendChild(nodeX509Data);

            nodeKeyInfo.AppendChild(tokenXmlReference);
        }

        protected XmlNamespaceManager nsmanager = null;
        protected SoapEnvelope soap = null;
        protected X509Certificate2 certificateSignature = null;

    }
}
