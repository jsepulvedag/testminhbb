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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;
using System.IO;

using System.Web.Mail;
using Restaurant.Library.Utilities.MailSMTP;

namespace Restaurant.Presentation.Home.Restaurant.OnlineReservation
{
    public partial class ProcessReservation : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Authentication.IsLogined)
            {
                string nextUrl = PageConstant.NEXT_URL + Server.UrlEncode(PageConstant.HOME_MEMBER_PROCESS_RESERVATION);
                Response.Redirect(PageConstant.HOME_MEMBER_LOGIN_FOR_PURCHASE_URL + nextUrl);
            }
            TransactionInfo transaction = (TransactionInfo)Session[PageConstant.SESSION_TRANSACTION];
            ReservationInfo reservation = (ReservationInfo)Session[PageConstant.SESSION_RESERVATION];
            transaction.MemberID = Authentication.CurrentMemberInfo.ID;
            try
            {
                transaction.ID = TransactionBLL.Insert(transaction);
                reservation.TransactionID = transaction.ID;
                ReservationBLL.Insert(reservation);
                RestaurantInfo restaurant = RestaurantBLL.GetInfo(transaction.RestaurantID);
                SendMailToMember(reservation, transaction,restaurant);
                SendMailToRestaurant(restaurant.Email,reservation);
                Response.Redirect(PageConstant.HOME_MEMBER_THANKS_FOR_RESERVATION + PageConstant.RESTAURANT_ID + transaction.RestaurantID.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        string TrimStr()
        {
            string str=Request.Url.PathAndQuery;
            string s = Request.Url.AbsoluteUri.Replace(str,"");
            return s;
        }
        void SendMailToRestaurant(string mailRestaurant, ReservationInfo reservation)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();
            MailMessage mail = new MailMessage();

            mail.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            mail.To = mailRestaurant;
            mail.BodyFormat = MailFormat.Html;

            //mail.Subject = Authentication.CurrentMemberInfo.FirstName + " " + Authentication.CurrentMemberInfo.LastName + " reservation on your restaurant";
            mail.Subject = "Customer has placed a reservation on your restaurant";
            mail.Body = GetMailBodyForRestaurant(reservation);
            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            try
            {
                SmtpMail.Send(mail);
            }
            catch { }
        }
        string GetMailBodyForRestaurant(ReservationInfo reservation)
        {
            string retVal = "Custommer has placed a reservation in your restaurant";
            string str = Server.MapPath("~/Media/Template/");
            DirectoryInfo direct = new DirectoryInfo(str);
            FileInfo[] files = direct.GetFiles();
            foreach (FileInfo info in files)
            {
                if (info.Name == "YourGotReservation.htm")
                {
                    StreamReader sr = File.OpenText(str+"YourGotReservation.htm");
                    retVal = sr.ReadToEnd();
                    sr.Close();
                    break;
                }
            }         
            retVal = retVal.Replace("##CustomerName##", reservation.CustomerFirstName + " " + reservation.CustomerLastName);
            retVal = retVal.Replace("##CustomerAddress##", reservation.CustomerAddress);
            retVal = retVal.Replace("##CustomerPhone##", reservation.CustomerPhone);
            retVal = retVal.Replace("##CustomerEmail##", reservation.CustomerEmail);
            retVal = retVal.Replace("##ReservationHour##", reservation.ReserDate.Hour + ":" + reservation.ReserDate.Minute);
            retVal = retVal.Replace("##ReservationDay##", reservation.ReserDate.ToShortDateString());
            retVal = retVal.Replace("##ReservationLink##",TrimStr() +"/Management/Default.aspx?mid=ReservationManagement");

            return retVal;
        }
        void SendMailToMember(ReservationInfo reservation, TransactionInfo trans, RestaurantInfo resInfo)
        {
            Parameters param = ParameterBLL.GetHashtableByGroupName(PageConstant.GROUP_EMAIL_SERVER_PARAMETER);
            param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            MailMessage mail = new MailMessage();
            mail.From = param[PageConstant.PARAMETER_MAIL_SERVER_USERNAME].ToString();
            mail.To = reservation.CustomerEmail;
            mail.BodyFormat = MailFormat.Html;

            mail.Subject = "You have placed a reservation at 212cuisine.com";
            mail.Body = GetMailBody(reservation, trans,resInfo);

            SmtpMail.SmtpServer = param[PageConstant.PARAMETER_MAIL_SERVER_HOST].ToString();

            try
            {
                SmtpMail.Send(mail);
            }
            catch (Exception ex) {
            throw ex;
            }
        }
        string GetMailBody(ReservationInfo reservation, TransactionInfo trans, RestaurantInfo resInfo)
        {
            string retVal = "Thank you for place a reservation at 212cuisine.com";
            string str = Server.MapPath("~/Media/Template/");
            DirectoryInfo direct = new DirectoryInfo(str);
            FileInfo[] files = direct.GetFiles();
            foreach (FileInfo info in files)
            {
                if (info.Name == "YouHavePlaceReservation.htm")
                {
                    StreamReader sr = File.OpenText(str+"YouHavePlaceReservation.htm");
                    retVal = sr.ReadToEnd();
                    sr.Close();
                    break;
                }
            }                
            retVal = retVal.Replace("##RestaurantName##",resInfo.Name );
            retVal = retVal.Replace("##RestaurantAddress##", resInfo.Address);
            retVal = retVal.Replace("##ReservationHour##", reservation.ReserDate.Hour.ToString() + ":" + reservation.ReserDate.Minute.ToString());
            retVal = retVal.Replace("##ReservationDay##", reservation.ReserDate.ToShortDateString());
            retVal = retVal.Replace("##MyReservationLink##", TrimStr()+"/Management/Default.aspx?mid=MyReservation");
            retVal = retVal.Replace("##RestaurantLink##", TrimStr()+"/Default.aspx?pid=ListReview&RidUrl=" + trans.RestaurantID.ToString());

            return retVal;
        }
    }
}