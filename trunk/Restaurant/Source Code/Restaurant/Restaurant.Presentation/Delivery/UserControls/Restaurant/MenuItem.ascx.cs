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

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class MenuItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuCategory();
               

            }
        }
        void BindMenuCategory()
        {
            rptMenuCategory.DataSource = MenuCategoryBLL.GetByCategory(Convert.ToInt32(Request.QueryString["MenuCategoryID"]));
            rptMenuCategory.DataBind();
        }

        protected void rptMenuCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptMenuItem = (Repeater)e.Item.FindControl("rptMenuItem");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                int menuCategoryId = Convert.ToInt32(drv["Id"]);

                rptMenuItem.DataSource = MenuItemBLL.GetByMenuCategory(menuCategoryId, 2);
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
                LinkButton lbtShow = (LinkButton)e.Item.FindControl("lbtShow");

                DataRowView drv = (DataRowView)e.Item.DataItem;
                ltPrice1.Text = Convert.ToString(drv["Price1"]);
                if (ltPrice1.Text == "-1")
                    ltPrice1.Text = "";
                else
                    ltPrice1.Text = "$" + string.Format("{0:0.00}", drv["Price1"]);
                ltPrice2.Text = Convert.ToString(drv["Price2"]);
                if (ltPrice2.Text == "-1")
                    ltPrice2.Text = "";
                else
                    ltPrice2.Text = "$" + string.Format("{0:0.00}", drv["Price2"]);
                ltPrice3.Text = Convert.ToString(drv["Price3"]);
                if (ltPrice3.Text == "-1")
                    ltPrice3.Text = "";
                else
                    ltPrice3.Text = "$" + string.Format("{0:0.00}", drv["Price3"]);
            }
        }
    }
}