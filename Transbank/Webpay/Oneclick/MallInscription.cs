using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.Oneclick
{
    public class MallInscription
    {

        public Options options;
        public MallInscription(Options options)
        {
            this.options = options;
        }

        public static MallInscription buildForIntegration(string commerceCode, string apiKey)
        {
            MallInscription mallInscription = new MallInscription(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return mallInscription;
        }

        public static MallInscription buildForProduction(string commerceCode, string apiKey)
        {
            MallInscription mallInscription = new MallInscription(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

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
                return options.RequestService.Perform<MallStartResponse, InscriptionStartException>(
                    startRequest, options);
            });
        }

        public MallFinishResponse Finish(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstants.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallFinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new MallFinishRequest(token);
                return options.RequestService.Perform<MallFinishResponse, InscriptionFinishException>(finishRequest, options);
            });
        }

        public DeleteResponse Delete(string tbkUser, string userName)
        {

            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstants.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstants.TBK_USER_LENGTH, "tbkUser");

            return ExceptionHandler.Perform<DeleteResponse, InscriptionDeleteException>(() =>
            {
                var deleteRequest = new MallDeleteRequest(userName, tbkUser);
                return options.RequestService.Perform<DeleteResponse, InscriptionDeleteException>(deleteRequest, options);
            });
        }
    }
}
