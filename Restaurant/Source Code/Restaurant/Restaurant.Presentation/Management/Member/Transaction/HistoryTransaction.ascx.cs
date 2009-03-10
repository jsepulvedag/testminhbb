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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Management.Member.Transaction
{
    public partial class HistoryTransaction : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                toDate.SelectedDate = DateTime.Now;
                BindTransaction();
            }
        }
        private void BindTransaction()
        {
            int memberID = Authentication.CurrentMemberInfo.ID;
            int type = Convert.ToInt32(drpType.SelectedValue.ToString());
            int status = Convert.ToInt32(drpStatus.SelectedValue.ToString());
            DateTime from = fromDate.SelectedDate;
            DateTime to = toDate.SelectedDate;
            gvTransaction.DataSource = TransactionBLL.SearchByMemberID(memberID, type, status, from, to);
            gvTransaction.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindTransaction();
        }

        protected void gvTransaction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTransaction.PageIndex = e.NewPageIndex;
            BindTransaction();
        }
    }
}