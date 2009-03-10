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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Home.Restaurant.GiftCertificates
{
    public partial class ThankForUseMyGiftService : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RestaurantInfo restaurant = RestaurantBLL.GetInfo(Convert.ToInt32(Request.QueryString["RidUrl"]));
                lbl.Text = restaurant.Name + "'s " + "Restaurant thanks for use my gift service";
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.MANAGEMENT_MEMBER_MY_GIFT);
        }
    }
}