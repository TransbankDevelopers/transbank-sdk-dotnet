using System;

namespace Transbank.Onepay.Enums
{
    public class ChannelType
    {
        public static readonly ChannelType Web = new ChannelType("WEB");
        public static readonly ChannelType Mobile = new ChannelType("MOBILE");
        public static readonly ChannelType App = new ChannelType("APP");
        
        private ChannelType(string channel)
        {
            Value = channel;
        }
        
        public string Value { get; private set; }

        public static ChannelType Parse(string channel)
        {
            if (channel.Equals("mobile", StringComparison.OrdinalIgnoreCase))
                return Mobile;
            
            if (channel.Equals("app", StringComparison.OrdinalIgnoreCase))
                return App;

            return Web;
        }
    }
}
