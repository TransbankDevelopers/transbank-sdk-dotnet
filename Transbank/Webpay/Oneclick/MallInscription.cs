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
            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstant.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextTrimWithMaxLength(email, ApiConstant.EMAIL_LENGTH, "email");
            ValidationUtil.hasTextWithMaxLength(responseUrl, ApiConstant.RETURN_URL_LENGTH, "responseUrl");

            return ExceptionHandler.Perform<MallStartResponse, InscriptionStartException>(() =>
            {
                var startRequest = new MallStartRequest(userName, email, responseUrl);
                var response = RequestService.Perform<InscriptionStartException>(
                    startRequest, Options);

                return JsonConvert.DeserializeObject<MallStartResponse>(response);
            });
        }

        public MallFinishResponse Finish(string token)
        {
            ValidationUtil.hasTextWithMaxLength(token, ApiConstant.TOKEN_LENGTH, "token");

            return ExceptionHandler.Perform<MallFinishResponse, InscriptionFinishException>(() =>
            {
                var finishRequest = new MallFinishRequest(token);
                var response = RequestService.Perform<InscriptionFinishException>(finishRequest, Options);

                return JsonConvert.DeserializeObject<MallFinishResponse>(response);
            });
        }

        public void Delete(string userName, string tbkUser)
        {

            ValidationUtil.hasTextTrimWithMaxLength(userName, ApiConstant.USER_NAME_LENGTH, "userName");
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstant.TBK_USER_LENGTH, "tbkUser");

            ExceptionHandler.Perform<InscriptionDeleteException>(() =>
            {
                var deleteRequest = new MallDeleteRequest(userName, tbkUser);
                RequestService.Perform<InscriptionDeleteException>(deleteRequest, Options);
            });
        }
    }
}
