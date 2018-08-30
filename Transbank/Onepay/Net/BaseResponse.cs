namespace Transbank.Onepay.Net
{
    public class BaseResponse
    {
        
        public string ResponseCode { get; set; }
       
        public string Description { get; set; }

        public override string ToString() =>
            $"ResponseCode={ResponseCode}, Description={Description}".Trim();
    }
}
