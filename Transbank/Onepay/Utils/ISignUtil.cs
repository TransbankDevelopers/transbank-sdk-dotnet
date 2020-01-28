// Class based in https://github.com/aws-samples/aws-iot-core-dotnet-app-mqtt-over-websockets-sigv4
// subsequently modified.

using Transbank.Onepay.Model;

namespace Transbank.Onepay.Utils
{
    public interface ISignUtil
    {
        void Sign(ISignable signable, string secret);
        bool Validate(ISignable signable, string secret);
    }
}
