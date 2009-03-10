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

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class Header : AuthenticateControl
    {
        int ctID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lnkHome.NavigateUrl = PageConstant.HOME_URL;
                lnkRestaurantOwnerProgram.NavigateUrl = PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL;

                InitControls();
                BindCity();
            }
        }
        void BindCity()
        {
            
            Utility.BindingDropDowList(CityBLL.GetAll(ref ctID),drpCity);
            ListItem it= new ListItem("--All City--","0");
            drpCity.Items.Insert(0,it);

            drpCity.SelectedValue = ctID.ToString();
            if (Request.Url.PathAndQuery.Contains("cityId"))
            {
                drpCity.SelectedValue= Request.QueryString["cityId"].ToString();
            }
            Session["cityId"] = drpCity.SelectedValue;
        }
        void InitControls()
        {
            if (Authentication.IsLogined && Authentication.CurrentAccountLogin != null)
            { 
                lblHi.Text = "Welcome, " + Authentication.CurrentAccountLogin.FullName + "!";
                lnkBtnViewProfile.Text = "My profile |";
                if (Authentication.CurrentAccountLogin.Type == PageConstant.MEMBER)
                {
                    lnkBtnViewProfile.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE;
                }
                else if (Authentication.CurrentAccountLogin.Type == PageConstant.RESTAURANT)
                {
                    lnkBtnViewProfile.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_PROFILE;
                }
                else
                {
                    lnkBtnViewProfile.NavigateUrl = PageConstant.ADMIN_PROFILE_URL;
                }
                lnkBtnLogin.Text = "Logout";
                lnkBtnLogin.NavigateUrl = PageConstant.HOME_LOGOUT_URL;
            }
            else
            {
                lblHi.Text = "New user ?";
                lnkBtnViewProfile.Text = "Create new account |";
                lnkBtnViewProfile.NavigateUrl = PageConstant.HOME_MEMBER_REGISTER_URL;
                lnkBtnLogin.Text = "Login";
                lnkBtnLogin.NavigateUrl = PageConstant.HOME_LOGIN_URL;
            }           
        }

        protected void drpCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_URL + "?cityId=" + Convert.ToString(drpCity.SelectedValue));
        }
    }
}