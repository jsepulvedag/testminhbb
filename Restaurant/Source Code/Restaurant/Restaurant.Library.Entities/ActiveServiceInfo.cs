using System;

namespace Restaurant.Library.Entities
{
    public class ActiveServiceInfo
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

        private bool _allowGiftCertificate;
        public bool AllowGiftCertificate
        {
            get { return _allowGiftCertificate; }
            set { _allowGiftCertificate = value; }
        }

        private bool _allowOnlineReservation;
        public bool AllowOnlineReservation
        {
            get { return _allowOnlineReservation; }
            set { _allowOnlineReservation = value; }
        }

        private bool _allowOnlineOrder;
        public bool AllowOnlineOrder
        {
            get { return _allowOnlineOrder; }
            set { _allowOnlineOrder = value; }
        }
    }
}
