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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;
using System.IO;

namespace Restaurant.Presentation.Management.Restaurant.Menu
{
    public partial class AddMenuCategory : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private MenuCategoryInfo SetMenuCategoryInfo()
        {
            MenuCategoryInfo menuCategoryInfo = new MenuCategoryInfo();
            menuCategoryInfo.Name = txtName.Text;
            menuCategoryInfo.Description = txtDescription.Text;
            menuCategoryInfo.PriceHeading1 = txtPrHeading1.Text;
            menuCategoryInfo.PriceHeading2 = txtPrHeading2.Text;
            menuCategoryInfo.PriceHeading3 = txtPrHeading3.Text;
            menuCategoryInfo.IsActive =true;
            menuCategoryInfo.CreateDate = DateTime.Now;
            menuCategoryInfo.RestaurantID =Convert.ToInt32( Request.QueryString["RestaurantID"]);
            menuCategoryInfo.Image="No Images";
            if (UplImage.HasFile)
            {
                string filename = Path.GetFileName(UplImage.FileName);
                string direc = Server.MapPath(@"~/Media/Images/") + filename;
                UplImage.SaveAs(direc);
                menuCategoryInfo.Image = "~/Media/Images/" + filename;
                //"~/Media/Restaurants/" + info.ID.ToString() + "/Photos/Main/" + info.Image;
            }

            return menuCategoryInfo;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Boolean i = MenuCategoryBLL.Insert(SetMenuCategoryInfo());
            if (i)
            {
                Response.Redirect("~/Management/Default.aspx?mid=menuCategory&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/Default.aspx?mid=MenuCategory");
        }
    }
}