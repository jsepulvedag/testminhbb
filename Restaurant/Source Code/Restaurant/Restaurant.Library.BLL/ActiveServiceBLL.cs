using System;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class ActiveServiceBLL
    {
        public static void Update(ActiveServiceInfo obj)
        {
            ActiveServiceDAL.Update(obj);
        }
        public static ActiveServiceInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return ActiveServiceDAL.GetInfo_ByRestaurantID(restaurantID);
        }
        public static DataTable GetInfoDetail_ByRestaurantID(int restaurantID)
        {
            return ActiveServiceDAL.GetInfoDetail_ByRestaurantID(restaurantID);
        }
    }
}
