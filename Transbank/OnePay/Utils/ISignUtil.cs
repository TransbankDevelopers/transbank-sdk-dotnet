using System;
using System.Collections.Generic;
using System.Text;
using Transbank.OnePay.Model;

namespace Transbank.OnePay.Utils
{
    public interface ISignUtil
    {
        void Sign(ISignable signable, string secret);
        bool Validate(ISignable signable, string secret);
    }
}
