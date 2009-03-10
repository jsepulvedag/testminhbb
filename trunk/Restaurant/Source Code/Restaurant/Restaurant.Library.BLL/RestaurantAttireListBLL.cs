using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantAttireListBLL
    {
        public static void Insert(RestaurantAttireList obj)
        {
            RestaurantAttireListDAL.Insert(obj);
        }
        public static void DeleteByRestaurantID(int restaurantID)
        {
            RestaurantAttireListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
