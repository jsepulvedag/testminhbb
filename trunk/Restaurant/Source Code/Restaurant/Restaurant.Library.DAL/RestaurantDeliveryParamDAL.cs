using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class RestaurantDeliveryParamDAL
    {
        public static RestaurantDeliveryParamInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            RestaurantDeliveryParamInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantDeliveryParam_GetInfo_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantDeliveryParamInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MinimumPrice = Convert.ToInt32(dr["MinimumPrice"]);
                    retVal.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                    retVal.ModifiedOn = Convert.ToDateTime(dr["ModifiedOn"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static void Update(RestaurantDeliveryParamInfo restaurantDeliveryParamInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantDeliveryParam_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantDeliveryParamInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MinimumPrice", restaurantDeliveryParamInfo.MinimumPrice);
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
        public static DataTable GetAll_ByRestaurantID(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("RestaurantDeliveryParam_GetInfo_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
