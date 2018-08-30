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
    }
}
