using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantGoodForListBLL
    {
        public static void Insert(RestaurantGoodForList obj)
        {
            RestaurantGoodForListDAL.Insert(obj);           
        }
        public static void DeleteByRestaurantID(int restaurantID)
        {
            RestaurantGoodForListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
