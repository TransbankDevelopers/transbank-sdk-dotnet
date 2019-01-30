using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
        public string Environment { get; set; }
        public string CommerceCode { get; set; }
        public string PublicCert { get; set; }
        public string WebpayCert { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> StoreCodes { get; set; }

        public Configuration(){}

        public string getEnvironmentDefault() {
            string modo = Environment;
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

        public static Configuration ForTestingWebpayPlusCapture() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597020000546",
            Password = "transbank123",
            PublicCert = GetAssemblyTempFile("WebpayPlusCaptureCLP.pem"),
            WebpayCert = GetAssemblyTempFile("WebpayPlusCaptureCLP.pfx")
        };

        public static Configuration ForTestingWebpayPlusMall() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597020000542",
            Password = "transbank123",
            PublicCert = GetAssemblyTempFile("WebpayPlusMallCLP.pem"),
            WebpayCert = GetAssemblyTempFile("WebpayPlusMallCLP.pfx")
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
