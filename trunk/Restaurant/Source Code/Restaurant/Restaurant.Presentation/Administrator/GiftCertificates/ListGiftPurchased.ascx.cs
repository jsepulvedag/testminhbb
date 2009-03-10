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

namespace Restaurant.Presentation.Administrator.GiftCertificates
{
    public partial class ListGiftPurchased : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindListGift();
        }

        public void BindListGift()
        {
            DataTable tbl = GiftCertificatesBLL.GetAll();
            dgrListGift.DataSource = tbl;
            dgrListGift.DataBind();
        }

        protected void dgrListGift_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgrListGift.CurrentPageIndex=e.NewPageIndex;
            BindListGift();
        }
    }
}