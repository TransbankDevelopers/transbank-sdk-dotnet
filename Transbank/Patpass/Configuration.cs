﻿namespace Transbank.PatPass
{
    public class Configuration : Webpay.Configuration
    {
        public string CommerceMail { get; set; }
        public bool UfFlag { get; set; }

        public static Configuration ForTestingPatPassByWebpayNormal() => new Configuration
        {
            CommerceCode = "597044444432",
            CommerceMail = "user@domain.com",
            WebpayCertPath = GetTestingPublicCertPath(),
            PrivateCertPfxPath = GetAssemblyTempFilePath("PatPassNormalCLP.p12"),
            Password = "12345678",
            UfFlag = false
        };
    }
}
