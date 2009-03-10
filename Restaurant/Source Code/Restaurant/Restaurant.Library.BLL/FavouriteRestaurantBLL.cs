using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class FavouriteRestaurantBLL
    {
        public static DataTable CheckFavourite(int restaurantID, int memberID)
        {
            return FavouriteRestaurantDAL.CheckFavourite(restaurantID, memberID);
        }
        public static int Insert(FavouriteRestaurantInfo _favouriteRestaurantInfo)
        {
            return FavouriteRestaurantDAL.Insert(_favouriteRestaurantInfo);
        }
        public static DataTable GetByMember(int memberID)
        {
            return FavouriteRestaurantDAL.GetByMember(memberID);
        }
        public static int Delete(int restaurantid, int memberid)
        {
            return FavouriteRestaurantDAL.Delete(restaurantid,memberid);
        }
    }
}
