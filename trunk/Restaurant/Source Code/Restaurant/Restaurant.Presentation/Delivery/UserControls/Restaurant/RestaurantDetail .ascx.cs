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
    public partial class RestaurantDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restaurantID = Convert.ToInt32(Request.QueryString["restaurantID"]);
                BindRestaurant(restaurantID);
               
            }
        }
        public void BindRestaurant(int restaurantID)
        {
            DataTable tb = RestaurantBLL.GetDetail(restaurantID);
            dtlRestaurantDetail.DataSource=tb;
            dtlRestaurantDetail.DataBind();
        }

        protected void dtlRestaurantDetail_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int restaurantID = Convert.ToInt32(Request.QueryString["restaurantID"]);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbFood = (Label)e.Item.FindControl("lbFood");
                Label lbPrice = (Label)e.Item.FindControl("lbPrice");
                Label lbService = (Label)e.Item.FindControl("lbService");
                Label lbDecor = (Label)e.Item.FindControl("lbDecor");
                string[] rating = ReviewBLL.GetRatingByRestaurant(restaurantID);
                lbFood.Text = Convert.ToString(rating[0]);
                lbPrice.Text = Convert.ToString(rating[1]);
                lbService.Text = Convert.ToString(rating[2]);
                lbDecor.Text = Convert.ToString(rating[3]);
            }
        }


    }
}