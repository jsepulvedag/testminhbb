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
using System.IO;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant
{
    public partial class CreateRestaurant : System.Web.UI.UserControl
    {
        #region properties, page_load
        int memberID = 0;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session[PageConstant.SESSION_RESTAURANT_INFO] == null)
            {
                Response.Redirect(PageConstant.ADMIN_ADD_RESTAURANT_MANAGEMENT_URL);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadScript();
            if (!IsPostBack)
            {
                BindDateTime();
                rdoCreateMember.Attributes.Add("onclick", "checkMemberExist('" + rdoCreateMember.ClientID + "','" + rdoExistMember.ClientID + "')");
                rdoExistMember.Attributes.Add("onclick", "checkMemberExist('" + rdoCreateMember.ClientID + "','" + rdoExistMember.ClientID + "')");
            }
        }
        #endregion
        #region Binding  Datetime and get
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
        #endregion
        #region Set Info method
        private RestaurantInfo OnSetRestaurant
        {
            get
            {
                RestaurantInfo info = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
                //restaurant info
                info.MemberID = memberID;

                //contact info
                MemberInfo mbInfo = MemberBLL.GetByMemberID(memberID);
                SetRestaurantContact(mbInfo, info);

                return info;
            }
        }
        private void SetRestaurantContact(MemberInfo mbInfo, RestaurantInfo restaurantInfo)
        {
            #region Restaurant Contact
            restaurantInfo.FirstNameContact = mbInfo.FirstName;
            restaurantInfo.LastNameContact = mbInfo.LastName;
            restaurantInfo.GenderContact = mbInfo.Gender;
            restaurantInfo.BirthdayContact = mbInfo.Birthday;
            restaurantInfo.AddressContact = mbInfo.Address;
            restaurantInfo.CountryIDContact = mbInfo.CountryID;
            restaurantInfo.StateIDContact = mbInfo.StateID;
            restaurantInfo.CityIDContact = mbInfo.CityID;
            restaurantInfo.ZipcodeContact = mbInfo.ZipCode;
            restaurantInfo.PhoneContact = mbInfo.Phone;
            restaurantInfo.FaxContact = mbInfo.Fax;
            restaurantInfo.EmailContact = mbInfo.Email;
            #endregion
        }
        private MemberInfo SetMemberInfo()
        {
            MemberInfo mbInfo = (MemberInfo)Session[PageConstant.SESSION_MEMBER_INFO];           
            mbInfo.UserName = txtUserName.Text.Trim();
            mbInfo.Password = txtPass.Text.Trim();
            RestaurantInfo res = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
            mbInfo.FirstName = res.Name;
            mbInfo.LastName = "";
            mbInfo.Email = res.Email.Trim();
            mbInfo.Gender = drpCurrentGender.SelectedValue.ToString();
            #region Fomat birthday
            mbInfo.Birthday = Convert.ToDateTime((drpCurrentMonth.SelectedValue.Trim()) + "/" + drpCurrentDay.Text.Trim() + "/" + drpCurrentYear.Text.Trim());
            #endregion
            mbInfo.IsWantReciveMail = checkReceiveMail.Checked;           
            mbInfo.ZipCode = res.ZipCode.Trim();
            mbInfo.Fax = res.Fax.Trim();
            mbInfo.Phone = res.Phone1.Trim();
            mbInfo.Address = res.Address.Trim();
            #region Local
            mbInfo.CountryID = res.CountryID;
            mbInfo.StateID = res.StateID;
            mbInfo.CityID = res.CityID;
            #endregion
            return mbInfo;
        }
        #endregion
        #region Event        
        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            if (rdoCreateMember.Checked == true)
            {
                if (txtConfirmPass.Text.Trim().Equals(txtPass.Text.Trim()))
                {
                    memberID = MemberBLL.Insert(SetMemberInfo());
                    if (memberID > 0)
                    {
                        Session[PageConstant.SESSION_RESTAURANT_INFO] = OnSetRestaurant;
                        Response.Redirect(PageConstant.ADMIN_CHOOSE_PACKAGE_URL);
                    }
                    else
                    {
                        lblMess.Visible = true;
                        lblMess.Text = "Member hasn't created. You can register with user, pass and email";
                    }
                }
                else
                {
                    lblMess.Visible = true;
                    lblMess.Text = "Password don't match.";
                }
            }
            else
            {
                MemberInfo mbInfo = MemberBLL.GetInfo(txtUserNameExist.Text.Trim());
                if (mbInfo != null)
                {
                    memberID = mbInfo.ID;
                    Session[PageConstant.SESSION_RESTAURANT_INFO] = OnSetRestaurant;
                    Response.Redirect(PageConstant.ADMIN_CHOOSE_PACKAGE_URL);
                }
                else
                {
                    lblMess.Visible = true;
                    lblMess.Text = "UserName does not exist.";
                }
            }
        }
        #endregion
        private void LoadScript()
        {
            ltrScript.Text += "<script language=javascript>";
            ltrScript.Text += "checkMemberExist('" + rdoCreateMember.ClientID + "','" + rdoExistMember.ClientID + "')";
            ltrScript.Text += "</script>";
        }
    }
}