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
using Restaurant.Presentation.Management.Restaurant.UserControls;
using Restaurant.Presentation.Library;
using System.Web.Mail;
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Management.Restaurant.GiftCertificates
{
    public partial class GiftPurchaseManagement : CheckRestaurant
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fromDate.SelectedDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
                toDate.SelectedDate = DateTime.Now;
                BindGiftPurchase();
            }
        }
        private void BindGiftPurchase()
        {
            int status = Convert.ToInt32(drpStatusFilter.SelectedValue.ToString());
            int restaurantID = Authentication.CurrentRestaurantInfo.ID;
            DateTime from = fromDate.SelectedDate;
            DateTime to = toDate.SelectedDate;
            gvGiftCertificate.DataSource = GiftCertificatesBLL.GetAllByRestaurantID(restaurantID,status,from,to);
            gvGiftCertificate.DataBind();
        }
        protected void gvGiftCertificate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiftCertificate.PageIndex = e.NewPageIndex;
            BindGiftPurchase();
        }
        void SendMailMember( string status)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            MailMessage member = new MailMessage();
            member.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            member.To = Authentication.CurrentMemberInfo.Email;
            if (status == "2")
            {
                member.Body = "Thank you for reserving gift certificate at 212cuisine.com. We will contact you soon. If you don't hear from us, please contact us at 212cuisine.com";
            }
            else
            {
                if (status == "3")
                {
                    member.Body = "The info you provided us is not clear and understandable. Can you confirm the info with us ? Thank you!";
                }
            }
            member.Subject = "Message from 212cuisine";
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                SmtpMail.Send(member);
            }
            catch
            {
            }
        }
        protected void gvGiftCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvGiftCertificate.SelectedRow;
            DropDownList drp = (DropDownList)row.Cells[7].FindControl("drpStatus");
            HiddenField hdID = (HiddenField)row.Cells[7].FindControl("hdID");
            if (drp != null && drp.Enabled != false)
            {
                TransactionBLL.Update_Status(Convert.ToInt32(hdID.Value.ToString()), Convert.ToInt16(drp.SelectedValue.ToString()));
                SendMailMember(drp.SelectedValue.ToString());
                BindGiftPurchase();
            }            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGiftPurchase();
        }
        protected void gvGiftCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList drp = (DropDownList)e.Row.FindControl("drpStatus");
            HiddenField lbl = (HiddenField)e.Row.FindControl("lblStatus");
            Label lblStatusGift=(Label) e.Row.FindControl("lblStatusGift");
            if (drp != null)
            {
                drp.SelectedValue = lbl.Value.ToString().Trim();
                if (lbl.Value.ToString().Equals(PageConstant.STATUS_TRANSACTION_CONFIRMED.ToString()) || lbl.Value.ToString().Equals(PageConstant.STATUS_TRANSACTION_REJECTED.ToString()))
                {
                    //drp.Enabled = false;
                    drp.Visible = false;
                    lblStatusGift.Visible=true;
                    if (lblStatusGift.Text == "2")
                    {
                        lblStatusGift.Text = " Confirmed";
                    }
                    else
                    {
                        if (lblStatusGift.Text == "3")
                        {
                            lblStatusGift.Text = " Rejected";
                        }
                    }
                }
            }
        }      
    }
}