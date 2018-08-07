using System;


namespace Transbank.Onepay.Exceptions
{
    public class AmountException : TransbankException
    {
        public AmountException() : base()
        {
        }

        public AmountException(string message) 
            : base(-1, message)
        {
        }

        public AmountException(string message, Exception innerException) 
            : base(-1, message, innerException)
        {
        }
    }
}
