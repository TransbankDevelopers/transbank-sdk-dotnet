using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Model
{
   public  class Options
    {
        public Options()
        {
            ApiKey = Options.getDefaults().ApiKey;
            AppKey = Options.getDefaults().AppKey;
            SharedSecret = Options.getDefaults().SharedSecret;
        }
        public Options(string apiKey, string appKey, string sharedSecret)
        {
            ApiKey = apiKey;
            AppKey = appKey;
            SharedSecret = sharedSecret;
        }

        public string ApiKey { get; set; }
        public string AppKey { get; set; }
        public string SharedSecret { set; get; }

        public override string ToString()
        {
            return $"ApiKey={ApiKey}, AppKey={AppKey}, SharedSecret={SharedSecret}";
        }

        public static Options getDefaults()
        {
            return new Options(OnePay.ApiKey, OnePay.AppKey, OnePay.SharedSecret);
        }
    }
}
