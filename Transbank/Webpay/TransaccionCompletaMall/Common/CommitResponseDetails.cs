using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Transbank.Webpay.TransaccionCompletaMall.Common
{
    public class CommitResponseDetails
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("payment_type_code")]
        public string PaymentTypeCode { get; set; }
        
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; set; }
        
        [JsonProperty("installments_number")]
        public int InstallmentsNumber { get; set; }
        
        [JsonProperty("commerce_code")]
        public string CommerceCode { get; set; }
        
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }

        public CommitResponseDetails(
            int amount,
            string status,
            string authorizationCode,
            string paymentTypeCode,
            int responseCode,
            int installmentsAmount,
            int installmentsNumber,
            string commerceCode,
            string buyOrder)
        {
            Amount = amount;
            Status = status;
            AuthorizationCode = authorizationCode;
            PaymentTypeCode = paymentTypeCode;
            ResponseCode = responseCode;
            InstallmentsAmount = installmentsAmount;
            InstallmentsNumber = installmentsNumber;
            CommerceCode = commerceCode;
            BuyOrder = buyOrder;
        }

        public override string ToString()
        {
            var properties = new List<string>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                properties.Add($"{name}={value}");
            }
            return String.Join(",\n", properties);
        }
    }
}
