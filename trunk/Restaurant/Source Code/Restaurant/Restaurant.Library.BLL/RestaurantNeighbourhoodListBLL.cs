using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantNeighbourhoodListBLL
    {
        public static void Insert(RestaurantNeighbourhoodList obj)
        {
            RestaurantNeighbourhoodListDAL.Insert(obj);
        }
        public static void DeleteByRestaurantID(int restaurantID)
        {
            RestaurantNeighbourhoodListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
