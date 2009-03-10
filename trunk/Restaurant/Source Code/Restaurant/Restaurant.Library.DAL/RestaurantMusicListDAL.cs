using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class RestaurantMusicListDAL
    {
        public static void Insert(RestaurantMusicList restaurantMusicList)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantMusic_InsertList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantMusicList.StringRestaurantID);
            dbCmd.Parameters.AddWithValue("@MusicID", restaurantMusicList.StringMusicID);            
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
            SqlCommand dbCmd = new SqlCommand("RestaurantMusic_DeleteByRestaurantID", dbConn);
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
