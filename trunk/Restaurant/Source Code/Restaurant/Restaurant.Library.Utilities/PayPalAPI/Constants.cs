using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Utilities.PayPalAPI
{
    public class Constants
    {
        public const string CERTIFICATE = "";
        public const string PRIVATE_KEY_PASSWORD = "";
        public const string SUBJECT = "";
        public const string ENVIRONMENT = "sandbox";
        public const string ECURLLOGIN = "https://developer.paypal.com";

        public const string GET_TRANSACTION_DETAILS_SESSION_KEY = "GetTransactionDetailsResponseType";
        public const string TRANSACTION_SEARCH_SESSION_KEY = "TransactionSearchResponseType";
        public const string RESPONSE_SESSION_KEY = "payPalResponse";
        public const string PROFILE_KEY = "Profile";
        public const string PAYMENTACTIONTYPE_SESSION_KEY = "PaymentActionType";

        public const string TRANSACTIONID_PARAM = "trxID";
        public const string REFUND_TYPE_PARAM = "refundType";
        public const string PAYMENT_AMOUNT_PARAM = "amount";
        public const string PAYMENT_CURRENCY_PARAM = "currency";
        public const string BUYER_LAST_NAME_PARAM = "buyerLastName";
        public const string BUYER_FIRST_NAME_PARAM = "buyerFirstName";
        public const string BUYER_ADDRESS1_PARAM = "buyerAddress1";
        public const string BUYER_ADDRESS2_PARAM = "buyerAddress2";
        public const string BUYER_CITY_PARAM = "buyerCity";
        public const string BUYER_STATE_PARAM = "buyerState";
        public const string BUYER_ZIPCODE_PARAM = "buyerZipCode";
        public const string CREDIT_CARD_TYPE_PARAM = "creditCardType";
        public const string CREDIT_CARD_NUMBER_PARAM = "creditCardNumber";
        public const string CVV2_PARAM = "cvv2";
        public const string EXP_MONTH_PARAM = "expMonth";
        public const string EXP_YEAR_PARAM = "expYear";
        public const string TOKEN_PARAM = "token";
        public const string PAYERID_PARAM = "payerID";
        public const string AUTHORIZATIONID_PARAM = "authorizationID";
        public const string PAYMENT_ACTION_PARAM = "paymentAction";
        public const string REFUND_FULL_TRANSACTION = "Full";
        public const string REFUND_PARTIAL_TRANSACTION = "Partial";
        public const string RESOURCE_ROOT = "com.paypal.sdk";
    }
}
