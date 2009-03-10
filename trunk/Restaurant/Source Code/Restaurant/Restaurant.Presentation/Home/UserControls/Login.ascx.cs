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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class Login : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblAlert.Visible = false;
            }
        }

        protected void ibtnLogIn_Click(object sender, ImageClickEventArgs e)
        {
            AccountLoginInfo accountLogin = AccountLoginBLL.GetInfo(txtUsername.Text.Trim(), txtPassword.Text.Trim(), true);
            if (accountLogin == null)
            {
                lblAlert.Visible = true;
            }
            else
            {
               string userName = accountLogin.UserName;
                if (Convert.ToBoolean(MemberBLL.GetByUserName(userName).IsActive) == false)
                {
                    lblError.Visible = true;
                }
                else 
                { 
                Authentication.Login(accountLogin.UserName, accountLogin.Password, true);
                string url = Server.UrlDecode(Request.QueryString[PageConstant.NEXT_URL.Replace("&","").Replace("=","")] );
                if (url != null)
                {
                    Response.Redirect(url);
                }
                else
                {
                    Response.Redirect(PageConstant.HOME_URL);
                }
                }
            }
        }

        protected void btnSignup_Click(object sender, ImageClickEventArgs e)
        {
            string url = Request.QueryString[PageConstant.NEXT_URL.Replace("&", "").Replace("=", "")];
            if (url != null && url != "")
            {
                Response.Redirect(PageConstant.HOME_MEMBER_REGISTER_URL + PageConstant.NEXT_URL + url);
            }
            else
            {

                Response.Redirect(PageConstant.HOME_MEMBER_REGISTER_URL);
            }
        }

        protected void btnRegister_Click(object sender, ImageClickEventArgs e)
        {
            if (Session[PageConstant.SESSION_RESTAURANT_INFO] != null)
            {
                Session[PageConstant.SESSION_RESTAURANT_INFO] = null;
            }
            else if (Session[PageConstant.SESSION_PACKAGE_DETAIL] != null)
            {
                Session[PageConstant.SESSION_PACKAGE_DETAIL] = null;
            }
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
        }
    }
}