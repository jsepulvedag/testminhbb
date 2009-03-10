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

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class DeliverySearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            BindRestaurant();
        }

        protected void dgPage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Response.Redirect(UrlUtilities.UpdateQueryStringItem(Request.Url.PathAndQuery, "page", (e.NewPageIndex + 1).ToString()));
        }

        void SetImage(string amount, string imagePath, ref Image img)
        {
            img.ImageUrl = imagePath + amount + "Star.jpg";
        }
        #region Method Binding
        void PageHandling()
        {
            int pageSize = 0;
            int pageIndex = 0;
            try
            {
                pageSize = Request.QueryString["psize"] != null ? Convert.ToInt32(Request.QueryString["psize"]) : 5;
            }
            catch
            {
                pageSize = 5;
            }

            pageIndex = Request.QueryString["page"] != null ? (Convert.ToInt32(Request.QueryString["page"]) - 1) : 0;

            dgPage.PageSize = pageSize;
            dgPage.CurrentPageIndex = pageIndex;
            ddlPerpage.SelectedValue = pageSize.ToString();
        }
        void VirtualTable()
        {
            DataTable virTable = new DataTable();
            virTable.Columns.Add("VirtualColumn");

            DataRow virRow = virTable.NewRow();
            virRow["VirtualColumn"] = "virtualValue";
            virTable.Rows.Add(virRow);
            dgPage.DataSource = virTable;
            dgPage.DataBind();
        }
        void BindRestaurant()
        {
            PageHandling();
            int cityId = 0;
            cityId = Request.QueryString["cityId"] != null ? Convert.ToInt32(Request.QueryString["cityId"]) : 0;
            string keyword = Request.QueryString["keyword"] != null ? Request.QueryString["keyword"] : "";

            string cuisineId = Request.QueryString["CuisineID"] != null ? Request.QueryString["CuisineID"] : "";
            cuisineId = cuisineId == "0" ? "" : cuisineId;
            string zipCode = "";
            string address = Request.QueryString["address"] != null ? Request.QueryString["address"] : "";
            int fee = -1;
            if (Request.Url.PathAndQuery.Contains("Fee"))
            {
                if (Request.QueryString["fee"] != "-1")
                {
                    fee = Convert.ToInt32(Request.QueryString["fee"]);
                }
            }

            int minimumPrice = 0;
            if (Request.QueryString["MinimumPrice"] != "0")
            {
                minimumPrice = Convert.ToInt32(Request.QueryString["MinimumPrice"]);
            }
            string score = Request.QueryString["Score"] != null ? Request.QueryString["Score"] : "";
            int pageIndex = dgPage.CurrentPageIndex;
            int pageSize = 5;
            int total = 0;

            DataTable dt = RestaurantBLL.DeliverySearch(keyword, cuisineId, zipCode, address,cityId, fee, minimumPrice, score, pageSize, pageIndex, ref total);
            rptRestaurant.DataSource = dt;
            rptRestaurant.DataBind();

            dgPage.VirtualItemCount = total;
            ltResult.Text = total.ToString();

            VirtualTable();
        }
        #endregion

        protected void ddlPerpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = UrlUtilities.UpdateQueryStringItem(Request.Url.PathAndQuery, "psize", ddlPerpage.SelectedValue);
            url = UrlUtilities.UpdateQueryStringItem(url, "page", "1");
            Response.Redirect(url);
        }

    }
}
