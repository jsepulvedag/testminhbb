using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class RestaurantGiftCertificateParameterDAL
    {
        public static void Delete(int id)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_Delete", dbConn);
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
        public static int Insert(RestaurantGiftCertificateParameterInfo restaurantGiftCertificateParameterInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantGiftCertificateParameterInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MinimunGiftCertificate", restaurantGiftCertificateParameterInfo.MinimunGiftCertificate);
            dbCmd.Parameters.AddWithValue("@MaximunGiftCertificate", restaurantGiftCertificateParameterInfo.MaximunGiftCertificate);
            dbCmd.Parameters.AddWithValue("@ExpiryDate", restaurantGiftCertificateParameterInfo.ExpiryDate);
            dbCmd.Parameters.AddWithValue("@IsActive", restaurantGiftCertificateParameterInfo.IsActive);
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
        public static void Update(RestaurantGiftCertificateParameterInfo restaurantGiftCertificateParameterInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantGiftCertificateParameterInfo.ID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantGiftCertificateParameterInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MinimunGiftCertificate", restaurantGiftCertificateParameterInfo.MinimunGiftCertificate);
            dbCmd.Parameters.AddWithValue("@MaximunGiftCertificate", restaurantGiftCertificateParameterInfo.MaximunGiftCertificate);
            dbCmd.Parameters.AddWithValue("@ExpiryDate", restaurantGiftCertificateParameterInfo.ExpiryDate);
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
        public static RestaurantGiftCertificateParameterInfo GetInfo(int id)
        {
            RestaurantGiftCertificateParameterInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantGiftCertificateParameterInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MinimunGiftCertificate = Convert.ToDouble(dr["MinimunGiftCertificate"]);
                    retVal.MaximunGiftCertificate = Convert.ToDouble(dr["MaximunGiftCertificate"]);
                    retVal.ExpiryDate = Convert.ToInt32(dr["ExpiryDate"]);
                    retVal.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    retVal.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
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
        public static RestaurantGiftCertificateParameterInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            RestaurantGiftCertificateParameterInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_GetInfo_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantGiftCertificateParameterInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MinimunGiftCertificate = Convert.ToDouble(dr["MinimunGiftCertificate"]);
                    retVal.MaximunGiftCertificate = Convert.ToDouble(dr["MaximunGiftCertificate"]);
                    retVal.ExpiryDate = Convert.ToInt32(dr["ExpiryDate"]);
                    retVal.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    retVal.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
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
        public static DataTable GetAllByRestaurantID(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantGiftCertificateParameter_GetAll_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID",restaurantID);
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
