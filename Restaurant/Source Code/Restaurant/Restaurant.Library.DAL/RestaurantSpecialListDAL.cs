using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using System.Data;

namespace Restaurant.Library.DAL
{
    public class RestaurantSpecialListDAL
    {
        public static void Insert(RestaurantSpecialList restaurantSpecialList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantSpecial_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantSpecialList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@SpecialID", restaurantSpecialList.StringSpecialID);
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
        public static void DeleteByRestaurantID(int restaurantID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantSpecial_DeleteByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
    }
}
