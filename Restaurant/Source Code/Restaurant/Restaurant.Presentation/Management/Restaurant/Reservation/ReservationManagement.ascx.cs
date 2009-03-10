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
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities.Validator;
using Restaurant.Library.Utilities.PayPalAPI;
using Restaurant.Library.Entities;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Restaurant.Presentation.Management.Restaurant.Reservation
{
    public partial class ReservationManagement : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                toDate.SelectedDate = DateTime.Now.AddDays(7);
                BindReservation();
            }
        }
        private void BindReservation()
        {
            int restaurantID = Authentication.CurrentRestaurantInfo.ID;
            DateTime from = fromDate.SelectedDate;
            DateTime to = toDate.SelectedDate;
            int status = Convert.ToInt32(drpStatusSearch.SelectedValue.ToString());
            gvReservation.DataSource = ReservationBLL.GetAll_ByRestaurantID(restaurantID, from, to, status);
            gvReservation.DataBind();
        }

        protected void gvReservation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReservation.PageIndex = e.NewPageIndex;
            BindReservation();
        }
        protected void gvReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvReservation.SelectedRow;
            HiddenField hd = (HiddenField)row.Cells[0].FindControl("hdTransactionID");
            DropDownList drp = (DropDownList)row.Cells[5].FindControl("drpStatus");
            if (hd != null && drp != null)
            {
                int transactionId = Convert.ToInt32(hd.Value.ToString());
                Int16 status = Convert.ToInt16(drp.SelectedValue.ToString());
                TransactionBLL.Update_Status(transactionId, status);
                ReservationInfo reservation = ReservationBLL.GetByTransactionID(Convert.ToInt32(hd.Value.ToString()));
                try
                {
                    sendMailToMember(reservation, status);
                }
                catch
                {
                }
                BindReservation();

            }
        }

        private void sendMailToMember(ReservationInfo reservation, Int16 status)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString());
            mail.To.Add(new MailAddress(reservation.CustomerEmail));
            mail.IsBodyHtml = true;

            if (status == 2)
                mail.Subject = Authentication.CurrentRestaurantInfo.Name + " has confirmed your Reservation";
            if (status == 3)
                mail.Subject = Authentication.CurrentRestaurantInfo.Name + " has rejected your Reservation";
            mail.Body = GetMailBody(reservation.ReserDate, status);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                smtp.Send(mail);
            }
            catch
            {
            }
        }
        private string GetMailBody(DateTime reservationDate, Int16 status)
        {
            string retVal = "";

            if (status == 2)
            {
                retVal = "Your reservation at " + Authentication.CurrentRestaurantInfo.Name + " has been confirmed.";
                string str = Server.MapPath("~/Media/Template/");
                DirectoryInfo direct = new DirectoryInfo(str);
                FileInfo[] files = direct.GetFiles();
                foreach (FileInfo info in files)
                {
                    if (info.Name == "ConfirmReservation.htm")
                    {
                        StreamReader sr = File.OpenText(str + "ConfirmReservation.htm");
                        retVal = sr.ReadToEnd();
                        sr.Close();
                        break;
                    }
                }
            }
            if (status == 3)
            {
                retVal = "Your reservation at " + Authentication.CurrentRestaurantInfo.Name + " has been rejected.";
                string str = Server.MapPath("~/Media/Template/");
                DirectoryInfo direct = new DirectoryInfo(str);
                FileInfo[] files = direct.GetFiles();
                foreach (FileInfo info in files)
                {
                    if (info.Name == "RejectReservation.htm")
                    {
                        StreamReader sr = File.OpenText(str + "RejectReservation.htm");
                        retVal = sr.ReadToEnd();
                        sr.Close();
                        break;
                    }
                }
            }

            retVal = retVal.Replace("##RestaurantName##", Authentication.CurrentRestaurantInfo.Name);
            retVal = retVal.Replace("##RestaurantAddress##", Authentication.CurrentRestaurantInfo.Address);
            retVal = retVal.Replace("##ReservationHour##", reservationDate.Hour.ToString());
            retVal = retVal.Replace("##ReservationDay##", reservationDate.ToShortDateString());
            retVal = retVal.Replace("##RestaurantLink##", Request.Url.Host + "/Default.aspx?pid=ListReview&RidUrl=" + Authentication.CurrentRestaurantInfo.ID.ToString());
            return retVal;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindReservation();
        }
        protected void gvReservation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hd = (HiddenField)e.Row.FindControl("hdStatus");
                if (hd != null)
                {
                    if (!hd.Value.ToLower().Trim().Equals("pending"))
                    {
                        Label lbl = (Label)e.Row.FindControl("lblStatus");
                        DropDownList drp = (DropDownList)e.Row.FindControl("drpStatus");
                        if (drp != null && lbl != null)
                        {
                            drp.Visible = false;
                            lbl.Visible = true;
                        }
                        e.Row.Cells[6].Controls[0].Visible = false;
                    }
                }
            }
        }
    }
}