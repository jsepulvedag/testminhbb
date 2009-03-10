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

namespace Restaurant.Presentation.Management.Member.Reservation
{
    public partial class MyReservation : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMyReservation();
            }
        }
        private void BindMyReservation()
        {
            gvMyReservation.DataSource = ReservationBLL.GetAll_ByMemberID(Authentication.CurrentMemberInfo.ID);
            gvMyReservation.DataBind();
        }

        protected void gvMyReservation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMyReservation.PageIndex= e.NewPageIndex;
            BindMyReservation();
        }

        
    }
}