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

        public XmlSignature(XmlDocument xml) : base(xml)
        {
        }

        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            XmlElement idElem = base.GetIdElement(document, idValue);

            if (idElem == null)
            {
                XmlNamespaceManager nsmanager = new XmlNamespaceManager(document.NameTable);
                nsmanager.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");

                idElem = (XmlElement)document.SelectSingleNode("//*[@wsu:Id=\"" + idValue + "\"]", nsmanager) as XmlElement;

                if (idElem == null)
                {
                    throw new Exception("Soap Message Not Exits Body Element");
                }
            }

            return idElem;
        }

    }
}
