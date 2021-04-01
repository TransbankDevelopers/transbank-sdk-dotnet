using System;
using Transbank.Common;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    [Obsolete("Use MallInscription instead", false)]
    public static class Inscription
    {
        public static StartResponse Start(string userName, string email, string responseUrl)
        {
            return (StartResponse)MallInscription.Start(userName, email, responseUrl);
        }

        public static StartResponse Start(string userName, string email,
            string responseUrl, Options options)
        {
            return (StartResponse)MallInscription.Start(userName, email, responseUrl, options);
        }

        public static FinishResponse Finish(string token)
        {
            return (FinishResponse)MallInscription.Finish(token);
        }

        public static FinishResponse Finish(string token, Options options)
        {
            return (FinishResponse)MallInscription.Finish(token, options);
        }

        public static void Delete(string userName, string tbkUser)
        {
            MallInscription.Delete(userName, tbkUser);
        }

        public static void Delete(string userName, string tbkUser, Options options)
        {
            MallInscription.Delete(userName, tbkUser, options);
        }
    }
}
