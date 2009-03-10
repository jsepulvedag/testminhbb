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

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
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

        protected void bntLogin_Click(object sender, EventArgs e)
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
                    string url = Server.UrlDecode(Request.QueryString[PageConstant.NEXT_URL.Replace("&", "").Replace("=", "")]);
                    if (url != null)
                    {
                        Response.Redirect(url);
                    }
                    else
                    {
                        Response.Redirect("~/Delivery/Default.aspx");
                    }
                }
            }
        }
    }
}