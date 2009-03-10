using System;

namespace Restaurant.Library.Entities
{
    public class RestaurantBusinessAccountInfo
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

        private string _aPIUserName;
        public string APIUserName
        {
            get { return _aPIUserName; }
            set { _aPIUserName = value; }
        }

        private string _aPIPassword;
        public string APIPassword
        {
            get { return _aPIPassword; }
            set { _aPIPassword = value; }
        }

        private string _aPISignature;
        public string APISignature
        {
            get { return _aPISignature; }
            set { _aPISignature = value; }
        }

        private string _supplierPayment;
        public string SupplierPayment
        {
            get { return _supplierPayment; }
            set { _supplierPayment = value; }
        }
    }
}
