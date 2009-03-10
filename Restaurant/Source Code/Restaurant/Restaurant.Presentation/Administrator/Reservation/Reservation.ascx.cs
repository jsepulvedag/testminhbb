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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;
using Restaurant.Library.Utilities.Validator;

namespace Restaurant.Presentation.Administrator.Reservation
{
    public partial class Reservation : AuthenticateControl
    {
        void BuildSearchControls()
        {
            if ((Request.QueryString["form"] != null) ||(Request.QueryString["to"] != null) ||(Request.QueryString["status"] != null))
            {
                fromDate.SelectedDate = Convert.ToDateTime(Request.QueryString["from"]);
                toDate.SelectedDate = Convert.ToDateTime(Request.QueryString["to"]);
                drpStatusSearch.SelectedValue = Request.QueryString["status"].ToString();
            }
            BindRestaurant();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fromDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                toDate.SelectedDate = DateTime.Now;
                BuildSearchControls();
                BindReservation();
            }
        }
        void BindRestaurant()
        {
            Utility.BindingDropDowList(RestaurantBLL.GetName(), drpRestaurant);
            
            ListItem li = new ListItem("--All Restaurant--", "0");
            drpRestaurant.Items.Insert(0, li);
            drpRestaurant.SelectedIndex = 0;
            if (Request.QueryString["RidUrl"] != null)
            {
                drpRestaurant.SelectedValue = Request.QueryString["RidUrl"].ToString();
            }
        }
        private void BindReservation()
        {

            int restaurantId = Request.QueryString["RidUrl"] != null ? Convert.ToInt32(Request.QueryString["RidUrl"]) : 0;
            
            gvReservation.DataSource = ReservationBLL.GetAll_ByAdmin(restaurantId, fromDate.SelectedDate, toDate.SelectedDate, Convert.ToInt32(drpStatusSearch.SelectedValue.ToString()));
            gvReservation.DataBind();
            if (gvReservation.Rows.Count > 0)
            {
                gvReservation.SelectedIndex = 0;
                GridViewRow gvRow = gvReservation.SelectedRow;
            }
        }
        protected void gvReservation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservation.PageIndex = e.NewPageIndex;
            BindReservation();
        }
        protected void gvReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = gvReservation.SelectedRow;
            HiddenField hdID = (HiddenField)gvRow.Cells[0].FindControl("hdID");
            if (hdID != null)
            {
                hdID.Value = hdID.Value.ToString().Trim();
            }
            string status = gvRow.Cells[4].Text.Trim();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.ADMIN_RESERVETION_GIFT
                + "&from=" + Convert.ToString(fromDate.SelectedDate)
                + "&to=" + Convert.ToString(toDate.SelectedDate)
                + "&status=" + drpStatusSearch.SelectedValue
                + "&RidUrl=" + drpRestaurant.SelectedValue);
        }

        protected void gvReservation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList drpRealized = (DropDownList)e.Row.FindControl("drpRealized");
                HiddenField idReservation = (HiddenField)e.Row.FindControl("idReservation");

                if (!e.Row.Cells[6].Text.Trim().ToLower().Equals("pending"))
                {
                    e.Row.Cells[7].Controls[0].Visible = false;
                }
                if ((idReservation != null) && (drpRealized != null))
                {
                    if (idReservation.Value.ToLower() == "true")
                    {
                        drpRealized.SelectedValue = "1";
                    }
                    else
                    {
                        drpRealized.SelectedValue = "0";
                    }
                }
            }
        }

    
        protected void gvReservation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateReservation")
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)(e.CommandSource)).NamingContainer);
                DropDownList drpRealized = (DropDownList)gvr.FindControl("drpRealized");
                HiddenField idReservation = (HiddenField)gvr.FindControl("idReservation");

                if (Convert.ToInt32(drpRealized.SelectedValue) == 1)
                {
                    ReservationBLL.UpdateRealized(Convert.ToInt32(e.CommandArgument), true);
                }
                else
                {
                    ReservationBLL.UpdateRealized(Convert.ToInt32(e.CommandArgument), false);
                }
                BindReservation();
            }
        }
    }
}