using System;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;
using System.Data;

namespace Restaurant.Library.BLL
{
    public class RestaurantBusinessAccountBLL
    {
        public static void Update(RestaurantBusinessAccountInfo obj)
        {
            RestaurantBusinessAccountDAL.Update(obj);
        }
        public static void Delete_ByRestaurantID(int restaurantID)
        {
            RestaurantBusinessAccountDAL.Delete_ByRestaurantID(restaurantID);
        }
        public static RestaurantBusinessAccountInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return RestaurantBusinessAccountDAL.GetInfo_ByRestaurantID(restaurantID);
        }
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            return RestaurantBusinessAccountDAL.GetByRestaurantID(restaurantID);
        }
    }
}
