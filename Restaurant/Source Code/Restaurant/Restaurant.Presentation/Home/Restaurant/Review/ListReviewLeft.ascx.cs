using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Home.Restaurant.Review
{
    public partial class ListReviewLeft : System.Web.UI.UserControl
    {

        int restaurantID;
        protected void Page_Load(object sender, EventArgs e)
        {
            restaurantID = Convert.ToInt32(Request.QueryString["RestaurantID"].ToString());
            try
            {
                dtlRestaurantInfo.DataSource = RestaurantBLL.GetInfoByRestaurant(restaurantID);
                dtlRestaurantInfo.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtlRestaurantInfo_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rpt = (Repeater)e.Item.FindControl("repeaterDressCode");
                rpt.DataSource = AttireBLL.GetByRestaurantAttire(restaurantID);
                rpt.DataBind();

                Repeater rptGoodFor = (Repeater)e.Item.FindControl("repeaterGoodFor");
                rptGoodFor.DataSource = GoodForBLL.GetByRestaurantGoodFor(restaurantID);
                rptGoodFor.DataBind();

                Repeater rptAtmosphere = (Repeater)e.Item.FindControl("repeaterAtmosphere");
                rptAtmosphere.DataSource = AtmosphereBLL.GetByRestaurantAtmosphere(restaurantID);
                rptAtmosphere.DataBind();

                Repeater rptSpecial = (Repeater)e.Item.FindControl("repeaterSpecial");
                rptSpecial.DataSource = SpecialBLL.GetByRestaurantSpecial(restaurantID);
                rptSpecial.DataBind();

                Repeater rptHour = (Repeater)e.Item.FindControl("repeaterHours");
                rptHour.DataSource = BusinessTimeBLL.GetHoursByRestaurant(restaurantID);
                rptHour.DataBind();
                
            }
        }
    }
}