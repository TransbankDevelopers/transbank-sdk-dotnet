using System;

namespace Transbank.Exceptions
{
    public class InscriptionDeleteException : TransbankException
    {
        public InscriptionDeleteException() : base()
        {
        }

        public InscriptionDeleteException(string message)
            : base(-1, message)
        {
        }

        public InscriptionDeleteException(int code, string message)
            : base(code, message)
        {
        }

        public InscriptionDeleteException(int code, string message,
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
