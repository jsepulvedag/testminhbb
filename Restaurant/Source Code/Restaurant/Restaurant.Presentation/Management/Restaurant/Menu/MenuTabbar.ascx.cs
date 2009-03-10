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

namespace Restaurant.Presentation.Management.Restaurant.Menu
{
    public partial class MenuTabbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string restaurantID = Request.QueryString["RidUrl"];
            lbMenuCategry.NavigateUrl = PageConstant.MANAGEMENT_RESTAURAN_MENUCATEGORY ;
            lbMenuItem.NavigateUrl = PageConstant.MANAGEMENT_RESTAURAN_MENUITEM;
        }
    }
}