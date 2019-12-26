using Newtonsoft.Json.Converters;

namespace Transbank.Webpay.Common
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
