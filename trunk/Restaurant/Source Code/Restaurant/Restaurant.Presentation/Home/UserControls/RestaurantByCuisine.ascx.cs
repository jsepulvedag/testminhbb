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
    public partial class RestaurantByCuisine : System.Web.UI.UserControl
    {
        void BindCuisine()
        {
            

            rptRestaurantInCuisine.DataSource = CuisineBLL.GetAllForHome();
            rptRestaurantInCuisine.DataBind();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            BindCuisine();
        }

        protected void rptRestaurantInCuisine_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hplListRestaurant = (HyperLink)e.Item.FindControl("hplListRestaurant");
                DataRowView drv = (DataRowView)e.Item.DataItem;
                if (!Request.Url.PathAndQuery.Contains("cityId"))
                {
                    if (Session["cityId"] != null)
                    {
                        hplListRestaurant.NavigateUrl = PageConstant.HOME_RESTAURANT_LISTING_URL + "&CuisineId=" + drv["ID"].ToString() + "&cityId=" + Session["cityId"].ToString();
                    }
                    else
                    {
                        hplListRestaurant.NavigateUrl = PageConstant.HOME_RESTAURANT_LISTING_URL + "&CuisineId=" + drv["ID"].ToString();
                    }
                }
                else
                {
                    hplListRestaurant.NavigateUrl = PageConstant.HOME_RESTAURANT_LISTING_URL + "&CuisineId=" + drv["ID"].ToString() + "&cityId=" + Convert.ToString(Request.QueryString["cityId"]);
                }
            }
        }
    }
}