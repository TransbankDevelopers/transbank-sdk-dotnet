using Transbank.Onepay.Model;

namespace Transbank.Onepay.Utils
{
    public interface ISignUtil
    {
        void Sign(ISignable signable, string secret);
        bool Validate(ISignable signable, string secret);
    }
}
