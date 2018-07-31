using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Onepay.Model
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
            get =>  new Options(Onepay.ApiKey, Onepay.SharedSecret);
        }

        public static Options Build(Options options)
        {
            if (options == null) return Options.Default;

            if (options.ApiKey == null) options.ApiKey = Onepay.ApiKey;
            if (options.SharedSecret == null) options.SharedSecret = Onepay.SharedSecret;

            return options;
        }
    }
}
