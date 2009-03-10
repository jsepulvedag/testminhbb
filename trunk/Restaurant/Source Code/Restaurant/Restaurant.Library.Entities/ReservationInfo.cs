using System;

namespace Restaurant.Library.Entities
{
    public class ReservationInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _transactionID;
        public int TransactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }
        private string _customerFirstName;
        public string CustomerFirstName
        {
            get { return _customerFirstName; }
            set { _customerFirstName = value; }
        }
        private string _customerLastName;
        public string CustomerLastName
        {
            get { return _customerLastName; }
            set { _customerLastName = value; }
        }
        private string _customerGender;
        public string CustomerGender
        {
            get { return _customerGender; }
            set { _customerGender = value; }
        }
        private string _customerPhone;
        public string CustomerPhone
        {
            get { return _customerPhone; }
            set { _customerPhone = value; }
        }
        private string _customerFax;
        public string CustomerFax
        {
            get { return _customerFax; }
            set { _customerFax = value; }
        }
        private string _customerEmail;
        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { _customerEmail = value; }
        }
        private string _customerAddress;
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { _customerAddress = value; }
        }
        private int _customerCountryID;
        public int CustomerCountryID
        {
            get { return _customerCountryID; }
            set { _customerCountryID = value; }
        }
        private int _customerStateID;
        public int CustomerStateID
        {
            get { return _customerStateID; }
            set { _customerStateID = value; }
        }
        private int _customerCityID;
        public int CustomerCityID
        {
            get { return _customerCityID; }
            set { _customerCityID = value; }
        }
        private DateTime _reserDate;
        public DateTime ReserDate
        {
            get { return _reserDate; }
            set { _reserDate = value; }
        }
        private string _confirmationCode;
        public string ConfirmationCode
        {
            get { return _confirmationCode; }
            set { _confirmationCode = value; }
        }
        private string _reserDescription;
        public string ReserDescription
        {
            get { return _reserDescription; }
            set { _reserDescription = value; }
        }
        private Int16 _status;
        public Int16 Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
