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

namespace Restaurant.Presentation.Home.Restaurant.UserControls
{
    public partial class LoginForPurchase : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AccountLoginInfo accountLogin = AccountLoginBLL.GetInfo(txtUserName.Text.Trim(),txtPassword.Text.Trim(),true);
            if (accountLogin == null)
            {
                lblError.Visible = true;
                return;
            }
            else
            {
                Authentication.Login(accountLogin.UserName, accountLogin.Password, true);
                string url = Server.UrlDecode(Request.QueryString["NextURL"]);
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
        protected void btnSigup_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_REGISTER_URL + PageConstant.NEXT_URL + Server.UrlEncode(Request.QueryString["NextURL"]));
        }
    }
}