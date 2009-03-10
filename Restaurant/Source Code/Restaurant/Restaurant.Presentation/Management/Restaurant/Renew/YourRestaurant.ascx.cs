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
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Management.Restaurant.Renew
{
    public partial class YourRestaurant : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL + PageConstant.RESTAURANT_ID + Authentication.CurrentRestaurantInfo.ID);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE);
        }
    }
}