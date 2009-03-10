using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantPackageDetailBLL
    {
        public static int Insert(RestaurantPackageDetailInfo obj)
        {
            return RestaurantPackageDetailDAL.Insert(obj);           
        }
        public static RestaurantPackageDetailInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return RestaurantPackageDetailDAL.GetInfo_ByRestaurantID(restaurantID);
        }
        public static void Update_ByTransactionID(int transactionID, int packageDetailID)
        {
            RestaurantPackageDetailDAL.Update_ByTransactionID(transactionID,packageDetailID);
        }
        public static void Update_ByRestaurantIDIsActive(int restaurantID, bool isActive)
        {
            RestaurantPackageDetailDAL.Update_ByRestaurantIDIsActive(restaurantID,isActive);
        }
    }
}
