using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class AtmosphereBLL
    {
        public static DataTable GetByRestaurantAtmosphere(int restaurantID)
        {
            try
            {
                return AtmosphereDAL.GetByRestaurantAtmosphere(restaurantID);
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
                return AtmosphereDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
