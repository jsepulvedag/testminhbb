using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class StateDAL
    {
        public static DataTable GetByCountryID(int countryID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("State_GetByCountryID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@CountryID", countryID);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetAll(bool distinct)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            if (!distinct)
            {                
            }
            else
            {
                SqlCommand dbCmd = new SqlCommand("State_GetAllDistinctName", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    retVal = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                    da.Fill(retVal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbConn.Close();
                }
            }
            return retVal;
        }
        public static DataTable GetByCountryID(int countryID,bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("State_GetByCountryID_IsActive", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@CountryID", countryID);
            dbCmd.Parameters.AddWithValue("@IsActive", active);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static bool Delete(int _iD,int countryID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[State_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            dbCmd.Parameters.AddWithValue("@CountryID", countryID);
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
        public static bool Update(StateInfo stateInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[State_Update]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID",stateInfo.ID);
            dbCmd.Parameters.AddWithValue("@Name", stateInfo.Name);
            dbCmd.Parameters.AddWithValue("@IsActive", stateInfo.isActive);
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
        public static bool Insert(StateInfo stateinfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[State_Insert]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Name", stateinfo.Name);
            dbCmd.Parameters.AddWithValue("@IsActive", stateinfo.isActive);
            dbCmd.Parameters.AddWithValue("@CountryID", stateinfo.CountryID);

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
        public static bool Up(int ID, int CountryID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("State_Up", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
        public static bool Down(int ID, int CountryID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("State_Down", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
        public static DataTable GetByPriority()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("State_GetPriority", dbConn);
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
    }
}
