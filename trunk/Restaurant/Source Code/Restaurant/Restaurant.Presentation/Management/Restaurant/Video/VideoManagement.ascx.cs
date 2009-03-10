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
using Restaurant.Library.Entities;
using System.IO;

namespace Restaurant.Presentation.Management.Restaurant.Video
{
    public partial class VideoManagement : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                BindListVideo(restaurantID);
            }
        }
        public void BindListVideo(int restaurantID)
        {
            DataTable tbl = VideoBLL.GetByRestaurantID(restaurantID);
            dgrListVideo.DataSource = tbl;
            dgrListVideo.DataBind();
        }
        public void BindVideo(int videoID)
        {
            DataTable tbl = VideoBLL.GetByVideoID(videoID);
            dtlEdit.DataSource = tbl;
            dtlEdit.DataBind();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            if (uploadPhoto.HasFile && upLoadVideo.HasFile)
            {
                bool checkPhoto = false;
                bool checkVideo = false;
                string filename = Path.GetFileName(uploadPhoto.FileName);
                string filePhotoExtension = Path.GetExtension(uploadPhoto.FileName).ToLower();
                if (filePhotoExtension == ".jpg" || filePhotoExtension == "jpeg" || filePhotoExtension == ".bmp" || filePhotoExtension == ".gif")
                {
                    string derec = Server.MapPath("~/Media/Images/" + filename);
                    uploadPhoto.SaveAs(derec);
                    checkPhoto = true;
                }
                else
                {
                    lblPhoto.Visible = true;
                    lblPhoto.Text = "That photo type is not allowed!";
                }
                
                //string[] Extension={"wma","avi"};
                string fileVideo = Path.GetFileName(upLoadVideo.FileName);
                string fileExtension = Path.GetExtension(upLoadVideo.FileName).ToLower();
                if (fileExtension == ".wma" || fileExtension == ".avi")
                {
                    string derec2 = Server.MapPath("~/Media/Videos/" + fileVideo);
                    upLoadVideo.SaveAs(derec2);
                    checkVideo = true;
                }
                else
                {
                    lblVideo.Visible = true;
                    lblVideo.Text = "That video type is not allowed!";
                }

                if (checkVideo == true && checkPhoto==true)
                {
                    VideoInfo videoInfo = new VideoInfo();
                    videoInfo.Title = txtTitle.Text;
                    videoInfo.Description = txtDescription.Text;
                    videoInfo.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
                    videoInfo.Picture = "~/Media/Images/" + filename;
                    videoInfo.VideoPath = "~/Media/Videos/" + fileVideo;
                    videoInfo.UploadedDate = DateTime.Now;
                    VideoBLL.InsertVideo(videoInfo);

                    BindListVideo(Authentication.CurrentRestaurantInfo.ID);
                    pnADD.Visible = false;
                    Video.Visible = true; 
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnADD.Visible = false;
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            pnADD.Visible = true;
            Video.Visible = false;
           
            pnEdit.Visible = false;
        }

        protected void dgrListVideo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.Trim() == "_delete")
            {
                int restaurantID = Authentication.CurrentRestaurantInfo.ID;
                int videoID = Convert.ToInt32(e.CommandArgument);
                VideoBLL.DeleteVideo(videoID);
                BindListVideo(restaurantID);
            }
            if (e.CommandName.Trim() == "_edit")
            {
                pnADD.Visible = false;
                Video.Visible = false; 
                int videoID = Convert.ToInt32(e.CommandArgument);
                VideoBLL.GetByVideoID(videoID);
                BindVideo(videoID);
                pnEdit.Visible = true;
            }
        }

        protected void dgrListVideo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void dtlEdit_OnItemCommand(object source, DataListCommandEventArgs e)
        {
            int checkPhoto=1;
            int checkVideo=1;
            if (e.CommandName.Trim() == "update")
            {
                FileUpload uploadPicture = (FileUpload)e.Item.FindControl("uploadPicture");
                FileUpload uploadVideo = (FileUpload)e.Item.FindControl("uploadVideo");
                string filename = "";
                string fileVideo = "";
                if (uploadPicture.HasFile)
                {
                      filename = Path.GetFileName(uploadPicture.FileName);
                      string filePhotoExtension = Path.GetExtension(uploadPicture.FileName).ToLower();
                      if (filePhotoExtension == ".jpg" || filePhotoExtension == "jpeg" || filePhotoExtension == ".bmp" || filePhotoExtension == ".gif")
                      {
                          string derec = Server.MapPath("~/Media/Images/" + filename);
                          uploadPicture.SaveAs(derec);
                      }
                      else
                      {
                          lblEditPhoto.Visible = true;
                          lblEditPhoto.Text = "That photo type is not allowed!";
                          checkPhoto = 0;
                      }
                }
                if (uploadVideo.HasFile)
                {
                    fileVideo = Path.GetFileName(uploadVideo.FileName);
                    string fileExtension = Path.GetExtension(uploadVideo.FileName).ToLower();
                    if (fileExtension == ".wma" || fileExtension == ".avi")
                    {
                        string derec2 = Server.MapPath("~/Media/Videos/" + fileVideo);
                        uploadVideo.SaveAs(derec2);
                       
                    }
                    else
                    {
                        lblEditVideo.Visible = true;
                        lblEditVideo.Text = "That video type is not allowed!";
                        checkVideo = 0;
                    }
                    
                }
                if (checkVideo != 0 && checkPhoto!= 0) 
                {
                TextBox uploadTitle = (TextBox)e.Item.FindControl("uploadTitle");
                TextBox uploadDescription = (TextBox)e.Item.FindControl("uploadDescription");
                VideoInfo videoInfo = new VideoInfo();
                videoInfo.Title = uploadTitle.Text;
                videoInfo.Description = uploadDescription.Text;
                videoInfo.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
                videoInfo.ID = Convert.ToInt32(e.CommandArgument);
                if (filename != "")
                {
                    videoInfo.Picture = "~/Media/Images/" + filename;
                }
                else
                    videoInfo.Picture = "";
                if (fileVideo != "")
                {
                    videoInfo.VideoPath = "~/Media/Videos/" + fileVideo;
                }
                else
                    videoInfo.VideoPath = "";
                videoInfo.UploadedDate = DateTime.Now;
                VideoBLL.UpdateVideo(videoInfo);
                BindListVideo(Authentication.CurrentRestaurantInfo.ID);
                pnEdit.Visible = false;
                Video.Visible = true;
            }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}