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
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using System.IO;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Management.Restaurant.Menu
{
    public partial class MenuCategory : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int active = -1;
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                BindMenuCategory(restaurantID, active);
                hlAddMenuCat.NavigateUrl = "~/Management/Default.aspx?mid=AddMenuCategory&restaurantID=" + restaurantID;
            }

        }
        public void BindMenuCategory(int restaurantID, int active)
        {
            DataTable tbl = MenuCategoryBLL.GetByRestaurant(restaurantID, active);
            grvMenuCat.DataSource = tbl;
            grvMenuCat.DataBind();
        }
        public MenuCategoryInfo GetMenuCategory(int menuCategoryID)
        {
            MenuCategoryInfo reval = new MenuCategoryInfo();
            reval = MenuCategoryBLL.GetInfo(menuCategoryID);
            return reval;
        }
        public void BindMenuCategoryInfo(int menuCategoryID)
        {
            txtName.Text = Convert.ToString(GetMenuCategory(menuCategoryID).Name);
            txtDescription.Text = GetMenuCategory(menuCategoryID).Description;
            txtPrHeading1.Text = GetMenuCategory(menuCategoryID).PriceHeading1;
            txtPrHeading2.Text = GetMenuCategory(menuCategoryID).PriceHeading2;
            txtPrHeading3.Text = GetMenuCategory(menuCategoryID).PriceHeading3;
            hdID.Value =Convert.ToString( GetMenuCategory(menuCategoryID).ID);
        }
        protected void grvMenuCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int restaurantID = Authentication.CurrentRestaurantInfo.ID;
            int count = MenuCategoryBLL.GetByRestaurant(restaurantID, -1).Rows.Count;
            
            if (e.CommandName.Trim() == "_delete")
            {
                int MenuCategoryID = Convert.ToInt32(e.CommandArgument);
                MenuCategoryBLL.Delete(MenuCategoryID);
                BindMenuCategory(restaurantID, -1);
            }
            if (e.CommandName.Trim() == "_edit")
            {
                pnEdit.Visible = true;
                int MenuCategoryID = Convert.ToInt32(e.CommandArgument);
                BindMenuCategoryInfo(MenuCategoryID);
            }
            
            if (e.CommandName.Trim() == "_down")
            {
                try
                {
                    int menuCategoryID = Convert.ToInt32(e.CommandArgument);
                    MenuCategoryBLL.Down(menuCategoryID);
                }
                catch
                {
                    BindMenuCategory(restaurantID, -1);
                }
               
                BindMenuCategory(restaurantID, -1);
            }
            if (e.CommandName.Trim() == "_up")
            {
                try
                {
                    int menuCategoryID = Convert.ToInt32(e.CommandArgument);
                    MenuCategoryBLL.Up(menuCategoryID);
                }
                catch 
                {
                    BindMenuCategory(restaurantID, -1);
                }
                BindMenuCategory(restaurantID, -1);
            }
        }
        private MenuCategoryInfo SetMenuCategoryInfo()
        {
            MenuCategoryInfo menuCategoryInfo = new MenuCategoryInfo();
            menuCategoryInfo.Name = txtName.Text;
            menuCategoryInfo.ID =Convert.ToInt32( hdID.Value);
            menuCategoryInfo.Description = txtDescription.Text;
            menuCategoryInfo.PriceHeading1 = txtPrHeading1.Text;
            menuCategoryInfo.PriceHeading2 = txtPrHeading2.Text;
            menuCategoryInfo.PriceHeading3 = txtPrHeading3.Text;
            if (UplImage.HasFile)
            {
                string filename = Path.GetFileName(UplImage.FileName);
                string direc = Server.MapPath(@"~/Media/Images/") + filename;
                UplImage.SaveAs(direc);
                menuCategoryInfo.Image = "~/Media/Images/" + filename;
            }
            else
            {
                menuCategoryInfo.Image = "";
            }
            return menuCategoryInfo;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            bool result = MenuCategoryBLL.Update(SetMenuCategoryInfo());
            if (result)
            {
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                BindMenuCategory(restaurantID, -1);
                pnEdit.Visible = false;
                //Response.Redirect("~/Management/Default.aspx?mid=MenuCategory&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            pnEdit.Visible = false;
        }

    }
}