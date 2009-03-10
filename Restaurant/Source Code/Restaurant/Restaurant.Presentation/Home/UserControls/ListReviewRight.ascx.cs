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
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.Encrypt;
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity;

namespace Restaurant.Presentation.Home.UserControls
{
    public partial class ListReviewRight : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Authentication.IsLogined)
                {
                    if (FavouriteRestaurantBLL.CheckFavourite(Convert.ToInt32(RestaurantID), Authentication.CurrentMemberInfo.ID).Rows.Count > 0)
                    {
                        lbtAddWatchlist.Text = "Your Favourite";
                    }
                    else
                    {
                        if (Request.Url.PathAndQuery.Contains("add"))
                        {
                            FavouriteRestaurantInfo _favourite = new FavouriteRestaurantInfo();
                            _favourite.MemberID = Authentication.CurrentMemberInfo.ID;
                            _favourite.RestaurantID = Convert.ToInt32(RestaurantID);

                            if (FavouriteRestaurantBLL.Insert(_favourite) > 0)
                            {
                                lbtAddWatchlist.Text = "Your Favourite";
                            }
                        }
                    }

                }
                if (RestaurantID != null && RestaurantID != "")
                {
                    RestaurantInfo restaurantInfo = RestaurantBLL.GetInfo(Convert.ToInt32(RestaurantID));
                    if (restaurantInfo.CreatedByAdmin)
                    {
                        lbtYourRestaurant.Visible = true;

                    }
                    else
                    {
                        lbtYourRestaurant.Visible = false;
                    }
                }
            }
        }
        private string RestaurantID
        {
            get { return Request.QueryString["RidUrl"]; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);            
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_CREATE_REVIEW_URL + PageConstant.RESTAURANT_ID + RestaurantID);
        }
        protected void lbtYourRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_RESTAURANT_CHOOSE_PACKAGE_URL + PageConstant.RESTAURANT_ID + RestaurantID);
        }
        protected void lbtOnlineReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_INSTANCE_RESERVATION_URL + PageConstant.RESTAURANT_ID + RestaurantID);
        }
        protected void lbtGiftCertificate_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_INSTANCE_GIFT_URL + PageConstant.RESTAURANT_ID + RestaurantID);
        }
        protected void lbtOnlineOrdering_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_DELIVERY_URL);
        }
        protected void lbtAddWatchlist_Click(object sender, EventArgs e)
        {
            if (lbtAddWatchlist.Text == "Add To Watchlist")
            {
                if (Authentication.IsLogined) 
                {
                    FavouriteRestaurantInfo _favourite = new FavouriteRestaurantInfo();
                    _favourite.MemberID = Authentication.CurrentMemberInfo.ID;
                    _favourite.RestaurantID = Convert.ToInt32(RestaurantID);

                    if (FavouriteRestaurantBLL.Insert(_favourite) > 0)
                    {
                        lbtAddWatchlist.Text = "Your Favourite";
                    }
                }
                else
                {
                    string strURL = Server.UrlEncode(Request.Url.PathAndQuery + "&add=1");
                    Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + strURL);
                }
            }
            else
            {
                if (lbtAddWatchlist.Text == "Your Favourite")
                {
                    Response.Redirect(PageConstant.MANAGEMENT_FAVORITES_RESTAURANT);
                }
            }

        }
        protected void lbtRecommendToFriend_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_RECOMMEND_FRIEND + PageConstant.RESTAURANT_ID + RestaurantID);
        }
        protected void lbtContactRestaurant_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_MEMBER_CONTACT_RESTAURANT + PageConstant.RESTAURANT_ID + RestaurantID);
        }
    }
}