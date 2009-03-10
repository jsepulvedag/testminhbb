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
    public partial class AddPhoto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //public static void GenerateThumbnail(FileUpload fImage, Page thisPage, string rootDirectory, int width, int height)
        //{

        //    System.Drawing.Image.GetThumbnailImageAbort dummyCallBack;
        //    dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbNailCallback);

        //    System.Drawing.Image fullSizeImg;
        //    fullSizeImg = System.Drawing.Image.FromStream(fImage.FileContent);

        //    int w = fullSizeImg.Width;
        //    int h = fullSizeImg.Height;
        //    int wNew;
        //    int hNew;
        //    if (w / h > width / height)
        //    {
        //        hNew = width * h / w;
        //        wNew = width;
        //    }
        //    else
        //    {
        //        wNew = w * height / h;
        //        hNew = height;
        //    }

        //    System.Drawing.Image ThumbNailImg = fullSizeImg.GetThumbnailImage(wNew, hNew, dummyCallBack, IntPtr.Zero);

        //    System.IO.MemoryStream stream = new System.IO.MemoryStream();

        //    if (!rootDirectory.EndsWith("/"))
        //    {
        //        rootDirectory += "/";
        //    }
        //    try
        //    {
        //        ThumbNailImg.Save(thisPage.Server.MapPath(rootDirectory) + fImage.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    ThumbNailImg.Dispose();
        //    fullSizeImg.Dispose();
        //}
        //protected static bool ThumbNailCallback()
        //{
        //    return false;
        //}
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (uploadPhoto.HasFile)
            {
                string filename = Path.GetFileName(uploadPhoto.FileName);
                string derec = Server.MapPath("~/Media/Images/" + filename);
                uploadPhoto.SaveAs(derec);
                PhotoInfo photoInfo = new PhotoInfo();
                photoInfo.Name = txtPhotoName.Text;
                photoInfo.RestaurantID = Convert.ToInt32(Request.QueryString["RestaurantID"]);
                photoInfo.Image = "~/Media/Images/" + filename;
                PhotoBLL.InsertPhoto(photoInfo);
                Response.Redirect("~/Management/Default.aspx?mid=PhotoManagement&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));
            }
           

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Management/Default.aspx?mid=PhotoManagement&restaurantID=" + Convert.ToInt32(Request.QueryString["RestaurantID"]));
        }
    }
}