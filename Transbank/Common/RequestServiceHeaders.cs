using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Common
{
    public class RequestServiceHeaders
    {

        public string CommerceCodeHeader { get; set; }

        public string ApiKeyHeader { get; set; }

        public RequestServiceHeaders()
        {
            CommerceCodeHeader = "Tbk-Api-Key-Id";
            ApiKeyHeader = "Tbk-Api-Key-Secret";
        }

        public RequestServiceHeaders(string apiKeyHeader, string commerceCodeHeader)
        {
            CommerceCodeHeader = commerceCodeHeader;
            ApiKeyHeader = apiKeyHeader;
        }
    }
}
