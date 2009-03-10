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

namespace Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant
{
    public partial class AddRestaurant : AuthenticateControl
    {
        #region properties, page_load    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDateTime();
                BindLocal();
                BindListBox();
            }
        }
        #endregion
        #region Binding ListBox, Local, Datetime, swap listbox and get

        private void BindListBox()
        {
            Utility.BindingListBox(GoodForBLL.GetAll(), listGoodFor);
            Utility.BindingListBox(AtmosphereBLL.GetAll(), listAtmosphere);
            Utility.BindingListBox(SpecialBLL.GetAll(), listSpecial);
            Utility.BindingListBox(CuisineBLL.GetAll(), listCuisine);
            Utility.BindingListBox(MusicBLL.GetAll(), listMusic);
            Utility.BindingListBox(AttireBLL.GetAll(), listAttire);
        }
        private void BindDateTime()
        {
            string[] monthDisplays = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] monthValues = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

            string[] days = new string[31];
            for (int i = 0; i < 31; i++)
            {
                days[i] = Convert.ToString(i + 1);
            }

        }
        public void BindState()
        {
            int countryID = Convert.ToInt32(drpRestaurantCountry.SelectedValue);
            if (StateBLL.GetByCountryID(countryID).Rows.Count <= 0)
            {
                countryID = Convert.ToInt32(CountryBLL.GetByPriority().Rows[0]["ID"].ToString());
                drpRestaurantCountry.SelectedValue= countryID.ToString();
            }
            Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drpRestaurantState);
        }
        public void BindCity()
        {
            int StateID = Convert.ToInt32(drpRestaurantState.SelectedValue);
            if (CityBLL.GetByStateID(StateID).Rows.Count <= 0)
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpRestaurantCountry.SelectedValue)), drpRestaurantState);
                StateID= Convert.ToInt32(drpRestaurantState.SelectedValue);
            }
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpRestaurantState.SelectedValue)), drpRestaurantCity);
        }
        private void BindLocal()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drpRestaurantCountry);
            BindState();
            BindCity();
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

        #endregion
        #region Set Restaurant Package
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


        #region Set Info method
        private void CheckEmail()
        {
            if (txtRestaurantEmail.Text.Trim() != "")
            {
                MemberInfo _mbInfo = MemberBLL.GetInfo_Email(txtRestaurantEmail.Text.Trim());
                if (_mbInfo.ID > 0)
                {
                    MessageBox.Show("Your Restaurant Email does exist.");
                }
            }
            else
            {
                if (txtRestaurantEmail.Text.Trim() != "")
                {
                    MessageBox.Show("Email is not null");
                }
            }
        }
        private RestaurantInfo OnSetRestaurant
        {
            get
            {
                RestaurantInfo info = new RestaurantInfo();
                info.Image = "No Image";
                if (fuImage.PostedFile.ContentLength != 0)
                {
                    info.Image += DateTime.Now.ToString().Replace(":", "-").Replace("/", ".").Replace(" ", "_");
                    int length = fuImage.PostedFile.FileName.Length;
                    info.Image += (length > 12) ? fuImage.PostedFile.FileName.Substring(length - 12, 12) : fuImage.PostedFile.FileName;
                    DirectoryInfo path = new DirectoryInfo(Server.MapPath("~/Media/TempImage/TempRestaurantImage/"));
                    if (!path.Exists)
                    {
                        path.Create();
                    }
                    fuImage.PostedFile.SaveAs(path + info.Image);
                }
                info.Name = txtRestaurantName.Text.Trim();
                info.ZipCode = txtRestaurantZipcode.Text.Trim();
                info.Website = txtRestaurantWebsite.Text.Trim();
                info.Phone1 = txtRestaurantPhone1.Text.Trim();
                info.Phone2 = txtRestaurantPhone2.Text.Trim();
                info.Fax = txtRestaurantFax.Text.Trim();
                info.Email = txtRestaurantEmail.Text.Trim();
                info.AcceptCreditCard = chkAcceptCreditCard.Checked;
                info.DateOpened = DateTime.Now;
                info.CountryID = Convert.ToInt32(drpRestaurantCountry.SelectedValue.ToString());
                info.StateID = Convert.ToInt32(drpRestaurantState.SelectedValue.ToString());
                info.CityID = Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString());
                info.Address = txtRestaurantAddress.Text.Trim();
                info.Description = txtRestaurantDescription.Text.Trim();
                info.CreatedByAdmin = true;
                info.IsActive = true;
                return info;
            }
        }
        private MemberInfo OnSetMember
        {
            get {
                MemberInfo mb = new MemberInfo();
                mb.FirstName = txtContactFirstName.Text.Trim();
                mb.LastName = txtContactLastName.Text.Trim();
                return mb;
            }
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
        #endregion
        #region Event
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //CheckEmail();
            if (txtRestaurantEmail.Text.Trim() != "" || txtRestaurantEmail.Text.Trim() != null)
            {
                MemberInfo _mbInfo = MemberBLL.GetInfo_Email(txtRestaurantEmail.Text.Trim());
                if (_mbInfo !=null)
                {
                    MessageBox.Show("Your Restaurant Email does exist.");
                }
                else
                {
                    Session[PageConstant.SESSION_RESTAURANT_INFO] = OnSetRestaurant;
                    Session[PageConstant.SESSION_MEMBER_INFO] = OnSetMember;
                    Session[PageConstant.SESSION_RESTAURANT_ATMOSPHERE] = OnSetRestaurantAtmosphere;
                    Session[PageConstant.SESSION_RESTAURANT_ATTIRE] = OnSetRestaurantAttire;
                    Session[PageConstant.SESSION_RESTAURANT_CUISINE] = OnSetRestaurantCuisine;
                    Session[PageConstant.SESSION_RESTAURANT_GOODFOR] = OnSetRestaurantGoodFor;
                    Session[PageConstant.SESSION_RESTAURANT_MUSIC] = OnSetRestaurantMusic;
                    Session[PageConstant.SESSION_RESTAURANT_NEIGHBOURHOOD] = OnSetRestaurantNeightbourhood;
                    Session[PageConstant.SESSION_RESTAURANT_SPECIAL] = OnSetRestaurantSpecial;
                    Response.Redirect(PageConstant.ADMIN_CREATE_MEMBER_URL);
                }
            }
            else
            {
                MessageBox.Show("Email is not null");
                return;
            }
            
        }
        protected void drpRestaurantCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCountry.SelectedValue == null)
            {
                return;
            }
            BindState();
            drpRestaurantState_SelectedIndexChanged(drpRestaurantState,new EventArgs());
        }
        protected void drpRestaurantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantState.SelectedValue == null)
            {
                return;
            } 
            BindCity();
            drpRestaurantCity_SelectedIndexChanged(drpRestaurantCity, new EventArgs());
        }
        protected void drpRestaurantCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCity.SelectedValue == null)
            {
                return;
            }
            //listSelectedNeighbourhood.Items.Clear();
            //Utility.BindingListBox(NeighbourhoodBLL.GetByCityID(Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString())), listNeighbourhood);
            Utility.BindingDropDowList(NeighbourhoodBLL.GetByCityID(Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString())), dropNeighbourhood);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtRestaurantDescription.Text = "";
            txtContactFirstName.Text = "";
            txtContactLastName.Text = "";
            txtRestaurantPhone1.Text = "";
            txtRestaurantPhone2.Text = "";
            txtRestaurantWebsite.Text = "";
            txtRestaurantZipcode.Text = "";
            txtRestaurantFax.Text = "";
            //txtOpendYear.Text = "";
        }
        #endregion
        #region Event ListBox
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
            SwapItem(listSelectedCuisine, listCuisine);
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
            SwapItem(listSelectedMusic, listMusic);
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
            SwapItem(listAtmosphere, listSelectedAtmosphere);
        }
        protected void btnAtmosphere_Click(object sender, EventArgs e)
        {
            SwapItem(listSelectedAtmosphere, listAtmosphere);
        }
        #endregion                
    }
}
