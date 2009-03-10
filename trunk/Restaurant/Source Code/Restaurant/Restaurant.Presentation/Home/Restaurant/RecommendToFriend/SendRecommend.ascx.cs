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

namespace Restaurant.Presentation.Home.Restaurant.RecommendToFriend
{
    public partial class SendRecommend : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string RestaurantID
        {
            get { return Request.QueryString["RidUrl"]; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                Response.Redirect(PageConstant.HOME_LOGIN_URL + PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_MEMBER_RECOMMEND_FRIEND + PageConstant.RESTAURANT_ID + RestaurantID));
            }
            else
            {
                txtYourMail.Text = Authentication.CurrentMemberInfo.Email;
            }
        }
        string TrimStr()
        {
            string str=Request.Url.PathAndQuery;
            string s = Request.Url.AbsoluteUri.Replace(str,"");
            return s;
        }
        void SendMailToFriend()
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            RestaurantInfo resInfo = RestaurantBLL.GetInfo(Convert.ToInt32(RestaurantID));

            MailMessage mail = new MailMessage();
            mail.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            mail.To=txtFriendMail.Text.Trim();
            mail.BodyFormat = MailFormat.Html;
            mail.Subject = "Message for you from a member of 212cuisine";
            string mailBody = "Hi,<br> I would like you to check out this restaurant profile on <br>";
            mailBody += TrimStr() + " <br><br>";
            mailBody += txtMessage.Text.Trim()+ "<br>Link Restaurant: "+ TrimStr() + "/Default.aspx?pid=ListReview&RidUrl="+ RestaurantID ;
            mailBody +="<br><br>-------------------------------";
            mailBody +=" <br>Regards,<br>" + Authentication.CurrentMemberInfo.FirstName + " " + Authentication.CurrentMemberInfo.LastName;
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
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            SendMailToFriend();
        }
    }
}