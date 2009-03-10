using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using System.Data;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class TransactionDAL
    {
        public static int Insert(TransactionInfo transactionInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", transactionInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MemberID", transactionInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@NumberTransaction", transactionInfo.NumberTransaction);
            dbCmd.Parameters.AddWithValue("@TotalPrice", transactionInfo.TotalPrice);
            dbCmd.Parameters.AddWithValue("@Fee", transactionInfo.Fee);
            dbCmd.Parameters.AddWithValue("@Tax", transactionInfo.Tax);
            dbCmd.Parameters.AddWithValue("@Status", transactionInfo.Status);
            dbCmd.Parameters.AddWithValue("@Type", transactionInfo.Type);
            dbCmd.Parameters.AddWithValue("@SupplierPayment", transactionInfo.SupplierPayment);
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
        public static void Update_Status(int transactionID,Int16 status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_Update_Status", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", transactionID);
            dbCmd.Parameters.AddWithValue("@Status", status);
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
        public static TransactionInfo GetInfo(int id)
        {
            TransactionInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new TransactionInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MemberID = Convert.ToInt32(dr["MemberID"]);
                    retVal.NumberTransaction = Convert.ToString(dr["NumberTransaction"]);
                    retVal.TotalPrice = Convert.ToDouble(dr["TotalPrice"]);
                    retVal.Fee = Convert.ToDouble(dr["Fee"]);
                    retVal.Tax = Convert.ToDouble(dr["Tax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    retVal.StatusDate = Convert.ToDateTime(dr["StatusDate"]);
                    retVal.Type = Convert.ToInt32(dr["Type"]);
                    retVal.SupplierPayment = Convert.ToString(dr["SupplierPayment"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static TransactionInfo GetInfo_ByRestaurantIDAndTypePackage(int restaurantID)
        {
            TransactionInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_GetInfo_ByRestaurantID_Package", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new TransactionInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MemberID = Convert.ToInt32(dr["MemberID"]);
                    retVal.NumberTransaction = Convert.ToString(dr["NumberTransaction"]);
                    retVal.TotalPrice = Convert.ToDouble(dr["TotalPrice"]);
                    retVal.Fee = Convert.ToDouble(dr["Fee"]);
                    retVal.Tax = Convert.ToDouble(dr["Tax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    retVal.StatusDate = Convert.ToDateTime(dr["StatusDate"]);
                    retVal.Type = Convert.ToInt32(dr["Type"]);
                    retVal.SupplierPayment = Convert.ToString(dr["SupplierPayment"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static void Update(TransactionInfo transactionInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", transactionInfo.ID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", transactionInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MemberID", transactionInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@NumberTransaction", transactionInfo.NumberTransaction);
            dbCmd.Parameters.AddWithValue("@TotalPrice", transactionInfo.TotalPrice);
            dbCmd.Parameters.AddWithValue("@Fee", transactionInfo.Fee);
            dbCmd.Parameters.AddWithValue("@Tax", transactionInfo.Tax);
            dbCmd.Parameters.AddWithValue("@Status", transactionInfo.Status);
            dbCmd.Parameters.AddWithValue("@Type", transactionInfo.Type);
            dbCmd.Parameters.AddWithValue("@SupplierPayment", transactionInfo.SupplierPayment);
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
        public static TransactionInfo GetInfo_ByGiftID(int giftID)
        {
            TransactionInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_GetInfo_ByGiftID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GiftID", giftID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new TransactionInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MemberID = Convert.ToInt32(dr["MemberID"]);
                    retVal.NumberTransaction = Convert.ToString(dr["NumberTransaction"]);
                    retVal.TotalPrice = Convert.ToDouble(dr["TotalPrice"]);
                    retVal.Fee = Convert.ToDouble(dr["Fee"]);
                    retVal.Tax = Convert.ToDouble(dr["Tax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
                    retVal.StatusDate = Convert.ToDateTime(dr["StatusDate"]);
                    retVal.Type = Convert.ToInt32(dr["Type"]);
                    retVal.SupplierPayment = Convert.ToString(dr["SupplierPayment"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable SearchByMemberID(int memberID, int type, int status, DateTime fromDate, DateTime toDate)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Transaction_SearchByMemberID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID",memberID);
            dbCmd.Parameters.AddWithValue("@Type",type);
            dbCmd.Parameters.AddWithValue("@Status",status);
            dbCmd.Parameters.AddWithValue("@FromDate",fromDate);
            dbCmd.Parameters.AddWithValue("@ToDate", toDate);
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
    }
}
