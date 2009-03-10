using System;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantDeliveryParamBLL
    {
        public static void Update(RestaurantDeliveryParamInfo obj)
        {
            RestaurantDeliveryParamDAL.Update(obj);
        }
        public static RestaurantDeliveryParamInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return RestaurantDeliveryParamDAL.GetInfo_ByRestaurantID(restaurantID);
        }
        public static DataTable GetAll_ByRestaurantID(int restaurantID)
        {
            return RestaurantDeliveryParamDAL.GetAll_ByRestaurantID(restaurantID);
        }
    }
}
