using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class RestaurantBusinessAccountDAL
    {
        public static void Delete_ByRestaurantID(int restaurantID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantBusinessAccount_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static void Update(RestaurantBusinessAccountInfo _restaurantBusinessAccountInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantBusinessAccount_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", _restaurantBusinessAccountInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@APIUserName", _restaurantBusinessAccountInfo.APIUserName);
            dbCmd.Parameters.AddWithValue("@APIPassword", _restaurantBusinessAccountInfo.APIPassword);
            dbCmd.Parameters.AddWithValue("@APISignature", _restaurantBusinessAccountInfo.APISignature);
            dbCmd.Parameters.AddWithValue("@SupplierPayment", _restaurantBusinessAccountInfo.SupplierPayment);
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
        public static RestaurantBusinessAccountInfo GetInfo_ByRestaurantID(int _iD)
        {
            RestaurantBusinessAccountInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantBusinessAccount_GetByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", _iD);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantBusinessAccountInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.APIUserName = Convert.ToString(dr["APIUserName"]);
                    retVal.APIPassword = Convert.ToString(dr["APIPassword"]);
                    retVal.APISignature = Convert.ToString(dr["APISignature"]);
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
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantBusinessAccount_GetByRestaurantID", dbConn);
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
