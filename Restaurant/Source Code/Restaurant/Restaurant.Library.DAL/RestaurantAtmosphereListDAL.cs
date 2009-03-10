using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using System.Data;

namespace Restaurant.Library.DAL
{
    public class RestaurantAtmosphereListDAL
    {
        public static void Insert(RestaurantAtmosphereList restaurantAtmosphereList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantAtmosphere_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantAtmosphereList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@AtmosphereID", restaurantAtmosphereList.StringAtmosphereID);            
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }                
        }
        public static bool DeleteByRestaurantID(int restaurantID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantAtmosphere_DeleteByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                int retVal = dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}
