using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using System.Data;

namespace Restaurant.Library.DAL
{
    public class BusinessTimeDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_GetAll", dbConn);
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
        public static bool Delete(int businessTimeID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", businessTimeID);
            try
            {
                dbConn.Open();
                int retVal = dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    throw new Exception(AppEnv.DELETED_FAILURE);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int Insert(BusinessTimeInfo _businessTimInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", _businessTimInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@DayOfWeek", _businessTimInfo.DayOfWeek);
            dbCmd.Parameters.AddWithValue("@BusinessStart", _businessTimInfo.BusinessStart);
            dbCmd.Parameters.AddWithValue("@BusinessEnd", _businessTimInfo.BusinessEnd);
            dbCmd.Parameters.AddWithValue("@DeliveryStart", _businessTimInfo.DeliveryStart);
            dbCmd.Parameters.AddWithValue("@DeliveryEnd", _businessTimInfo.DeliveryEnd);
            dbCmd.Parameters.AddWithValue("@MealServed", _businessTimInfo.MealServed);
            dbCmd.Parameters.AddWithValue("@Status", _businessTimInfo.Status);
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

        public static bool Update(BusinessTimeInfo _businessTimInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _businessTimInfo.ID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", _businessTimInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@DayOfWeek", _businessTimInfo.DayOfWeek);
            dbCmd.Parameters.AddWithValue("@BusinessStart", _businessTimInfo.BusinessStart);
            dbCmd.Parameters.AddWithValue("@BusinessEnd", _businessTimInfo.BusinessEnd);
            dbCmd.Parameters.AddWithValue("@DeliveryStart", _businessTimInfo.DeliveryStart);
            dbCmd.Parameters.AddWithValue("@DeliveryEnd", _businessTimInfo.DeliveryEnd);
            dbCmd.Parameters.AddWithValue("@MealServed", _businessTimInfo.MealServed);
            dbCmd.Parameters.AddWithValue("@Status", _businessTimInfo.Status);
            try
            {
                dbConn.Open();
                int retVal = dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    throw new Exception(AppEnv.INSERTED_FAILURE);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

        public static BusinessTimeInfo GetInfo(int businessTimeID)
        {
            BusinessTimeInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", businessTimeID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new BusinessTimeInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.DayOfWeek = Convert.ToInt32(dr["DayOfWeek"]);
                    retVal.BusinessStart = Convert.ToInt32(dr["BusinessStart"]);
                    retVal.BusinessEnd = Convert.ToInt32(dr["BusinessEnd"]);
                    retVal.DeliveryStart = Convert.ToInt32(dr["DeliveryStart"]);
                    retVal.DeliveryEnd = Convert.ToInt32(dr["DeliveryEnd"]);
                    retVal.MealServed = Convert.ToString(dr["MealServed"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetHoursByRestaurant(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("BusinessTime_GetHoursByRestaurant", dbConn);
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
