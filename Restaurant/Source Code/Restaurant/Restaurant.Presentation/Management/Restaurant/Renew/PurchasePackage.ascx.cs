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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities.Validator;
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities.PayPalAPI;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Management.Restaurant.Renew
{
    public partial class PurchasePackage : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDateTime();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            int temp;
            if (!int.TryParse(PackageDetailID, out temp))
            {
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_CHOOSE_PACKAGE);
            }
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.MANAGEMENT_RESTAURANT_PURCHASE_PACKAGE + PageConstant.PACKAGE_ID + PackageDetailID));
            }
        }
        private string PackageDetailID
        {
            get { return Request.QueryString[PageConstant.PACKAGE_ID.Replace("&", "").Replace("=", "")]; }
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
                PackageDetailInfo packageDetail = PackageDetailBLL.GetInfo(Convert.ToInt32(PackageDetailID));
                AdminBusinessAccountInfo adminAccount = new AdminBusinessAccountInfo();
                Parameters paraPaypal = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_PAYPAL_PARAMETER);
                adminAccount.APIUserName = paraPaypal[PageConstant.PARAMETER_PAYPAL_USERNAME].ToString();
                adminAccount.APIPassword = paraPaypal[PageConstant.PARAMETER_PAYPAL_PASSWORD].ToString();
                adminAccount.APISignature = paraPaypal[PageConstant.PARAMETER_PAYPAL_SIGNATURE].ToString();

                AccountPaymentInfo account = new AccountPaymentInfo();
                account.CardSercurityCode = txtCCV.Text.Trim();
                account.CreditCardNumber = txtCardNumber.Text.Replace("-", "").Replace(" ", "");
                account.ExpiredMonth = Convert.ToInt32(drpExpMonth.SelectedValue.ToString());
                account.ExpiredYear = Convert.ToInt32(drpExYear.SelectedValue.ToString());
                account.TypeOfCreditCard = drpCardType.SelectedValue.ToString().Trim();

                string resultPayment = PaymentPaypal.CheckOutPackage(packageDetail, adminAccount, account, Authentication.CurrentMemberInfo);
                if (resultPayment.Contains("ERRORNHATNV"))
                {
                    MessageBox.Show(resultPayment.Replace("ERRORNHATNV", ""));
                    return;
                }

                RestaurantInfo restaurant = RestaurantBLL.GetInfo(Authentication.CurrentRestaurantInfo.ID);
                restaurant.ExpiryDate = DateTime.Now.AddMonths(packageDetail.ExpiryMonth);

                TransactionInfo transactionInfo = new TransactionInfo();
                transactionInfo.CreateDate = DateTime.Now;
                transactionInfo.Fee = 0;
                transactionInfo.ExpiryDate = DateTime.Now.AddMonths(packageDetail.ExpiryMonth);
                transactionInfo.StatusDate = DateTime.Now;
                transactionInfo.MemberID = Authentication.CurrentMemberInfo.ID;
                transactionInfo.NumberTransaction = resultPayment;
                transactionInfo.Status = PageConstant.STATUS_TRANSACTION_CONFIRMED;
                transactionInfo.SupplierPayment = PageConstant.SUPPLIER_PAYPAL;
                transactionInfo.Tax = 0;
                transactionInfo.TotalPrice = packageDetail.Price;
                transactionInfo.Type = PageConstant.TRANSACTION_PURCHASE_PACKAGE;
                transactionInfo.RestaurantID = restaurant.ID;
                transactionInfo.ID = TransactionBLL.Insert(transactionInfo);

                RestaurantPackageDetailInfo restaurantPackageDetail = new RestaurantPackageDetailInfo();
                restaurantPackageDetail.TransactionID = transactionInfo.ID;
                restaurantPackageDetail.PackageDetailID = packageDetail.ID;

                RestaurantPackageDetailBLL.Update_ByRestaurantIDIsActive(restaurant.ID, false);
                RestaurantPackageDetailBLL.Insert(restaurantPackageDetail);

                RestaurantBLL.Update(restaurant);

                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_THANKS_FOR_RENEW);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE);
        }
    }
}