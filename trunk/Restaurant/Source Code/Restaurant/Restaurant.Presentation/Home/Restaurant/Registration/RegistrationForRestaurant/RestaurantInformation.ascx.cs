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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Home.UserControls;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Validator;
using Restaurant.Library.Utilities.Encrypt;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;
using System.IO;

namespace Restaurant.Presentation.Home.Restaurant.Registration.RegistrationForRestaurant
{
    public partial class RestaurantInformation : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                BindDateTime();
                BindLocal();
                BindListBox(); txtRestaurantWebsite.Attributes.Add("onfocus", "OnFocus('"+txtRestaurantWebsite.ClientID+"')");
                txtRestaurantWebsite.Attributes.Add("onblur","OnBlur('"+txtRestaurantWebsite.ClientID+"','http://www.yourwebsite.com')");
                if (RestaurantID != null && RestaurantID != "")
                {
                    RestaurantInfo restaurantInfo = RestaurantBLL.GetInfo(Convert.ToInt32(RestaurantID));
                    if (restaurantInfo != null)
                    {
                        ConfirmRestaurant(restaurantInfo);
                    }
                }                
            }
        }
        private string RestaurantID
        {
            get { return Request.QueryString[PageConstant.RESTAURANT_ID.Replace("&", "").Replace("=", "")]; }
        }
        private void BindDateTime()
        {
            string[] monthDisplays = { "January","February","March","April","May","June","July","August","September","October","November","December"};
            string[] monthValues = { "1","2","3","4","5","6","7","8","9","10","11","12"};

            string[] days = new string[31];
            for (int i = 0; i < 31; i++)
            {
                days[i] = Convert.ToString(i + 1);
            }

            string[] years = new string[120];
            for (int i = 0; i < 120; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year - i);
            }

            Utility.BindingDropDowList(Utility.CreateTable(monthValues, monthDisplays), drpOpenedMonth);
            Utility.BindingDropDowList(Utility.CreateTable(days, days), drpOpenedDay);
         }
        public void BindState()
        {
            int countryID;
            
            if (Int32.TryParse(drpRestaurantCountry.SelectedValue.ToString(), out countryID))
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID, true), drpRestaurantState);
            }            
        }
        public void BindCity()
        {
            int stateID;
            if (Int32.TryParse(drpRestaurantState.SelectedValue.ToString(), out stateID))
            {
                Utility.BindingDropDowList(CityBLL.GetByStateID(stateID, true), drpRestaurantCity);
            }
            int cityID;
            if (Int32.TryParse(drpRestaurantCity.SelectedValue.ToString(), out cityID))
            {
                Utility.BindingDropDowList(NeighbourhoodBLL.GetByCityID(cityID,true), dropNeighbourhood);
            }            
        }
        private void BindLocal()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(true), drpRestaurantCountry);
            BindState();
            BindCity();
        }
        private void BindListBox()
        {
            Utility.BindingListBox(GoodForBLL.GetAll(),listGoodFor);
            Utility.BindingListBox(AtmosphereBLL.GetAll(),listAtmosphere);
            Utility.BindingListBox(SpecialBLL.GetAll(), listSpecial);
            Utility.BindingListBox(CuisineBLL.GetAll(),listCuisine);
            Utility.BindingListBox(MusicBLL.GetAll(),listMusic);
            Utility.BindingListBox(AttireBLL.GetAll(),listAttire);                       
        }
        private void SwapItem(ListBox source, ListBox goal)
        {
            int i = 0;
            while (i < source.Items.Count)
            {
                if (source.Items[i].Selected)
                {
                    ListItem Item = source.Items[i];
                    goal.Items.Add(Item);
                    source.Items.RemoveAt(i);
                    continue;
                }
                i++;
            }
        }
        void RefreshControl()
        {
            txtOpendYear.Text="";
            txtRestaurantAddress.Text="";
            txtRestaurantEmail.Text="";
            txtRestaurantFax.Text="";
            txtRestaurantName.Text="";
            txtRestaurantPhone1.Text="";
            txtRestaurantPhone2.Text="";
            txtRestaurantWebsite.Text="http://www.yourwebsite.com";
            txtRestaurantZipcode.Text="";

            SwapItem(listSelectedGoodFor,listGoodFor);
            SwapItem(listSelectedAttire,listAttire);
            SwapItem(listSelectedCuisine, listCuisine);
            SwapItem(listSelectedMusic, listMusic);
            SwapItem(listSelectedSpecial, listSpecial);
            SwapItem(listSelectedAtmosphere, listAtmosphere);
        }
        #region OnSet
        private RestaurantInfo OnSetRestaurant
        {
            get 
            {
                RestaurantInfo info = new RestaurantInfo();
                if (fuImage.PostedFile.ContentLength != 0)
                {
                    info.Image += DateTime.Now.ToString().Replace(":", "-").Replace("/", ".").Replace(" ", "_");
                    int length = fuImage.PostedFile.FileName.Length;
                    info.Image += (length > 12) ? fuImage.PostedFile.FileName.Substring(length-12, 12) : fuImage.PostedFile.FileName;                    
                    DirectoryInfo path = new DirectoryInfo(Server.MapPath("~/Media/TempImage/TempRestaurantImage/"));
                    if (!path.Exists)
                    {
                        path.Create();
                    }                    
                    fuImage.PostedFile.SaveAs(path + info.Image);
                }
                else
                {
                    info.Image = "No Image";
                }
                info.Name = txtRestaurantName.Text.Trim();
                info.ZipCode = txtRestaurantZipcode.Text.Trim();
                info.Website = txtRestaurantWebsite.Text.Trim();
                info.Phone1 = txtRestaurantPhone1.Text.Trim();
                info.Phone2 = txtRestaurantPhone2.Text.Trim();
                info.Fax = txtRestaurantFax.Text.Trim();
                info.Email = txtRestaurantEmail.Text.Trim();
                info.AcceptCreditCard = chkAcceptCreditCard.Checked;
                info.DateOpened = Convert.ToDateTime(drpOpenedMonth.SelectedValue + "/" + drpOpenedDay.SelectedValue.ToString() + "/" + txtOpendYear.Text.Trim());
                info.CountryID = Convert.ToInt32(drpRestaurantCountry.SelectedValue.ToString());
                info.StateID = Convert.ToInt32(drpRestaurantState.SelectedValue.ToString());
                info.CityID = Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString());
                info.Address = txtRestaurantAddress.Text.Trim();              
                info.Description = "No description";

                if (RestaurantID != null && RestaurantID != "")
                {
                    info.ID = Convert.ToInt32(RestaurantID);
                }

                return info;
            }
        }
        private RestaurantGoodForList OnSetRestaurantGoodFor
        {
            get             
            {
                RestaurantGoodForList goodFor = new RestaurantGoodForList();
                foreach (ListItem item in listSelectedGoodFor.Items)
                {
                    RestaurantGoodForInfo obj = new RestaurantGoodForInfo();
                    obj.GoodForID = Convert.ToInt32(item.Value.ToString());
                    goodFor.Add(obj);
                }
                return goodFor;
            } 
        }
        private RestaurantNeighbourhoodList OnSetRestaurantNeightbourhood
        {
            get
            {
                RestaurantNeighbourhoodList neightbourhood = new RestaurantNeighbourhoodList();
                
                if (dropNeighbourhood.Items.Count > 0)
                {
                    RestaurantNeighbourhoodInfo obj = new RestaurantNeighbourhoodInfo();
                    obj.NeighbourhoodID = Convert.ToInt32(dropNeighbourhood.SelectedValue.ToString());
                    neightbourhood.Add(obj); 
                }          
                return neightbourhood;
            }
        }
        private RestaurantCuisineList OnSetRestaurantCuisine
        {
            get
            {
                RestaurantCuisineList cuisine = new RestaurantCuisineList();
                foreach (ListItem item in listSelectedCuisine.Items)
                {
                    RestaurantCuisineInfo obj = new RestaurantCuisineInfo();
                    obj.CuisineID = Convert.ToInt32(item.Value.ToString());
                    cuisine.Add(obj);
                }
                return cuisine;
            }

        }
        private RestaurantSpecialList OnSetRestaurantSpecial
        {
            get 
            {
                RestaurantSpecialList special = new RestaurantSpecialList();
                foreach (ListItem item in listSelectedSpecial.Items)
                {
                    RestaurantSpecialInfo obj = new RestaurantSpecialInfo();
                    obj.SpecialID = Convert.ToInt32(item.Value.ToString());
                    special.Add(obj);
                }
                return special;
            }
        }
        private RestaurantMusicList OnSetRestaurantMusic
        {
            get
            {
                RestaurantMusicList music = new RestaurantMusicList();
                foreach (ListItem item in listSelectedMusic.Items)
                {
                    RestaurantMusicInfo obj = new RestaurantMusicInfo();
                    obj.MusicID = Convert.ToInt32(item.Value.ToString());
                    music.Add(obj);
                }
                return music;
            }
        }
        private RestaurantAttireList OnSetRestaurantAttire
        {
            get
            {
                RestaurantAttireList attire = new RestaurantAttireList();
                foreach (ListItem item in listSelectedAttire.Items)
                {
                    RestaurantAttireInfo obj = new RestaurantAttireInfo();
                    obj.AttireID = Convert.ToInt32(item.Value.ToString());
                    attire.Add(obj);
                }
                return attire;
            }
        }
        private RestaurantAtmosphereList OnSetRestaurantAtmosphere
        {
            get
            {
                RestaurantAtmosphereList atmosphere = new RestaurantAtmosphereList();
                foreach (ListItem item in listSelectedAtmosphere.Items)
                {
                    RestaurantAtmosphereInfo obj = new RestaurantAtmosphereInfo();
                    obj.AtmosphereID = Convert.ToInt32(item.Value.ToString());
                    atmosphere.Add(obj);
                }
                return atmosphere;
            }
        }
        #endregion 
        private void ConfirmRestaurant(RestaurantInfo restaurantInfo)
        {            
            txtRestaurantAddress.Text = restaurantInfo.Address;
            txtRestaurantEmail.Text = restaurantInfo.Email;
            txtRestaurantFax.Text = restaurantInfo.Fax;
            txtRestaurantName.Text = restaurantInfo.Name;
            txtRestaurantPhone1.Text = restaurantInfo.Phone1;
            txtRestaurantPhone2.Text = restaurantInfo.Phone2;
            txtRestaurantWebsite.Text = restaurantInfo.Website;
            txtRestaurantZipcode.Text = restaurantInfo.ZipCode;
            chkAcceptCreditCard.Checked = restaurantInfo.AcceptCreditCard;
            drpOpenedDay.SelectedValue = restaurantInfo.DateOpened.Day.ToString();
            drpOpenedMonth.SelectedValue = restaurantInfo.DateOpened.Month.ToString();
            txtOpendYear.Text = restaurantInfo.DateOpened.Year.ToString();

            drpRestaurantCountry.SelectedValue = restaurantInfo.CountryID.ToString();
            drpRestaurantCountry.SelectedIndexChanged += new EventHandler(drpRestaurantCountry_SelectedIndexChanged);
            drpRestaurantState.SelectedValue = restaurantInfo.StateID.ToString();
            drpRestaurantState.SelectedIndexChanged += new EventHandler(drpRestaurantState_SelectedIndexChanged);
            drpRestaurantCity.SelectedValue = restaurantInfo.CityID.ToString();
            drpRestaurantCity.SelectedIndexChanged += new EventHandler(drpRestaurantCity_SelectedIndexChanged);

            Utility.BindingListBox(RestaurantBLL.GetAtmosphere(restaurantInfo.ID),listSelectedAtmosphere);
            RemoveSameItem(listAtmosphere,listSelectedAtmosphere);
            Utility.BindingListBox(RestaurantBLL.GetAttire(restaurantInfo.ID),listSelectedAttire);
            RemoveSameItem(listAttire,listSelectedAttire);
            Utility.BindingListBox(RestaurantBLL.GetCuisine(restaurantInfo.ID), listSelectedCuisine);
            RemoveSameItem(listCuisine, listSelectedCuisine);
            Utility.BindingListBox(RestaurantBLL.GetGoodFor(restaurantInfo.ID),listSelectedGoodFor);
            RemoveSameItem(listGoodFor,listSelectedGoodFor);
            Utility.BindingListBox(RestaurantBLL.GetMusic(restaurantInfo.ID), listSelectedMusic);
            RemoveSameItem(listMusic,listSelectedMusic);            
            Utility.BindingListBox(RestaurantBLL.GetSpecial(restaurantInfo.ID),listSelectedSpecial);
            RemoveSameItem(listSpecial,listSelectedSpecial);
        }
        private void RemoveSameItem(ListBox list, ListBox selected)
        { 
            if (selected.Items.Count > 0)
            {
                foreach (ListItem item1 in selected.Items)
                {
                    foreach (ListItem item2 in list.Items)
                    {
                        if (item1.Value == item2.Value)
                        {
                            list.Items.Remove(item2);
                            break;
                        }
                    }
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string packageID = Request.QueryString[PageConstant.PACKAGE_ID.Replace("&", "").Replace("=", "")];
            if (packageID == null)
            {
                Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
            }            
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {         
            Session[PageConstant.SESSION_RESTAURANT_INFO] = OnSetRestaurant;
            PackageDetailInfo packageDetail = PackageDetailBLL.GetInfo(Convert.ToInt32(Request.QueryString[PageConstant.PACKAGE_ID.Replace("&", "").Replace("=", "")]));
            Session[PageConstant.SESSION_PACKAGE_DETAIL] = packageDetail;
            Session[PageConstant.SESSION_RESTAURANT_ATMOSPHERE] = OnSetRestaurantAtmosphere;
            Session[PageConstant.SESSION_RESTAURANT_ATTIRE] = OnSetRestaurantAttire;
            Session[PageConstant.SESSION_RESTAURANT_CUISINE] = OnSetRestaurantCuisine;
            Session[PageConstant.SESSION_RESTAURANT_GOODFOR] = OnSetRestaurantGoodFor;
            Session[PageConstant.SESSION_RESTAURANT_MUSIC] = OnSetRestaurantMusic;
            Session[PageConstant.SESSION_RESTAURANT_NEIGHBOURHOOD] = OnSetRestaurantNeightbourhood;
            Session[PageConstant.SESSION_RESTAURANT_SPECIAL] = OnSetRestaurantSpecial;
            if (Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_RESTAURANT_CONTACT);
            }
            else
            {
                if (RestaurantID != null && RestaurantID != "")
                {
                    Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_RESTAURANT_CONTACT + PageConstant.RESTAURANT_ID + RestaurantID));
                }
                else
                {
                    Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_RESTAURANT_CONTACT));
                }
            }
        }
        #region SwapListItem
        protected void btnSelectedGoodFor_Click(object sender, EventArgs e)
        {
            SwapItem(listGoodFor, listSelectedGoodFor);
        }
        protected void btnGoodFor_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedGoodFor, listGoodFor);
        }
        protected void btnSelectedCuisine_Click(object sender, EventArgs e)
        {
            SwapItem(listCuisine, listSelectedCuisine);
        }
        protected void btnCuisine_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedCuisine,listCuisine);
        }
        protected void btnSelectedSpecial_Click(object sender, EventArgs e)
        {
            SwapItem(listSpecial, listSelectedSpecial);
        }
        protected void btnSpecial_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedSpecial, listSpecial);
        }
        protected void btnSelectedMusic_Click(object sender, EventArgs e)
        {
            SwapItem(listMusic, listSelectedMusic);
        }
        protected void btnMusic_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedMusic,listMusic);
        }
        protected void btnSelectedAttire_Click(object sender, EventArgs e)
        {
            SwapItem(listAttire, listSelectedAttire);
        }
        protected void btnAttire_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedAttire, listAttire);
        }
        protected void btnSelectedAtmosphere_Click(object sender, EventArgs e)
        {
            SwapItem(listAtmosphere,listSelectedAtmosphere);
        }
        protected void btnAtmosphere_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedAtmosphere, listAtmosphere);
        }
        #endregion        
        protected void drpRestaurantCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCountry.SelectedValue == null || drpRestaurantCountry.Items.Count <= 0)
            {
                return;
            }
            BindState();
            BindCity();
        }
        protected void drpRestaurantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantState.SelectedValue == null || drpRestaurantState.Items.Count <= 0)
            {
                return;
            } 
            BindCity();
        }
        protected void drpRestaurantCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCity.SelectedValue == null || drpRestaurantCountry.Items.Count <= 0)
            {
                return;
            }            
            Utility.BindingDropDowList(NeighbourhoodBLL.GetByCityID(Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString())), dropNeighbourhood);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RefreshControl();
        }               
    }
}