namespace Transbank.PatPass
{
    public class PatPass
    {
        private PatPassByWebpayNormal _normalTransaction;
        readonly Configuration configuration;

        private static readonly object padlock = new object();

        public PatPass(Configuration param)
        {
            if (param.WebpayCertPath != null)
                switch (param.Environment)
                {
                    case "PRODUCCION":
                        param.WebpayCertPath = Webpay.Configuration.GetProductionPublicCertPath();
                        break;
                    default:
                        param.WebpayCertPath = Webpay.Configuration.GetTestingPublicCertPath();
                        break;
                }
            configuration = param;
        }

        public PatPassByWebpayNormal NormalTransaction
        {
            get
            {
                if (_normalTransaction == null)
                    lock (padlock)
                        if (_normalTransaction == null)
                            _normalTransaction = new PatPassByWebpayNormal(configuration);
                return _normalTransaction;
            }
        }
    }
}
