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
using Restaurant.Presentation.Library;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities.DataBinder;

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class HomeSearch : System.Web.UI.UserControl
    {
        string cityId="";
        private void BindCuisine()
        {
            drpCuisine.DataSource = CuisineBLL.GetAll();
            drpCuisine.DataBind();
            ListItem item = new ListItem("--Select Cuisine--", "0");
            drpCuisine.Items.Insert(0,item);
            drpCuisine.SelectedIndex = 0;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            BindCuisine();
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string url = PageConstant.HOME_RESTAURANT_LISTING_URL + "&keyword=" + txtRestaurantName.Text;
            if (Session["cityId"] != null)
            {
                url += "&cityId=" + Session["CityId"].ToString() + "&cuisineId=" + drpCuisine.SelectedValue.ToString() + "&zipcode=" + txtZip.Text;
            }
            else
            {
                url += "&cityId=" + Request.QueryString["cityId"].ToString() + "&cuisineId=" + drpCuisine.SelectedValue.ToString() + "&zipcode=" + txtZip.Text;
            }
            Response.Redirect(url);
        }
    }
}