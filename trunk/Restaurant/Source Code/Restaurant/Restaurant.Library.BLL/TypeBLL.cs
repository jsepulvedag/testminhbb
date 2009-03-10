using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class TypeBLL
    {
        public static DataTable GetByRestaurant(int restaurantID)
        {
            try
            {
                return TypeDAL.GetByRestaurant(restaurantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
