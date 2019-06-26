﻿using System;
using Transbank.Webpay.Common;
using System.Net.Http;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class StatusRequest : BaseRequest
    {
        internal StatusRequest(string token)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Get) { }
    }
}
