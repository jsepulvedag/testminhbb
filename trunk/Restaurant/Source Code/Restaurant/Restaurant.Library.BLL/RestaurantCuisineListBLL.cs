using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantCuisineListBLL
    {
        public static void Insert(RestaurantCuisineList obj)
        {
            RestaurantCuisineListDAL.Insert(obj);            
        }
        public static void DeleteByRestaurantID(int restaurantID)
        {
            RestaurantCuisineListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
