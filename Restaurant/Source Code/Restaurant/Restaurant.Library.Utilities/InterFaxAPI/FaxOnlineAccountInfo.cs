using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Utilities.InterFaxAPI
{
    public class FaxOnlineAccountInfo
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
