using System;
using System.Collections.Generic;
using System.Text;

namespace Transbank.Onepay.Model
{
    public interface ISignable
    {
        string Signature { get; set; }
        string GetDataToSign();
    }
}
