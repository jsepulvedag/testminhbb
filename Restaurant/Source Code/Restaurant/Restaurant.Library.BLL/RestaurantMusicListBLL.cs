using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class RestaurantMusicListBLL
    {
        public static void Insert(RestaurantMusicList obj)
        {
            RestaurantMusicListDAL.Insert(obj);            
        }
        public static void DeletebyRestaurantID(int restaurantID)
        {
            RestaurantMusicListDAL.DeleteByRestaurantID(restaurantID);
        }
    }
}
