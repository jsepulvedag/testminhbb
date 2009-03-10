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
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Home.Restaurant.Menu
{
    public partial class MenuItem : System.Web.UI.UserControl
    {
        int menuCategoryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            int mnItemID = Convert.ToInt32(Request.QueryString["menuItemId"]);
            MenuItemInfo menuItemInfo = MenuItemBLL.GetInfo(mnItemID);
            lblmnItemName.Text = menuItemInfo.Name;
            lblmnItemDescription.Text = menuItemInfo.ShortDescription;
            imgItem.ImageUrl = menuItemInfo.Image;
            menuCategoryID = menuItemInfo.MenuCategoryID;
            BindingRepeater();
        }
        private void BindingRepeater()
        {
            int restaurantId = Request.QueryString["RidUrl"] != null ? Convert.ToInt32(Request.QueryString["RidUrl"]) : 0;
            Repeater1.DataSource = MenuAddonGroupBLL.GetByMenuCategory(menuCategoryID, 1);
            Repeater1.DataBind();
        }

     
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButtonList rdoListAddon = (RadioButtonList)e.Item.FindControl("rdoListAddon");
                DataRowView drv = (DataRowView)e.Item.DataItem;

                int menuItemID = Convert.ToInt32(drv["Id"]);
                rdoListAddon.DataSource = MenuAddonBLL.GetByMenuAddonGroup(menuItemID, 1);
                rdoListAddon.DataTextField = "GroupName";
                rdoListAddon.DataBind();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {

        }
    }
}