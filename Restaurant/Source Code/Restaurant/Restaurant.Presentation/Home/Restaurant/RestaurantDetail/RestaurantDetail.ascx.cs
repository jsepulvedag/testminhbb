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
using Restaurant.Library.Utilities.Encrypt;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Home.Restaurant.RestaurantDetail
{
    public partial class RestaurantDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int restaurantId = Convert.ToInt32(Request.QueryString["RidUrl"]);
            BindRestaurantDetail(restaurantId);
        }

        public void dlRestaurantDetail_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int restaurantId = Convert.ToInt32(Request.QueryString["RidUrl"]);
                DataList dtlCuisine = (DataList)e.Item.FindControl("dtlCuisine");
                DataList dtlNeighbourhood = (DataList)e.Item.FindControl("dtlNeighbourhood");
                DataTable tbl = CuisineBLL.GetByRestaurantID(restaurantId);
                dtlCuisine.DataSource = tbl;
                dtlCuisine.DataBind();
                DataTable tbl1 = NeighbourhoodBLL.GetByRestaurantID(restaurantId);
                dtlNeighbourhood.DataSource = tbl1;
                dtlNeighbourhood.DataBind();
            }
        }

        public void BindRestaurantDetail(int restaurantID)
        {
            int restaurantId = Convert.ToInt32(Request.QueryString["RidUrl"]);
            DataTable tbl = RestaurantBLL.GetDetail(restaurantId);
            dlRestaurantDetail.DataSource = tbl;
            dlRestaurantDetail.DataBind();
        }
    }
}