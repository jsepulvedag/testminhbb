using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Restaurant.Library.DAL
{
   public class OrderItemAddOnDAL
    {

        public static bool Delete(int _iD)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItemAddons_Delete", dbConn);
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

        public static bool Insert(OrderItemAddonInfo _orderItemAddonsInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItemAddons_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _orderItemAddonsInfo.ID);
            dbCmd.Parameters.AddWithValue("@OrderItemID", _orderItemAddonsInfo.OrderItemID);
            dbCmd.Parameters.AddWithValue("@MenuItemAddon", _orderItemAddonsInfo.MenuItemAddon);
            dbCmd.Parameters.AddWithValue("@Quantity", _orderItemAddonsInfo.Quantity);
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


        public static OrderItemAddonInfo GetInfo(int _iD)
        {
            OrderItemAddonInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("OrderItemAddons_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            SqlDataReader dr = null;

            try
            {
                dbConn.Open();
                dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new OrderItemAddonInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.OrderItemID = Convert.ToInt32(dr["OrderItemID"]);
                    retVal.MenuItemAddon = Convert.ToInt32(dr["MenuItemAddon"]);
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
