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
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               int restaurantID=Convert.ToInt32( Request.QueryString["restaurantID"]);
               BindMenu(restaurantID, 1);
            }
        }
        public void BindMenu(int restaurantID,int isActive)
        {
            DataTable tb = MenuCategoryBLL.GetByRestaurant(restaurantID, isActive);
            dtlMenu.DataSource = tb;
            dtlMenu.DataBind();
        }
    }
}