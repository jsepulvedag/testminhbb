using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantPackageDetailInfo
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
        private int _packageDetailID;
        public int PackageDetailID
        {
            get { return _packageDetailID; }
            set { _packageDetailID = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}
