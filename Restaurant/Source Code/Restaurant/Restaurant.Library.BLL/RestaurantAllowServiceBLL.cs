using System;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantAllowServiceBLL
    {
        public static RestaurantAllowServiceInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return RestaurantAllowServiceDAL.GetInfo_ByRestaurantID(restaurantID);
        }
    }
}
