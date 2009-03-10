using System;
using System.Collections.Generic;
using System.Text;
using com.paypal.sdk.services;
using com.paypal.soap.api;

namespace Restaurant.Library.Utilities.PayPalAPI
{
    internal class PaypalAPI
    {
        private readonly CallerServices caller;
        MassPayRequestType pp_request = new MassPayRequestType();
        MassPayRequestItemType massItemReq = new MassPayRequestItemType();

        public PaypalAPI()
        {
            APILoginSetup();
            caller = new CallerServices();
            caller.APIProfile = SetProfile.SessionProfile;
        }

        private void APILoginSetup()
        {
            string APIUserName = AppEnv.API_USERNAME;
            string APIPassword = AppEnv.API_PASSWORD;
            string APISignature = AppEnv.API_SIGNATURE;
            SetProfile.SessionProfile = SetProfile.CreateAPIProfile(APIUserName, APIPassword, APISignature, "", "", "", "");
        }

        public PaypalAPI(BusinessAccountInfo account)
        {
            APILoginSetup(account);
            caller = new CallerServices();
            caller.APIProfile = SetProfile.SessionProfile;
        }

        private void APILoginSetup(BusinessAccountInfo account)
        {
            string APIUserName = account.APIUserName;
            string APIPassword = account.APIPassword;
            string APISignature = account.APISignature;
            SetProfile.SessionProfile = SetProfile.CreateAPIProfile(APIUserName, APIPassword, APISignature, "", "", "", "");
        }

        public TransactionSearchResponseType TransactionSearch(DateTime startDate, DateTime endDate, string transactionId)
        {
            TransactionSearchRequestType concreteRequest = new TransactionSearchRequestType();
            concreteRequest.StartDate = startDate.ToUniversalTime();
            concreteRequest.EndDate = endDate.AddDays(1).ToUniversalTime();
            concreteRequest.EndDateSpecified = true;
            concreteRequest.TransactionID = transactionId;
            return (TransactionSearchResponseType)caller.Call("TransactionSearch", concreteRequest);
        }

        public GetTransactionDetailsResponseType GetTransactionDetails(string trxID)
        {
            GetTransactionDetailsRequestType concreteRequest = new GetTransactionDetailsRequestType();
            concreteRequest.TransactionID = trxID;
            return (GetTransactionDetailsResponseType)caller.Call("GetTransactionDetails", concreteRequest);
        }

        public RefundTransactionResponseType RefundTransaction(string trxID, string refundType, string amount)
        {
            RefundTransactionRequestType concreteRequest = new RefundTransactionRequestType();
            concreteRequest.TransactionID = trxID;
            switch (refundType)
            {
                case Constants.REFUND_FULL_TRANSACTION:
                    concreteRequest.RefundType = RefundType.Full;

                    concreteRequest.RefundTypeSpecified = true;
                    break;
                case Constants.REFUND_PARTIAL_TRANSACTION:
                    concreteRequest.RefundType = RefundType.Partial;
                    concreteRequest.RefundTypeSpecified = true;
                    concreteRequest.Amount = new BasicAmountType();
                    concreteRequest.Amount.currencyID = CurrencyCodeType.USD;
                    concreteRequest.Amount.Value = amount;
                    break;
            }
            return (RefundTransactionResponseType)caller.Call("RefundTransaction", concreteRequest);
        }

        public DoDirectPaymentResponseType DoDirectPayment(string paymentAmount, string buyerLastName, string buyerFirstName, string buyerAddress1, string buyerAddress2, string buyerCity, string buyerState, string buyerZipCode, string creditCardType, string creditCardNumber, string CVV2, int expMonth, int expYear, PaymentActionCodeType paymentAction)
        {
            DoDirectPaymentRequestType pp_Request = new DoDirectPaymentRequestType();
            pp_Request.DoDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();
            pp_Request.DoDirectPaymentRequestDetails.IPAddress = "10.244.43.106";
            pp_Request.DoDirectPaymentRequestDetails.MerchantSessionId = "1X911810264059026";
            pp_Request.DoDirectPaymentRequestDetails.PaymentAction = paymentAction;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard = new CreditCardDetailsType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardNumber = creditCardNumber;
            switch (creditCardType)
            {
                case "Visa":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Visa;
                    break;
                case "MasterCard":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.MasterCard;
                    break;
                case "Discover":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Discover;
                    break;
                case "Amex":
                    pp_Request.DoDirectPaymentRequestDetails.CreditCard.CreditCardType = CreditCardTypeType.Amex;
                    break;
            }
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CVV2 = CVV2;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonthSpecified = true;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpMonth = expMonth;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYearSpecified = true;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.ExpYear = expYear;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner = new PayerInfoType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Payer = "";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerID = "";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerStatus = PayPalUserStatusCodeType.unverified;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerCountry = CountryCodeType.US;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address = new AddressType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street1 = buyerAddress1;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Street2 = buyerAddress2;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CityName = buyerCity;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.StateOrProvince = buyerState;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.PostalCode = buyerZipCode;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountryName = "USA";
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.Country = CountryCodeType.US;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.Address.CountrySpecified = true;

            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName = new PersonNameType();
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.FirstName = buyerFirstName;
            pp_Request.DoDirectPaymentRequestDetails.CreditCard.CardOwner.PayerName.LastName = buyerLastName;
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.USD;
            pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = paymentAmount;
            return (DoDirectPaymentResponseType)caller.Call("DoDirectPayment", pp_Request);
        }

