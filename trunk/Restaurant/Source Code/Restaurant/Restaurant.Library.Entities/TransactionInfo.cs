using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class TransactionInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _restaurantID;
        public int RestaurantID
        {
            get { return _restaurantID; }
            set { _restaurantID = value; }
        }
        private int _memberID;
        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }
        private string _numberTransaction;
        public string NumberTransaction
        {
            get { return _numberTransaction; }
            set { _numberTransaction = value; }
        }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        private double _fee;
        public double Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private DateTime _createDate;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private DateTime _statusDate;
        public DateTime StatusDate
        {
            get { return _statusDate; }
            set { _statusDate = value; }
        }
        private DateTime _expiryDate;
        public DateTime ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }
        private int _type;
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _supplierPayment;
        public string SupplierPayment
        {
            get { return _supplierPayment; }
            set { _supplierPayment = value; }
        }
    }
}
