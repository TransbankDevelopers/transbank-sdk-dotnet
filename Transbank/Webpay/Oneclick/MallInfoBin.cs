using System;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.Oneclick.Requests;
using Transbank.Webpay.Oneclick.Responses;

namespace Transbank.Webpay.Oneclick
{
    public class MallInfoBin
    {
        private Options _options;

        public Options Options
        {
            get => _options;
            private set => _options = value ?? throw new ArgumentNullException(
                nameof(value), "Options can't be null."
            );
        }

        public MallInfoBin(Options options)
        {
            Options = options;
        }

        public static MallInfoBin buildForIntegration(string commerceCode, string apiKey)
        {
            MallInfoBin mallInfoBin = new MallInfoBin(new Options(commerceCode, apiKey, WebpayIntegrationType.Test));

            return mallInfoBin;
        }

        public static MallInfoBin buildForProduction(string commerceCode, string apiKey)
        {
            MallInfoBin mallInfoBin = new MallInfoBin(new Options(commerceCode, apiKey, WebpayIntegrationType.Live));

            return mallInfoBin;
        }

        public MallQueryBinResponse queryBin(string tbkUser)
        {
            ValidationUtil.hasTextWithMaxLength(tbkUser, ApiConstants.TBK_USER_LENGTH, "tbkUser");

            return ExceptionHandler.Perform<MallQueryBinResponse, MallQueryBinException>(() =>
            {
                var queryBinRequest = new MallQueryBinRequest(tbkUser);
                return Options.RequestService.Perform<MallQueryBinResponse, MallQueryBinException>(queryBinRequest, Options);
            });
        }
    }
}
