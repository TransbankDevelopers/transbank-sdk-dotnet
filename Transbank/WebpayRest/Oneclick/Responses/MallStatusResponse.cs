using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Webpay.Common;

namespace Transbank.WebpayRest.Oneclick.Responses
{
    public class MallStatusResponse
    {
        [JsonProperty("buy_order")]
        public string BuyOrder { get; set; }
        
        [JsonProperty("card_detail")]
        public CardDetail CardDetail { get; set; }
        
        [JsonProperty("accounting_date")]
        public string AccountingDate { get; set; }
        
        [JsonProperty("transaction_date")]
        public string TransactionDate { get; set; }

        [JsonProperty("details")]
        public List<PaymentResponse> Details { get; private set; }

        public MallStatusResponse(string buyOrder, CardDetail cardDetail, string accountingDate, string transactionDate)
        {
            BuyOrder = buyOrder;
            CardDetail = cardDetail;
            AccountingDate = accountingDate;
            TransactionDate = transactionDate;
        }

        public override string ToString()
        {
            var details = "";
            Details.ForEach(i => details += "{\n"+ i.ToString() + "\n}\n");
            return $"\"BuyOrder\": \"{BuyOrder}\"\n" +
                   $"\"AccountingDate\": \"{AccountingDate}\"\n" +
                   $"\"TransactionDate\": \"{TransactionDate}\"\n" +
                   "\"Details\":\n{\n\t" + details + "\n}\n";
        }
  
        public class Detail
        {
            [JsonProperty("amount")]
            public decimal Amount { get; set; }
            
            [JsonProperty("status")]
            public string Status { get; set; }
            
            [JsonProperty("authorization_code")]
            public string AuthorizationCode { get; set; }
            
            [JsonProperty("payment_type_code")]
            public string PaymentTypeCode { get; set; }
            
            [JsonProperty("response_code")]
            public int ResponseCode { get; set; }
            
            [JsonProperty("installments_number")]
            public int InstallmentsNumber { get; set; }
            
            [JsonProperty("commerce_code")]
            public string CommerceCode { get; set; }
            
            [JsonProperty("buy_order")]
            public string BuyOrder { get; set; }

            public Detail(decimal amount, string status, string authorizationCode, string paymentTypeCode,
                int responseCode, int installmentsNumber, string commerceCode, string buyOrder)
            {
                Amount = amount;
                Status = status;
                AuthorizationCode = authorizationCode;
                PaymentTypeCode = paymentTypeCode;
                ResponseCode = responseCode;
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
}