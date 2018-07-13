using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace OnePay.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
     public enum IntegrationType
    {
        [EnumMember(Value = "")]
        LIVE,

        [EnumMember(Value = "https://web2desa.test.transbank.cl")]
        TEST,
    }
}
