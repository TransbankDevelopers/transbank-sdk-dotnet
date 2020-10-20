// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

using System;
using System.Text;
using Transbank.Onepay.Exceptions;

namespace Transbank.Onepay.Utils
{
    public static class HttpHelper
    {
        // The Set of accepted and valid Url characters per RFC3986. Characters outside of this set will be encoded.
        const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        public static string UrlEncode(string data, bool isPath = false)
        {

            var encoded = new StringBuilder(data.Length * 2);

            try
            {
                string unreservedChars = String.Concat(ValidUrlCharacters, (isPath ? "/:" : ""));

                foreach (char symbol in Encoding.UTF8.GetBytes(data))
                {
                    if (unreservedChars.IndexOf(symbol) != -1)
                        encoded.Append(symbol);
                    else
                        encoded.Append("%").Append(String.Format("{0:X2}", (int)symbol));
                }
            }
            catch (Exception e)
            {
                throw new HttpHelperException("Unable to encode URL", e);
            }
            return encoded.ToString();
        }
    }
}
