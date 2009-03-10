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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Telerik.RadWindowUtils;
using Restaurant.Library.Utilities.Encrypt;
using Restaurant.Library.Entities;
using System.IO;
using Restaurant.Library.Utilities.GenerateThumbnailImage;

namespace Restaurant.Presentation.Administrator.RestaurantPackage
{
    public partial class ChoosePackage : AuthenticateControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session[PageConstant.SESSION_RESTAURANT_INFO] == null)
            {
                Response.Redirect(PageConstant.ADMIN_ADD_RESTAURANT_MANAGEMENT_URL);
            }
        }
        public string GetCheck
        {
            get
            {
                string url = Request.Url.PathAndQuery;
                string s="";
                if (url.Contains("Check"))
                {
                     s = Request.QueryString["Check"].ToString();
                }
                return s;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Bind_dlPackage();
            }
        }
        private void Bind_dlPackage()
        {
            dlPackage.DataSource = PackageBLL.GetFree(true);
            dlPackage.DataBind();
            if (dlPackage.Items.Count <= 0)
            {
                MessageBox.Show("Can not find any package for restaurant !");
            }
        }
        protected void dlPackage_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblPackageID");
            if (lbl != null)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater rpt = (Repeater)e.Item.FindControl("rptPackageDetail");
                    if (rpt != null)
                    {
                        rpt.DataSource = PackageDetailBLL.GetByPackageID(Convert.ToInt32(lbl.Text.Trim()));
                        rpt.ItemDataBound += new RepeaterItemEventHandler(rpt_ItemDataBound);
                        rpt.DataBind();                        
                    }
                }
            }
        }
        void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                RadioButton rdo = (RadioButton)e.Item.FindControl("rdSelected");
                if (rdo != null)
                {
                    rdo.Attributes.Add("onclick", "SetUniqueRadioButton('rdSelected',this)");
                }
            }
        }
        private int PackageDetailID_Selected()
        {
            foreach (DataListItem item in dlPackage.Items)
            {
                Repeater rpt = (Repeater)item.FindControl("rptPackageDetail");
                if (rpt != null)
                {
                    foreach (RepeaterItem itm in rpt.Items)
                    {
                        RadioButton rdo = (RadioButton)itm.FindControl("rdSelected");
                        if (rdo != null && rdo.Checked == true)
                        {
                            Label lbl = (Label)itm.FindControl("lblPackageDetailID");
                            if (lbl != null)
                            {
                                return Convert.ToInt32(lbl.Text.Trim());
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }                
            }
            return 0;
        }
        #region Insert method
        private void InsertRestaurantDetail(int restaurantID)
        {
            if (Session[PageConstant.SESSION_RESTAURANT_ATMOSPHERE] != null)
            {
                RestaurantAtmosphereList _resAtmosphere = (RestaurantAtmosphereList)Session[PageConstant.SESSION_RESTAURANT_ATMOSPHERE];
                _resAtmosphere.AddRestaurantID(restaurantID);
                RestaurantAtmosphereListBLL.Insert(_resAtmosphere);
            }
            if (Session[PageConstant.SESSION_RESTAURANT_ATTIRE] != null)
            {
                RestaurantAttireList _resAttire = (RestaurantAttireList)Session[PageConstant.SESSION_RESTAURANT_ATTIRE];
                _resAttire.AddRestaurantID(restaurantID);
                RestaurantAttireListBLL.Insert(_resAttire);
            }
            if (Session[PageConstant.SESSION_RESTAURANT_CUISINE] != null)
            {
                RestaurantCuisineList _resCuisine = (RestaurantCuisineList)Session[PageConstant.SESSION_RESTAURANT_CUISINE];
                _resCuisine.AddRestaurantID(restaurantID);
                RestaurantCuisineListBLL.Insert(_resCuisine);
            }
            if (Session[PageConstant.SESSION_RESTAURANT_GOODFOR] != null)
            {
                RestaurantGoodForList _resGoodFor = (RestaurantGoodForList)Session[PageConstant.SESSION_RESTAURANT_GOODFOR];
                _resGoodFor.AddRestaurantID(restaurantID);
                RestaurantGoodForListBLL.Insert(_resGoodFor);
            }
            if (Session[PageConstant.SESSION_RESTAURANT_MUSIC] != null)
            {
                RestaurantMusicList _resMusic = (RestaurantMusicList)Session[PageConstant.SESSION_RESTAURANT_MUSIC];
                _resMusic.AddRestaurantID(restaurantID);
                RestaurantMusicListBLL.Insert(_resMusic);
            }
            if (Session[PageConstant.SESSION_RESTAURANT_NEIGHBOURHOOD] != null)
            {
                RestaurantNeighbourhoodList _resNeighbour = (RestaurantNeighbourhoodList)Session[PageConstant.SESSION_RESTAURANT_NEIGHBOURHOOD];
                _resNeighbour.AddRestaurantID(restaurantID);
                if (_resNeighbour.ListRestaurantNeighbourhood.Count > 0)
                {
                    RestaurantNeighbourhoodListBLL.Insert(_resNeighbour);
                }
            }
            if (Session[PageConstant.SESSION_RESTAURANT_SPECIAL] != null)
            {
                RestaurantSpecialList _resSpecial = (RestaurantSpecialList)Session[PageConstant.SESSION_RESTAURANT_SPECIAL];
                _resSpecial.AddRestaurantID(restaurantID);
                RestaurantSpecialListBLL.Insert(_resSpecial);
            }
        }       
        private void CreateFolderForRestaurant(int restaurantID)
        {
            DirectoryInfo direcMain, direcRestaurant, direcPhoto, direcPhotoMain, direcPhotoCollection, direcVideo, direcGift, direcMenu;
            string pathMain = Server.MapPath("~/Media/Restaurants/");
            direcMain = new DirectoryInfo(pathMain);
            if (!direcMain.Exists)
            {
                direcMain.Create();
            }
            string path = "~/Media/Restaurants/" + restaurantID.ToString() + "/";
            string pathRestaurant = Server.MapPath(path);
            direcRestaurant = new DirectoryInfo(pathRestaurant);
            if (!direcRestaurant.Exists)
            {
                direcRestaurant.Create();
            }
            string pathPhoto = Server.MapPath(path + "Photos/");
            direcPhoto = new DirectoryInfo(pathPhoto);
            if (!direcPhoto.Exists)
            {
                direcPhoto.Create();
            }
            string pathPhotoMain = Server.MapPath(path + "Photos/Main/");
            direcPhotoMain = new DirectoryInfo(pathPhotoMain);
            if (!direcPhotoMain.Exists)
            {
                direcPhotoMain.Create();
            }
            string pathPhotoCollection = Server.MapPath(path + "/Photos/Collections/");
            direcPhotoCollection = new DirectoryInfo(pathPhotoCollection);
            if (!direcPhotoCollection.Exists)
            {
                direcPhotoCollection.Create();
            }
            string pathVideo = Server.MapPath(path + "Video/");
            direcVideo = new DirectoryInfo(pathVideo);
            if (!direcVideo.Exists)
            {
                direcVideo.Create();
                DirectoryInfo direcPhotoVideo = new DirectoryInfo(Server.MapPath(path + "Video/Photo/"));
                direcPhotoVideo.Create();
                DirectoryInfo direcSourceVideo = new DirectoryInfo(Server.MapPath(path + "Video/Source/"));
                direcSourceVideo.Create();
            }
            string pathGift = Server.MapPath(path + "Gift/");
            direcGift = new DirectoryInfo(pathGift);
            if (!direcGift.Exists)
            {
                direcGift.Create();
            }
            string pathMenu = Server.MapPath(path + "MenuCategory/");
            direcMenu = new DirectoryInfo(pathMenu);
            if (!direcMenu.Exists)
            {
                direcMenu.Create();
            }
            string pathTempImage = Server.MapPath(path + "TempImagePhoto");
            DirectoryInfo direcTempImage = new DirectoryInfo(pathTempImage);
            if (!direcTempImage.Exists)
            {
                direcTempImage.Create();
            }
        }
        #endregion
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            int packegeDetailID = PackageDetailID_Selected();
            if (packegeDetailID.ToString().Equals("0"))
            {
                MessageBox.Show("Select one of package !");
                return;
            }
            else
            {
                PackageDetailInfo packageDetailInfo = PackageDetailBLL.GetInfo(packegeDetailID);
                RestaurantInfo restaurantInfo = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
                restaurantInfo.PackageDetailID = packageDetailInfo.ID;
                restaurantInfo.ExpiryDate = DateTime.Now.AddMonths(packageDetailInfo.ExpiryMonth);
                restaurantInfo.ID = RestaurantBLL.Insert(restaurantInfo);
                if (restaurantInfo.ID > 0)
                {
                    CreateFolderForRestaurant(restaurantInfo.ID);
                    if (!restaurantInfo.Image.ToLower().Equals("no image"))
                    {
                        string path = "~/Media/Restaurants/" + restaurantInfo.ID + "/TempImagePhoto/";
                        string save = "~/Media/Restaurants/" + restaurantInfo.ID + "/Photos/Main/";
                        DirectoryInfo direct = new DirectoryInfo(Server.MapPath("~/Media/TempImage/TempRestaurantImage/"));
                        FileInfo[] files = direct.GetFiles();
                        if (files.Length > 0)
                        {
                            foreach (FileInfo file in files)
                            {
                                if (file.Name == restaurantInfo.Image)
                                {
                                    file.MoveTo(Server.MapPath(path + restaurantInfo.Image));
                                    Generator generator = new Generator(170, 206, Server.MapPath(path + file.Name), Server.MapPath(save + file.Name));
                                    generator.SaveThumbnail();
                                    RestaurantBLL.UpdateMainPhoto(restaurantInfo.ID, "~/Media/Restaurants/" + restaurantInfo.ID.ToString() + "/Photos/Main" + restaurantInfo.Image);
                                    break;
                                }
                            }
                        }
                        direct = new DirectoryInfo(Server.MapPath(path));
                        files = direct.GetFiles();
                        foreach (FileInfo file in files)
                        {
                            file.Delete();
                        }
                    }

                    InsertRestaurantDetail(restaurantInfo.ID);
                    lblMess.Visible = true;
                    lblMess.Text = "Restaurant has been created successfully";
                    btnContinue.Enabled=false;
                }
                else
                {
                    lblMess.Visible = true;
                    lblMess.Text = "Restaurant hasn't been created successfully";
                }            
                HttpContext.Current.Session.Abandon();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.ADMIN_CHOOSE_PACKAGE_URL);
        }
        protected void btnRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.ADMIN_ADD_RESTAURANT_MANAGEMENT_URL);
        }
    }
}