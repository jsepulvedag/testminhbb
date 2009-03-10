using System;
using System.IO;
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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.PayPalAPI;
using Restaurant.Library.Utilities.Validator;
using Restaurant.Library.Utilities.GenerateThumbnailImage;

namespace Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant
{
    public partial class Purchase : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDateTime();
                BindInfo();
            }
        }
        private void BindDateTime()
        {
            string[] monthDisplays = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] monthValues = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            string[] years = new string[15];
            for (int i = 0; i < 15; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year + i);
            }
            Utility.BindingDropDowList(Utility.CreateTable(monthValues, monthDisplays), drpExpMonth);
            Utility.BindingDropDowList(Utility.CreateTable(years,years), drpExYear);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            Response.Redirect(PageConstant.HOME_URL);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_RESTAURANT_PURCHASE_PACKAGE_URL));
            }
            if (Session[PageConstant.SESSION_RESTAURANT_INFO] == null)
            {
                Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
            }
        }
        void BindInfo()
        {
            RestaurantInfo resInfo = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
            PackageDetailInfo package = (PackageDetailInfo)Session[PageConstant.SESSION_PACKAGE_DETAIL];
            lblName.Text=resInfo.Name;
            lblWebsite.Text=resInfo.Website;
            lblEmail.Text=resInfo.Email;
            lblAddress.Text=resInfo.Address;
            lblZipcode.Text=resInfo.ZipCode;
            lblPackage.Text= package.Name;
        }
        private void CreateFolderForRestaurant(int restaurantID)
        {
            DirectoryInfo direcMain,direcRestaurant,direcPhoto,direcPhotoMain,direcPhotoCollection,direcVideo,direcGift,direcMenu;
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
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (!DataField.CheckValidCreditCard(txtCardNumber.Text.Trim()))
            {
                lblError.Visible = true;
                txtCardNumber.Focus();
                return;
            }
            if (Convert.ToInt32(drpExpMonth.SelectedValue.ToString()) <= DateTime.Now.Month && Convert.ToInt32(drpExYear.SelectedValue.ToString()) <= DateTime.Now.Year)
            {
                lblError1.Visible = true;
                return;
            }
            try
            {
                PackageDetailInfo packageDetail = (PackageDetailInfo)Session[PageConstant.SESSION_PACKAGE_DETAIL];

                AdminBusinessAccountInfo adminAccount = new AdminBusinessAccountInfo();
                Parameters paraPaypal = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_PAYPAL_PARAMETER);
                adminAccount.APIUserName = paraPaypal[PageConstant.PARAMETER_PAYPAL_USERNAME].ToString();
                adminAccount.APIPassword = paraPaypal[PageConstant.PARAMETER_PAYPAL_PASSWORD].ToString();
                adminAccount.APISignature = paraPaypal[PageConstant.PARAMETER_PAYPAL_SIGNATURE].ToString();

                AccountPaymentInfo account = new AccountPaymentInfo();
                account.CardSercurityCode = txtCCV.Text.Trim();
                account.CreditCardNumber = txtCardNumber.Text.Replace("-","").Replace(" ","");
                account.ExpiredMonth = Convert.ToInt32(drpExpMonth.SelectedValue.ToString());
                account.ExpiredYear = Convert.ToInt32(drpExYear.SelectedValue.ToString());
                account.NameOnCreditCard = txtHolderName.Text.Trim();
                account.TypeOfCreditCard = drpCardType.SelectedValue.ToString().Trim();

                string resultPayment = PaymentPaypal.CheckOutPackage(packageDetail,adminAccount,account,Authentication.CurrentMemberInfo);
                if (resultPayment.Contains("ERRORNHATNV"))
                {
                    MessageBox.Show(resultPayment.Replace("ERRORNHATNV",""));
                    return;
                }
                RestaurantInfo restaurantInfo = (RestaurantInfo)Session[PageConstant.SESSION_RESTAURANT_INFO];
                restaurantInfo.PackageDetailID = packageDetail.ID;
                restaurantInfo.ExpiryDate = DateTime.Now.AddMonths(packageDetail.ExpiryMonth);
                restaurantInfo.MemberID = Authentication.CurrentMemberInfo.ID;
                restaurantInfo.IsActive = true;
                restaurantInfo.CreatedByAdmin = false;               
                bool flag = true;
                if (restaurantInfo.ID <= 0)
                {
                    restaurantInfo.ID = RestaurantBLL.Insert(restaurantInfo);                    
                    flag = true;
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
                                    RestaurantBLL.UpdateMainPhoto(restaurantInfo.ID, "~/Media/Restaurants/" + restaurantInfo.ID.ToString() + "/Photos/Main/" + restaurantInfo.Image);
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
                }
                else
                {
                    restaurantInfo.CreatedByAdmin = false;
                    RestaurantBLL.Update(restaurantInfo);
                    flag = false;
                }

                TransactionInfo transactionInfo = new TransactionInfo();
                transactionInfo.CreateDate = DateTime.Now;
                transactionInfo.Fee = 0;
                transactionInfo.ExpiryDate = DateTime.Now.AddMonths(packageDetail.ExpiryMonth);
                transactionInfo.StatusDate = DateTime.Now;
                transactionInfo.MemberID = Authentication.CurrentMemberInfo.ID;
                transactionInfo.NumberTransaction = resultPayment;
                transactionInfo.Status = PageConstant.STATUS_TRANSACTION_CONFIRMED;
                transactionInfo.SupplierPayment = PageConstant.SUPPLIER_PAYPAL;
                transactionInfo.Tax = 0;
                transactionInfo.TotalPrice = packageDetail.Price;
                transactionInfo.Type = PageConstant.TRANSACTION_PURCHASE_PACKAGE;
                transactionInfo.RestaurantID = restaurantInfo.ID;
              
                transactionInfo.ID = TransactionBLL.Insert(transactionInfo);
                

                RestaurantPackageDetailInfo restaurantPackageDetail = new RestaurantPackageDetailInfo();
                restaurantPackageDetail.TransactionID = transactionInfo.ID;
                restaurantPackageDetail.PackageDetailID = packageDetail.ID;                
                RestaurantPackageDetailBLL.Insert(restaurantPackageDetail);              

                ActiveServiceInfo activeService = new ActiveServiceInfo();
                PackageInfo package = PackageBLL.GetInfo(packageDetail.PackageID);
                activeService.AllowOnlineReservation = package.AllowReservation;
                activeService.AllowOnlineOrder = package.AllowOnlineOrder;
                activeService.AllowGiftCertificate = package.AllowGiftCertificate;
                activeService.RestaurantID = restaurantInfo.ID;
                ActiveServiceBLL.Update(activeService);

                RestaurantAtmosphereList restaurantAtmosphere = (RestaurantAtmosphereList)Session[PageConstant.SESSION_RESTAURANT_ATMOSPHERE];
                restaurantAtmosphere.AddRestaurantID(restaurantInfo.ID);                
                RestaurantAttireList restaurantAttire = (RestaurantAttireList)Session[PageConstant.SESSION_RESTAURANT_ATTIRE];
                restaurantAttire.AddRestaurantID(restaurantInfo.ID);                
                RestaurantCuisineList restaurantCuisine = (RestaurantCuisineList)Session[PageConstant.SESSION_RESTAURANT_CUISINE];
                restaurantCuisine.AddRestaurantID(restaurantInfo.ID);                
                RestaurantGoodForList restaurantGoodFor = (RestaurantGoodForList)Session[PageConstant.SESSION_RESTAURANT_GOODFOR];
                restaurantGoodFor.AddRestaurantID(restaurantInfo.ID);                
                RestaurantMusicList restaurantMusic = (RestaurantMusicList)Session[PageConstant.SESSION_RESTAURANT_MUSIC];
                restaurantMusic.AddRestaurantID(restaurantInfo.ID);  
                
                RestaurantNeighbourhoodList restaurantNeighbourhood = (RestaurantNeighbourhoodList)Session[PageConstant.SESSION_RESTAURANT_NEIGHBOURHOOD];
                restaurantNeighbourhood.AddRestaurantID(restaurantInfo.ID);                
                RestaurantSpecialList restaurantSpecial = (RestaurantSpecialList)Session[PageConstant.SESSION_RESTAURANT_SPECIAL];
                restaurantSpecial.AddRestaurantID(restaurantInfo.ID);
                if (flag)
                {                    
                    RestaurantAtmosphereListBLL.Insert(restaurantAtmosphere);
                    RestaurantAttireListBLL.Insert(restaurantAttire);
                    RestaurantCuisineListBLL.Insert(restaurantCuisine);
                    RestaurantGoodForListBLL.Insert(restaurantGoodFor);
                    RestaurantMusicListBLL.Insert(restaurantMusic);
                    if (restaurantNeighbourhood.ListRestaurantNeighbourhood.Count > 0)
                    {
                        RestaurantNeighbourhoodListBLL.Insert(restaurantNeighbourhood);
                    }
                    RestaurantSpecialListBLL.Insert(restaurantSpecial);
                }
                else 
                {
                    RestaurantAtmosphereListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                    RestaurantAtmosphereListBLL.Insert(restaurantAtmosphere);
                    RestaurantAttireListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                    RestaurantAttireListBLL.Insert(restaurantAttire);
                    RestaurantCuisineListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                    RestaurantCuisineListBLL.Insert(restaurantCuisine);
                    RestaurantGoodForListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                    RestaurantGoodForListBLL.Insert(restaurantGoodFor);
                    RestaurantMusicListBLL.DeletebyRestaurantID(restaurantInfo.ID);
                    RestaurantMusicListBLL.Insert(restaurantMusic);
                    if (restaurantNeighbourhood.ListRestaurantNeighbourhood.Count > 0)
                    {
                        RestaurantNeighbourhoodListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                        RestaurantNeighbourhoodListBLL.Insert(restaurantNeighbourhood);
                    }
                    RestaurantSpecialListBLL.DeleteByRestaurantID(restaurantInfo.ID);
                    RestaurantSpecialListBLL.Insert(restaurantSpecial);
                }                
                HttpContext.Current.Session.Abandon();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            Response.Redirect(PageConstant.HOME_RESTAURANT_THANK_FOR_REGISTRY_URL);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CONTACT);
        }
    }
}