﻿using System;
using Transbank.Common;
using System.Net.Http;

namespace Transbank.Webpay.WebpayPlus.Requests
{
    public class StatusRequest : BaseRequest
    {
        internal StatusRequest(string token)
            : base($"{ApiConstants.WEBPAY_METHOD}/transactions/{token}", HttpMethod.Get) { }
    }
}
