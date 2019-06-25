using System;
using Newtonsoft.Json;
namespace Transbank.Webpay.Common
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        private readonly string _endpoint;
        [JsonIgnore]
        public string Endpoint { get { return _endpoint; } }

        protected BaseRequest(string endpoint)
        {
            if (String.IsNullOrEmpty(endpoint))
                throw new ArgumentNullException(
                    nameof(endpoint), "Endpoint can't be null.");

            _endpoint = endpoint;
        }
    }
}
