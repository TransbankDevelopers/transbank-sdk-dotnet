namespace Transbank.Onepay.Model
{
    public interface ISignable
    {
        string Signature { get; set; }
        string GetDataToSign();
    }
}
