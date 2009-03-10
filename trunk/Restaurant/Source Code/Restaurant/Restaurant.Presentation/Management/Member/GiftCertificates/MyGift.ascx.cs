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

namespace Restaurant.Presentation.Management.Member.GiftCertificates
{
    public partial class MyGift : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyGift();
            }
        }
        private void BindMyGift()
        {
            gvMyGift.DataSource = GiftCertificatesBLL.GetAllByMemberID(Authentication.CurrentMemberInfo.ID);
            gvMyGift.DataBind();
        }

        protected void gvMyGift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMyGift.PageIndex = e.NewPageIndex;
            BindMyGift();
        }
        protected void gvMyGift_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgBtn = (ImageButton)e.Row.FindControl("imgBtnPrint");
                LinkButton lbtRestaurant=(LinkButton)e.Row.FindControl("lbtRestaurant");
                DataRowView drv = (DataRowView)e.Row.DataItem;

                if (imgBtn != null)
                {
                    if (drv["StatusCode"].ToString() == "2")
                        imgBtn.Attributes.Add("onclick", "popup('" + imgBtn.CommandArgument.ToString() + "')");
                    else
                        imgBtn.Visible = false;
                }
                if (lbtRestaurant != null)
                {
                    lbtRestaurant.Attributes.Add("onclick","onClick('"+"/Default.aspx?pid=ListReview"+ PageConstant.RESTAURANT_ID+drv["RestaurantID"].ToString()+"')");
                }
            }
        }
    }
}