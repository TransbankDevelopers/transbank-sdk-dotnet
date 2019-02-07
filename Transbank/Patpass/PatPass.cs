namespace Transbank.PatPass
{
    public class PatPass
    {
        private PatPassNormal _normalTransaction;
        readonly Configuration configuration;

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

        public PatPassNormal NormalTransaction
        {
            get
            {
                if (_normalTransaction == null)
                {
                    _normalTransaction = new PatPassNormal(configuration);
                }
                return _normalTransaction;
            }
        }
    }
}
