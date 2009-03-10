using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using System.Data;

namespace Restaurant.Library.DAL
{
    public class RestaurantNeighbourhoodListDAL
    {
        public static void Insert(RestaurantNeighbourhoodList restaurantNeighbourhoodList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantNeighbourhood_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantNeighbourhoodList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@NeighbourhoodID", restaurantNeighbourhoodList.StringNeighbourhoodID);
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
            SqlCommand dbCmd = new SqlCommand("RestaurantNeighbourhood_DeleteByRestaurantID", dbConn);
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
