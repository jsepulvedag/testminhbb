using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class IncomeTransactionDAL
    {
        public static int Insert(IncomeTransactionInfo incomeTransactionInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("IncomeTransaction_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", incomeTransactionInfo.TransactionID);
            dbCmd.Parameters.AddWithValue("@NumberTransaction", incomeTransactionInfo.NumberTransaction);
            dbCmd.Parameters.AddWithValue("@Price", incomeTransactionInfo.Price);
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
        public static void Update(IncomeTransactionInfo incomeTransactionInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("IncomeTransaction_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", incomeTransactionInfo.ID);
            dbCmd.Parameters.AddWithValue("@TransactionID", incomeTransactionInfo.TransactionID);
            dbCmd.Parameters.AddWithValue("@NumberTransaction", incomeTransactionInfo.NumberTransaction);
            dbCmd.Parameters.AddWithValue("@Price", incomeTransactionInfo.Price);
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
