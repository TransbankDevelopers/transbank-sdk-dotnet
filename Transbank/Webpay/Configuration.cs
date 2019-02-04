using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Transbank.Webpay
{
    public class Configuration
    {
        public string Environment { get; set; } = "INTEGRACION";
        public string CommerceCode { get; set; }
        public string WebpayCertPath { get; set; }
        public string PrivateCertPfxPath { get; set; }
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
            WebpayCertPath = GetTestingPublicCertPath(),
            PrivateCertPfxPath = GetAssemblyTempFilePath("WebpayPlusCLP.p12")
        };

        public static Configuration ForTestingWebpayOneClickNormal() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597044444405",
            Password = "12345678",
            WebpayCertPath = GetTestingPublicCertPath(),
            PrivateCertPfxPath = GetAssemblyTempFilePath("WebpayOneClickCLP.p12")
        };

        public static Configuration ForTestingWebpayPlusCapture() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597044444404",
            Password = "12345678",
            WebpayCertPath = GetTestingPublicCertPath(),
            PrivateCertPfxPath = GetAssemblyTempFilePath("WebpayPlusCaptureCLP.p12")
        };

        public static Configuration ForTestingWebpayPlusMall() => new Configuration
        {
            Environment = "INTEGRACION",
            CommerceCode = "597044444401",
            Password = "12345678",
            WebpayCertPath = GetTestingPublicCertPath(),
            PrivateCertPfxPath = GetAssemblyTempFilePath("WebpayPlusMallCLP.p12"),
            StoreCodes = new Dictionary<string, string>
            {
                {"Tienda1", "597044444402" },
                {"Tienda2", "597044444403" }
            }
        };

        public static string GetTestingPublicCertPath()
        {
            return GetAssemblyTempFilePath("TransbankIntegrationPublic.pem");
        }

        public static string GetProductionPublicCertPath()
        {
            return GetAssemblyTempFilePath("TransbankProductionPublic.pem");
        }

        public static string GetAssemblyTempFilePath(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Transbank.Webpay.Certs." + resource;
            var tempFile = Path.Combine(Path.GetTempPath(), resource);

            int bufferSize = 1024 * 1024;
            using (var fileStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
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
