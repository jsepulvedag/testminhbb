using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using com.paypal.soap.api;

namespace Restaurant.Library.Utilities.PayPalAPI
{
    public class PaymentPaypal
    {
        private static PaypalAPI process;
        public static string RefundTransaction(string transactionNumber, double money,string refundType)
        {
            process = new PaypalAPI();
            RefundTransactionResponseType retVal = new RefundTransactionResponseType();
            retVal = process.RefundTransaction(transactionNumber, refundType, money.ToString());
            if (retVal.Errors == null)
            {
                return retVal.RefundTransactionID;
            }
            else
            {
                int ErrCount = retVal.Errors.Length;
                string msg = "ERRORNHATNV";
                for (int i = 0; i < ErrCount; i++)
                {
                    msg += retVal.Errors[i].ErrorCode.ToString();
                    msg += retVal.Errors[i].LongMessage.ToString();
                    msg += retVal.Errors[i].ToString();
                }
                return msg;
            }
        }
        public static string CheckOutTransaction(double money, RestaurantBusinessAccountInfo restaurant, AccountPaymentInfo card, MemberInfo member)
        {
            process = new PaypalAPI(new BusinessAccountInfo(restaurant));
            DoDirectPaymentResponseType DpRsp;
            DpRsp = (DoDirectPaymentResponseType)process.DoDirectPayment(
                                                                money.ToString(),
                                                                member.FirstName,
                                                                member.LastName,
                                                                member.Address,
                                                                member.Address,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                card.TypeOfCreditCard,
                                                                card.CreditCardNumber,
                                                                card.CardSercurityCode,
                                                                card.ExpiredMonth,
                                                                card.ExpiredYear,
                                                                PaymentActionCodeType.Sale);
            if (DpRsp.Errors == null)
            {
                return DpRsp.TransactionID;
            }
            else
            {
                int ErrCount = DpRsp.Errors.Length;
                string msg = "ERRORNHATNV";
                for (int i = 0; i < ErrCount; i++)
                {
                    msg += DpRsp.Errors[i].ErrorCode.ToString();
                    msg += DpRsp.Errors[i].LongMessage.ToString();
                    msg += DpRsp.Errors[i].ToString();
                }
                return msg;
            }
        }
        public static string CheckOutIncomeTransaction(AdminBusinessAccountInfo admin,double money,AccountPaymentInfo card)
        {
            string msg = "";
            process = new PaypalAPI(new BusinessAccountInfo(admin));
            DoDirectPaymentResponseType DpRsp;
            DpRsp = (DoDirectPaymentResponseType)process.DoDirectPayment(
                                                                money.ToString(),
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                card.TypeOfCreditCard,
                                                                card.CreditCardNumber,
                                                                card.CardSercurityCode,
                                                                card.ExpiredMonth,
                                                                card.ExpiredYear,
                                                                PaymentActionCodeType.Sale);
            if (DpRsp.Errors == null)
            {
                return DpRsp.TransactionID;
            }
            else
            {
                int ErrCount = DpRsp.Errors.Length;
                msg = "ERRORNHATNV";
                for (int i = 0; i < ErrCount; i++)
                {
                    msg += DpRsp.Errors[i].ErrorCode.ToString();
                    msg += DpRsp.Errors[i].LongMessage.ToString();
                    msg += DpRsp.Errors[i].ToString();
                }
                return msg;
            }
        }
        public static string CheckOutPackage(PackageDetailInfo packageDetail, AdminBusinessAccountInfo admin, AccountPaymentInfo card, MemberInfo member)
        {            
            process = new PaypalAPI(new BusinessAccountInfo(admin));
            DoDirectPaymentResponseType DpRsp;
            DpRsp = (DoDirectPaymentResponseType)process.DoDirectPayment(
                                                                packageDetail.Price.ToString(),
                                                                member.FirstName,
                                                                member.LastName,
                                                                member.Address,
                                                                member.Address,
                                                                string.Empty,
                                                                string.Empty,
                                                                string.Empty,
                                                                card.TypeOfCreditCard,
                                                                card.CreditCardNumber,
                                                                card.CardSercurityCode,
                                                                card.ExpiredMonth,
                                                                card.ExpiredYear,
                                                                PaymentActionCodeType.Sale);
            if (DpRsp.Errors == null)
            {
                return DpRsp.TransactionID;
            }
            else
            {
                int ErrCount = DpRsp.Errors.Length;
                string msg = "ERRORNHATNV";
                for (int i = 0; i < ErrCount; i++)
                {
                    msg += DpRsp.Errors[i].ErrorCode.ToString();
                    msg += DpRsp.Errors[i].LongMessage.ToString();
                    msg += DpRsp.Errors[i].ToString();
                }
                return msg;
            }
        }        
    }
}
