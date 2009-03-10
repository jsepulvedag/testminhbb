using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using System.Data;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class RestaurantGoodForListDAL
    {
        public static void Insert(RestaurantGoodForList restaurantGoodForList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGoodFor_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantGoodForList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@GoodForID", restaurantGoodForList.StringGoodForID);
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
            SqlCommand dbCmd = new SqlCommand("RestaurantGoodFor_DeleteByRestaurantID", dbConn);
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
