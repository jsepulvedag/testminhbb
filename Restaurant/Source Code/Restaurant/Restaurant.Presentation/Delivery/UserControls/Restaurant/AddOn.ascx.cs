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
using Restaurant.Library.Utilities.DataBinder;

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class AddOn : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int mnItemID = Convert.ToInt32(Request.QueryString["menuItemID"]);
                MenuItemInfo menuItemInfo = MenuItemBLL.GetInfo(mnItemID);
                lblmnItemName.Text = menuItemInfo.Name;
               int menuCategoryID = menuItemInfo.MenuCategoryID;
                BindingRepeater(menuCategoryID);
                BindingQuatity();
            }
        }
        private void BindingQuatity()
        {
            string[] count = new string[20];
            for (int i = 0; i < 20; i++)
            {
                count[i] =Convert.ToString(i+1);
            }
            Utility.BindingDropDowList(Utility.CreateTable(count, count), drdQuality);
        }
        private void BindingRepeater(int menuCategoryID)
        {
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

        protected void btnCart_Click(object sender, EventArgs e)
        {

        }
    }
}