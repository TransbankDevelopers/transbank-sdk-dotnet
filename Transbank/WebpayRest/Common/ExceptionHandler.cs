using System;
using Transbank.Exceptions;

namespace Transbank.Webpay.Common
{
    internal static class ExceptionHandler
    {
        // These two methods should act the same, the difference is the return type.
        // This is needed because at the moment Inscription.delete returns void.

        internal static ReturnType Perform<ReturnType, ExceptionType>(Func<ReturnType> block)
            where ExceptionType : TransbankException
        {
            try
            {
                return block();
            }
            catch (Exception e)
            {
               throw RiseTransbankException<ExceptionType>(e);
            }
        }

        internal static void Perform<ExceptionType>(Action block)
            where ExceptionType : TransbankException
        {
            try
            {
                block();
            }
            catch (Exception e)
            {
                throw RiseTransbankException<ExceptionType>(e);
            }
        }

        private static ExceptionType RiseTransbankException<ExceptionType>(Exception e)
            where ExceptionType : TransbankException
        {
            int code = e.GetType().Equals(typeof(TransbankException)) ?
                ((TransbankException)e).Code : -1;

            return (ExceptionType)Activator.CreateInstance(
                typeof(ExceptionType), new object[] { code, e.Message, e });
        }
    }
}
