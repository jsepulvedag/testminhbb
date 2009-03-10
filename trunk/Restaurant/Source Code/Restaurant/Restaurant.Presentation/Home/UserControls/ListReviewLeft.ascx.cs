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
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class ListReviewLeft : System.Web.UI.UserControl
    {
        int restaurantID;
        protected void Page_Load(object sender, EventArgs e)
        {
            restaurantID = Convert.ToInt32(Request.QueryString["RidUrl"].ToString());
            if (RestaurantBLL.GetInfoByRestaurant(restaurantID).Rows.Count > 0)
            {
                dtlRestaurantInfo.DataSource = RestaurantBLL.GetInfoByRestaurant(restaurantID);
                dtlRestaurantInfo.DataBind();
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
                
                HyperLink hplViewPhoto = (HyperLink)e.Item.FindControl("hplViewPhoto");
                hplViewPhoto.NavigateUrl=PageConstant.HOME_LIST_PHOTO_URL + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"].ToString();
                
            }

        }
    }
}