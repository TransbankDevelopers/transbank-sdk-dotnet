using System;

namespace Transbank.Exceptions
{
    public class InscriptionStatusException : TransbankException
    {
        public InscriptionStatusException(string message) : base(-1, message){ }

        public InscriptionStatusException(int code, string message) : base(code, message){}

        public InscriptionStatusException(int code, string message, Exception innerException) : base(code, message,
            innerException){}
    }
}
