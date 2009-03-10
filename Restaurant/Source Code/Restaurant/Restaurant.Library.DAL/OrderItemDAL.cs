using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Restaurant.Library.DAL
{
   public class OrderItemDAL
    {
        public static bool Delete(int _iD)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItems_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                retVal = true;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static bool Insert(OrderItemInfo _orderItemsInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItems_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _orderItemsInfo.ID);
            dbCmd.Parameters.AddWithValue("@OrderID", _orderItemsInfo.OrderID);
            dbCmd.Parameters.AddWithValue("@MenuItemID", _orderItemsInfo.MenuItemID);
            dbCmd.Parameters.AddWithValue("@Size", _orderItemsInfo.Size);
            dbCmd.Parameters.AddWithValue("@Quantity", _orderItemsInfo.Quantity);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                retVal = true;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static OrderItemInfo GetInfo(int _iD)
        {
            OrderItemInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItems_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            SqlDataReader dr = null;

            try
            {
                dbConn.Open();
                dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new OrderItemInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.OrderID = Convert.ToInt32(dr["OrderID"]);
                    retVal.MenuItemID = Convert.ToInt32(dr["MenuItemID"]);
                    retVal.Size = Convert.ToString(dr["Size"]);
                    retVal.Quantity = Convert.ToInt32(dr["Quantity"]);
                }
            }
            finally
            {
                if (dr != null) dr.Close();
                dbConn.Close();
            }
            return retVal;
        }
 

    }
}
