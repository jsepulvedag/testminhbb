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

namespace Restaurant.Presentation.Administrator.UserControls
{
    public partial class SearchRestaurant : System.Web.UI.UserControl
    {
        #region  GetPageIndex, GetPageSize, GetTotal Properties
        private int totalRecord ;
        public int GetTotal
        {
            get
            {
                return totalRecord;
            }
            set
            {
                totalRecord = value;
            }
        }
        public int GetPageIndex
        {
            get
            {
                return 1;
            }
        }
        public int GetPageSize
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["PageSize"]);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindingDropSearch();
            
        }
        
        #region Binding Drop, Binding GridView  Method
        private void BindingDropSearch()
        {
            Utility.BindingDropDowList(CountryBLL.GetAll(), drpCountry);
            Utility.BindingDropDowList(CuisineBLL.GetAll(), drpCuisine);
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCountry.SelectedValue)),drpState);
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpState.SelectedValue)), drpCity);
        }
        public void BindingGridView(GridView grvSearch, string keyword, ref int total)
        {            
            grvSearch.DataSource = RestaurantBLL.Admin_ListByCriterias(keyword, Convert.ToInt32(drpCity.SelectedValue), Convert.ToInt32(drpState.SelectedValue), Convert.ToInt32(drpCountry.SelectedValue), drpCuisine.SelectedValue, txtZip.Text,GetPageIndex,GetPageSize,ref total);
            grvSearch.DataBind();
        }
        #endregion

        #region Event Drop, Button
        public void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            string keyword = txtRestaurantName.Text.Trim() + txtZip.Text.Trim() + drpCountry.Text.Trim() + drpState.Text.Trim() + drpCity.Text.Trim() + drpCuisine.Text.Trim();
            GridView g = new GridView();
            BindingGridView(g, keyword, ref totalRecord);
        }

        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCountry.SelectedValue)), drpState);
        }
        protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpState.SelectedValue)), drpCity);
        }
        #endregion
    }
}