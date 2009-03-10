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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Telerik.WebControls.Design;
using Telerik.RadComboboxUtils;
using Telerik.RadMenuUtils;
using Telerik.RadUploadUtils;
using Telerik.RadWindowUtils;
using Restaurant.Library.Utilities.DataBinder;
using System.Text.RegularExpressions;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Administrator.Review
{
    public partial class ReviewManagement : System.Web.UI.UserControl
    {
        public int GetReviewID
        {
            get
            {
                return Convert.ToInt32(str[0].ToString());
            }
        }
        public int GetMemberID
        {
            get
            {
                return Convert.ToInt32(str[1].ToString());
            }
        }
        public int GetRestaurantID
        {
            get
            {
                return Convert.ToInt32(str[2].ToString());
            }
        }
        bool t = true;

        static string[] str;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int filter = 3;
                BindGridView(filter);
            }
        }

        #region Method

        private void BindGridView(int filter)
        {
            if (ReviewBLL.GetByAdmin(filter).Rows.Count > 0)
            {
                grvReviewAdmin.DataSource = ReviewBLL.GetByAdmin(filter);
                grvReviewAdmin.DataBind();
                lblMessage.Visible = false;
                grvReviewAdmin.Visible = true;
            }
            else
            {
                lblMessage.Visible = true;
                grvReviewAdmin.Visible = false;
            }
        }
        private void BindReviewDetail()
        {
            string[] members = { "1", "2", "3", "4", "5" };
            string[] partySize ={ "< 10", "10 - 20", "20 - 50", "50 - 100", "> 100" };
            string[] priceRange ={ "< 50$", "50$ - 150$", "150$ - 300$", "> 300$" };

            Utility.BindingDropDowList(Utility.CreateTable(members, members), dropFood);
            Utility.BindingDropDowList(Utility.CreateTable(members, members), dropPrice);
            Utility.BindingDropDowList(Utility.CreateTable(members, members), dropService);
            Utility.BindingDropDowList(Utility.CreateTable(members, members), dropDecor);

            Utility.BindingDropDowList(Utility.CreateTable(partySize, partySize), dropPartySize);
            Utility.BindingDropDowList(Utility.CreateTable(priceRange, priceRange), dropPriceRange);
        }
        public ReviewInfo SetReviewInfo(int isActive)
        {
            ReviewInfo reviewInfo = new ReviewInfo();
            reviewInfo.ID = GetReviewID;
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
                        if (rdoOther.Checked)
                            reviewInfo.PartySize = dropPartySize.Text.Trim() + " Other";

                    }
                }
            }
            #endregion
            reviewInfo.RestaurantID = GetRestaurantID;
            reviewInfo.MemberID = GetMemberID;
            if (!txtDisplayName.Text.Trim().Equals(""))
            {
                t = true;
                reviewInfo.Title = txtDisplayName.Text.Trim();
            }
            else
            {
                t = false;
            }
            reviewInfo.CreatedDate = DateTime.Now;
            reviewInfo.RateFood = Convert.ToInt32(dropFood.Text);
            reviewInfo.RateService = Convert.ToInt32(dropService.Text);
            reviewInfo.RatePrice = Convert.ToInt32(dropPrice.Text);
            reviewInfo.IsActive = isActive;
            reviewInfo.TableOrderService = txtYourOrder.Text;
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
                }
                else
                    if (rdoVisitYes.Checked)
                        reviewInfo.VisitAgain = "Yes";
            }
            #endregion

            reviewInfo.PriceRange = dropPriceRange.Text;
            reviewInfo.Description = txtYourReview.Text;
            reviewInfo.RateDecor = Convert.ToInt32(dropDecor.Text);
            return reviewInfo;
        }
        public void GetReviewInfo(ReviewInfo _reviewInfo)
        {
            CheckRadio(_reviewInfo.PartySize);
            txtDisplayName.Text = _reviewInfo.Title;
            dropFood.Text = Convert.ToString(_reviewInfo.RateFood);
            dropService.Text = Convert.ToString(_reviewInfo.RateService);
            dropPrice.Text = Convert.ToString(_reviewInfo.RatePrice);
            #region Check Visit Again
            string checkVisit = _reviewInfo.VisitAgain.ToLower();
            if (checkVisit.Contains("yes"))
            {
                rdoVisitYes.Checked = true;
            }
            else
            {
                if (checkVisit.Contains("maybe"))
                {
                    rdoVisitMaybe.Checked = true;
                }
                else
                {
                    if (checkVisit.Contains("never"))
                    {
                        rdoVisitNever.Checked = true;
                    }
                }
            }
            #endregion
            dropDecor.Text = Convert.ToString(_reviewInfo.RateDecor);
            dropPriceRange.Text = _reviewInfo.PriceRange;
            txtYourOrder.Text = _reviewInfo.TableOrderService;
            txtYourReview.Text = _reviewInfo.Description;
        }
        public static string StripHtml(string html)
        {
            if (html == null || html == string.Empty)
                return string.Empty;
            return Regex.Replace(html, "<[0-9]>", string.Empty);
        }
        private void CheckRadio(string checkMeal)
        {
            rdoBreakFirst.Checked = false;
            rdoLunch.Checked = false;
            rdoDinner.Checked = false;
            rdoOther.Checked = false;
            rdoVisitMaybe.Checked = false;
            rdoVisitNever.Checked = false;
            rdoVisitYes.Checked = false;
            if (checkMeal.Contains(" BreakFast"))
            {
                rdoBreakFirst.Checked = true;
                dropPartySize.Text = checkMeal.Replace(" BreakFast", "").ToString();
            }
            else
            {
                if (checkMeal.Contains(" Lunch"))
                {
                    rdoLunch.Checked = true;
                    dropPartySize.Text = checkMeal.Replace(" Lunch", "").ToString();
                }
                else
                {
                    if (checkMeal.Contains(" Dinner"))
                    {
                        rdoDinner.Checked = true;
                        dropPartySize.Text = checkMeal.Replace(" Dinner", "").ToString();
                    }
                    else
                    {
                        if (checkMeal.Contains(" Other"))
                        {
                            rdoOther.Checked = true;
                            dropPartySize.Text = checkMeal.Replace(" Other", "").ToString();
                        }
                    }
                }
            }
        }
        #endregion

        #region Event
        protected void grvReviewAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            if (Panel1.Visible == true)
            {
                BindReviewDetail();
                checkDetail.Visible = true;
                checkDetail.Checked = false;
                txtYourReview.Height = 200;
                ReviewInfo reviewInfo = ReviewBLL.GetInfo(GetReviewID, GetRestaurantID, GetMemberID);
                GetReviewInfo(reviewInfo);
            }

        }
        protected void grvReviewAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            str = new string[3];
            str = e.CommandArgument.ToString().Split('&');
          
            if (e.CommandName.Equals("ApproveUpdate"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)(e.CommandSource)).NamingContainer);
                DropDownList dropStatus = (DropDownList)gvr.FindControl("dropStatus");

                ReviewInfo reviewInfo = ReviewBLL.GetInfo(GetReviewID, GetRestaurantID, GetMemberID);

                if (dropStatus.SelectedValue == "Approve")
                {
                    reviewInfo.IsActive = 1;
                }
                else
                {
                    if (dropStatus.SelectedValue == "Reject")
                    {
                        reviewInfo.IsActive = 0;
                    }
                    else
                    {
                        if (dropStatus.SelectedValue == "Pending")
                        {
                            reviewInfo.IsActive = 2;
                        }
                    }
                }
                if (ReviewBLL.Update(reviewInfo) == true)
                {
                    BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
                    Panel1.Visible = false;
                }
            }

            if (e.CommandName.Equals("DeleteUpdate"))
            {
                if (ReviewBLL.Delete(Convert.ToInt32(e.CommandArgument)) == true)
                {
                    BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
                    Panel1.Visible = false;
                }
            }
        }
        protected void checkDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDetail.Checked == true)
            {
                Panel1.Visible = false;
            }
        }
        protected void butAccept_Click(object sender, EventArgs e)
        {
            ReviewInfo reviewInfo = ReviewBLL.GetInfo(GetReviewID, GetRestaurantID, GetMemberID);
            reviewInfo.IsActive = 1;
            if (ReviewBLL.Update(reviewInfo) == true)
            {
                BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
                Panel1.Visible = false;
            }
        }
        protected void butReject_Click(object sender, EventArgs e)
        {
            ReviewInfo reviewInfo = ReviewBLL.GetInfo(GetReviewID, GetRestaurantID, GetMemberID);
            reviewInfo.IsActive = 0;
            if (ReviewBLL.Update(reviewInfo) == true)
            {
                BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
                Panel1.Visible = false;
            }
        }
        protected void butEdit_Click(object sender, EventArgs e)
        {
            if (t)
            {
                if (ReviewBLL.Update(SetReviewInfo(1)) == true)
                {
                    BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
                    Panel1.Visible = false;
                }
            }
        }
        protected void grvReviewAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvReviewAdmin.PageIndex = e.NewPageIndex;
            BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
        }
        protected void grvReviewAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dropStatus = (DropDownList)e.Row.FindControl("dropStatus");
                HiddenField hdfStatus = (HiddenField)e.Row.FindControl("hdfStatus");

                LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton linkApprove = (LinkButton)e.Row.FindControl("linkApprove");
                LinkButton linkDelete = (LinkButton)e.Row.FindControl("linkDelete");
                if ((hdfStatus != null) && (dropStatus != null))
                {
                    if ((hdfStatus.Value == "Approve") || (hdfStatus.Value == "Reject"))
                    {
                        if (hdfStatus.Value == "Approve")
                        {
                            dropStatus.SelectedValue = "1";
                        }
                        else
                        {
                            dropStatus.SelectedValue = "0";
                        }
                        LinkButton1.Enabled = false;
                        dropStatus.Enabled = false;
                        linkApprove.Enabled=false;
                        linkDelete.Enabled=false;
                    }
                    else
                    {
                        dropStatus.SelectedValue = hdfStatus.Value;
                        string[] drp ={ "Reject", "Approve", "Pending" };
                        dropStatus.DataSource = drp;
                        dropStatus.DataBind();
                    }
                }
            }
        }
        #endregion

        protected void dropFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(Convert.ToInt32(dropFilter.SelectedValue));
        }
    }
}