using System;

namespace Transbank.Common
{
    public static class ApiConstant
    {
        public const string WEBPAY_METHOD = "/rswebpaytransaction/api/webpay/v1.2";
        public const string ONECLICK_METHOD = "/rswebpaytransaction/api/oneclick/v1.2";
        public const byte BUY_ORDER_LENGTH = 26;
        public const byte SESSION_ID_LENGTH = 61;
        public const byte RETURN_URL_LENGTH = 255;
        public const byte AUTHORIZATION_CODE_LENGTH = 6;
        public const byte CARD_EXPIRATION_DATE_LENGTH = 5;
        public const byte CARD_NUMBER_LENGTH = 19;
        public const byte TBK_USER_LENGTH = 40;
        public const byte USER_NAME_LENGTH = 40;
        public const byte COMMERCE_CODE_LENGTH = 12;
        public const byte TOKEN_LENGTH = 64;
        public const byte EMAIL_LENGTH = 100;
    }
}
