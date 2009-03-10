using System;

namespace Restaurant.Library.Entities
{
    public class AccountLoginInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

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

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
