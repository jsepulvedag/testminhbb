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

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class Logout : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authentication.Logout();
            Response.Redirect(PageConstant.HOME_LOGIN_URL);
        }
    }
}