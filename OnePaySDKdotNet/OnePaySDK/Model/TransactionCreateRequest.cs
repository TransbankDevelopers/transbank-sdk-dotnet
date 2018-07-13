using System;
using System.Collections.Generic;

namespace Transbank.Model
{
    public sealed class TransactionCreateRequest : BaseRequest
    {       
        private List<Item> items;
        private string callbackUrl;
        private string channel;
        private string signature;
        private readonly bool generateOttQrCode = true;

        public long ExternalUniqueNumber { get; set; }
        public long Total { get; set; }
        public int ItemsQuantity { get; set; }
        public long IssuedAt { get; set; }
        public List<Item> Items
        {
            get => items;
            set => items = value ?? throw 
                new ArgumentNullException("Items can't be null");
        }
        public string CallbackUrl
        {
            get => callbackUrl;
            set => callbackUrl = value ?? throw 
                new ArgumentNullException("CallbackUrl can't be null");
        }
        public string Channel
        {
            get => channel;
            set => channel = value ?? throw 
                new ArgumentNullException("Channel can't be null");
        }
        public string Signature
        {
            get => signature;
            set => signature = value ?? throw 
                new ArgumentNullException("Signature can't be null");
        }

        public override string ToString()
        {
            return $"ExternalUniqueNumber={ExternalUniqueNumber}, Total={Total}" +
                $", ItemsQuantity={ItemsQuantity}, IssueaAt={IssuedAt}" +
                $", Items={string.Join<Item>(" , ", Items.ToArray())}" +
                $", CallbackUrl={CallbackUrl}, Channel={Channel}, Signature={Signature}";
        }
    }
}
