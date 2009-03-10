using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Home.Restaurant.Review
{
    public partial class ReviewDetail : System.Web.UI.UserControl
    {
        int restaurantID, reviewID;
        protected void Page_Load(object sender, EventArgs e)
        {
            restaurantID = Convert.ToInt32(Request.QueryString["RidUrl"].ToString());
            reviewID = Convert.ToInt32(Request.QueryString["ReviewID"].ToString());
            if (ReviewBLL.GetByRestaurant(restaurantID, reviewID).Rows.Count > 0)
            {
                dtlReviewDetail.DataSource = ReviewBLL.GetByRestaurant(restaurantID, reviewID);
                dtlReviewDetail.DataBind();
                HyperLink2.NavigateUrl = PageConstant.HOME_PUBLIC_LIST_REVIEW_URL + PageConstant.RESTAURANT_ID + restaurantID.ToString();
            }
        }       
    }
}