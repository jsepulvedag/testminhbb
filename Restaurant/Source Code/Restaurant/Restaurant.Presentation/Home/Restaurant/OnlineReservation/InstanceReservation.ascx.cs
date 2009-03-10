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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Home.Restaurant.OnlineReservation
{
    public partial class InstanceReservation : AuthenticateControl//UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                BindRegion();
                if (Authentication.IsLogined)
                {
                    BindMemberInfo();
                }
                radDateReservation.SelectedDate = DateTime.Now;
            }
        }
        void BindMemberInfo()
        {
            txtFirstName.Text = Authentication.CurrentMemberInfo.FirstName;
            txtLastName.Text = Authentication.CurrentMemberInfo.LastName;
            txtAddress.Text = Authentication.CurrentMemberInfo.Address;
            txtPhone.Text = Authentication.CurrentMemberInfo.Phone;
            txtFax.Text = Authentication.CurrentMemberInfo.Fax;
            txtEmail.Text = Authentication.CurrentMemberInfo.Email;

            try
            {
                listGender.SelectedValue = Authentication.CurrentMemberInfo.Gender;
                listCountry.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.CountryID);
                BindState();
                listState.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.StateID);
                BindCity();
            }
            catch { }
        }
        private void BindRegion()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(true), listCountry);
            BindState();
            BindCity();
        }

        private void BindState()
        {
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(listCountry.SelectedValue.ToString()),true), listState);
        }

        private void BindCity()
        {
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(listState.SelectedValue.ToString()),true), listCity);
        }

        private ReservationInfo OnSetReservation
        {
            get
            {
                ReservationInfo obj = new ReservationInfo();
                obj.CustomerAddress = txtAddress.Text.Trim();
                obj.CustomerCityID = Convert.ToInt32(listCity.SelectedValue.ToString());
                obj.CustomerCountryID = Convert.ToInt32(listCountry.SelectedValue.ToString());
                obj.CustomerStateID = Convert.ToInt32(listState.SelectedValue.ToString());
                obj.CustomerEmail = txtEmail.Text.Trim();
                obj.CustomerFax = txtFax.Text.Trim();
                obj.CustomerFirstName = txtFirstName.Text.Trim();
                obj.CustomerGender = listGender.SelectedValue.ToString();
                obj.CustomerLastName = txtLastName.Text.Trim();
                obj.CustomerPhone = txtPhone.Text.Trim();
                obj.ReserDate = radDateReservation.SelectedDate;
                obj.ReserDescription = txtReDescription.Text.Trim();
                obj.Status = PageConstant.STATUS_NOT_REALIZED;
                obj.ConfirmationCode = "nhatnv";
                return obj;
            }
        }
        private TransactionInfo OnSetTransaction
        {
            get
            {
                TransactionInfo tran = new TransactionInfo();
                tran.CreateDate = DateTime.Now;
                tran.ExpiryDate = DateTime.Now;
                tran.Fee = 0;
                tran.NumberTransaction = "Successful";
                tran.RestaurantID = Convert.ToInt32(Request.QueryString[PageConstant.RESTAURANT_ID.Replace("&", "").Replace("=", "")]);
                tran.Status = PageConstant.STATUS_TRANSACTION_PENDING;
                tran.StatusDate = DateTime.Now;
                tran.SupplierPayment = PageConstant.SUPPLIER_PAYPAL;
                tran.Tax = 0;
                tran.TotalPrice = 0;
                tran.Type = PageConstant.TRANSACTION_PURCHASE_RESERVATION;
                return tran;
            }
        }
        private bool CheckReservation()
        {
            if (radDateReservation.SelectedDate.CompareTo(DateTime.Now) <= 0)
            {
                return false;
            }
            return true;
        }
        protected void listCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCountry.SelectedValue == null)
            {
                return;
            }
            //Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(listCountry.SelectedValue.ToString())), listState);
            //listState_SelectedIndexChanged(listState, new EventArgs());
            BindState();
            BindCity();
        }
        protected void listState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listState.SelectedValue == null)
            {
                return;
            }
            //Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(listState.SelectedValue.ToString())), listCity);
            BindCity();
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckReservation())
            {
                MessageBox.Show("Date and time of reservation invalid");
                return;
            }
            Session[PageConstant.SESSION_TRANSACTION] = OnSetTransaction;
            Session[PageConstant.SESSION_RESERVATION] = OnSetReservation;
            Response.Redirect(PageConstant.HOME_MEMBER_PROCESS_RESERVATION );
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindRegion();
            radDateReservation.SelectedDate = DateTime.Now;
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtReDescription.Text = "";
        }
    }
}