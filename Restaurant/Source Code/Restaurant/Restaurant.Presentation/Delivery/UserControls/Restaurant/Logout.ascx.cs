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

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class Logout : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Authentication.Logout();
            Response.Redirect("~/Delivery/Default.aspx");
        }
    }
}