using System;
using Restaurant.Library.Entities;

namespace Restaurant.Library.Utilities.PayPalAPI
{
    public class BusinessAccountInfo
    {
        private string _apiUserName;
        public string APIUserName
        {
            get { return _apiUserName; }
            set { _apiUserName = value; }
        }

        private string _apiPassword;
        public string APIPassword
        {
            get { return _apiPassword; }
            set { _apiPassword = value; }
        }

        private string _apiSignature;
        public string APISignature
        {
            get { return _apiSignature; }
            set { _apiSignature = value; }
        }
        public BusinessAccountInfo() { }
        public BusinessAccountInfo(AdminBusinessAccountInfo adminAccount)
        {
            _apiPassword = adminAccount.APIPassword;
            _apiUserName = adminAccount.APIUserName;
            _apiSignature = adminAccount.APISignature;
        }

        public BusinessAccountInfo(RestaurantBusinessAccountInfo restaurantAccount)
        {
            _apiPassword = restaurantAccount.APIPassword;
            _apiUserName = restaurantAccount.APIUserName;
            _apiSignature = restaurantAccount.APISignature;
        }
    }
}
