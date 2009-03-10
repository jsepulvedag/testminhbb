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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using System.IO;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Management.Restaurant.Menu
{
    public partial class MenuItem : AuthenticateControl
    {
        static int menuItemID;
        public int GetMenuItemID
        {
            get
            {
                return menuItemID;
            }
        }
        static int menuCategoryID;
        public int GetRestaurantID
        {
            get
            {
                return Authentication.CurrentRestaurantInfo.ID;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            BindingDropMenuCategory();
            BindMenuCategory();
        }
        private void AddFirstListItem(ref DropDownList ddl, string str)
        {
            ListItem lst = new ListItem(str, "0");
            ddl.Items.Insert(0, lst);
            ddl.SelectedIndex = 0;
        }
        private void BindingDropMenuCategory()
        {
            dropCategoryName.DataSource = MenuCategoryBLL.GetByRestaurant(GetRestaurantID, 2);
            dropCategoryName.DataTextField = "Name";
            dropCategoryName.DataValueField = "ID";
            dropCategoryName.DataBind();

            dropCategoryEdit.DataSource = MenuCategoryBLL.GetByRestaurant(GetRestaurantID, 2);
            dropCategoryEdit.DataTextField = "Name";
            dropCategoryEdit.DataValueField = "ID";
            dropCategoryEdit.DataBind();

            AddFirstListItem(ref dropCategoryName, "All");
        }
        void BindMenuCategory()
        {
            if (dropCategoryName.SelectedValue.Equals("0"))
            {
                rptMenuCategory.DataSource = MenuCategoryBLL.GetByRestaurant(GetRestaurantID, 2);
                rptMenuCategory.DataBind();
                panelMenuItem.Visible = false;
                btnAdd.Enabled = false;
            }
            else
            {
                if (Convert.ToInt32(dropCategoryName.SelectedValue) > 0)
                {
                    rptMenuCategory.DataSource = MenuCategoryBLL.GetByCategory(Convert.ToInt32(dropCategoryName.SelectedValue));
                    rptMenuCategory.DataBind();
                    panelMenuItem.Visible = false;
                    btnAdd.Enabled = false;
                }
            }
        }
        private void BindMenuItem(MenuItemInfo mnItemInfo)
        {
            txtName.Text = mnItemInfo.Name;
            txtPrice1.Text = Convert.ToString(mnItemInfo.Price1);
            txtPrice2.Text = Convert.ToString(mnItemInfo.Price2);
            txtPrice3.Text = Convert.ToString(mnItemInfo.Price3);
            txtShortDescription.Text = mnItemInfo.ShortDescription;
            txtFullDescription.Text = mnItemInfo.FullDescription;
            dropCategoryEdit.SelectedValue = Convert.ToString(mnItemInfo.MenuCategoryID);
        }
        private MenuItemInfo SetMenuItem(int _menuItemID)
        {
            MenuItemInfo menuItemInfo = new MenuItemInfo();
            menuItemInfo.ID = _menuItemID;
            menuItemInfo.MenuCategoryID = menuCategoryID;

            menuItemInfo.Name = txtName.Text.Trim();
            if (!txtPrice1.Text.Equals(""))
                menuItemInfo.Price1 = Convert.ToDouble(txtPrice1.Text.Trim()) > 0 ? Convert.ToDouble(txtPrice1.Text.Trim()) : 0;
            else
                menuItemInfo.Price1 = -1;
            if (!txtPrice2.Text.Equals(""))
            menuItemInfo.Price2 = Convert.ToDouble(txtPrice2.Text.Trim())>0 ?Convert.ToDouble(txtPrice2.Text.Trim()):0;
            else
                menuItemInfo.Price2 = -1;
            if (!txtPrice3.Text.Equals(""))
                menuItemInfo.Price3 = Convert.ToDouble(txtPrice3.Text.Trim())>0?Convert.ToDouble(txtPrice3.Text.Trim()):0;
            else
            menuItemInfo.Price3 = -1;
            menuItemInfo.ShortDescription = txtShortDescription.Text.Trim();
            menuItemInfo.FullDescription = txtFullDescription.Text.Trim();
            menuItemInfo.MenuCategoryID = Convert.ToInt32(dropCategoryEdit.SelectedValue);
            menuItemInfo.Image = "No image";
            if (fileuploadImage.PostedFile.ContentLength != 0)
            {
                menuItemInfo.Image = DateTime.Now.ToString().Replace(":", " ").Replace("/", "_") + fileuploadImage.PostedFile.FileName;
                DirectoryInfo path = new DirectoryInfo(Server.MapPath("~/Media/TempImage/"));
                if (!path.Exists)
                {
                    path.Create();
                }
                fileuploadImage.PostedFile.SaveAs(path + menuItemInfo.Image);
            }
            menuItemInfo.CreatedDate = DateTime.Now;
            menuItemInfo.IsActive = true;
            menuItemInfo.Views = 0;
            return menuItemInfo;
        }
        private void RefreshControl()
        {
            txtFullDescription.Text = "";
            txtName.Text = "";
            txtPrice1.Text = "";
            txtPrice2.Text = "";
            txtPrice3.Text = "";
            txtShortDescription.Text = "";
        }

        #region Event
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

                //ltPrice1.Text = drv["Price1"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price1"]) : "";
                //ltPrice2.Text = drv["Price2"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price2"]) : "";
                //ltPrice3.Text = drv["Price3"] != DBNull.Value ? "$" + string.Format("{0:0.00}", drv["Price3"]) : "";
                ltPrice1.Text =Convert.ToString( drv["Price1"]);
                if (ltPrice1.Text == "-1")
                    ltPrice1.Text = "";
                else
                    ltPrice1.Text = "$" + string.Format("{0:0.00}", drv["Price1"]);
                ltPrice2.Text = Convert.ToString(drv["Price2"]);
                if (ltPrice2.Text == "-1")
                    ltPrice2.Text = "";
                else
                    ltPrice2.Text = "$" + string.Format("{0:0.00}", drv["Price2"]);
                ltPrice3.Text =Convert.ToString( drv["Price3"]);
                if ( ltPrice3.Text == "-1")
                    ltPrice3.Text = "";
                else
                    ltPrice3.Text = "$" + string.Format("{0:0.00}", drv["Price3"]);
                if (drv["ISActive"].ToString().Equals("True"))
                {
                    lbtShow.CommandName = "Hide";
                    lbtShow.Text = "Hide";
                }
                else
                {
                    if (drv["ISActive"].ToString().Equals("False"))
                    {
                        lbtShow.CommandName = "Show";
                        lbtShow.Text = "Show";
                    }
                }
            }
        }
        protected void rptMenuItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Trim().Equals("EditMenuItem"))
            {
                panelMenuItem.Visible = true;
                menuItemID = Convert.ToInt32(e.CommandArgument);
                MenuItemInfo _mnItemInfo = MenuItemBLL.GetInfo(menuItemID);
                menuCategoryID = _mnItemInfo.MenuCategoryID;
                BindMenuItem(_mnItemInfo);
                return;
            }
            if (e.CommandName.Trim().Equals("DropMenuItem"))
            {
                panelMenuItem.Visible = false;
                MenuItemInfo _mnItemInfo = MenuItemBLL.GetInfo(Convert.ToInt32(e.CommandArgument));
                _mnItemInfo.IsActive = false;
                if (MenuItemBLL.Update(_mnItemInfo))
                {
                    BindMenuCategory();
                }
                return;
            }
            if (e.CommandName.Trim().Equals("Down"))
            {
                if (MenuItemBLL.UpdateDown(Convert.ToInt32(e.CommandArgument)))
                {
                    BindMenuCategory();
                }
                return;
            }
            if (e.CommandName.Trim().Equals("Up"))
            {
                if (MenuItemBLL.UpdateUp(Convert.ToInt32(e.CommandArgument)))
                {
                    BindMenuCategory();
                }
                return;
            }
            if (e.CommandName.Trim().Equals("Show"))
            {
                panelMenuItem.Visible = false;
                MenuItemInfo _mnItemInfo = MenuItemBLL.GetInfo(Convert.ToInt32(e.CommandArgument));
                _mnItemInfo.IsActive = true;
                if (MenuItemBLL.Update(_mnItemInfo))
                {
                    BindMenuCategory();
                }
                return;
            }
            if (e.CommandName.Trim().Equals("Hide"))
            {
                panelMenuItem.Visible = false;
                MenuItemInfo _mnItemInfo = MenuItemBLL.GetInfo(Convert.ToInt32(e.CommandArgument));
                _mnItemInfo.IsActive = false;
                if (MenuItemBLL.Update(_mnItemInfo))
                {
                    BindMenuCategory();
                }
                return;
            }
            
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (MenuItemBLL.Update(SetMenuItem(GetMenuItemID)))
            {
                BindMenuCategory();
            }
        }
        protected void dropCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMenuCategory();
        }
        protected void btnAddMNItem_Click(object sender, EventArgs e)
        {
            RefreshControl();
            panelMenuItem.Visible = true;
            btnAdd.Enabled = true;
            Button1.Enabled = false;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.Trim().Equals(""))
            {
                int _mnItemID = MenuItemBLL.Insert(SetMenuItem(0));
                BindMenuCategory();
            }
            else
            {
                lblMess.Visible = true;
            }
        }
        #endregion
    }

}