using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Model
{
   public class Options
    {
        public Options()
        {
            ApiKey = Options.getDefaults().ApiKey;
            SharedSecret = Options.getDefaults().SharedSecret;
        }
        public Options(string apiKey, string sharedSecret)
        {
            ApiKey = apiKey;
            SharedSecret = sharedSecret;
        }

        public string ApiKey { get; set; }
        public string SharedSecret { set; get; }

        public override string ToString()
        {
            return $"ApiKey={ApiKey}, SharedSecret={SharedSecret}";
        }

        public static Options getDefaults()
        {
            return new Options(OnePay.ApiKey, OnePay.SharedSecret);
        }
    }
}
