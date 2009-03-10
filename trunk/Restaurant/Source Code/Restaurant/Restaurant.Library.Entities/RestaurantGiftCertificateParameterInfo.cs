using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantGiftCertificateParameterInfo
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
        private double _minimunGiftCertificate;
        public double MinimunGiftCertificate
        {
            get { return _minimunGiftCertificate; }
            set { _minimunGiftCertificate = value; }
        }
        private double _maximunGiftCertificate;
        public double MaximunGiftCertificate
        {
            get { return _maximunGiftCertificate; }
            set { _maximunGiftCertificate = value; }
        }
        private int _expiryDate;
        public int ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private DateTime _modifiedDate;
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}
