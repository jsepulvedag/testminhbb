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
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant
{
    public partial class RestaurantContact : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDateTime();
                BindLocal();
                BindCurrentContact();
                if (Authentication.IsLogined && RestaurantID != null && RestaurantID != "" && Authentication.CurrentAccountLogin.Type != PageConstant.ADMIN)
                {
                    RestaurantInfo restaurantInfo = RestaurantBLL.GetInfo(Convert.ToInt32(RestaurantID));
                    ConfirmRestaurant(restaurantInfo);
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_RESTAURANT_CONTACT));
            }
            if (Session[PageConstant.SESSION_RESTAURANT_INFO] == null)
            {
                Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
            }
        }
        private string RestaurantID
        {
            get
            {
                return Request.QueryString[PageConstant.RESTAURANT_ID.Replace("&", "").Replace("=", "")];
            }
        }
        private void BindDateTime()
        {
            string[] monthDisplays = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] monthValues = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            string[] days = new string[31];
            for (int i = 0; i < 31; i++)
            {
                days[i] = Convert.ToString(i + 1);
            }

            string[] years = new string[120];
            for (int i = 0; i < 120; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year - i);
            }

            Utility.BindingDropDowList(Utility.CreateTable(monthValues, monthDisplays), drpCurrentMonth);
            Utility.BindingDropDowList(Utility.CreateTable(days, days), drpCurrentDay);
            Utility.BindingDropDowList(Utility.CreateTable(years, years), drpCurrentYear);
        }
        private void BindLocal()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drpCurrentCountry);
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCurrentCountry.SelectedValue.ToString())), drpCurrentState);
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpCurrentState.SelectedValue.ToString())), drpCurrentCity);
        }
        private void BindCurrentContact()
        {
            if (Authentication.IsLogined && (RestaurantID == null || RestaurantID == "") && Authentication.CurrentAccountLogin.Type != PageConstant.ADMIN)
            {
                txtCurrentFirstName.Text = Authentication.CurrentMemberInfo.FirstName;
                txtCurrentLastName.Text = Authentication.CurrentMemberInfo.LastName;
                txtCurrentAddress.Text = Authentication.CurrentMemberInfo.Address;
                txtCurrentEmail.Text = Authentication.CurrentMemberInfo.Email;
                txtCurrentFax.Text = Authentication.CurrentMemberInfo.Fax;
                txtCurrentPhone.Text = Authentication.CurrentMemberInfo.Phone;
                txtCurrentZipCode.Text = Authentication.CurrentMemberInfo.ZipCode;

                drpCurrentGender.SelectedValue = Authentication.CurrentMemberInfo.Gender;
                drpCurrentMonth.SelectedValue = Authentication.CurrentMemberInfo.Birthday.Month.ToString();
                drpCurrentDay.SelectedValue = Authentication.CurrentMemberInfo.Birthday.Day.ToString();
                drpCurrentYear.SelectedValue = Authentication.CurrentMemberInfo.Birthday.Year.ToString();

                drpCurrentCountry.SelectedValue = Authentication.CurrentMemberInfo.CountryID.ToString();
                drpCurrentCountry.SelectedIndexChanged += new EventHandler(drpCurrentCountry_SelectedIndexChanged);
                drpCurrentState.SelectedValue = Authentication.CurrentMemberInfo.StateID.ToString();
                drpCurrentState.SelectedIndexChanged += new EventHandler(drpCurrentState_SelectedIndexChanged);
                drpCurrentCity.SelectedValue = Authentication.CurrentMemberInfo.CityID.ToString();
            }
        }
        private void ConfirmRestaurant(RestaurantInfo restaurantInfo)
        {
            txtCurrentAddress.Text = restaurantInfo.AddressContact;
            txtCurrentEmail.Text = restaurantInfo.EmailContact;
            txtCurrentFax.Text = restaurantInfo.FaxContact;
            txtCurrentFirstName.Text = restaurantInfo.FirstNameContact;
            txtCurrentLastName.Text = restaurantInfo.LastNameContact;
            txtCurrentPhone.Text = restaurantInfo.PhoneContact;
            txtCurrentZipCode.Text = restaurantInfo.ZipcodeContact;

            drpCurrentCountry.SelectedValue = restaurantInfo.CountryIDContact.ToString();
            drpCurrentCountry_SelectedIndexChanged(drpCurrentCountry, new EventArgs());
            drpCurrentState.SelectedValue = restaurantInfo.StateIDContact.ToString();
            drpCurrentState_SelectedIndexChanged(drpCurrentState, new EventArgs());
            drpCurrentCity.SelectedValue = restaurantInfo.CityIDContact.ToString();

            drpCurrentDay.SelectedValue = restaurantInfo.BirthdayContact.Day.ToString();
            drpCurrentMonth.SelectedValue = restaurantInfo.BirthdayContact.Month.ToString();
            drpCurrentYear.SelectedValue = restaurantInfo.BirthdayContact.Year.ToString();
            drpCurrentGender.SelectedValue = restaurantInfo.GenderContact;
        }
        private void OnSetRestaurant()
        {
            RestaurantInfo info = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
            info.FirstNameContact = txtCurrentFirstName.Text.Trim();
            info.LastNameContact = txtCurrentLastName.Text.Trim();
            info.GenderContact = drpCurrentGender.SelectedValue.ToString();
            info.PhoneContact = txtCurrentPhone.Text.Trim();
            info.ZipcodeContact = txtCurrentZipCode.Text.Trim();
            info.FaxContact = txtCurrentFax.Text.Trim();
            info.EmailContact = txtCurrentEmail.Text.Trim();
            info.BirthdayContact = Convert.ToDateTime(drpCurrentMonth.SelectedValue.ToString() + "/" + drpCurrentDay.SelectedValue.ToString() + "/" + drpCurrentYear.SelectedValue.ToString());
            info.AddressContact = txtCurrentAddress.Text.Trim();
            info.CountryIDContact = Convert.ToInt32(drpCurrentCountry.SelectedValue.ToString());
            info.CityIDContact = Convert.ToInt32(drpCurrentCity.SelectedValue.ToString());
            info.StateIDContact = Convert.ToInt32(drpCurrentState.SelectedValue.ToString());
            Session[PageConstant.SESSION_RESTAURANT_INFO] = info;
        }
        protected void drpCurrentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCurrentCountry.SelectedValue == null)
            {
                return;
            }
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCurrentCountry.SelectedValue.ToString())), drpCurrentState);
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpCurrentState.SelectedValue.ToString())), drpCurrentCity);
        }
        protected void drpCurrentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCurrentCountry.SelectedValue == null)
            {
                return;
            }
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpCurrentState.SelectedValue.ToString())), drpCurrentCity);
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            OnSetRestaurant();
            Response.Redirect(PageConstant.HOME_RESTAURANT_PURCHASE_PACKAGE_URL);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            PackageDetailInfo packageDetail = (PackageDetailInfo)Session[PageConstant.SESSION_PACKAGE_DETAIL];
            Response.Redirect(PageConstant.HOME_RESTAURANT_INFORMATION_URL + PageConstant.PACKAGE_ID + packageDetail.ID.ToString());
        }
    }
}