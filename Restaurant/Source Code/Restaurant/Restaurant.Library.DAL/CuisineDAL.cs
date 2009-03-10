using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using Restaurant.Library.Entities;


namespace Restaurant.Library.DAL
{
    public class CuisineDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Cuisine_GetAll", dbConn);
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
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Cuisine_GetByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantID);
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
            
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Cuisine_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            
            try
            {
                dbConn.Open();
                int relVal = dbCmd.ExecuteNonQuery();
                if (relVal <= 0)
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
        public static CuisineInfo GetInfo ( int _iD )
		{
			CuisineInfo retVal = null;
 			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Cuisine_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@ID", _iD);
			try 
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read()) 
				{
					retVal = new CuisineInfo();
					retVal.ID=Convert.ToInt32(dr["ID"]);
					retVal.Name=Convert.ToString(dr["Name"]);
					retVal.Description=Convert.ToString(dr["Description"]);
					retVal.IsActive=Convert.ToBoolean(dr["IsActive"]);
				}
				if (dr != null)	dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}

        public static bool Update(CuisineInfo cuisineInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Cuisine_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", cuisineInfo.ID);
            dbCmd.Parameters.AddWithValue("@Name", cuisineInfo.Name);
            dbCmd.Parameters.AddWithValue("@Description", cuisineInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", cuisineInfo.IsActive);
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

        public static bool Insert(CuisineInfo cuisineInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Cuisine_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Name", cuisineInfo.Name);
            dbCmd.Parameters.AddWithValue("@Description", cuisineInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", cuisineInfo.IsActive);
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
