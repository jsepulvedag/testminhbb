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

namespace Restaurant.Presentation.Home.Restaurant.Menu
{
    public partial class Menu : System.Web.UI.UserControl
    {
        public int GetRestaurantID
        {
            get
            {
                return Request.QueryString["RidUrl"] != null ? Convert.ToInt32(Request.QueryString["RidUrl"]) : 0;
            }
        }
        void BindMenuCategory()
        {
            int restaurantId = GetRestaurantID;
            rptMenuCategory.DataSource = MenuCategoryBLL.GetByRestaurant(restaurantId,1);
            rptMenuCategory.DataBind();
        }
        //void BindMenuAddonGroup(int menuCategoryID)
        //{
        //    rptMenuAddonGroup.DataSource=MenuAddonGroupBLL.GetByMenuCategory(menuCategoryID,1);
        //    rptMenuAddonGroup.DataBind();
        //    if (rptMenuAddonGroup.Items.Count > 0)
        //    {
        //        rptMenuAddonGroup.Visible = true;
        //    }
        //    else
        //    {
        //        rptMenuAddonGroup.Visible=false;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            BindMenuCategory();
        }

        protected void rptMenuCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptMenuItem = (Repeater)e.Item.FindControl("rptMenuItem");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                int menuCategoryId = Convert.ToInt32(drv["Id"]);

                rptMenuItem.DataSource = MenuItemBLL.GetByMenuCategory(menuCategoryId, 1);
                rptMenuItem.DataBind();
            }
        }

        protected void rptMenuItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltPrice1 = (Literal)e.Item.FindControl("ltPrice1");
                Literal ltPrice2 = (Literal)e.Item.FindControl("ltPrice2");
                Literal ltPrice3 = (Literal)e.Item.FindControl("ltPrice3");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                ltPrice1.Text = drv["Price1"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price1"]) : "";
                ltPrice2.Text = drv["Price2"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price2"]) : "";
                ltPrice3.Text = drv["Price3"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price3"]) : "";
            }
        }
        protected void rptMenuAddonGroup_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptMenuAddon = (Repeater)e.Item.FindControl("rptMenuAddon");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                int menuAddonGroupId = Convert.ToInt32(drv["Id"]);

                rptMenuAddon.DataSource = MenuAddonBLL.GetByMenuAddonGroup(menuAddonGroupId,1);
                rptMenuAddon.DataBind();
            }
        }

        protected void rptMenuCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "SelectMenuAddonGroup")
            //{
            //    BindMenuAddonGroup(Convert.ToInt32(e.CommandArgument));
            //}
        }

        protected void rptMenuAddon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltPriceAddon = (Literal)e.Item.FindControl("ltPriceAddon");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                ltPriceAddon.Text = drv["Price"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price"]) : "";
            }
        }
    }
}