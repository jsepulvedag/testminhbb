using System;

namespace Restaurant.Library.Entities
{
    public class AdminBusinessAccountInfo
    {
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

        private int _supplierPayment;
        public int SupplierPayment
        {
            get { return _supplierPayment; }
            set { _supplierPayment = value; }
        }
    }
}
