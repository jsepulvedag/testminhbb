using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class ReservationDAL
    {
        public static int Insert(ReservationInfo reservationInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", reservationInfo.TransactionID);
            dbCmd.Parameters.AddWithValue("@CustomerFirstName", reservationInfo.CustomerFirstName);
            dbCmd.Parameters.AddWithValue("@CustomerLastName", reservationInfo.CustomerLastName);
            dbCmd.Parameters.AddWithValue("@CustomerGender", reservationInfo.CustomerGender);
            dbCmd.Parameters.AddWithValue("@CustomerPhone", reservationInfo.CustomerPhone);
            dbCmd.Parameters.AddWithValue("@CustomerFax", reservationInfo.CustomerFax);
            dbCmd.Parameters.AddWithValue("@CustomerEmail", reservationInfo.CustomerEmail);
            dbCmd.Parameters.AddWithValue("@CustomerAddress", reservationInfo.CustomerAddress);
            dbCmd.Parameters.AddWithValue("@CustomerCountryID", reservationInfo.CustomerCountryID);
            dbCmd.Parameters.AddWithValue("@CustomerStateID", reservationInfo.CustomerStateID);
            dbCmd.Parameters.AddWithValue("@CustomerCityID", reservationInfo.CustomerCityID);
            dbCmd.Parameters.AddWithValue("@ReserDate", reservationInfo.ReserDate);
            dbCmd.Parameters.AddWithValue("@Status", reservationInfo.Status);
            dbCmd.Parameters.AddWithValue("@ConfirmationCode", reservationInfo.ConfirmationCode);
            dbCmd.Parameters.AddWithValue("@ReserDescription", reservationInfo.ReserDescription);
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
        public static DataTable GetAll_ByMemberID(int memberID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_GetByMemberID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
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
        public static DataTable GetAll_ByRestaurantID(int restaurantID, DateTime from, DateTime to, int status)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_GetByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            dbCmd.Parameters.AddWithValue("@FromDate", from);
            dbCmd.Parameters.AddWithValue("@ToDate", to);
            dbCmd.Parameters.AddWithValue("@Status", status);
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
        public static DataTable GetAll_ByAdmin(int restaurantID, DateTime from, DateTime to, int status)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_GetByAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            dbCmd.Parameters.AddWithValue("@FromDate", from);
            dbCmd.Parameters.AddWithValue("@ToDate", to);
            dbCmd.Parameters.AddWithValue("@Status", status);
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
        public static void UpdateStatus(int id,Int16 status)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_UpdateStatus", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ReservationID", id);
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
        public static void UpdateRealized(int id,bool realized)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_UpdateRealized", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ReservationID", id);
            dbCmd.Parameters.AddWithValue("@Realized", realized);
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
        public static ReservationInfo GetByTransactionID(int transactionID)
        {
            ReservationInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Reservation_GetByTransactionID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@TransactionID", transactionID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ReservationInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                    retVal.CustomerFirstName = Convert.ToString(dr["CustomerFirstName"]);
                    retVal.CustomerLastName = Convert.ToString(dr["CustomerLastName"]);
                    retVal.CustomerGender = Convert.ToString(dr["CustomerGender"]);
                    retVal.CustomerPhone = Convert.ToString(dr["CustomerPhone"]);
                    retVal.CustomerFax = Convert.ToString(dr["CustomerFax"]);
                    retVal.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
                    retVal.CustomerAddress = Convert.ToString(dr["CustomerAddress"]);
                    retVal.CustomerCountryID = Convert.ToInt32(dr["CustomerCountryID"]);
                    retVal.CustomerStateID = Convert.ToInt32(dr["CustomerStateID"]);
                    retVal.CustomerCityID = Convert.ToInt32(dr["CustomerCityID"]);
                    retVal.ReserDate = Convert.ToDateTime(dr["ReserDate"]);
                    retVal.ConfirmationCode = Convert.ToString(dr["ConfirmationCode"]);
                    retVal.ReserDescription = Convert.ToString(dr["ReserDescription"]);
                    retVal.Status = Convert.ToInt16(dr["Realized"]);
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