        public SetExpressCheckoutResponseType SetExpressCheckout(string paymentAmount, string returnURL, string cancelURL, PaymentActionCodeType paymentAction, CurrencyCodeType currencyCodeType)
        {
            SetExpressCheckoutRequestType pp_request = new SetExpressCheckoutRequestType();

            pp_request.SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType();
            pp_request.SetExpressCheckoutRequestDetails.PaymentAction = paymentAction;
            pp_request.SetExpressCheckoutRequestDetails.PaymentActionSpecified = true;

            pp_request.SetExpressCheckoutRequestDetails.OrderTotal = new BasicAmountType();

            pp_request.SetExpressCheckoutRequestDetails.OrderTotal.currencyID = currencyCodeType;
            pp_request.SetExpressCheckoutRequestDetails.OrderTotal.Value = paymentAmount;

            pp_request.SetExpressCheckoutRequestDetails.CancelURL = cancelURL;
            pp_request.SetExpressCheckoutRequestDetails.ReturnURL = returnURL;

            return (SetExpressCheckoutResponseType)caller.Call("SetExpressCheckout", pp_request);
        }

        public GetExpressCheckoutDetailsResponseType GetExpressCheckoutDetails(string token)
        {
            GetExpressCheckoutDetailsRequestType pp_request = new GetExpressCheckoutDetailsRequestType();

            pp_request.Token = token;

            return (GetExpressCheckoutDetailsResponseType)caller.Call("GetExpressCheckoutDetails", pp_request);
        }

        public DoExpressCheckoutPaymentResponseType DoExpressCheckoutPayment(string token, string payerID, string paymentAmount, PaymentActionCodeType paymentAction, CurrencyCodeType currencyCodeType)
        {
            DoExpressCheckoutPaymentRequestType pp_request = new DoExpressCheckoutPaymentRequestType();

            pp_request.DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            pp_request.DoExpressCheckoutPaymentRequestDetails.Token = token;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PayerID = payerID;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentAction = paymentAction;

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails = new PaymentDetailsType();

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal = new BasicAmountType();

            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = currencyCodeType;
            pp_request.DoExpressCheckoutPaymentRequestDetails.PaymentDetails.OrderTotal.Value = paymentAmount;
            return (DoExpressCheckoutPaymentResponseType)caller.Call("DoExpressCheckoutPayment", pp_request);
        }

        public DoVoidResponseType DoVoid(string authorizationId, string note)
        {
            DoVoidRequestType pp_request = new DoVoidRequestType();
            pp_request.AuthorizationID = authorizationId;
            pp_request.Note = note;
            return (DoVoidResponseType)caller.Call("DoVoid", pp_request);
        }

        public DoCaptureResponseType DoCapture(string authorizationId, string note, string value, CurrencyCodeType currencyId, string invoiceId)
        {
            DoCaptureRequestType pp_request = new DoCaptureRequestType();
            pp_request.AuthorizationID = authorizationId;
            pp_request.Note = note;
            pp_request.Amount = new BasicAmountType();
            pp_request.Amount.Value = value;
            pp_request.Amount.currencyID = currencyId;
            pp_request.InvoiceID = invoiceId;
            return (DoCaptureResponseType)caller.Call("DoCapture", pp_request);
        }

        public DoAuthorizationResponseType DoAuthorization(string orderId, string value, CurrencyCodeType currencyId)
        {
            DoAuthorizationRequestType pp_request = new DoAuthorizationRequestType();
            pp_request.TransactionID = orderId;
            pp_request.Amount = new BasicAmountType();
            pp_request.Amount.Value = value;
            pp_request.Amount.currencyID = currencyId;
            return (DoAuthorizationResponseType)caller.Call("DoAuthorization", pp_request);
        }

        public DoReauthorizationResponseType DoReAuthorization(string authorizationId, string value, CurrencyCodeType currencyId)
        {
            DoReauthorizationRequestType pp_request = new DoReauthorizationRequestType();
            pp_request.AuthorizationID = authorizationId;
            pp_request.Amount = new BasicAmountType();
            pp_request.Amount.Value = value;
            pp_request.Amount.currencyID = currencyId;
            return (DoReauthorizationResponseType)caller.Call("DoReauthorization", pp_request);
        }

        public MassPayResponseType MassPay(string EmailSubject, ReceiverInfoCodeType receiverType, string[] ReceiverEmail, string[] value, string[] UniqueId, string[] note, CurrencyCodeType[] currencyId, int Count)
        {

            pp_request.MassPayItem = new MassPayRequestItemType[Count];
            for (int i = 0; i < Count; i++)
            {

                pp_request.MassPayItem[i] = new MassPayRequestItemType();
                pp_request.MassPayItem[i].ReceiverEmail = ReceiverEmail[i];
                pp_request.MassPayItem[i].Amount = new BasicAmountType();
                pp_request.MassPayItem[i].Amount.Value = value[i];
                pp_request.MassPayItem[i].Amount.currencyID = currencyId[i];
                pp_request.MassPayItem[i].UniqueId = UniqueId[i];
                pp_request.MassPayItem[i].Note = note[i];

            }

            pp_request.EmailSubject = EmailSubject;
            pp_request.ReceiverType = receiverType;
            return (MassPayResponseType)caller.Call("MassPay", pp_request);

        }
    }
}
