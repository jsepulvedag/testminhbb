using System;

namespace Restaurant.Library.Utilities.MailSMTP
{
    public class Mail
    {
        private string _to;
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        private string _from;
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _attachment;
        public string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }

        public Mail() { }
        public Mail(string to,string from,string subject,string body)
        {
            _to = to;
            _from = from;
            _subject = subject;
            _body = body;
        }
        public Mail(string to, string from, string subject, string body, string attachment)
        {
            _to = to;
            _from = from;
            _subject = subject;
            _body = body;
            _attachment = attachment;
        }
    }
}
