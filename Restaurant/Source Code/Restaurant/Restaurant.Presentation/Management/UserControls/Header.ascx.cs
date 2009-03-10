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

namespace Restaurant.Presentation.Member.UserControls
{
    public partial class Header : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();

                lnkHome.NavigateUrl = PageConstant.HOME_URL;
                lnkRestaurantOwnerProgram.NavigateUrl = PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL;
            }
        }

        void InitControls()
        {
            if (Authentication.IsLogined && Authentication.CurrentAccountLogin != null)
            {                
                //if (Authentication.CurrentAccountLogin.Type == PageConstant.MEMBER)
                //{
                    lblHi.Text = "Wellcome, " + Authentication.CurrentAccountLogin.FullName + "!";
                    lnkBtnViewProfile.Text = "My profile |";
                    lnkBtnViewProfile.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE;
                    lnkBtnLogin.Text = "Logout";
                    lnkBtnLogin.NavigateUrl = PageConstant.HOME_LOGOUT_URL;
                //}
                //else if (Authentication.CurrentAccountLogin.Type == PageConstant.RESTAURANT)
                //{
                //    lblHi.Text = "Wellcome, " + Authentication.CurrentAccountLogin.FullName + "!";
                //    lnkBtnViewProfile.Visible = false;
                //    lnkBtnLogin.Text = "Logout";
                //    lnkBtnLogin.NavigateUrl = PageConstant.HOME_LOGOUT_URL;
                //}
            }
            else
            {
                lblHi.Text = "New user ?";
                lnkBtnViewProfile.Text = "Create new account |";
                lnkBtnViewProfile.NavigateUrl = PageConstant.HOME_MEMBER_TERM_OF_USE_URL;
                lnkBtnLogin.Text = "Login";
                lnkBtnLogin.NavigateUrl = PageConstant.HOME_LOGIN_URL;
            }           
        }
    }
}