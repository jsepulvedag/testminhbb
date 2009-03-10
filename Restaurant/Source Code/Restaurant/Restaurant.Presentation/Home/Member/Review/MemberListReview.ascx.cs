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
using Restaurant.Library.Utilities.DataBinder;

namespace Restaurant.Presentation.Home.Member.Review
{
    public partial class MemberListReview : System.Web.UI.UserControl
    {
        int pageCount;
        public int GetMemberID
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["MemberID"]);
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
            Utility.BindingPageSizeDataList(_objPsrc, ReviewBLL.MemberListReview(GetMemberID), 5, _pageCurrent);
            pageCount = _objPsrc.PageCount;
            BindDropPage(pageCount);
            dtlMemberListReview.DataSource = _objPsrc;
            dtlMemberListReview.DataBind();
            dropPage.Text = Convert.ToString(_pageCurrent);
        }
        #endregion
    }
}