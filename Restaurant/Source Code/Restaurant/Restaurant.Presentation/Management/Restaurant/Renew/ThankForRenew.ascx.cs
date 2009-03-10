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

namespace Restaurant.Presentation.Management.Restaurant.Renew
{
    public partial class ThankForRenew : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_PROFILE);
        }
    }
}