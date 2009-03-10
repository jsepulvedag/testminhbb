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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;


using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;namespace Restaurant.Presentation.Home.Member.Review
{
    public partial class CreateReview : AuthenticateControl//System.Web.UI.UserControl
    {
        int restaurantID;
        public int GetRestaurantID
        {
            get
            {
                return restaurantID;
            }
        }
        public int GetMemberID
        {
            get
            {
                return Authentication.CurrentMemberInfo.ID;
            }
        }
        bool t = true;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtYourReview.Attributes.Add("onkeypress"," return setTextAreaLength(this, 1500);");
                txtYourReview.Attributes.Add("onkeyup","return count(this);");
                BindReviewDetail();
                if (ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows.Count > 0)
                {
                    lblRestaurantName.Text =  ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows[0][16].ToString() + " Restaurant";
                    lblReviewCount.Text = ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows[0][18].ToString() + " Review For:";
                }
                else
                {
                    lblRestaurantName.Text = RestaurantBLL.GetInfoByRestaurant(GetRestaurantID).Rows[0]["Name"].ToString();
                    lblReviewCount.Text = "No Review For:";
                }
            }
        }
  
        #region Event
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string strURL = Server.UrlEncode(PageConstant.HOME_MEMBER_CREATE_REVIEW_URL + PageConstant.RESTAURANT_ID + Request.QueryString["RidUrl"]);
            restaurantID = Convert.ToInt32(Request.QueryString["RidUrl"]);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + strURL);
            }
        }
        protected void imgButSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (txtDisplayName.Text.Trim().Equals(""))
            {
                t = false;
                lblMessage.Visible = true;
                lblMessage.Text = "Display Name is not null";
            }
            if (t == true)
            {
                if (ReviewBLL.Insert(SetReviewInfo()) > 0)
                {
                    lblMessage.Visible = true;
                    hplResponseURL.Visible = true;
                    lblMessage.Text = "Thank you for Review. Your Review will be approved by admin before upload.";
                    hplResponseURL.Text = "Back to List Review";
                    hplResponseURL.NavigateUrl = PageConstant.HOME_PUBLIC_LIST_REVIEW_URL + PageConstant.RESTAURANT_ID + GetRestaurantID;
                    imgButSubmit.Enabled = false;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "You can not create Review for your Restaurant";
                }
            }
        }
        
        protected void imgButReset_Click(object sender, ImageClickEventArgs e)
        {
            txtDisplayName.Text = "";
            txtYourReview.Text = "";
            rdoOther.Checked = true;
            rdoVisitMaybe.Checked = true;
        }
        #endregion

        #region Set, Bind Data in control Method
        
        public ReviewInfo SetReviewInfo()
        {
            ReviewInfo reviewInfo = new ReviewInfo();
            #region Choose Meal Type <--> PartySize
            if (rdoBreakFirst.Checked)
            {
                reviewInfo.PartySize = dropPartySize.Text.Trim() + " BreakFast";
            }
            else
            {
                if (rdoLunch.Checked)
                {
                    reviewInfo.PartySize = dropPartySize.Text.Trim() + " Lunch";
                }
                else
                {
                    if (rdoDinner.Checked)
                    {
                        reviewInfo.PartySize = dropPartySize.Text.Trim() + " Dinner";
                    }
                    else
                    {
                        if(rdoOther.Checked)
                            reviewInfo.PartySize = dropPartySize.Text.Trim() + " Other";

                    }
                }
            }
            #endregion
            reviewInfo.RestaurantID = GetRestaurantID;
            reviewInfo.MemberID = GetMemberID;
            reviewInfo.Title = txtDisplayName.Text.Trim();
            reviewInfo.CreatedDate= DateTime.Now;
            reviewInfo.RateFood=Convert.ToInt32(dropFood.Text);
            reviewInfo.RateService = Convert.ToInt32(dropService.Text);
            reviewInfo.RatePrice = Convert.ToInt32(dropPrice.Text);
            reviewInfo.IsActive = 2;//pending
            reviewInfo.TableOrderService=txtYourOrder.Text;
            #region Visited Again
            if (rdoVisitMaybe.Checked)
            {
                reviewInfo.VisitAgain = "Maybe";
            }
            else 
            {
                if (rdoVisitNever.Checked)
                {
                    reviewInfo.VisitAgain = "Never";
                }else
                    if (rdoVisitYes.Checked)
                        reviewInfo.VisitAgain = "Yes";
            }
            #endregion
            reviewInfo.RateDecor = Convert.ToInt32(dropDecor.Text.Trim());
            reviewInfo.PriceRange= dropPriceRange.Text;
            reviewInfo.Description= txtYourReview.Text;
            return reviewInfo;
        }
        
        private void BindReviewDetail()
        {
            string[] members = { "1 - Poor", "2 - Bad", "3 - Fair", "4 - Good", "5 - Excellent" };
            string[] values = { "1","2","3","4","5"};
            string[] partySize ={ "< 10", "10 - 20", "20 - 50", "50 - 100", "> 100" };
            string[] priceRange ={ "< 50$", "50$ - 150$", "150$ - 300$", "> 300$" };

            Utility.BindingDropDowList(Utility.CreateTable(values, members), dropFood,dropService,dropPrice,dropDecor);

            Utility.BindingDropDowList(Utility.CreateTable(partySize, partySize), dropPartySize);
            Utility.BindingDropDowList(Utility.CreateTable(priceRange, priceRange), dropPriceRange);
        }
        
        #endregion

        
    }
}