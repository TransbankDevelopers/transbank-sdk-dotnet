using System;
using System.Xml;
using System.Security.Cryptography.Xml;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Security
{
    public sealed class XmlSignature : SignedXml
    {
        public XmlSignature(XmlElement element)
            : base(element)
        {
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            XmlElement idElem = base.GetIdElement(document, idValue);

            if (idElem == null)
            {
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(document.NameTable);
                nsmanager.AddNamespace(Constants.WSU, Constants.WSSECURITY_UTILITY);

                idElem = (XmlElement)document.SelectSingleNode(String.Format(Constants.WSU_ID, idValue), nsmanager);

                if (idElem == null)
                {
                    throw new Exception("Soap Message Not Exits Body Element");
                }
            }

            return idElem;
        }

    }
}
