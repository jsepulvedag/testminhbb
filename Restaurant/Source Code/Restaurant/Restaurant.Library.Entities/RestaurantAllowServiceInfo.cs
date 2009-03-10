using System;

namespace Restaurant.Library.Entities
{
    public class RestaurantAllowServiceInfo
    {
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

        private bool _adminSettingGiftCommission;
        public bool AdminSettingGiftCommission
        {
            get { return _adminSettingGiftCommission; }
            set { _adminSettingGiftCommission = value; }
        }

        private bool _restaurantSettingGiftParameter;
        public bool RestaurantSettingGiftParameter
        {
            get { return _restaurantSettingGiftParameter; }
            set { _restaurantSettingGiftParameter = value; }
        }

        private bool _adminSettingReservationCommission;
        public bool AdminSettingReservationCommission
        {
            get { return _adminSettingReservationCommission; }
            set { _adminSettingReservationCommission = value; }
        }

        private bool _adminSettingOrderCommission;
        public bool AdminSettingOrderCommission
        {
            get { return _adminSettingOrderCommission; }
            set { _adminSettingOrderCommission = value; }
        }

        private bool _restaurantSettingOrderParameter;
        public bool RestaurantSettingOrderParameter
        {
            get { return _restaurantSettingOrderParameter; }
            set { _restaurantSettingOrderParameter = value; }
        }

        private int _restaurantID;
        public int RestaurantID
        {
            get { return _restaurantID; }
            set { _restaurantID = value; }
        }
    }
}
