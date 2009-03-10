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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Administrator.RestaurantManagement.ListRestaurant
{
    public partial class ListRestaurant : AuthenticateControl
    {
        int pageSize = 7;
        int pageIndex = 0;
        int pageCount = 0;
        int total = 0;
        static string idRes = "";
        static string[] str;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindingDropSearch();
                BidingGridSearch(pageIndex, pageSize, ref total);
                pageCount = GetPageCount(pageSize, total);
            }
        }
        #region Biding Drop, Insert row in drop, Gridview Method
        private void AddFirstListItem(ref DropDownList ddl, string str)
        {
            ListItem lst = new ListItem(str, "0");
            ddl.Items.Insert(0, lst);
            ddl.SelectedIndex = 0;
        }
        private void BindingDropSearch()
        {
            if (!IsPostBack)
            {

                Utility.BindingDropDowList(CountryBLL.GetAll(), drpCountry);
                Utility.BindingDropDowList(CuisineBLL.GetAll(), drpCuisine);
                Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCountry.SelectedValue)), drpState);
                Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpState.SelectedValue)), drpCity);
            }
            AddFirstListItem(ref drpCountry, "All");
            AddFirstListItem(ref drpState, "All");
            AddFirstListItem(ref drpCity, "All");
            AddFirstListItem(ref drpCuisine, "All");
        }
        /// <summary>
        /// Binding GridView when search with 
        /// infomation search:country, id, state, cuisine, 
        ///                   restaurant name, zipcode
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="total"></param>
        private void BidingGridSearch(int _pageIndex, int _pageSize, ref int total)
        {
            string cuisineID;
            if (drpCuisine.SelectedValue.ToString().Equals("0"))
            {
                cuisineID = "";
            }
            else
            {
                cuisineID = drpCuisine.SelectedValue.ToString();
            }
            int record = RestaurantBLL.Admin_ListByCriterias(txtRestaurantName.Text.Trim(), Convert.ToInt32(drpCity.SelectedValue), Convert.ToInt32(drpState.SelectedValue), Convert.ToInt32(drpCountry.SelectedValue), cuisineID, txtZip.Text.Trim(), _pageIndex, _pageSize, ref total).Rows.Count;
            if (record > 0)
            {
                grvRestaurant.Visible = true;
                grvRestaurant.DataSource = RestaurantBLL.Admin_ListByCriterias(txtRestaurantName.Text.Trim(), Convert.ToInt32(drpCity.SelectedValue), Convert.ToInt32(drpState.SelectedValue), Convert.ToInt32(drpCountry.SelectedValue), cuisineID, txtZip.Text.Trim(), _pageIndex, _pageSize, ref total);
                grvRestaurant.DataBind();
                lblPage.Visible = true;
                dropPage.Visible = true;
                lblMess.Visible = false;
            }
            else
            {
                lblMess.Visible = true;
                lblMess.Text = "No result for infomation search.";
                lblPage.Visible = false;
                dropPage.Visible = false;
                grvRestaurant.Visible = false;
            }

        }

        /// <summary>
        /// get page count of with record total and pagesize
        /// </summary>
        /// <param name="_pageSize"></param>
        /// <param name="_totalRecord"></param>
        /// <returns></returns>
        private int GetPageCount(int _pageSize, int _totalRecord)
        {
            int t = (_totalRecord / _pageSize);//div operator
            int mod = (_totalRecord % _pageSize);//mod operator
            if (mod == 0)
            {
                pageCount = t;
            }
            else
            {
                if (mod < _pageSize)
                {
                    pageCount = t + 1;
                }
                else
                {
                    pageCount = t + 2;
                }
            }
            string[] strPage = new string[pageCount];
            for (int i = 0; i < pageCount; i++)
            {
                strPage[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(dropPage, Utility.CreateTable(strPage, strPage));
            return pageCount;
        }
        #endregion

        #region Bind drop when drop_selectedChange
        protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpState.SelectedValue)), drpCity);
            AddFirstListItem(ref drpCity, "All");
        }
        protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.BindingDropDowList(StateBLL.GetByCountryID(Convert.ToInt32(drpCountry.SelectedValue)), drpState);
            Utility.BindingDropDowList(CityBLL.GetByStateID(Convert.ToInt32(drpCountry.SelectedValue)), drpCity);

            AddFirstListItem(ref drpState, "All");
            AddFirstListItem(ref drpCity, "All");
        }
        #endregion
        #region Event

        protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            BidingGridSearch(Convert.ToInt32(dropPage.SelectedValue) - 1, pageSize, ref total);
            dropPage.Text = dropPage.SelectedValue;
        }
        protected void grvRestaurant_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropStatus = (DropDownList)e.Row.FindControl("dropStatus");
                HiddenField hdfStatus = (HiddenField)e.Row.FindControl("hdfStatus");

                DataRowView drv = (DataRowView)e.Row.DataItem;

                HyperLink hlkReservation = (HyperLink)e.Row.FindControl("hlkReservation");
                hlkReservation.NavigateUrl = "/Administrator/Default.aspx?ctrl=ReservationGift"
                    + "&RidUrl=" + drv["Id"].ToString();

                if ((hdfStatus != null) && (dropStatus != null))
                {
                    if (hdfStatus.Value.ToLower() == "true")
                    {
                        dropStatus.SelectedValue = "1";
                    }
                    else
                    {
                        dropStatus.SelectedValue = "0";
                    }
                }
            }
        }
        protected void grvRestaurant_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int restaurantID = Convert.ToInt32(e.CommandArgument.ToString());

            RestaurantInfo resInfo = RestaurantBLL.GetInfoByAdmin(restaurantID);
            if (e.CommandName.Equals("ApproveUpdate"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)(e.CommandSource)).NamingContainer);
                DropDownList dropStatus = (DropDownList)gvr.FindControl("dropStatus");
                if (dropStatus.SelectedValue == "1")
                {
                    resInfo.IsActive = true;
                }
                else
                {
                    if (dropStatus.SelectedValue == "0")
                    {
                        resInfo.IsActive = false;
                    }
                }
                if (RestaurantBLL.Update(resInfo) == true)
                {
                    pageIndex = Convert.ToInt32(dropPage.SelectedValue) - 1;
                    BidingGridSearch(pageIndex, pageSize, ref total);
                }
            }
            if (e.CommandName.Equals("LogAsThisRestaurant"))
            {
                Authentication.AdminMemberId = resInfo.MemberID;
                MemberBLL.UpdateLastRestaurantId(resInfo.MemberID, restaurantID);
                Response.Redirect("/Management/Default.aspx?mid=Profile");
            }

        }
        protected void butSearch_Click(object sender, EventArgs e)
        {
            BidingGridSearch(pageIndex, pageSize, ref total);
            pageCount = GetPageCount(pageSize, total);
        }

        #endregion
    }
}