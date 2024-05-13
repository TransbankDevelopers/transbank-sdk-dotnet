using System.Net.Http;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public class MallInscription : OneclickOptions
    {
        private MallInscription() { }
        public MallInscription(Options options, HttpClient httpClient = null) : base(options, httpClient) { }
        public MallInscription(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) { }

        public static MallInscription buildForProduction(string commerceCode, string apiKey)
        {
            MallInscription mallInscription = new MallInscription();
            mallInscription.ConfigureForProduction(commerceCode, apiKey);

            return mallInscription;
        }

        public static MallInscription buildForIntegration(string commerceCode, string apiKey)
        {
            MallInscription mallInscription = new MallInscription();
            mallInscription.ConfigureForIntegration(commerceCode, apiKey);
            
            return mallInscription;
        }

        public MallStartResponse Start(string userName, string email,
            string responseUrl)
        {
            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextTrimWithMaxLength(email, ApiConstants.EMAIL_LENGTH, "email");
            ValidationUtil.hasTextWithMaxLength(responseUrl, ApiConstants.RETURN_URL_LENGTH, "responseUrl");

            return ExceptionHandler.Perform<MallStartResponse, InscriptionStartException>(() =>
            {
                var startRequest = new MallStartRequest(userName, email, responseUrl);
                return _requestService.Perform<MallStartResponse, InscriptionStartException>(
                    startRequest, Options);
            });
        }

        public MallFinishResponse Finish(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallFinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new MallFinishRequest(token);
                return _requestService.Perform<MallFinishResponse, InscriptionFinishException>(finishRequest, Options);
            });
        }

        public DeleteResponse Delete(string tbkUser, string userName)
        {

            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstants.TBK_USER_LENGTH, "tbkUser");

            return ExceptionHandler.Perform<DeleteResponse, InscriptionDeleteException>(() =>
            {
                var deleteRequest = new MallDeleteRequest(userName, tbkUser);
                return _requestService.Perform<DeleteResponse, InscriptionDeleteException>(deleteRequest, Options);
            });
        }
    }
}
