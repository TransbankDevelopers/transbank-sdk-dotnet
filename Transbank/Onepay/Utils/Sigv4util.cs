// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

using System;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using Transbank.Onepay.Exceptions;
using Transbank.Onepay.Model;

namespace Transbank.Onepay.Utils
{
    public static class Sigv4util
    {
        public const string ISO8601BasicFormat = "yyyyMMddTHHmmssZ";
        public const string DateStringFormat = "yyyyMMdd";
        public const string EmptyBodySha256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";
        public static HashAlgorithm CanonicalRequestHashAlgorithm = HashAlgorithm.Create("SHA-256");
        public const string HmacSha256 = "HMACSHA256";
        public const string XAmzSignature = "X-Amz-Signature";

        private static byte[] HmacSHA256(String data, byte[] key)
        {
            var algorithm = "HmacSHA256";
            var keyHashAlgorithm = KeyedHashAlgorithm.Create(algorithm);
            keyHashAlgorithm.Key = key;

            return keyHashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        private static byte[] ComputeKeyedHash(string algorithm, byte[] key, byte[] data)
        {
            var kha = KeyedHashAlgorithm.Create(algorithm);
            kha.Key = key;
            return kha.ComputeHash(data);
        }

        public static string ToHexString(byte[] data, bool lowerCase)
        {
            var stringBuilder = new StringBuilder();

            try
            {
                for (var i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString(lowerCase ? "x2" : "X2"));
                }

            }
            catch (Exception e)
            {
                throw new Sigv4UtilException("Unable to convert data to hex string", e);
            }
            return stringBuilder.ToString();
        }

        private static byte[] getSignatureKey(String key, String dateStamp, String regionName, String serviceName)
        {
            byte[] kSecret = Encoding.UTF8.GetBytes(("AWS4" + key).ToCharArray());
            byte[] kDate = HmacSHA256(dateStamp, kSecret);
            byte[] kRegion = HmacSHA256(regionName, kDate);
            byte[] kService = HmacSHA256(serviceName, kRegion);
            byte[] kSigning = HmacSHA256("aws4_request", kService);

            return kSigning;
        }

        public static string getSignedurl(WebsocketCredentials credentials)
        {
            string requestUrl;
            try
            {

                var requestDateTime = DateTime.UtcNow;
                string datetime = requestDateTime.ToString(ISO8601BasicFormat, CultureInfo.InvariantCulture);
                var date = requestDateTime.ToString(DateStringFormat, CultureInfo.InvariantCulture);

                string method = "GET";
                string protocol = "wss";
                string uri = "/mqtt";
                string service = "iotdevicegateway";
                string algorithm = "AWS4-HMAC-SHA256";

                string credentialScope = date + "/" + credentials.region + "/" + service + "/" + "aws4_request";
                string canonicalQuerystring = "X-Amz-Algorithm=" + algorithm;
                canonicalQuerystring += "&X-Amz-Credential=" + HttpHelper.UrlEncode(credentials.accessKey + '/' + credentialScope);

                canonicalQuerystring += "&X-Amz-Date=" + datetime;
                canonicalQuerystring += "&X-Amz-Expires=86400";
                canonicalQuerystring += "&X-Amz-SignedHeaders=host";

                string canonicalHeaders = "host:" + credentials.iotEndpoint + "\n";

                var canonicalRequest = method + "\n" + uri + "\n" + canonicalQuerystring + "\n" + canonicalHeaders + "\n" + "host" + "\n" + EmptyBodySha256;

                byte[] hashValueCanonicalRequest = CanonicalRequestHashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(canonicalRequest));

                var builder = new StringBuilder();

                for (int i = 0; i < hashValueCanonicalRequest.Length; i++)
                {
                    builder.Append(hashValueCanonicalRequest[i].ToString("x2"));
                }

                string byteString = builder.ToString();

                var stringToSign = algorithm + "\n" + datetime + "\n" + credentialScope + "\n" + byteString;

                // compute the signing key
                var keyedHashAlgorithm = KeyedHashAlgorithm.Create(HmacSha256);

                keyedHashAlgorithm.Key = getSignatureKey(credentials.secretKey, date, credentials.region, service);

                var signingKey = keyedHashAlgorithm.Key;

                var signature = ComputeKeyedHash(HmacSha256, signingKey, Encoding.UTF8.GetBytes(stringToSign));
                var signatureString = ToHexString(signature, true);

                canonicalQuerystring += "&X-Amz-Signature=" + signatureString;
                canonicalQuerystring += "&X-Amz-Security-Token=" + HttpHelper.UrlEncode(credentials.sessionToken);

                requestUrl = protocol + "://" + credentials.iotEndpoint + uri + "?" + canonicalQuerystring;
            }

            catch (Exception e)
            {
                throw new Sigv4UtilException("Unable to get signed url", e);
            }


            return requestUrl;
        }
    }
}
