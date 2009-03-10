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

namespace Restaurant.Presentation.Member.UserControls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ftLnkHome.NavigateUrl = PageConstant.HOME_URL;
                ftLnkRestaurantOwnerProgram.NavigateUrl = PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL;
            }
        }
    }
}