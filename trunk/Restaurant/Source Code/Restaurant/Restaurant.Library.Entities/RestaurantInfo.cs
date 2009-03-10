using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _memberID;
        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private DateTime _dateOpened;
        public DateTime DateOpened
        {
            get { return _dateOpened; }
            set { _dateOpened = value; }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
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
        private string _phone1;
        public string Phone1
        {
            get { return _phone1; }
            set { _phone1 = value; }
        }
        private string _phone2;
        public string Phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }
        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _website;
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        private bool _acceptCreditCard;
        public bool AcceptCreditCard
        {
            get { return _acceptCreditCard; }
            set { _acceptCreditCard = value; }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private DateTime _expiryDate;
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }
        private string _luckyNo;
        public string LuckyNo
        {
            get { return _luckyNo; }
            set { _luckyNo = value; }
        }
        private string _firstNameContact;
        public string FirstNameContact
        {
            get { return _firstNameContact; }
            set { _firstNameContact = value; }
        }
        private string _lastNameContact;
        public string LastNameContact
        {
            get { return _lastNameContact; }
            set { _lastNameContact = value; }
        }
        private string _genderContact;
        public string GenderContact
        {
            get { return _genderContact; }
            set { _genderContact = value; }
        }
        private DateTime _birthdayContact;
        public DateTime BirthdayContact
        {
            get { return _birthdayContact; }
            set { _birthdayContact = value; }
        }
        private string _addressContact;
        public string AddressContact
        {
            get { return _addressContact; }
            set { _addressContact = value; }
        }
        private int _countryIDContact;
        public int CountryIDContact
        {
            get { return _countryIDContact; }
            set { _countryIDContact = value; }
        }
        private int _stateIDContact;
        public int StateIDContact
        {
            get { return _stateIDContact; }
            set { _stateIDContact = value; }
        }
        private int _cityIDContact;
        public int CityIDContact
        {
            get { return _cityIDContact; }
            set { _cityIDContact = value; }
        }
        private string _zipcodeContact;
        public string ZipcodeContact
        {
            get { return _zipcodeContact; }
            set { _zipcodeContact = value; }
        }
        private string _phoneContact;
        public string PhoneContact
        {
            get { return _phoneContact; }
            set { _phoneContact = value; }
        }
        private string _faxContact;
        public string FaxContact
        {
            get { return _faxContact; }
            set { _faxContact = value; }
        }
        private string _emailContact;
        public string EmailContact
        {
            get { return _emailContact; }
            set { _emailContact = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private bool _createdByAdmin;
        public bool CreatedByAdmin
        {
            get { return _createdByAdmin; }
            set { _createdByAdmin = value; }
        }
        private int _packageDetailID;
        public int PackageDetailID
        {
            get { return _packageDetailID; }
            set { _packageDetailID = value; }
        }
    }
}
