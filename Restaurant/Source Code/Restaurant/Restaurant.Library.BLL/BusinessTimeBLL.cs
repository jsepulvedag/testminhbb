using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class BusinessTimeBLL
    {
        public static DataTable GetHoursByRestaurant(int restaurantID)
        {
            try
            {
                return BusinessTimeDAL.GetHoursByRestaurant(restaurantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
