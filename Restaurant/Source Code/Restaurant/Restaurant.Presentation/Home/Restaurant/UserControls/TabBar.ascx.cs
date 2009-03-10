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

namespace Restaurant.Presentation.Home.Restaurant.UserControls
{
    public partial class TabBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                lbReview.NavigateUrl = PageConstant.HOME_PUBLIC_LIST_REVIEW_URL + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"];
                lbPhotos.NavigateUrl = PageConstant.HOME_LIST_PHOTO_URL + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"];
                //lbGift.NavigateUrl = PageConstant.HOME_MEMBER_INSTANCE_GIFT_URL + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"];                
                lbMenu.NavigateUrl = PageConstant.HOME_RESTAURANT_MENU + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"];
            }
        }
       
    }
}