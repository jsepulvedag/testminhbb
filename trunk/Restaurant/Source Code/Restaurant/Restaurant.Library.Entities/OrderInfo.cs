using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
   public class OrderInfo
    {
        private int _iD;
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        }
        private int _transactionID;
        public int TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
            }
        }
        private string _orderName;
        public string OrderName
        {
            get
            {
                return _orderName;
            }
            set
            {
                _orderName = value;
            }
        }
        private string _orderDescription;
        public string OrderDescription
        {
            get
            {
                return _orderDescription;
            }
            set
            {
                _orderDescription = value;
            }
        }
        private string _customerFirstName;
        public string CustomerFirstName
        {
            get
            {
                return _customerFirstName;
            }
            set
            {
                _customerFirstName = value;
            }
        }
        private string _customerLastName;
        public string CustomerLastName
        {
            get
            {
                return _customerLastName;
            }
            set
            {
                _customerLastName = value;
            }
        }
        private string _customerGender;
        public string CustomerGender
        {
            get
            {
                return _customerGender;
            }
            set
            {
                _customerGender = value;
            }
        }
        private string _customerPhone;
        public string CustomerPhone
        {
            get
            {
                return _customerPhone;
            }
            set
            {
                _customerPhone = value;
            }
        }
        private string _customerFax;
        public string CustomerFax
        {
            get
            {
                return _customerFax;
            }
            set
            {
                _customerFax = value;
            }
        }
        private string _customerEmail;
        public string CustomerEmail
        {
            get
            {
                return _customerEmail;
            }
            set
            {
                _customerEmail = value;
            }
        }
        private string _customerAddress;
        public string CustomerAddress
        {
            get
            {
                return _customerAddress;
            }
            set
            {
                _customerAddress = value;
            }
        }
        private int _customerCountryID;
        public int CustomerCountryID
        {
            get
            {
                return _customerCountryID;
            }
            set
            {
                _customerCountryID = value;
            }
        }
        private int _customerStateID;
        public int CustomerStateID
        {
            get
            {
                return _customerStateID;
            }
            set
            {
                _customerStateID = value;
            }
        }
        private int _customerCityID;
        public int CustomerCityID
        {
            get
            {
                return _customerCityID;
            }
            set
            {
                _customerCityID = value;
            }
        }
        private string _customerZipCode;
        public string CustomerZipCode
        {
            get
            {
                return _customerZipCode;
            }
            set
            {
                _customerZipCode = value;
            }
        }
        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }

    }
}
