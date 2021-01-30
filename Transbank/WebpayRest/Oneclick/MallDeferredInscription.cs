using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class MallDeferredInscription
    {
        public static RequestServiceHeaders Headers
        {
            get => MallDeferredTransaction.Headers;
            set => MallDeferredTransaction.Headers = value;
        }

        public static string CommerceCode
        {
            get => MallDeferredTransaction.CommerceCode;
            set => MallDeferredTransaction.CommerceCode = value;
        }

        public static string ApiKey
        {
            get => MallDeferredTransaction.ApiKey;
            set => MallDeferredTransaction.ApiKey = value;
        }

        public static WebpayIntegrationType IntegrationType
        {
            get => MallDeferredTransaction.IntegrationType;
            set => MallDeferredTransaction.IntegrationType = value;
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType, Headers);
        }

        public static MallStartResponse Start(string userName, string email, string responseUrl)
        {
            return MallInscription.Start(userName, email, responseUrl, DefaultOptions());
        }

        public static MallStartResponse Start(string userName, string email,
            string responseUrl, Options options)
        {
            return MallInscription.Start(userName, email, responseUrl, options);
        }

        public static MallFinishResponse Finish(string token)
        {
            return MallInscription.Finish(token, DefaultOptions());
        }

        public static MallFinishResponse Finish(string token, Options options)
        {
            return MallInscription.Finish(token, options);
        }

        public static void Delete(string userName, string tbkUser)
        {
            MallInscription.Delete(userName, tbkUser, DefaultOptions());
        }

        public static void Delete(string userName, string tbkUser, Options options)
        {
            MallInscription.Delete(userName, tbkUser, options);
        }
    }
}
