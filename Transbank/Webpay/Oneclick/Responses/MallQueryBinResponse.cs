using System;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Responses
{
    public class MallQueryBinResponse : BaseResponse
    {
        [JsonProperty("bin_issuer")]
        public string BinIssuer { get; set; }

        [JsonProperty("bin_payment_type")]
        public string BinPaymentType { get; set; }

        [JsonProperty("bin_brand")]
        public string BinBrand { get; set; }

        public override string ToString()
        {
            return $"\"BinIssuer\": \"{BinIssuer}\"\n" +
                   $"\"BinPaymentType\": \"{BinPaymentType}\"\n" +
                   $"\"BinBrand\": \"{BinBrand}\"\n";
        }
    }
}
