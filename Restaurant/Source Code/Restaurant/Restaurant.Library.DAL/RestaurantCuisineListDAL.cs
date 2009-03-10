using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using System.Data;

namespace Restaurant.Library.DAL
{
    public class RestaurantCuisineListDAL
    {
        public static void Insert(RestaurantCuisineList restaurantCuisineList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantCuisine_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantCuisineList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@CuisineID", restaurantCuisineList.StringCuisineID);
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
            SqlCommand dbCmd = new SqlCommand("RestaurantCuisine_DeleteByRestaurantID", dbConn);
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
