using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantSpecialListBLL
    {
        public static void Insert(RestaurantSpecialList obj)
        {
            RestaurantSpecialListDAL.Insert(obj);            
        }
        public static void DeleteByRestaurantID(int restaurantID)
        {
            RestaurantSpecialListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
