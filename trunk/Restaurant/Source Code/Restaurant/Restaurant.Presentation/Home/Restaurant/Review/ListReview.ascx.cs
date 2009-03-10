using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Utilities.Encrypt;


namespace Restaurant.Presentation.Home.Restaurant.Review
{
    public partial class ListReview : AuthenticateControl //System.Web.UI.UserControl
    {
        #region Properties
        public int GetRestaurantID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["RidUrl"].ToString());
            }
        }
        int pageCount;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dropPage.AutoPostBack = true;
                PagedDataSource objPsrc = new PagedDataSource();
                BindPage(objPsrc, 1);
            }
        }
        #region Method
        private void BindDropPage(int _pageCount)
        {
            string [] str= new string[_pageCount];
            for (int i = 0; i < _pageCount; i++)
            {
                str[i] = Convert.ToString(i+1);
            }
            Utility.BindingDropDowList(dropPage, Utility.CreateTable(str,str));
        }
        private void BindPage(PagedDataSource _objPsrc,int _pageCurrent)
        {
            if (ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows.Count > 0)
            {
                lblPage.Visible = true;
                dropPage.Visible = true;
                Utility.BindingPageSizeDataList(_objPsrc, ReviewBLL.GetByRestaurant(GetRestaurantID, 0), 5, _pageCurrent);
                pageCount = _objPsrc.PageCount;
                BindDropPage(pageCount);
                dtlListReview.DataSource = _objPsrc;
                dtlListReview.DataBind();
                lblRestaurantName.Text = ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows[0]["RestaurantName"].ToString() + " Restaurant";
                lblReviewCount.Text = "   " + ReviewBLL.GetByRestaurant(GetRestaurantID, 0).Rows[0]["CountReview"].ToString() + " Review For:";
                dropPage.Text = Convert.ToString(_pageCurrent);
            }
            else
            {
                lblMess.Visible = true;
                lblMess.Text = "No Review for Restaurant";
                lblPage.Visible = false ;
                dropPage.Visible = false;
                hplCreateReview.Visible = true;
                hplCreateReview.NavigateUrl = PageConstant.HOME_MEMBER_CREATE_REVIEW_URL + PageConstant.RESTAURANT_ID + GetRestaurantID.ToString();
            }
        }
        #endregion

        #region Event
        protected void dtlListReview_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("Title"))
            {
                string reviewID = e.CommandArgument.ToString();
                Response.Redirect(PageConstant.HOME_PUBLIC_REVIEW_DETAIL_URL + PageConstant.RESTAURANT_ID + Convert.ToString(GetRestaurantID) + "&ReviewID=" + reviewID.ToString());
            }
            if (e.CommandName.Equals("AddReview"))
            {
                Response.Redirect(PageConstant.HOME_MEMBER_CREATE_REVIEW_URL + PageConstant.RESTAURANT_ID + GetRestaurantID.ToString());

            }
        }
        protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
        {            
            PagedDataSource objPsrc = new PagedDataSource();
            BindPage(objPsrc, Convert.ToInt32(dropPage.SelectedValue));
            dropPage.Text = dropPage.SelectedValue;
        }
        #endregion
    }
}