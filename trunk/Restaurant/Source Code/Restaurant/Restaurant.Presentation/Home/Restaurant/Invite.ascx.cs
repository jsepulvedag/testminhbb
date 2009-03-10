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
using System.Net.Mail;
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Home.Member
{
    public partial class Invite : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            MailMessage mail = new MailMessage();
            mail.To.Add( new MailAddress(txtAddress2.Text.Trim()));
            mail.From =new MailAddress(param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString());
            mail.Body = txtMessage.Text.Trim();
            mail.Subject = txtSubject.Text.Trim();
            mail.ReplyTo= new MailAddress(txtAddress.Text.Trim());
            SmtpClient smtp = new SmtpClient();
            smtp.Host = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            try
            {
                smtp.Send(mail);
                lbError.Visible = true;
            }
            catch { }
        }
    }
}