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
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Management.Member.Profile
{
    public partial class ProfileManagement : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;                       
            BindCountry();
            BindState();
            BindCity();
            BindMonth();
            BindDay();
            BindYear();
            BindMember(Authentication.CurrentAccountLogin.ID);
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drdCountry);
        }
        public void BindState()
        {
            int countryID;
            if (Int32.TryParse(drdCountry.SelectedValue.ToString(), out countryID))
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drdState);
            }
        }
        public void BindCity()
        {
            int stateID;
            if (Int32.TryParse(drdState.SelectedValue.ToString(), out stateID))
            {
                Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drdState.SelectedValue)), drdCity);
            }
        }
        private void BindMonth()
        {
            string[] members = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] values = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            Utility.BindingDropDowList(Utility.CreateTable(values, members), drdMonth);
        }
        private void BindDay()
        {
            string[] members = new string[31];
            string[] values = new string[31];
            for (int i = 0; i <= 30; i++)
            {
                members[i] = Convert.ToString(i + 1);
                values[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(Utility.CreateTable(members, values), drdDate);
        }
        private void BindYear()
        {
            string[] years = new string[120];
            for (int i = 0; i < 120; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year - i);
            }
            Utility.BindingDropDowList(Utility.CreateTable(years, years), drdYear);
        }
        public void BindMember(int MemberID)
        {
            txtEmail.Text = Authentication.CurrentMemberInfo.Email;
            txtFirstName.Text=Authentication.CurrentMemberInfo.FirstName;
            txtLastName.Text = Authentication.CurrentMemberInfo.LastName;
            txtAddress.Text = Authentication.CurrentMemberInfo.Address;
            txtPhone.Text = Authentication.CurrentMemberInfo.Phone;
            drdGender.SelectedValue = Authentication.CurrentMemberInfo.Gender;
            txtZipcode.Text = Authentication.CurrentMemberInfo.ZipCode;
            txtFax.Text = Authentication.CurrentMemberInfo.Fax;
            cbReciveMail.Checked = Authentication.CurrentMemberInfo.IsWantReciveMail;
            drdMonth.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.Birthday.Month);
            drdDate.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.Birthday.Day);
            drdYear.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.Birthday.Year);
            drdCountry.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.CountryID);
            drdCountry.SelectedIndexChanged += new EventHandler(drdCountry_SelectedIndexChanged);
            drdState.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.StateID);
            drdState.SelectedIndexChanged += new EventHandler(drdState_SelectedIndexChanged);
            drdCity.SelectedValue = Convert.ToString(Authentication.CurrentMemberInfo.CityID);
        }
       
        private MemberInfo SetMemberInfo()
        {
            string birthday;
            birthday = drdMonth.SelectedValue.ToString() + "/" + drdDate.SelectedValue.ToString() + "/" + drdYear.SelectedValue.ToString();
            MemberInfo userInfo = new MemberInfo();
            userInfo.Email = txtEmail.Text.Trim();
            userInfo.ID = Authentication.CurrentMemberInfo.ID;
            userInfo.FirstName = txtFirstName.Text.Trim();
            userInfo.LastName = txtLastName.Text.Trim();
            userInfo.Address = txtAddress.Text.Trim();
            userInfo.Phone = txtPhone.Text.Trim();
            userInfo.Gender = drdGender.Text;
            userInfo.IsActive = true;
            userInfo.Birthday = DateTime.Parse(birthday);
            userInfo.ZipCode = txtZipcode.Text.Trim();
            userInfo.Fax = txtFax.Text;
            userInfo.IsWantReciveMail = cbReciveMail.Checked;
            if (drdCountry.Items.Count > 0)
            {
                userInfo.CountryID = Convert.ToInt32(drdCountry.SelectedValue.ToString());
            }
            else
            {
                userInfo.CountryID = 1;
            }
            userInfo.StateID = 1;
            userInfo.CityID = 1;

            return userInfo;

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            int i = MemberBLL.UpdateMember(SetMemberInfo());
            if (i == -1)
            {
                lbEmail.Text = AppEnv.EMAIL_EXIST;
            }
            else
            {
                Authentication.CurrentMemberInfo = SetMemberInfo();
                Response.Redirect("~/Management/Default.aspx?mid=Profile");
            }
        }

        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdCountry.SelectedValue == null)
            {
                return;
            }
            BindState();
            BindCity();
        }

        protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdState.SelectedValue == null)
            {
                return;
            }
            BindCity();
        }
    }
}