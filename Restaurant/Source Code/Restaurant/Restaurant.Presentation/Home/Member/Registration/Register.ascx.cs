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

namespace Restaurant.Presentation.Home.Member.Registration
{
    public partial class Register : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindState();
                BindCity();
                BindMonth();
                BindDay();
                BindYear();
            }
        }
        public void BindCountry()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drdCountry);
        }
        public void BindState()
        {
            int countryID = Convert.ToInt32(drdCountry.SelectedValue);
            Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drdState);
        }
        public void BindCity()
        {
            int stateID = Convert.ToInt32(drdState.SelectedValue);
            Utility.BindingDropDowList(CityBLL.GetByStateID(stateID), drdCity);
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
        private MemberInfo SetMemberInfo()
        {
            string birthday;
            birthday = drdMonth.SelectedValue.ToString() + "/" + drdDate.SelectedValue.ToString() + "/" + drdYear.SelectedValue.ToString();
            MemberInfo userInfo = new MemberInfo();
            userInfo.UserName = txtUseName.Text.Trim();
            userInfo.Password = txtPassword.Text.Trim();
            userInfo.Email = txtEmail.Text.Trim();
            userInfo.FirstName = txtFirstName.Text.Trim();
            userInfo.LastName = txtLastName.Text.Trim();
            userInfo.Address = txtAddress.Text.Trim();
            userInfo.Phone = txtPhone.Text.Trim();
            userInfo.Gender = drdGender.Text;
            userInfo.Birthday = DateTime.Parse(birthday);
            userInfo.ZipCode = txtZipcode.Text.Trim();
            userInfo.Fax = txtFax.Text;
            userInfo.IsWantReciveMail = cbReciveMail.Checked;
            userInfo.CountryID = Convert.ToInt32(drdCountry.SelectedValue.ToString());
            userInfo.StateID = Convert.ToInt32(drdState.SelectedValue.ToString());
            userInfo.CityID = Convert.ToInt32(drdCity.SelectedValue.ToString());
            return userInfo;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (CheckTerm.Checked == true)
                {
                    lbCheck.Visible = false;

                    i = MemberBLL.Insert(SetMemberInfo());
                    if (i == -1)
                    {
                        lbUsename.Text = AppEnv.USERNAME_EXIST;
                    }
                    else if (i == -2)
                    {
                        lbEmail.Text = AppEnv.EMAIL_EXIST;
                    }
                    else if (i == 0)
                    {
                        MessageBox.Show(AppEnv.INSERTED_FAILURE);
                    }
                    else if (i > 0)
                    {
                        string url = Request.QueryString[PageConstant.NEXT_URL.Replace("&", "").Replace("=", "")];
                        if (url != null && url != "")
                        {
                            Authentication.Login(txtUseName.Text.Trim(), MD5.Encrypt(txtPassword.Text.Trim()), true);
                            Response.Redirect(url);
                        }
                        else
                        {
                            Response.Redirect(PageConstant.HOME_MEMBER_SUCCESSFULL_URL);
                        }
                    }
                }
                else if (CheckTerm.Checked == false)
                {
                    lbCheck.Visible = true;
                    lbCheck.Text = "You don't accept condition?";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_URL);
        }

        protected void drdCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindState();
            BindCity();
        }

        protected void drdState_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void CheckTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckTerm.Checked == false)
            {
                lbCheck.Visible = true;
                lbCheck.Text = "*";
                btnRegister.Enabled = false;
            }
            else
            {
                lbCheck.Visible = false;
                btnRegister.Enabled = true;
            }
        }
    }
}