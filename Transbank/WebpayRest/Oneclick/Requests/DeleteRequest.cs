using System;

namespace Transbank.Webpay.Oneclick.Requests
{
    [Obsolete("Use MallDeleteRequest instead", false)]
    internal class DeleteRequest : MallDeleteRequest
    {
        internal DeleteRequest(string userName, string tbkUser)
            : base(userName, tbkUser) { }
    }
}
