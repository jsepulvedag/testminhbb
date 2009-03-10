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
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Management.Restaurant.Photo
{
    public partial class PhotoManagement : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                BindListPhoto(restaurantID);
            }
        }
     
        public void BindListPhoto(int restaurantID)
        {
            DataTable tbl = PhotoBLL.GetByRestaurantID(restaurantID);
            dgrListPhoto.DataSource = tbl;
            dgrListPhoto.DataBind();
        }
       
        
        protected void dgrListPhotos_ItemCommand(object source, DataGridCommandEventArgs e)
        {

            if (e.CommandName.Trim() == "_delete")
            {
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                int photoID = Convert.ToInt32(e.CommandArgument);
                PhotoBLL.DeletePhoto(photoID);
                BindListPhoto(restaurantID);
            }
        }
        protected void lbAdd_Click1(object sender, EventArgs e)
        {
            int restaurantID = Authentication.CurrentRestaurantInfo.ID;
            Response.Redirect("~/Management/Default.aspx?mid=AddPhoto&restaurantID=" + restaurantID);
        }
    }
}