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
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Home.Restaurant.ListRestaurant
{
    public partial class ListRestaurant : System.Web.UI.UserControl
    {
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
        void PageHandling()
        {
            int pageSize = 0;
            int pageIndex = 0;
            try
            {
                pageSize = Request.QueryString["psize"] != null ? Convert.ToInt32(Request.QueryString["psize"]) : 10;
            }
            catch
            {
                pageSize = 10;
            }

            pageIndex = Request.QueryString["page"] != null ? (Convert.ToInt32(Request.QueryString["page"]) - 1) : 0;

            dgPage.PageSize = pageSize;
            dgPage.CurrentPageIndex = pageIndex;
            ddlPerpage.SelectedValue = pageSize.ToString();
        }
        void BindRestaurant()
        {
            //dtlRestaurant.DataSource = RestaurantBLL.GetAll();
            //dtlRestaurant.DataBind();

            PageHandling();

            string keyword = Request.QueryString["keyword"] != null ? Request.QueryString["keyword"] : "";
            int cityId = 0;
            cityId = Request.QueryString["cityId"] != null ? Convert.ToInt32(Request.QueryString["cityId"]) : 0;
            int StateId = 0;
            int countryId = 0;
            string cuisineId = Request.QueryString["CuisineId"] != null ? Request.QueryString["CuisineId"] : "";
            cuisineId = cuisineId == "0" ? "" : cuisineId;
            string zipCode = "";
            int neighborhoodId = 0;
            neighborhoodId = Request.QueryString["neighborhoodId"] != null ? Convert.ToInt32(Request.QueryString["neighborhoodId"]) : 0;
            int pageIndex = dgPage.CurrentPageIndex;
            int pageSize = Convert.ToInt32(ddlPerpage.SelectedValue);
            int total = 0;

            DataTable dt = RestaurantBLL.ListByCriterias(keyword, cityId, StateId, countryId, cuisineId, neighborhoodId, zipCode, pageIndex, pageSize, ref total);
            if (dt.Rows.Count <= 0)
            {
                rptRestaurant.Visible = false;
                dgPage.Visible = false;
                lblMess.Visible = true;
                lblMess.Text = "No Restaurant Records Found";
            }
            else
            {
                rptRestaurant.Visible = true;
                dgPage.Visible = true;
                rptRestaurant.DataSource = dt;
                rptRestaurant.DataBind();

                //total = dt.Rows.Count;
                dgPage.VirtualItemCount = total;
                ltResult.Text = total.ToString();

                VirtualTable();
                if (cityId > 0)
                {
                    lblTitle.Text = "Restaurants list for: " + dt.Rows[0]["CityName"].ToString();
                    if (Convert.ToInt32(Request.QueryString["CuisineId"]) > 0)
                    {
                        lblTitle.Text += " -> " + CuisineBLL.GetInfo(Convert.ToInt32(Request.QueryString["CuisineId"])).Name + " Cuisine";
                        if (neighborhoodId > 0)
                        {
                            lblTitle.Text += " -> " + NeighbourhoodBLL.GetInfo(neighborhoodId).Name + " Neighborhood";
                        }
                    }
                    else
                    {
                        lblTitle.Text += " -> All Cuisine";
                        if (neighborhoodId > 0)
                        {
                            lblTitle.Text += " -> " + NeighbourhoodBLL.GetInfo(neighborhoodId).Name + " Neighborhood";
                        }
                    }
                }

            }
            BindNeighbourhood(cityId);

        }
        void BindNeighbourhood(int cityId)
        {
            rptNeighborhood.DataSource = NeighbourhoodBLL.GetByCitySearch(cityId);
            rptNeighborhood.DataBind();
            if (rptNeighborhood.Items.Count > 0)
            {
                rptNeighborhood.Visible = true;
            }
            else
            {
                rptNeighborhood.Visible = false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            BindRestaurant();

        }

        protected void rptRestaurant_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hlkHome = (HyperLink)e.Item.FindControl("hlkHome");
                HyperLink hlkMenu = (HyperLink)e.Item.FindControl("hlkMenu");
                HyperLink hlkReservation = (HyperLink)e.Item.FindControl("hlkReservation");
                HyperLink hlkGift = (HyperLink)e.Item.FindControl("hlkGift");
                HyperLink hlkOrder = (HyperLink)e.Item.FindControl("hlkOrder");
                HyperLink hlkPhoto = (HyperLink)e.Item.FindControl("hlkPhoto");
                HyperLink hlkVideo = (HyperLink)e.Item.FindControl("hlkVideo");
                HyperLink hlkMobile = (HyperLink)e.Item.FindControl("hlkMobile");

                Image imgHome = (Image)e.Item.FindControl("imgHome");
                Image imgMenu = (Image)e.Item.FindControl("imgMenu");
                Image imgReservation = (Image)e.Item.FindControl("imgReservation");
                Image imgGift = (Image)e.Item.FindControl("imgGift");
                Image imgOrder = (Image)e.Item.FindControl("imgOrder");
                Image imgPhoto = (Image)e.Item.FindControl("imgPhoto");
                Image imgVideo = (Image)e.Item.FindControl("imgVideo");
                Image imgMobile = (Image)e.Item.FindControl("imgMobile");

                DataRowView drv = (DataRowView)e.Item.DataItem;

                //Home
                SetImageLink(true, "/Default.aspx?pid=ListReview&RidUrl=" + drv["Id"].ToString(),
                    "", ref hlkHome, ref imgHome);

                //Menu
                SetImageLink(Convert.ToBoolean(drv["AllowMenu"]), "/Default.aspx?pid=Menu&RidUrl=" + drv["Id"].ToString(),
                    "/Media/Images/menuIconDisable.jpg", ref hlkMenu, ref imgMenu);

                //Reservation
                SetImageLink(Convert.ToBoolean(drv["AllowReservation"]), PageConstant.HOME_MEMBER_INSTANCE_RESERVATION_URL + PageConstant.RESTAURANT_ID + drv["Id"].ToString(),
                    "/Media/Images/reservationIconDisable.jpg", ref hlkReservation, ref imgReservation);

                //Gift Certificate
                SetImageLink(Convert.ToBoolean(drv["AllowGiftCertificate"]), "/Default.aspx?pid=InstanceGift&RidUrl=" + drv["Id"].ToString(),
                    "/Media/Images/giftIconDisable.jpg", ref hlkGift, ref imgGift);

                //Order / Delivery
                SetImageLink(Convert.ToBoolean(drv["AllowOnlineOrder"]), "",
                    "/Media/Images/deliveryIconDisable.jpg", ref hlkOrder, ref imgOrder);

                //Photo
                SetImageLink(Convert.ToBoolean(drv["AllowPhoto"]), "/Default.aspx?pid=ListPhoto&RidUrl=" + drv["Id"].ToString(),
                    "/Media/Images/photoIconDisable.jpg", ref hlkPhoto, ref imgPhoto);

                //Video
                SetImageLink(Convert.ToBoolean(drv["AllowVideo"]), "",
                    "/Media/Images/videoIconDisable.jpg", ref hlkVideo, ref imgVideo);

                //Mobile
                SetImageLink(true, "",
                    "/Media/Images/mobileIconDisable.jpg", ref hlkMobile, ref imgMobile);
            }
        }

        void SetImageLink(bool enable, string url, string disableImagePath, ref HyperLink link, ref Image img)
        {
            if (enable)
                link.NavigateUrl = url;
            else
                img.ImageUrl = disableImagePath;
        }

        protected void ddlPerpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = UrlUtilities.UpdateQueryStringItem(Request.Url.PathAndQuery, "psize", ddlPerpage.SelectedValue);
            url = UrlUtilities.UpdateQueryStringItem(url, "page", "1");
            Response.Redirect(url);
        }

        protected void dgPage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            Response.Redirect(UrlUtilities.UpdateQueryStringItem(Request.Url.PathAndQuery, "page", (e.NewPageIndex + 1).ToString()));
        }
        protected void imgbtnJoin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL);
        }
        protected void imgbtnLinktoUs_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx?pid=LinkToUs");
        }
        protected void imgbtnInvite_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx?pid=Invite");
        }
    }
}