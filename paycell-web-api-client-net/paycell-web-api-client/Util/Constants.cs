

namespace paycell_web_api_client.Util
{
    public static class Constants
    {
        public const string APPLICATION_NAME = "PAYCELLTEST";
        public const string APPLICATION_PASSWORD = "PaycellTestPassword";
        public const string SECURE_CODE = "PAYCELL12345";
        public const string EULAID = "17";
        public const string MERCHANT_CODE = "9998";
        public const string REFERENCE_NUMBER_PREFIX = "001";

        public const string SOAP = "SOAP";
        public const string REST = "REST";

        public const string GET_CARD_TOKEN_URL = "https://omccstb.turkcell.com.tr/paymentmanagement/rest/getCardTokenSecure";
        public const string THREE_D_SECURE_URL = "https://omccstb.turkcell.com.tr/paymentmanagement/rest/threeDSecure";

        public const string SUCCESS_CODE = "0";
      
        //  SOAP
        public const string PROVISION_SERVICES_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/ws";     

        //  REST
        public const string GET_CARDS_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/getCards/";
        public const string REGISTER_CARD_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/registerCard/";
        public const string UPDATE_CARD_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/updateCard/";
        public const string DELETE_CARD_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/deleteCard/";
        public const string PROVISION_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/provision/";
        public const string INQUIRE_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/inquire/";
        public const string REVERSE_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/reverse/";
        public const string REFUND_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/refund/";
        public const string SUMMARY_RECONCILIATION_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/summaryReconciliation/";
        public const string GET_THREE_D_SESSION_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/getThreeDSession/";
        public const string GET_THREE_D_SESSION_RESULT_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/getThreeDSessionResult/";
        public const string GET_PROVISION_HISTORY_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/getProvisionHistory";
        public const string PROVISION_FOR_MARKET_PLACE_URL = "https://tpay-test.turkcell.com.tr/tpay/provision/services/restful/getCardToken/provisionForMarketPlace/";

    }
}