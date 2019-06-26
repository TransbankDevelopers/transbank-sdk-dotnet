using System;
using System.Net.Http;
using Newtonsoft.Json;
namespace Transbank.Webpay.Common
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        private readonly string _endpoint;
        [JsonIgnore]
        public string Endpoint { get { return _endpoint; } }
        [JsonIgnore]
        private readonly HttpMethod _method;
        [JsonIgnore]
        public HttpMethod Method { get { return _method; } }

        protected BaseRequest(string endpoint, HttpMethod method)
        {
            if (String.IsNullOrEmpty(endpoint))
                throw new ArgumentNullException(
                    nameof(endpoint), "Endpoint can't be null.");

            _endpoint = endpoint;

            _method = method ?? throw new ArgumentNullException(
                    nameof(method), "Method can't be null.");
        }
    }
}
