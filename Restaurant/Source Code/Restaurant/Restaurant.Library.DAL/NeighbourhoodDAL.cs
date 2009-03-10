using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class NeighbourhoodDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetAll", dbConn);
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
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetByRestaurantID", dbConn);
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
        public static DataTable GetByCityID(int cityID)
        { 
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetByCityID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@CityID", cityID);
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
        public static DataTable GetByCitySearch(int cityID)
        { 
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetByCitySearch", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@CityID", cityID);
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
        public static DataTable GetByCityID(int cityID, bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetByCityID_Active", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@CityID", cityID);
            dbCmd.Parameters.AddWithValue("@IsActive", active);
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
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_Delete", dbConn);
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
        public static bool Insert(NeighbourhoodInfo _neighbourhoodInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Name", _neighbourhoodInfo.Name);
            dbCmd.Parameters.AddWithValue("@CityID", _neighbourhoodInfo.CityID);
            dbCmd.Parameters.AddWithValue("@Description", _neighbourhoodInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", _neighbourhoodInfo.IsActive);
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
        public static bool Update(NeighbourhoodInfo _neighbourhoodInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Neighbourhood_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _neighbourhoodInfo.ID);
            dbCmd.Parameters.AddWithValue("@Name", _neighbourhoodInfo.Name);
            dbCmd.Parameters.AddWithValue("@Description", _neighbourhoodInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", _neighbourhoodInfo.IsActive);
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
        public static NeighbourhoodInfo GetInfo ( int _iD )
		{
			NeighbourhoodInfo retVal = null;
 			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Neighbourhood_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@ID", _iD);
			try 
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read()) 
				{
					retVal = new NeighbourhoodInfo();
					retVal.ID=Convert.ToInt32(dr["ID"]);
					retVal.Name=Convert.ToString(dr["Name"]);
					retVal.CityID=Convert.ToInt32(dr["CityID"]);
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

    }
}
