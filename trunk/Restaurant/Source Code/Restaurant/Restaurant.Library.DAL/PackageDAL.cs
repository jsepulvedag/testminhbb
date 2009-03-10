using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class PackageDAL
    {
        public static DataTable GetAll(bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd;
            if (!active)
            {
                dbCmd = new SqlCommand("Package_GetAll", dbConn);
            }
            else
            {
                dbCmd = new SqlCommand("Package_GetAll_Active", dbConn);
            }
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
        public static DataTable GetFree(bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd;
            dbCmd = new SqlCommand("Package_GetFree", dbConn);
            dbCmd.Parameters.AddWithValue("@IsActive",active);
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
        public static DataTable GetNotFree(bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd;
            dbCmd = new SqlCommand("Package_GetNotFree", dbConn);
            dbCmd.Parameters.AddWithValue("@IsActive", active);
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
        public static int Insert(PackageInfo packageInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Package_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Name", packageInfo.Name);
            dbCmd.Parameters.AddWithValue("@AllowOnlineOrder", packageInfo.AllowOnlineOrder);
            dbCmd.Parameters.AddWithValue("@AllowGiftCertificate", packageInfo.AllowGiftCertificate);
            dbCmd.Parameters.AddWithValue("@AllowReservation", packageInfo.AllowReservation);
            dbCmd.Parameters.AddWithValue("@AllowMap", packageInfo.AllowMap);
            dbCmd.Parameters.AddWithValue("@AllowVideo", packageInfo.AllowVideo);
            dbCmd.Parameters.AddWithValue("@AllowPhoto", packageInfo.AllowPhoto);
            dbCmd.Parameters.AddWithValue("@AllowEvent", packageInfo.AllowEvent);
            dbCmd.Parameters.AddWithValue("@AllowJobPortal", packageInfo.AllowJobPortal);
            dbCmd.Parameters.AddWithValue("@AllowMenu", packageInfo.AllowMenu);
            dbCmd.Parameters.AddWithValue("@AllowSponsored", packageInfo.AllowSponsored);
            dbCmd.Parameters.AddWithValue("@Priority", packageInfo.Priority);
            dbCmd.Parameters.AddWithValue("@Description", packageInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", packageInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void Update(PackageInfo packageInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Package_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", packageInfo.ID);
            dbCmd.Parameters.AddWithValue("@Name", packageInfo.Name);
            dbCmd.Parameters.AddWithValue("@AllowOnlineOrder", packageInfo.AllowOnlineOrder);
            dbCmd.Parameters.AddWithValue("@AllowGiftCertificate", packageInfo.AllowGiftCertificate);
            dbCmd.Parameters.AddWithValue("@AllowReservation", packageInfo.AllowReservation);
            dbCmd.Parameters.AddWithValue("@AllowMap", packageInfo.AllowMap);
            dbCmd.Parameters.AddWithValue("@AllowVideo", packageInfo.AllowVideo);
            dbCmd.Parameters.AddWithValue("@AllowPhoto", packageInfo.AllowPhoto);
            dbCmd.Parameters.AddWithValue("@AllowEvent", packageInfo.AllowEvent);
            dbCmd.Parameters.AddWithValue("@AllowJobPortal", packageInfo.AllowJobPortal);
            dbCmd.Parameters.AddWithValue("@AllowMenu", packageInfo.AllowMenu);
            dbCmd.Parameters.AddWithValue("@AllowSponsored", packageInfo.AllowSponsored);
            dbCmd.Parameters.AddWithValue("@Priority", packageInfo.Priority);
            dbCmd.Parameters.AddWithValue("@Description", packageInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", packageInfo.IsActive);
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
        public static void Delete(int id)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Package_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
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
        public static PackageInfo GetInfo(int id)
        {
            PackageInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Package_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new PackageInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.Name = Convert.ToString(dr["Name"]);
                    retVal.AllowOnlineOrder = Convert.ToBoolean(dr["AllowOnlineOrder"]);
                    retVal.AllowGiftCertificate = Convert.ToBoolean(dr["AllowGiftCertificate"]);
                    retVal.AllowReservation = Convert.ToBoolean(dr["AllowReservation"]);
                    retVal.AllowMap = Convert.ToBoolean(dr["AllowMap"]);
                    retVal.AllowVideo = Convert.ToBoolean(dr["AllowVideo"]);
                    retVal.AllowPhoto = Convert.ToBoolean(dr["AllowPhoto"]);
                    retVal.AllowEvent = Convert.ToBoolean(dr["AllowEvent"]);
                    retVal.AllowJobPortal = Convert.ToBoolean(dr["AllowJobPortal"]);
                    retVal.AllowMenu = Convert.ToBoolean(dr["AllowMenu"]);
                    retVal.AllowSponsored = Convert.ToBoolean(dr["AllowSponsored"]);
                    retVal.Priority = Convert.ToInt16(dr["Priority"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}
