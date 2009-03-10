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
using Restaurant.Presentation.Library;
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities.MailSMTP;
using System.Web.Mail;

namespace Restaurant.Presentation.Home.Restaurant.ContactRestaurant
{
    public partial class SendContact : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string RestaurantID
        {
            get { return Request.QueryString["RidUrl"]; }
        }
        protected override void  OnInit(EventArgs e)
        {
 	        base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_MEMBER_CONTACT_RESTAURANT + PageConstant.RESTAURANT_ID + RestaurantID));
            }
            else
            {
                txtEmail.Text = Authentication.CurrentMemberInfo.Email;
            }
        }
        string TrimStr()
        {
            string str=Request.Url.PathAndQuery;
            string s = Request.Url.AbsoluteUri.Replace(str,"");
            return s;
        }
        void SendMailToRestaurant()
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            RestaurantInfo resInfo = RestaurantBLL.GetInfo(Convert.ToInt32(RestaurantID));

            MailMessage mail = new MailMessage();
            mail.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            mail.To = resInfo.Email;
            mail.Subject = "Message From Member";
            mail.BodyFormat = MailFormat.Html;
            string mailBody = "Hi,<br> I am "+ Authentication.CurrentMemberInfo.FirstName + " " + Authentication.CurrentMemberInfo.LastName;
            mailBody += " <br>" + txtMessage.Text.Trim() ;
            mailBody +="<br><br>-------------------------------";
            mailBody +=" <br>Regards,<br>" ;
            mailBody += Authentication.CurrentMemberInfo.FirstName + " " + Authentication.CurrentMemberInfo.LastName +"<br>";
            mailBody += "Email: " + Authentication.CurrentMemberInfo.Email;
            mail.Body = mailBody;
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            
            try
            {
                SmtpMail.Send(mail);
                lblMess.Visible=true;
                lblMess.Text="Your email has been send";
            }
            catch (Exception ex) 
            {
                lblMess.Visible=true;
                lblMess.Text="Your email hasn't been send";
                //Response.Write(ex.ToString());
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            SendMailToRestaurant();
        }
    }
}