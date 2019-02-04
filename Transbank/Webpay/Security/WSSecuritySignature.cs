
using Transbank.Webpay.Common;
using Microsoft.Web.Services3;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Transbank.Webpay.Security
{
    public sealed class WSSecuritySignature<S, C> : WSSecurity
    {
        public WSSecuritySignature()
            : base()
        {

        }

        public bool CheckSignature(S envelope, C certificate)
        {
            SoapEnvelope soap = null;
            X509Certificate2 certificateSignature = null;

            try
            {
                if (envelope == null)
                {
                    throw new Exception("Envelope message soap is null.");
                }

                if (certificate == null)
                {
                    throw new Exception("Certificate security is null.");
                }

                soap = envelope as SoapEnvelope;
                certificateSignature = certificate as X509Certificate2;

                if (certificateSignature == null)
                {
                    throw new Exception("Certificate security not is X509.");
                }

                InitializeNameSpace(soap);

                if (VerifierSigned(soap, certificateSignature, nsmanager))
                {
                    RemoveSecurity(soap);
                }
                else
                {
                    throw new Exception("CheckSignature not Validate.");
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Signature(S envelope, C certificate)
        {
            soap = null;
            certificateSignature = null;

            soap = envelope as SoapEnvelope;
            certificateSignature = certificate as X509Certificate2;

            InitializeEnvelope(soap);

            XmlElement nodeSecurity = (XmlElement)soap.CreateNode(XmlNodeType.Element, Constants.WSSE, Constants.SECURITY, Constants.WSSECURITY_SECEXT);

            nodeSecurity.SetAttribute(Constants.NS_WEBSERVICE_UTILITY, Constants.WSSECURITY_UTILITY);

            soap.Header.AppendChild(nodeSecurity);

            soap.Header.AppendChild(nodeSecurity);

            InitializeSoapEnv(soap);

            SignedXml signedXml = new SignedXml(soap);

            KeyInfo keyInfo = new KeyInfo();
            signedXml.SigningKey = certificateSignature.PrivateKey;
            KeyInfoX509Data keyInfoData = new KeyInfoX509Data();
            keyInfoData.AddIssuerSerial(certificateSignature.Issuer, certificateSignature.GetSerialNumberString());
            keyInfo.AddClause(keyInfoData);
            signedXml.KeyInfo = keyInfo;

            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;

            signedXml.AddReference(GetReference());
            signedXml.ComputeSignature();

            var signedElement = signedXml.GetXml();

            nodeSecurity.AppendChild(signedElement);

            CreateToken(soap, certificateSignature, (XmlElement)signedElement.ChildNodes[2]);

        }

    }
}
