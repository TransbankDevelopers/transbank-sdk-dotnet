using System;

namespace Transbank.Exceptions
{
    public class InvalidAmountException : TransbankException
    {
        public const string DEFAULT_MESSAGE = "Invalid amount given.";
        public const string HAS_DECIMALS_MESSAGE = "Given amount has decimals. Webpay only accepts integer amounts. Please remove decimal places.";
        public InvalidAmountException() : this(DEFAULT_MESSAGE)
        {
        }

        public InvalidAmountException(string message)
            : base(-1, message)
        {
        }

        public InvalidAmountException(int code, string message)
            : base(code, message)
        {
        }

        public InvalidAmountException(int code, string message,
            Exception innerException) : base(code, message, innerException)
        {
        }
    }
}
