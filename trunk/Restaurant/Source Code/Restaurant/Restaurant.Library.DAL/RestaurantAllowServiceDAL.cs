using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class RestaurantAllowServiceDAL
    {
        public static RestaurantAllowServiceInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            RestaurantAllowServiceInfo retVal = new RestaurantAllowServiceInfo();
            retVal.RestaurantID = restaurantID;
            PackageInfo package = RestaurantDAL.GetPackage(restaurantID);
            ActiveServiceInfo activeService = ActiveServiceDAL.GetInfo_ByRestaurantID(restaurantID);
            RestaurantDeliveryParamInfo deliveryParam = RestaurantDeliveryParamDAL.GetInfo_ByRestaurantID(restaurantID);
            RestaurantGiftCertificateParameterInfo giftParam = RestaurantGiftCertificateParameterDAL.GetInfo_ByRestaurantID(restaurantID);
            string giftCommission = (ParameterDAL.GetHashtableByGroupName("SystemGiftParameter")["SystemGiftCommission"] == null) ? "" : ParameterDAL.GetHashtableByGroupName("SystemGiftParameter")["SystemGiftCommission"].ToString();
            string reservationCommission = (ParameterDAL.GetHashtableByGroupName("SystemReservationParameter")["SystemReservationCommission"] == null) ? "" : ParameterDAL.GetHashtableByGroupName("SystemReservationParameter")["SystemReservationCommission"].ToString();
            string orderCommission = (ParameterDAL.GetHashtableByGroupName("SystemDeliveryParameter")["SystemDeliveryCommission"] == null) ? "" : ParameterDAL.GetHashtableByGroupName("SystemDeliveryParameter")["SystemDeliveryCommission"].ToString();

            if (activeService != null && package != null)
            {
                retVal.AllowGiftCertificate = package.AllowGiftCertificate & activeService.AllowGiftCertificate;
                retVal.AllowOnlineReservation = package.AllowReservation & activeService.AllowOnlineReservation;
                retVal.AllowOnlineOrder = package.AllowOnlineOrder & activeService.AllowOnlineOrder;
            }
            else
            {
                retVal.AllowGiftCertificate = false;
                retVal.AllowOnlineOrder = false;
                retVal.AllowOnlineReservation = false;
            }
            retVal.AdminSettingGiftCommission = (giftCommission == "" || giftCommission == null) ? false : true;
            retVal.AdminSettingOrderCommission = (orderCommission == "" || orderCommission == null) ? false : true;
            retVal.AdminSettingReservationCommission = (reservationCommission == "" || reservationCommission == null) ? false : true;
            retVal.RestaurantSettingGiftParameter = (giftParam == null) ? false : true;
            retVal.RestaurantSettingOrderParameter = (deliveryParam == null) ? false : true;

            return retVal;
        }
    }
}
