using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class ActiveServiceDAL
    {
        public static void Update(ActiveServiceInfo activeServiceInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("ActiveService_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", activeServiceInfo.ID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", activeServiceInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@AllowGiftCertificate", activeServiceInfo.AllowGiftCertificate);
            dbCmd.Parameters.AddWithValue("@AllowOnlineReservation", activeServiceInfo.AllowOnlineReservation);
            dbCmd.Parameters.AddWithValue("@AllowOnlineOrder", activeServiceInfo.AllowOnlineOrder);
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
        public static ActiveServiceInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            ActiveServiceInfo retVal = null;
 			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("ActiveService_GetInfo_ByRestaurantID", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
			try 
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read()) 
				{
					retVal = new ActiveServiceInfo();
					retVal.ID=Convert.ToInt32(dr["ID"]);
					retVal.RestaurantID=Convert.ToInt32(dr["RestaurantID"]);
					retVal.AllowGiftCertificate=Convert.ToBoolean(dr["AllowGiftCertificate"]);
					retVal.AllowOnlineReservation=Convert.ToBoolean(dr["AllowOnlineReservation"]);
					retVal.AllowOnlineOrder=Convert.ToBoolean(dr["AllowOnlineOrder"]);
				}
				if (dr != null)	dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
        }
        public static DataTable GetInfoDetail_ByRestaurantID(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("ActiveService_GetInfoDetail_ByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
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
