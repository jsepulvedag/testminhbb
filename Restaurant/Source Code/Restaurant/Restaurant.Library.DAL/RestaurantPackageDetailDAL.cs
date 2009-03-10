using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class RestaurantPackageDetailDAL
    {
        public static int Insert(RestaurantPackageDetailInfo restaurantPackageDetailInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantPackageDetail_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", restaurantPackageDetailInfo.TransactionID);
            dbCmd.Parameters.AddWithValue("@PackageDetailID", restaurantPackageDetailInfo.PackageDetailID);
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
        public static RestaurantPackageDetailInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            RestaurantPackageDetailInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantPackageDetail_GetInfo_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantPackageDetailInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                    retVal.PackageDetailID = Convert.ToInt32(dr["PackageDetailID"]);
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
        public static void Update_ByTransactionID(int transactionID,int packageDetailID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantPackageDetail_Update_ByTransactionID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", transactionID);
            dbCmd.Parameters.AddWithValue("@PackageDetailID", packageDetailID);
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
        public static void Update_ByRestaurantIDIsActive(int restaurantID, bool isActive)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantPackageDetail_UpdateIsActive", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            dbCmd.Parameters.AddWithValue("@IsActive", isActive);
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
