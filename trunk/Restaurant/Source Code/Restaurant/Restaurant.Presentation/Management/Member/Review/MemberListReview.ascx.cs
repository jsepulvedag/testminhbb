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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Management.Member.Review
{
    public partial class MemberListReview : AuthenticateControl
    {
        int pageCount;
        public int GetMemberID
        {
            get
            {
                return Authentication.CurrentMemberInfo.ID;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropPage.AutoPostBack = true;
                PagedDataSource objPsrc = new PagedDataSource();
                BindPage(objPsrc, 1);
            }
        }

        protected void dropPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            PagedDataSource objPsrc = new PagedDataSource();
            BindPage(objPsrc, Convert.ToInt32(dropPage.SelectedValue));
            dropPage.Text = dropPage.SelectedValue;
        }

        #region Method        
        private void BindDropPage(int _pageCount)
        {
            string[] str = new string[_pageCount];
            for (int i = 0; i < _pageCount; i++)
            {
                str[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(dropPage, Utility.CreateTable(str, str));
        }
        private void BindPage(PagedDataSource _objPsrc, int _pageCurrent)
        {
            if (ReviewBLL.MemberListReview(GetMemberID).Rows.Count > 0)
            {
                dropPage.Visible = true;
                lblPage.Visible = true;
                lblReview.Text = "List Review";
                Utility.BindingPageSizeDataList(_objPsrc, ReviewBLL.MemberListReview(GetMemberID), 3, _pageCurrent);
                pageCount = _objPsrc.PageCount;
                BindDropPage(pageCount);
                dtlMemberListReview.DataSource = _objPsrc;
                dtlMemberListReview.DataBind();
                dropPage.Text = Convert.ToString(_pageCurrent);
            }
            else
            {
                lblReview.Text = "No Review";
            }
        }
        #endregion

        protected void dtlMemberListReview_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            HyperLink hplRestaurantName = (HyperLink)e.Item.FindControl("hplRestaurantName");
            DataRowView drv = (DataRowView)e.Item.DataItem;
            hplRestaurantName.NavigateUrl = PageConstant.HOME_PUBLIC_LIST_REVIEW_URL + PageConstant.RESTAURANT_ID+ drv["RestaurantID"].ToString();
        }
    }
}