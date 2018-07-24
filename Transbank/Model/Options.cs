using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Model
{
   public class Options
    {
        public Options()
        {
            ApiKey = Options.Default.ApiKey;
            SharedSecret = Options.Default.SharedSecret;
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

        public static Options Default
        {
            get =>  new Options(OnePay.ApiKey, OnePay.SharedSecret);
        }

        public static Options build(Options options)
        {
            if (options == null) return Options.Default;

            if (options.ApiKey == null) options.ApiKey = OnePay.ApiKey;
            if (options.SharedSecret == null) options.SharedSecret = OnePay.SharedSecret;

            return options;
        }
    }
}
