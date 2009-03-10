using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantAtmosphereListBLL
    {
        public static void Insert(RestaurantAtmosphereList obj)
        {
            RestaurantAtmosphereListDAL.Insert(obj);
        }
        public static bool DeleteByRestaurantID(int restaurantID)
        {
            return RestaurantAtmosphereListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
