using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Threading;

namespace Restaurant.Library.Utilities.MailSMTP
{
    public class SMTP
    {
        private SmtpClient smtp;
        private List<MailMessage> listMail;

        private void CreateMessage(Mail mail)
        {
            listMail = new List<MailMessage>();
            MailMessage msg = new MailMessage();
            msg.Body = mail.Body;
            msg.From = new MailAddress(mail.From);
            msg.To.Add(new MailAddress(mail.To));
            msg.Subject = mail.Subject;
            msg.IsBodyHtml = true;
            listMail.Add(msg);
        }
        private void CreateMessage(List<Mail> list_mail)
        {
            listMail = new List<MailMessage>();
            foreach (Mail mail in list_mail)
            {
                MailMessage msg = new MailMessage();
                msg.Body = mail.Body;
                msg.From = new MailAddress(mail.From);
                msg.To.Add(new MailAddress(mail.To));
                msg.Subject = mail.Subject;
                msg.IsBodyHtml = true;
                listMail.Add(msg);
            }
        }
        public SMTP()
        {
            listMail = new List<MailMessage>();
            smtp = new SmtpClient();
        }
        public SMTP(string host,Mail Mail)
        {
            smtp = new SmtpClient(host);
            CreateMessage(Mail);
        }
        public SMTP(string host, List<Mail> listMail)
        {
            smtp = new SmtpClient(host);
            CreateMessage(listMail);
        }
        public SMTP(string host, int port, Mail Mail)
        {
            smtp = new SmtpClient(host, port);
            CreateMessage(Mail);
        }
        public SMTP(string host, int port, List<Mail> listMail)
        {
            smtp = new SmtpClient(host, port);
            CreateMessage(listMail);
        }
        public SMTP(string host, int port, string username, string password,Mail Mail)
        {
            smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(username, password);
            CreateMessage(Mail);
        }
        public SMTP(string host, int port, string username, string password, List<Mail> listMail)
        {
            smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(username, password);
            CreateMessage(listMail);
        }
        public void SendOneMail()
        {
            try
            {
                smtp.Send(listMail[0]);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SendOneMail(MailAddressCollection cc)
        {
            foreach (MailAddress Mail in cc)
            {
                listMail[0].CC.Add(Mail);
            }
            try
            {
                smtp.Send(listMail[0]);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void SendMultiMail()
        {
            Thread t = new Thread(new ThreadStart(sendMulti));
            t.Start();
            Thread.Sleep(30000);
        }
        private void sendMulti()
        {
            foreach (MailMessage msg in listMail)
            {
                try
                {
                    smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
