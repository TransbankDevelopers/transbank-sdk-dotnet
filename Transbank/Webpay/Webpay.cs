
/**
 * @author     Allware Ltda. (http://www.allware.cl)
 * @copyright  2015 Transbank S.A. (http://www.tranbank.cl)
 * @date       May 2016
 * @license    GNU LGPL
 * @version    2.0.1
 */

namespace Transbank.Webpay
{
    public class Webpay
    {
        WebpayNormal _normalTransaction;
        WebpayOneClick _oneclickTransaction;
        WebpayNullify _nullifyTransaction;
        WebpayMallNormal _mallNormalTransaction;
        WebpayCapture _captureTransaction;
        WebpayComplete _completeTransaction;        
        readonly Configuration configuration;

        public Webpay(Configuration param)
        {
            configuration = param;
        }

        public WebpayNormal NormalTransaction
        {
            get
            {
                if (_normalTransaction == null)
                {
                    _normalTransaction = new WebpayNormal(configuration);
                }
                return _normalTransaction;
            }
        }

        public WebpayOneClick OneClickTransaction
        {
            get
            {
                if (_oneclickTransaction == null)
                {
                    _oneclickTransaction = new WebpayOneClick(configuration);
                }
                return _oneclickTransaction;
            }
        }

        public WebpayMallNormal MallNormalTransaction
        {
            get
            {
                if (_mallNormalTransaction == null)
                {
                    _mallNormalTransaction = new WebpayMallNormal(configuration);
                }
                return _mallNormalTransaction;
            }
        }

        public WebpayNullify NullifyTransaction
        {
            get
            {
                if (_nullifyTransaction == null)
                {
                    _nullifyTransaction = new WebpayNullify(configuration);
                }
                return _nullifyTransaction;

            }
        }

        public WebpayCapture CaptureTransaction
        {
            get
            {
                if (_captureTransaction == null)
                {
                    _captureTransaction = new WebpayCapture(configuration);
                }
                return _captureTransaction;
            }
        }

        public WebpayComplete CompleteTransaction
        {
            get
            {
                if (_completeTransaction == null)
                {
                    _completeTransaction = new WebpayComplete(configuration);
                }
                return _completeTransaction;
            }
        }
    }
}
