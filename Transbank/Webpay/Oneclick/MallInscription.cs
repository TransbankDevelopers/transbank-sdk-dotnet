using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public class MallInscription : OneclickOptions
    {
        public MallInscription() : this(
            new Options(
                IntegrationCommerceCodes.ONECLICK_MALL,
                IntegrationApiKeys.WEBPAY,
                WebpayIntegrationType.Test
            )
        )
        { }

        public MallInscription(Options options) :base(options) { }

        public MallStartResponse Start(string userName, string email,
            string responseUrl)
        {
            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextTrimWithMaxLength(email, ApiConstants.EMAIL_LENGTH, "email");
            ValidationUtil.hasTextWithMaxLength(responseUrl, ApiConstants.RETURN_URL_LENGTH, "responseUrl");

            return ExceptionHandler.Perform<MallStartResponse, InscriptionStartException>(() =>
            {
                var startRequest = new MallStartRequest(userName, email, responseUrl);
                return RequestService.Perform<MallStartResponse, InscriptionStartException>(
                    startRequest, Options);
            });
        }

        public MallFinishResponse Finish(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallFinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new MallFinishRequest(token);
                return RequestService.Perform<MallFinishResponse, InscriptionFinishException>(finishRequest, Options);
            });
        }

        public DeleteResponse Delete(string tbkUser, string userName)
        {

            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstants.TBK_USER_LENGTH, "tbkUser");

            return ExceptionHandler.Perform<DeleteResponse, InscriptionDeleteException>(() =>
            {
                var deleteRequest = new MallDeleteRequest(userName, tbkUser);
                return RequestService.Perform<DeleteResponse, InscriptionDeleteException>(deleteRequest, Options);
            });
        }
    }
}
