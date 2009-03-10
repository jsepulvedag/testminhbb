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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Management.Member.UserControls
{
    public partial class Menu : AuthenticateControl
    {
        void BuildMenu()
        {     
            hplProfile.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_VIEW_PROFILE;
            hplChangePassword.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_CHANGE_PASSWORD;
            hplMyReservation.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_MY_RESERVATION;
            hplOrder.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_UNDERCONSTRUCTION;
            hplMyGiftCertificate.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_MY_GIFT;
            hplReview.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_REVIEW;
            hplFavourite.NavigateUrl = PageConstant.MANAGEMENT_FAVORITES_RESTAURANT;
            hplTransactionHistory.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_HISTORY_TRANSACTION;

            DataTable dt = RestaurantBLL.GetByMemberID(Authentication.CurrentMemberInfo.ID);
            pnlRestaurantMenu.Visible = dt.Rows.Count > 0;
            if (dt.Rows.Count == 0)
                return;
            rptRestaurant.DataSource = dt;
            rptRestaurant.DataBind();
                                                
            hplRestaurantInfo.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_PROFILE;
            hplMenu.NavigateUrl = PageConstant.MANAGEMENT_RESTAURAN_MENUCATEGORY;
            hplPhoto.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_PHOTO;
            hplVideo.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_UNDERCONSTRUCTION;
            hplEvents.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_UNDERCONSTRUCTION;
            hplSettingService.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_SETTING_SERVICE;
            hplReservation.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_RESERVATION;
            hplBusinessAccount.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_BUSINESS_ACCOUNT;
            hplOrderingOnlineParam.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_ORDER_PARAMETER;
            hplGiftCertificate.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_GIFT_PURCHASE;
            hplGiftCertificateParam.NavigateUrl = PageConstant.MANAGEMENT_RESTAURANT_GIFT_PARAMETER;
            hplReview.NavigateUrl = PageConstant.MANAGEMENT_MEMBER_REVIEW;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            BuildMenu();
        }

        protected void rptRestaurant_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltRestaurantName = (Literal)e.Item.FindControl("ltRestaurantName");
                LinkButton lkbRestaurantName = (LinkButton)e.Item.FindControl("lkbRestaurantName");
                lkbRestaurantName.CausesValidation = false;
                DataRowView drv = (DataRowView)e.Item.DataItem;

                if (Convert.ToInt32(drv["Id"]) == Authentication.CurrentRestaurantInfo.ID)
                {
                    
                    ltRestaurantName.Text = "<b>" + drv["Name"].ToString() + "</b>";
                    ltRestaurantName.Visible = true;
                    lkbRestaurantName.Visible = false;
                    //HyperLink hplRestaurantName = (HyperLink)e.Item.FindControl("hplRestaurantName");

                    //if (drv["IsActive"].ToString().Equals("False"))
                    //{
                    //    hplRestaurantName.NavigateUrl = @"~/Management/Default.aspx?mid=BlockRestaurant";
                    //}
                    //else
                    //{
                    //    if (drv["IsActive"].ToString().Equals("False"))
                    //    {
                    //        hplRestaurantName.NavigateUrl = @"~/Management/Default.aspx?mid=MemberRestaurant";
                    //    }
                    //}
                }
                else {
                    lkbRestaurantName.Text = drv["Name"].ToString();
                    lkbRestaurantName.Visible = true;
                    ltRestaurantName.Visible = false;
                }
            }
        }

        protected void rptRestaurant_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "switchrestaurant")
            {
                int restaurantId = Convert.ToInt32(e.CommandArgument);
                MemberBLL.UpdateLastRestaurantId(Authentication.CurrentMemberInfo.ID, restaurantId);
                Response.Redirect(PageConstant.MANAGEMENT_RESTAURANT_PROFILE);
            }
        }
    }
}