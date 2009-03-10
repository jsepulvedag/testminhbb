using System;

namespace Restaurant.Library.Entities
{
    public class MemberInfo
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

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _countryID;
        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }

        private int _stateID;
        public int StateID
        {
            get { return _stateID; }
            set { _stateID = value; }
        }

        private int _cityID;
        public int CityID
        {
            get { return _cityID; }
            set { _cityID = value; }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private DateTime _registerDate;
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }

        private bool _isWantReciveMail;
        public bool IsWantReciveMail
        {
            get { return _isWantReciveMail; }
            set { _isWantReciveMail = value; }
        }
        private int _lastRestaurantId;
        public int LastRestaurantId
        {
            get { return _lastRestaurantId; }
            set { _lastRestaurantId = value; }
        }
    }
}
