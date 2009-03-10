using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities.Validator;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities.PayPalAPI;
using Restaurant.Library.BLL;
using System.Web.Mail;
//using System.Net.Mail;

namespace Restaurant.Presentation.Home.Restaurant.GiftCertificates
{
    public partial class PurchaseGift : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDateTime();
            }
        }
        private string RestaurantID
        {
            get 
            {
                return Request.QueryString["RidUrl"];
            }
        }
        private void BindDateTime()
        {
            string[] monthDisplays = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] monthValues = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            string[] years = new string[15];
            for (int i = 0; i < 15; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year + i);
            }

            Utility.BindingDropDowList(Utility.CreateTable(monthValues, monthDisplays), drpExpMonth);
            Utility.BindingDropDowList(Utility.CreateTable(years, years), drpExYear);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_MEMBER_PURCHASE_GIFT_URL + PageConstant.RESTAURANT_ID + RestaurantID));
            }
            if (Session[PageConstant.SESSION_GIFT_CERTIFICATE] == null)
            {
                Response.Redirect(PageConstant.HOME_MEMBER_INSTANCE_GIFT_URL + PageConstant.RESTAURANT_ID + RestaurantID);
            }
        }
        void SendMailMember()
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();

            MailMessage member = new MailMessage();
            member.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            member.To = Authentication.CurrentMemberInfo.Email;
            member.Body = "Thank you for reserving gift certificate in 212cuisine.com";
            member.Subject = "Message from 212cuisine";
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                SmtpMail.Send(member);
                lblMess.Visible = false;
            }
            catch
            {
                lblMess.Visible = true;
                lblMess.Text = "Send Email faild";
            }
        }
        void SendMailYourMember( string tomail, string file)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();

            MailMessage yourMember = new MailMessage();
            yourMember.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            yourMember.To = tomail;
            yourMember.Body = "You has receive a Gift Certificate from Email Address: " + Authentication.CurrentMemberInfo.Email;
            yourMember.Subject = "Message from 212cuisine";

            MailAttachment att = new MailAttachment(file);
            yourMember.Attachments.Add(att);
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                SmtpMail.Send(yourMember);
                lblMess.Visible = false;
            }
            catch
            {
                lblMess.Visible = true;
                lblMess.Text = "Send Email faild";
            }
        }
        void SendMailRestaurant( string resEmail)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();

            MailMessage res = new MailMessage();
            res.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            res.To = resEmail;
            res.Subject = "Message from 212cuisine.com";
            res.Body = "A new user has reserved the gift certificate at YourRestaurant";
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                SmtpMail.Send(res);
                lblMess.Visible = false;
            }
            catch
            {
                lblMess.Visible = true;
                lblMess.Text = "Send Email faild ";
            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (!DataField.CheckValidCreditCard(txtCardNumber.Text.Trim()))
            {
                lblError.Visible = true;
                txtCardNumber.Focus();
                return;
            }
            if (Convert.ToInt32(drpExpMonth.SelectedValue.ToString()) <= DateTime.Now.Month && Convert.ToInt32(drpExYear.SelectedValue.ToString()) <= DateTime.Now.Year)
            {
                lblError1.Visible = true;
                return;
            }
            try
            {
                GiftCertificateInfo giftCertificate = (GiftCertificateInfo)Session[PageConstant.SESSION_GIFT_CERTIFICATE];
                TransactionInfo transaction = new TransactionInfo();
                transaction.CreateDate = DateTime.Now;
                transaction.StatusDate = DateTime.Now;
                transaction.MemberID = Authentication.CurrentMemberInfo.ID;
                transaction.ExpiryDate = DateTime.Now.AddDays(30);
                transaction.RestaurantID = Convert.ToInt32(RestaurantID);
                transaction.Status = PageConstant.STATUS_TRANSACTION_PENDING;
                transaction.SupplierPayment = PageConstant.SUPPLIER_PAYPAL;
                transaction.Tax = 0;
                transaction.TotalPrice = Convert.ToDouble(Session[PageConstant.SESSION_PRICE].ToString());
                transaction.Fee = 0;
                transaction.Type = PageConstant.TRANSACTION_PURCHASE_GIFT;

                RestaurantBusinessAccountInfo restaurant = RestaurantBusinessAccountBLL.GetInfo_ByRestaurantID(transaction.RestaurantID);
                AccountPaymentInfo account = new AccountPaymentInfo();
                account.CardSercurityCode = txtCCV.Text.Trim();
                account.CreditCardNumber = txtCardNumber.Text.Replace("-", "").Replace(" ", "");
                account.ExpiredMonth = Convert.ToInt32(drpExpMonth.SelectedValue.ToString());
                account.ExpiredYear = Convert.ToInt32(drpExYear.SelectedValue.ToString());
                account.NameOnCreditCard = txtHolderName.Text.Trim();
                account.TypeOfCreditCard = drpCardType.SelectedValue.ToString().Trim();
                MemberInfo member = MemberBLL.GetByMemberID(transaction.MemberID);

                IncomeTransactionInfo incomeTran = new IncomeTransactionInfo();
                ParameterInfo paras = ParameterBLL.GetInfo(PageConstant.PARAMETER_GIFT_COMMISSION);
                if (paras.Unit == 1)
                {
                    incomeTran.Price = transaction.TotalPrice * Convert.ToDouble(paras.Value) / 100;
                }
                else
                {
                    incomeTran.Price = Convert.ToDouble(paras.Value);
                }


                transaction.TotalPrice = transaction.TotalPrice - incomeTran.Price;
                string resultPayment = PaymentPaypal.CheckOutTransaction(transaction.TotalPrice, restaurant, account, member);

                AdminBusinessAccountInfo adminAccount = new AdminBusinessAccountInfo();
                Parameters paraPaypal = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_PAYPAL_PARAMETER);
                adminAccount.APIUserName = paraPaypal[PageConstant.PARAMETER_PAYPAL_USERNAME].ToString();
                adminAccount.APIPassword = paraPaypal[PageConstant.PARAMETER_PAYPAL_PASSWORD].ToString();
                adminAccount.APISignature = paraPaypal[PageConstant.PARAMETER_PAYPAL_SIGNATURE].ToString();

                if (!resultPayment.Contains("ERRORNHATNV"))
                {
                    string retVal = PaymentPaypal.CheckOutIncomeTransaction(adminAccount, incomeTran.Price, account);
                    if (!retVal.Contains("ERRORNHATNV"))
                    {
                        transaction.NumberTransaction = resultPayment;
                        int transactionID = TransactionBLL.Insert(transaction);
                        giftCertificate.TransactionID = transactionID;
                        int gc = GiftCertificatesBLL.Insert(giftCertificate);
                        incomeTran.NumberTransaction = retVal;
                        incomeTran.TransactionID = transactionID;
                        IncomeTransactionBLL.Insert(incomeTran);
                        //send mail
                        if (gc > 0)
                        {
                            RestaurantInfo resInfo = RestaurantBLL.GetInfo(Convert.ToInt32(Request.QueryString["RidUrl"]));
                            GiftCertificateInfo gcInfo = GiftCertificatesBLL.GetInfo(gc);
                            SendMailMember();
                            SendMailRestaurant(resInfo.Email);
                            SendMailYourMember(gcInfo.SendGift, Server.MapPath(gcInfo.GiftImageURL));
                        }
                        HttpContext.Current.Session.Abandon();
                        Response.Redirect(PageConstant.HOME_MEMBER_THANK_FOR_USE_GIFT + PageConstant.RESTAURANT_ID + RestaurantID);
                    }
                    else
                    {
                        PaymentPaypal.RefundTransaction(resultPayment, transaction.TotalPrice, Constants.REFUND_FULL_TRANSACTION);
                        MessageBox.Show(retVal.Replace("ERRORNHATNV", ""));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(resultPayment.Replace("ERRORNHATNV", ""));
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Redirect(PageConstant.HOME_URL);
        }
    }
}