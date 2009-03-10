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
using System.Data.SqlClient;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Home.Member.Photo
{
    public partial class ListPhoto : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            int RidUrl = Convert.ToInt32(Request.QueryString["RidUrl"]);
            if (PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count > 0)
            {
                pnlist.Visible = true;
                pnNoImage.Visible = false;
                BindListPhoto(RidUrl);
                imgDetail.ImageUrl = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Image;
                lbPhotoName.Text = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Name;
                lbPhoto.Text = PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
                lbPhotoID.Text = Convert.ToString(GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).ID);
                lbCountPhoto.Text = "Showing image " + 1 + " of " + PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
            }
            else
            {
                pnlist.Visible = false;
                pnNoImage.Visible = false;
            }
        }
        public PhotoInfo GetPhoto(int photoID)
        {
            PhotoInfo reval = new PhotoInfo();
            reval = PhotoBLL.GetInfo(photoID);
            return reval;
        }
        public void BindListPhoto(int RidUrl)
        {
            DataTable tbl = PhotoBLL.GetByRestaurantID(RidUrl);
            dtlListPhoto.DataSource = tbl;
            dtlListPhoto.DataBind();
        }


        protected void dtlListPhoto_ItemCommand(object source, DataListCommandEventArgs e)
        {

            int ID = 0;
            if (e.CommandName.Trim() == "listPhoto")
            {
                ID = Convert.ToInt32(e.CommandArgument);
                imgDetail.ImageUrl = GetPhoto(ID).Image;
                lbPhotoName.Text = GetPhoto(ID).Name;
                lbPhotoID.Text = Convert.ToString(GetPhoto(ID).ID);
            }
        }
        protected void imgNext_Command(object sender, CommandEventArgs e)
        {

            int RidUrl = Convert.ToInt32(Request.QueryString["RidUrl"]);
            int row = PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count;
            int photoID = 0;
            photoID = Convert.ToInt32(lbPhotoID.Text);
            try
            {
                for (int i = 0; i < row; i++)
                {
                    if (Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[i][0]) == photoID)
                    {
                        int ID = Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[i + 1][0]);
                        imgDetail.ImageUrl = GetPhoto(ID).Image;
                        lbPhotoID.Text = Convert.ToString(GetPhoto(ID).ID);
                        int phto = i + 2;
                        lbCountPhoto.Text = "Showing image " + phto + " of " + PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
                        break;
                    }
                }
            }
            catch
            {
                imgDetail.ImageUrl = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Image;
                lbPhotoID.Text = Convert.ToString(GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).ID);
                lbCountPhoto.Text = "Showing image " + 1 + " of " + PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
                lbPhotoName.Text = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Name;
            }
        }

        protected void lbAddImage_Click(object sender, EventArgs e)
        {
            int RidUrl = Convert.ToInt32(Request.QueryString["RidUrl"]);
            Response.Redirect("~/Management/Default.aspx?mid=AddPhoto&restaurantID=" + RidUrl);
        }

        protected void ListReviewRight1_Load(object sender, EventArgs e)
        {

        }

        protected void imgPreview_Command(object sender, CommandEventArgs e)
        {
            int RidUrl = Convert.ToInt32(Request.QueryString["RidUrl"]);
            int row = PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count;
            int photoID = 0;
            photoID = Convert.ToInt32(lbPhotoID.Text);
            try
            {
                for (int i = row - 1; i < row; i--)
                {
                    if (Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[i][0]) == photoID)
                    {
                        int ID = Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[i - 1][0]);
                        imgDetail.ImageUrl = GetPhoto(ID).Image;
                        lbPhotoID.Text = Convert.ToString(GetPhoto(ID).ID);
                        int phto = i;
                        lbCountPhoto.Text = "Showing image " + phto + " of " + PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
                        break;
                    }
                }
            }
            catch
            {
                imgDetail.ImageUrl = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Image;
                lbPhotoID.Text = Convert.ToString(GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).ID);
                lbCountPhoto.Text = "Showing image " + 1 + " of " + PhotoBLL.GetByRestaurantID(RidUrl).Rows.Count.ToString() + " ";
                lbPhotoName.Text = GetPhoto(Convert.ToInt32(PhotoBLL.GetByRestaurantID(RidUrl).Rows[0][0])).Name;
            }
        }
    }
}