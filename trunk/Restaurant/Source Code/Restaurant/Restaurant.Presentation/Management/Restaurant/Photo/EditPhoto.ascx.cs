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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Entities;
using System.IO;


namespace Restaurant.Presentation.Management.Restaurant.Photo
{
    public partial class EditPhoto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                return;
            int photoID =Convert.ToInt32(Request.QueryString["PhotoID"]);
            BindPhoto(photoID);
        }
        public void BindPhoto(int ID)
        {
            DataTable tbl = PhotoBLL.GetByPhotoID(ID);
            dgrEditPhoto.DataSource = tbl;
            dgrEditPhoto.DataBind();
        }

        protected void dgrEditPhoto_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "_edit")
            {
                FileUpload fileupload = (FileUpload)e.Item.FindControl("uploadphoto");
                TextBox txtName = (TextBox)e.Item.FindControl("txtPhotoName");
                if (fileupload.HasFile)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string direc = Server.MapPath(@"~/Media/Images/") + filename;
                    fileupload.SaveAs(direc);

                    PhotoInfo photoInfo = new PhotoInfo();
                    photoInfo.ID = Convert.ToInt32(Request.QueryString["PhotoID"]);
                    photoInfo.RestaurantID = Convert.ToInt32(Request.QueryString["RestaurantID"]);
                    photoInfo.Name = txtName.Text;
                    photoInfo.Image = "~/Media/Images/" + filename;
                    bool result = PhotoBLL.UpdatePhoto(photoInfo);
                    if (result)
                    {
                        Response.Redirect("~/Management/Default.aspx?mid=PhotoManagement&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));

                    }
                }
                else
                {
                    PhotoInfo photoInfo2 = new PhotoInfo();
                    photoInfo2.ID = Convert.ToInt32(Request.QueryString["PhotoID"]);
                    photoInfo2.RestaurantID = Convert.ToInt32(Request.QueryString["RestaurantID"]);
                    photoInfo2.Name = txtName.Text;
                    photoInfo2.Image="";
                    
                    bool result = PhotoBLL.UpdatePhoto(photoInfo2);
                    if (result)
                    {
                        Response.Redirect("~/Management/Default.aspx?mid=PhotoManagement&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));

                    }
                }

          

            }
            else
                if (e.CommandName.Trim() == "_cancel")
                {
                    Response.Redirect("~/Management/Default.aspx?mid=PhotoManagement&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));
                }
        }

        protected void dgrEditPhoto_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

        }
    }
}