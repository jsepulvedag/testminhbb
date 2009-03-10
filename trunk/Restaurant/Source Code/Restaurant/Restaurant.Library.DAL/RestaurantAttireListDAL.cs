using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class RestaurantAttireListDAL
    {
        public static void Insert(RestaurantAttireList restaurantAttireList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantAttire_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantAttireList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@AttireID", restaurantAttireList.StringAttireID);
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
            SqlCommand dbCmd = new SqlCommand("RestaurantAttire_DeleteByRestaurantID", dbConn);
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
