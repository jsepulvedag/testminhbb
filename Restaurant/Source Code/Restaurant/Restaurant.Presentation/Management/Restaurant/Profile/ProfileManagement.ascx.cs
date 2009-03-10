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
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;
using System.IO;
using Restaurant.Presentation.Management.Restaurant.UserControls;
using Restaurant.Library.Utilities.GenerateThumbnailImage;

namespace Restaurant.Presentation.Management.Restaurant.Profile
{
    public partial class ProfileManagement : CheckRestaurant
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnEdit.Attributes.Add("onclick", "return confirm('Are you sure to update your restaurant information ?')");
            if (!IsPostBack)
            {
                BindDateTime();
                BindRegion();
                BindListBox();
                ConfirmRestaurant(Authentication.CurrentRestaurantInfo);
            }
        }
        public void BindState(DropDownList drpRestaurantCountry, DropDownList drpRestaurantState)
        {
            int countryID = Convert.ToInt32(drpRestaurantCountry.SelectedValue);
            if (StateBLL.GetByCountryID(countryID).Rows.Count <= 0)
            {
                countryID = Convert.ToInt32(CountryBLL.GetByPriority().Rows[0]["ID"].ToString());
                drpRestaurantCountry.SelectedValue = countryID.ToString();
            }
            Utility.BindingDropDowList(StateBLL.GetByCountryID(countryID), drpRestaurantState);
        }
        public void BindCity(DropDownList drpCountry, DropDownList drpRestaurantState, DropDownList drpRestaurantCity)
        {
            int StateID = Convert.ToInt32(drpRestaurantState.SelectedValue);
            if (CityBLL.GetByStateID(StateID).Rows.Count <= 0)
            {
                Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCountry.SelectedValue)), drpRestaurantState);
                StateID = Convert.ToInt32(drpRestaurantState.SelectedValue);
            }
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpRestaurantState.SelectedValue)), drpRestaurantCity);
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

            string[] years = new string[120];
            for (int i = 0; i < 120; i++)
            {
                years[i] = Convert.ToString(DateTime.Now.Year - i);
            }

            Utility.BindingDropDowList(Utility.CreateTable(monthValues, monthDisplays), drpCurrentMonth, drpOpenedMonth);
            Utility.BindingDropDowList(Utility.CreateTable(days, days), drpCurrentDay, drpOpenedDay);
            Utility.BindingDropDowList(Utility.CreateTable(years, years), drpCurrentYear);
        }
        private void BindRegion()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drpCurrentCountry, drpRestaurantCountry);
        }
        private void BindListBox()
        {
            Utility.BindingListBox(GoodForBLL.GetAll(), listGoodFor);
            Utility.BindingListBox(AtmosphereBLL.GetAll(), listAtmosphere);
            Utility.BindingListBox(SpecialBLL.GetAll(), listSpecial);
            Utility.BindingListBox(CuisineBLL.GetAll(), listCuisine);
            Utility.BindingListBox(MusicBLL.GetAll(), listMusic);
            Utility.BindingListBox(AttireBLL.GetAll(), listAttire);
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
        private void ConfirmRestaurant(RestaurantInfo restaurantInfo)
        {
            txtCurrentAddress.Text = restaurantInfo.AddressContact;
            txtCurrentEmail.Text = restaurantInfo.EmailContact;
            txtCurrentFax.Text = restaurantInfo.FaxContact;
            txtCurrentFirstName.Text = restaurantInfo.FirstNameContact;
            txtCurrentLastName.Text = restaurantInfo.LastNameContact;
            txtCurrentPhone.Text = restaurantInfo.PhoneContact;
            txtCurrentZipCode.Text = restaurantInfo.ZipcodeContact;

            drpCurrentCountry.SelectedValue = restaurantInfo.CountryIDContact.ToString();
            drpCurrentCountry_SelectedIndexChanged(drpCurrentCountry, new EventArgs());
            drpCurrentState.SelectedValue = restaurantInfo.StateIDContact.ToString();
            drpCurrentState_SelectedIndexChanged(drpCurrentState, new EventArgs());
            drpCurrentCity.SelectedValue = restaurantInfo.CityIDContact.ToString();

            drpCurrentDay.SelectedValue = restaurantInfo.BirthdayContact.Day.ToString();
            drpCurrentMonth.SelectedValue = restaurantInfo.BirthdayContact.Month.ToString();
            drpCurrentYear.SelectedValue = restaurantInfo.BirthdayContact.Year.ToString();
            drpCurrentGender.SelectedValue = restaurantInfo.GenderContact;

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
            imgRestaurant.ImageUrl = restaurantInfo.Image;

            drpRestaurantCountry.SelectedValue = restaurantInfo.CountryID.ToString();
            drpRestaurantCountry_SelectedIndexChanged(drpRestaurantCountry, new EventArgs());
            drpRestaurantState.SelectedValue = restaurantInfo.StateID.ToString();
            drpRestaurantState_SelectedIndexChanged(drpRestaurantState, new EventArgs());
            drpRestaurantCity.SelectedValue = restaurantInfo.CityID.ToString();
            drpRestaurantCity_SelectedIndexChanged(drpRestaurantCity, new EventArgs());

            Utility.BindingListBox(RestaurantBLL.GetAtmosphere(restaurantInfo.ID), listAtmosphereSelected);
            RemoveSameItem(listAtmosphere, listAtmosphereSelected);
            Utility.BindingListBox(RestaurantBLL.GetAttire(restaurantInfo.ID), listAttireSelected);
            RemoveSameItem(listAttire, listAttireSelected);
            Utility.BindingListBox(RestaurantBLL.GetCuisine(restaurantInfo.ID), listCuisineSelected);
            RemoveSameItem(listCuisine, listCuisineSelected);
            Utility.BindingListBox(RestaurantBLL.GetGoodFor(restaurantInfo.ID), listGoodForSelected);
            RemoveSameItem(listGoodFor, listGoodForSelected);
            Utility.BindingListBox(RestaurantBLL.GetMusic(restaurantInfo.ID), listMusicSelected);
            RemoveSameItem(listMusic, listMusicSelected);
            Utility.BindingListBox(RestaurantBLL.GetSpecial(restaurantInfo.ID), listSpecialSelected);
            RemoveSameItem(listSpecial, listSpecialSelected);

            NeighbourhoodInfo neighbourhood = RestaurantBLL.GetNeighbourhoodInfo(restaurantInfo.ID);
            if (neighbourhood != null)
            {
                dropNeighbourhood.SelectedValue = neighbourhood.ID.ToString();
            }
        }
        private RestaurantInfo OnSetRestaurant
        {
            get
            {
                RestaurantInfo info = Authentication.CurrentRestaurantInfo;
                info.FirstNameContact = txtCurrentFirstName.Text.Trim();
                info.LastNameContact = txtCurrentLastName.Text.Trim();
                info.GenderContact = drpCurrentGender.SelectedValue.ToString();
                info.PhoneContact = txtCurrentPhone.Text.Trim();
                info.ZipcodeContact = txtCurrentZipCode.Text.Trim();
                info.FaxContact = txtCurrentFax.Text.Trim();
                info.EmailContact = txtCurrentEmail.Text.Trim();
                info.BirthdayContact = Convert.ToDateTime(drpCurrentMonth.SelectedValue.ToString() + "/" + drpCurrentDay.SelectedValue.ToString() + "/" + drpCurrentYear.SelectedValue.ToString());
                info.AddressContact = txtCurrentAddress.Text.Trim();
                info.CountryIDContact = Convert.ToInt32(drpCurrentCountry.SelectedValue.ToString());
                info.CityIDContact = Convert.ToInt32(drpCurrentCity.SelectedValue.ToString());
                info.StateIDContact = Convert.ToInt32(drpCurrentState.SelectedValue.ToString());
                if (fuImage.PostedFile.ContentLength != 0)
                {
                    info.Image += DateTime.Now.ToString().Replace(":", "-").Replace("/", ".").Replace(" ", "_");
                    int length = fuImage.PostedFile.FileName.Length;
                    info.Image += (length > 12) ? fuImage.PostedFile.FileName.Substring(length - 12, 12) : fuImage.PostedFile.FileName;
                    string path = "~/Media/Restaurants/" + info.ID + "/TempImagePhoto/";
                    string save = "~/Media/Restaurants/" + info.ID + "/Photos/Main/";
                    DirectoryInfo directpath = new DirectoryInfo(Server.MapPath(path));
                    fuImage.PostedFile.SaveAs(directpath + info.Image);
                    FileInfo[] files = directpath.GetFiles();
                    if (files.Length > 0)
                    {
                        foreach (FileInfo file in files)
                        {
                            if (file.Name == info.Image)
                            {
                                Generator generator = new Generator(170, 206, Server.MapPath(path + file.Name), Server.MapPath(save + file.Name));
                                generator.SaveThumbnail();
                                continue;
                            }
                            file.Delete();
                        }
                    }
                    info.Image = save + info.Image;
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

                return info;
            }
        }
        private RestaurantGoodForList OnSetRestaurantGoodFor
        {
            get
            {
                RestaurantGoodForList goodFor = new RestaurantGoodForList();
                foreach (ListItem item in listGoodForSelected.Items)
                {
                    RestaurantGoodForInfo obj = new RestaurantGoodForInfo();
                    obj.GoodForID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                foreach (ListItem item in listCuisineSelected.Items)
                {
                    RestaurantCuisineInfo obj = new RestaurantCuisineInfo();
                    obj.CuisineID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                foreach (ListItem item in listSpecialSelected.Items)
                {
                    RestaurantSpecialInfo obj = new RestaurantSpecialInfo();
                    obj.SpecialID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                foreach (ListItem item in listMusicSelected.Items)
                {
                    RestaurantMusicInfo obj = new RestaurantMusicInfo();
                    obj.MusicID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                foreach (ListItem item in listAttireSelected.Items)
                {
                    RestaurantAttireInfo obj = new RestaurantAttireInfo();
                    obj.AttireID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
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
                foreach (ListItem item in listAtmosphereSelected.Items)
                {
                    RestaurantAtmosphereInfo obj = new RestaurantAtmosphereInfo();
                    obj.AtmosphereID = Convert.ToInt32(item.Value.ToString());
                    obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
                    atmosphere.Add(obj);
                }
                return atmosphere;
            }
        }
        protected void drpCurrentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCurrentCountry.SelectedValue == null)
            {
                return;
            }
            BindState(drpCurrentCountry, drpCurrentState);
            BindCity(drpCurrentCountry, drpCurrentState, drpCurrentCity);
        }
        protected void drpCurrentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCurrentCountry.SelectedValue == null || drpCurrentCountry.SelectedValue.ToString() != "")
            {
                return;
            }
            BindCity(drpCurrentCountry, drpCurrentState, drpCurrentCity);
        }
        protected void drpRestaurantCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCountry.SelectedValue == null)
            {
                return;
            }
            BindState(drpRestaurantCountry, drpRestaurantState);
            BindCity(drpRestaurantCountry, drpRestaurantState, drpRestaurantCity);

        }
        protected void drpRestaurantState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantState.SelectedValue == null)
            {
                return;
            }
            BindCity(drpRestaurantCountry, drpRestaurantState, drpRestaurantCity);
        }
        protected void drpRestaurantCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpRestaurantCity.SelectedValue == null)
            {
                return;
            }
            Utility.BindingDropDowList(NeighbourhoodBLL.GetByCityID(Convert.ToInt32(drpRestaurantCity.SelectedValue.ToString())), dropNeighbourhood);
        }
        #region ListEvent
        protected void btnSelectedGoodFor_Click(object sender, EventArgs e)
        {
            SwapItem(listGoodFor, listGoodForSelected);
        }
        protected void btnGoodFor_Click(object sender, EventArgs e)
        {
            SwapItem(listGoodForSelected, listGoodFor);
        }
        protected void btnSelectedCuisine_Click(object sender, EventArgs e)
        {
            SwapItem(listCuisine, listCuisineSelected);
        }
        protected void btnCuisine_Click(object sender, EventArgs e)
        {
            SwapItem(listCuisineSelected, listCuisine);
        }
        protected void btnSelectedSpecial_Click(object sender, EventArgs e)
        {
            SwapItem(listSpecial, listSpecialSelected);
        }
        protected void btnSpecial_Click(object sender, EventArgs e)
        {
            SwapItem(listSpecialSelected, listSpecial);
        }
        protected void btnSelectedMusic_Click(object sender, EventArgs e)
        {
            SwapItem(listMusic, listMusicSelected);
        }
        protected void btnMusic_Click(object sender, EventArgs e)
        {
            SwapItem(listMusicSelected, listMusic);
        }
        protected void btnSelectedAttire_Click(object sender, EventArgs e)
        {
            SwapItem(listAttire, listAttireSelected);
        }
        protected void btnAttire_Click(object sender, EventArgs e)
        {
            SwapItem(listAttireSelected, listAttire);
        }
        protected void btnSelectedAtmosphere_Click(object sender, EventArgs e)
        {
            SwapItem(listAtmosphere, listAtmosphereSelected);
        }
        protected void btnAtmosphere_Click(object sender, EventArgs e)
        {
            SwapItem(listAtmosphereSelected, listAtmosphere);
        }
        #endregion
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                RestaurantBLL.Update(OnSetRestaurant);
                RestaurantAtmosphereListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantAtmosphereListBLL.Insert(OnSetRestaurantAtmosphere);
                RestaurantAttireListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantAttireListBLL.Insert(OnSetRestaurantAttire);
                RestaurantCuisineListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantCuisineListBLL.Insert(OnSetRestaurantCuisine);
                RestaurantGoodForListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantGoodForListBLL.Insert(OnSetRestaurantGoodFor);
                RestaurantMusicListBLL.DeletebyRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantMusicListBLL.Insert(OnSetRestaurantMusic);

                RestaurantNeighbourhoodListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantNeighbourhoodListBLL.Insert(OnSetRestaurantNeightbourhood);

                RestaurantSpecialListBLL.DeleteByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                RestaurantSpecialListBLL.Insert(OnSetRestaurantSpecial);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}