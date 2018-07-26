using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.OnePay.Model
{
    public interface ISignable
    {
        string Signature { get; set; }
        string GetDataToSign();
    }
}
