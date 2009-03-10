using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Management.Restaurant.UserControls
{
    public class CheckRestaurant : AuthenticateControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.CurrentRestaurantInfo.IsActive)
            {
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_BLOCK);
            }
            else if (Authentication.CurrentRestaurantInfo.CreatedByAdmin)
            {
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_YOUR_RESTAURANT);
            }
            else if (Authentication.CurrentRestaurantInfo.ExpiryDate.CompareTo(DateTime.Now) < 0)
            {
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_RENEW);
            }
        }
    }
}
