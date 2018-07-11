namespace OnePaySDK.Model
{
    public abstract class BaseRequest
    {
        private string apiKey { get; set; }
        private string appKey { get; set; }
        private readonly bool GenerateOttQrCode = true;
    }
}