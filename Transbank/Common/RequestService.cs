using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Transbank.Exceptions;
using System.Collections.Generic;

namespace Transbank.Common
{
    public class RequestService
    {
        private static HttpClient _staticHttpClient;
        private HttpClient _httpClient;
        private static readonly string CONTENT_TYPE = "application/json";
        public RequestService(HttpClient httpClient = null) { _httpClient = httpClient;  }
        private HttpClient GetHttpClient(int requestTimeoutInSeconds)
        {
            if (_httpClient != null)
                return _httpClient;
            if (_staticHttpClient == null)
                _staticHttpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(requestTimeoutInSeconds)
                };
            return _staticHttpClient;
           
        }
        private static void AddRequiredHeaders(HttpRequestMessage request, string commerceCode, string apiKey, RequestServiceHeaders headers)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));
            request.Headers.Add(headers.CommerceCodeHeader, commerceCode);
            request.Headers.Add(headers.ApiKeyHeader, apiKey);
        }
        private static HttpRequestMessage CreateHttpRequestMessage(BaseRequest request, String jsonRequest, Options options, RequestServiceHeaders requestServiceHeaders)
        {
            var message = new HttpRequestMessage(request.Method, new Uri(options.IntegrationType.ApiBase + request.Endpoint));
            if (request.Method != HttpMethod.Get)
                message.Content = new StringContent(jsonRequest, Encoding.UTF8, CONTENT_TYPE);
            AddRequiredHeaders(message, options.CommerceCode, options.ApiKey, requestServiceHeaders);
            return message;
        }
        private string Perform<T>(HttpRequestMessage message, int requestTimeoutInSeconds) where T : TransbankException
        {
            var client = GetHttpClient(requestTimeoutInSeconds);
            var response = client.SendAsync(message).ConfigureAwait(false)
                .GetAwaiter().GetResult();
            var jsonResponse = response.Content.ReadAsStringAsync()
                .ConfigureAwait(false).GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                String errorMessage = "";
                var jsonObject = (JObject)JsonConvert.DeserializeObject(jsonResponse);
                if (jsonObject != null && jsonObject.ContainsKey("error_message")){
                    errorMessage = $"Error message: {jsonObject.Value<string>("error_message")}";
                }
                else if (jsonObject != null && jsonObject.ContainsKey("description")){
                    errorMessage = $"Error message: {jsonObject.Value<string>("code")} - {jsonObject.Value<string>("description")}";
                }
                else{
                    errorMessage = $"Error message: {jsonResponse}";
                }
                throw (T)Activator.CreateInstance(typeof(T), new object[] {
                    (int)response.StatusCode, errorMessage
                });
            }
            return jsonResponse;
        }
        public ReturnType Perform<ReturnType, ExceptionType>(BaseRequest request, Options options)
            where ExceptionType : TransbankException
            where ReturnType : BaseResponse
        {
            // Call perform with default headers
            return Perform<ReturnType, ExceptionType>(request, options, new RequestServiceHeaders());
        }

        public ReturnType Perform<ReturnType, ExceptionType>(BaseRequest request, Options options, RequestServiceHeaders requestServiceHeaders) 
            where ExceptionType : TransbankException
            where ReturnType : BaseResponse
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var resp = Perform<ExceptionType>(CreateHttpRequestMessage(request, jsonRequest, options, requestServiceHeaders), options.Timeout);
            var result = JsonConvert.DeserializeObject<ReturnType>(String.IsNullOrWhiteSpace(resp) ? "{}" : resp );
            result.OriginalRequest = jsonRequest;
            result.OriginalResponse = resp;
            return result;
        }
        public List<ReturnType> PerformToList<ReturnType, ExceptionType>(BaseRequest request, Options options)
            where ExceptionType : TransbankException
            where ReturnType : BaseResponse
        {
            // Call perform with default headers
            return PerformToList<ReturnType, ExceptionType>(request, options, new RequestServiceHeaders());
        }
        public List<ReturnType> PerformToList<ReturnType, ExceptionType>(BaseRequest request, Options options, RequestServiceHeaders requestServiceHeaders)
            where ExceptionType : TransbankException
            where ReturnType : BaseResponse
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var resp = Perform<ExceptionType>(CreateHttpRequestMessage(request, jsonRequest, options, requestServiceHeaders), options.Timeout);
            return JsonConvert.DeserializeObject<List<ReturnType>>(String.IsNullOrWhiteSpace(resp) ? "[]" : resp);
        }

    }
}
