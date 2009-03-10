using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class PackageDetailDAL
    {
        public static DataTable GetByPackageID(int packageID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("PakageDetail_GetByPackageID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@PackageID",packageID);
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
        public static PackageDetailInfo GetInfo(int id)
        {
            PackageDetailInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("PackageDetail_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new PackageDetailInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.PackageID = Convert.ToInt32(dr["PackageID"]);
                    retVal.Name = Convert.ToString(dr["Name"]);
                    retVal.ExpiryMonth = Convert.ToInt32(dr["ExpiryMonth"]);
                    retVal.Price = Convert.ToDouble(dr["Price"]);
                    retVal.Priority = Convert.ToInt32(dr["Priority"]);
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
        public static DataTable GetAll(bool active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd;
            if (!active)
            {
                dbCmd = new SqlCommand("PackageDetail_GetAll", dbConn);
            }
            else
            {
                dbCmd = new SqlCommand("PackageDetail_GetAll_Active", dbConn);
            }
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
            return retVal; 
        }
        public static int Insert(PackageDetailInfo packageDetailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("PackageDetail_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@PackageID", packageDetailInfo.PackageID);
            dbCmd.Parameters.AddWithValue("@Name", packageDetailInfo.Name);
            dbCmd.Parameters.AddWithValue("@ExpiryMonth", packageDetailInfo.ExpiryMonth);
            dbCmd.Parameters.AddWithValue("@Price", packageDetailInfo.Price);
            dbCmd.Parameters.AddWithValue("@Priority", packageDetailInfo.Priority);
            dbCmd.Parameters.AddWithValue("@Description", packageDetailInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", packageDetailInfo.IsActive);
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
        public static void Update(PackageDetailInfo packageDetailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("PackageDetail_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", packageDetailInfo.ID);
            dbCmd.Parameters.AddWithValue("@PackageID", packageDetailInfo.PackageID);
            dbCmd.Parameters.AddWithValue("@Name", packageDetailInfo.Name);
            dbCmd.Parameters.AddWithValue("@ExpiryMonth", packageDetailInfo.ExpiryMonth);
            dbCmd.Parameters.AddWithValue("@Price", packageDetailInfo.Price);
            dbCmd.Parameters.AddWithValue("@Priority", packageDetailInfo.Priority);
            dbCmd.Parameters.AddWithValue("@Description", packageDetailInfo.Description);
            dbCmd.Parameters.AddWithValue("@IsActive", packageDetailInfo.IsActive);
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
            SqlCommand dbCmd = new SqlCommand("PackageDetail_Delete", dbConn);
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
    }
}
