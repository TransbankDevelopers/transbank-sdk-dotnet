using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/**
 * @author     Allware Ltda. (http://www.allware.cl)
 * @copyright  2015 Transbank S.A. (http://www.tranbank.cl)
 * @date       May 2016
 * @license    GNU LGPL
 * @version    2.0.1
 */

namespace Transbank.Webpay
{
    public class Configuration
    {

        private string environment;
        private string commerce_code;
        private string public_cert;
        private string webpay_cert;
        private string password;
        private Dictionary<string, string> store_codes;

        public Configuration(){

        }


        public string Environment
        {
            get
            {
                return this.environment;
            }
            set
            {
                this.environment = value;
            }
        }

        public string CommerceCode
        {
            get
            {
                return this.commerce_code;
            }
            set
            {
                this.commerce_code = value;
            }
        }

        public string PublicCert
        {
            get
            {
                return this.public_cert;
            }
            set
            {
                this.public_cert = value;
            }
        }

        public string WebpayCert
        {
            get
            {
                return this.webpay_cert;
            }
            set
            {
                this.webpay_cert = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public Dictionary<string, string> StoreCodes
        {
            get
            {
                return this.store_codes;
            }
            set
            {
                this.store_codes = value;
            }
        }

        public string getEnvironmentDefault() {
            string modo = this.environment;
            if (modo == null || modo == "") {
                modo = "INTEGRACION";
            }
        return modo;
        }

        public static Configuration ForTestingWebpayPlusNormal() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597020000540",
            Password = "",
            PublicCert = GetAssemblyTempFile("WebpayPlusCLP.pem"),
            WebpayCert = GetAssemblyTempFile("WebpayPlusCLP.pfx")
        };

        public static Configuration ForTestingWebpayOneClickNormal() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597020000547",
            Password = "transbank123",
            PublicCert = GetAssemblyTempFile("WebpayOneClickCLP.pem"),
            WebpayCert = GetAssemblyTempFile("WebpayOneClickCLP.pfx")
        };

        public static string GetAssemblyTempFile(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Transbank.Webpay.IntegrationCerts." + resource;
            var tempFile = Path.Combine(Path.GetTempPath(), resource);

            int bufferSize = 1024 * 1024;
            using (FileStream fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                var resourceFileStream = assembly.GetManifestResourceStream(resourceName);
                fileStream.SetLength(resourceFileStream.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];
                while ((bytesRead = resourceFileStream.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                }
            }
            return tempFile;
        }
    }



}
