using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class GoodForBLL
    {
        public static DataTable GetByRestaurantGoodFor(int restaurantID)
        {
            try
            {
                return GoodForDAL.GetByRestaurantGoodFor(restaurantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAll()
        {
            try
            {
                return GoodForDAL.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
