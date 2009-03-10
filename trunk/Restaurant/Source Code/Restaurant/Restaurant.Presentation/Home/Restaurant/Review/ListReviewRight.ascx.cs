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

namespace Restaurant.Presentation.Home.Restaurant.Review
{
    public partial class ListReviewRight : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkYourRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
        }
    }
}