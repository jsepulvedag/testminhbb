using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class SpecialDAL
    {
        public static DataTable GetByRestaurantSpecial(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_GetByRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal; 
        }
        public static DataTable GetByAdmin()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_GetByAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal; 
        }
        public static bool Delete(int _iD)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                retVal = true;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static bool Update(SpecialInfo SpecialInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", SpecialInfo.ID);
            dbCmd.Parameters.AddWithValue("@Name", SpecialInfo.Name);
            dbCmd.Parameters.AddWithValue("@Description", SpecialInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", SpecialInfo.IsActive);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                retVal = true;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static bool Insert(SpecialInfo SpecialInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Special_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Name", SpecialInfo.Name);
            dbCmd.Parameters.AddWithValue("@Description", SpecialInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", SpecialInfo.IsActive);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                retVal = true;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}
