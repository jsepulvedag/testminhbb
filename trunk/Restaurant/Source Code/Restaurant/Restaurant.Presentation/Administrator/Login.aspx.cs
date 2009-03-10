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
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Administrator
{
    public partial class Login : AuthenticatePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
            }
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            AccountLoginInfo accountLogin = AccountLoginBLL.GetInfo(txtUserName.Text.Trim(), txtPassword.Text.Trim(), true);
            if (accountLogin == null)
            {
                lblAlert.Visible = true;
                return;
            }
            if (accountLogin != null && accountLogin.Type == PageConstant.ADMIN)
            {
                Login(accountLogin.UserName, accountLogin.Password, true);
                if (Request.QueryString[PageConstant.NEXT_URL.Replace("&","").Replace("=","")] != null)
                {
                    Response.Redirect(Server.UrlDecode(Request.QueryString[PageConstant.NEXT_URL.Replace("&", "").Replace("=", "")]));
                }
                Response.Redirect(PageConstant.ADMIN_PROFILE_URL);
            }
        }
    }
}
