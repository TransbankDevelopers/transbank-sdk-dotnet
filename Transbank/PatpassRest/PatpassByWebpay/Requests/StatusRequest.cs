﻿using System;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Patpass.PatpassByWebpay.Requests
{
    public class StatusRequest : BaseRequest
    {
        internal StatusRequest(string token)
            : base($"/rswebpaytransaction/api/webpay/v1.0/transactions/{token}", HttpMethod.Get) { }
    }
}
