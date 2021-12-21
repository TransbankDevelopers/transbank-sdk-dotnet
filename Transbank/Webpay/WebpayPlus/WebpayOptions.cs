using Transbank.Common;
using Transbank.Webpay.Common;

namespace Transbank.Webpay.WebpayPlus
{
    public class WebpayOptions
    {
        public Options Options { get; protected set; }

        public WebpayOptions(Options options) { Options = options; }

    }
}
