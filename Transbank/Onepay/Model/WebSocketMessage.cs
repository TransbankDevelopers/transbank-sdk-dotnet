namespace Transbank.Onepay.Model
{
    public class WebsocketMessage
    {
        public string status;
        public string description;

        public override string ToString()
        {
            return "Status: " + status + "\n" +
                   "Description: " + description;
        }
    }
}