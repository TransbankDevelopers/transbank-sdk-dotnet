﻿using System;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Patpass.PatpassByWebpay.Requests
{
    public class StatusRequest : BaseRequest
    {
        internal StatusRequest(string token)
            : base($"{Constant.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Get) { }
    }
}
