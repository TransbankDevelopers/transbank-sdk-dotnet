using System;

namespace Transbank.Exceptions
{
    public class InscriptionStartException : TransbankException
    {
        public InscriptionStartException(string message) : base(-1, message) { }

        public InscriptionStartException(int code, string message) : base(code, message) { }
        
        public InscriptionStartException(int code, string message, Exception innerException) : base(code, message, innerException) { }
    }
}
