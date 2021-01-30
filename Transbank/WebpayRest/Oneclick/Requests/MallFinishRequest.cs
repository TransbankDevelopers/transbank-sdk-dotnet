﻿using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    internal class MallFinishRequest : BaseRequest
    {
        internal MallFinishRequest(string token)
            : base($"/rswebpaytransaction/api/oneclick/v1.0/inscriptions/{token}",
                  HttpMethod.Put){}
    }
}
