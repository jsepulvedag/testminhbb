using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class MenuItemDAL
    {
        public static System.Data.DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand(" MenuItem_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
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

        public static DataTable GetByMenuCategory(int menuCategoryId, int active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuItem_GetByMenuCategory", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuCategoryId", menuCategoryId);
            dbCmd.Parameters.AddWithValue("@Active", active);
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

        public static bool UpdatePriority(int menuCategoryId, int priority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuItem_UpdatePriority]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", menuCategoryId);
            dbCmd.Parameters.AddWithValue("@Priority", priority);
            try
            {
                dbConn.Open();
                if (dbCmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                dbConn.Close();
            }
            return false;
        }

        public static MenuItemInfo GetInfo(int _id)
        {
			MenuItemInfo retVal = null;
 			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("MenuItem_GetInfo", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
			dbCmd.Parameters.AddWithValue("@ID", _id);
			try 
			{
				dbConn.Open();
				SqlDataReader dr = dbCmd.ExecuteReader();
				if (dr.Read()) 
				{
					retVal = new MenuItemInfo();
					retVal.ID=Convert.ToInt32(dr["ID"]);
					retVal.MenuCategoryID=Convert.ToInt32(dr["MenuCategoryID"]);
					retVal.Name=Convert.ToString(dr["Name"]);
					retVal.ShortDescription=Convert.ToString(dr["ShortDescription"]);
					retVal.Views=Convert.ToInt32(dr["Views"]);
					retVal.Price1=Convert.ToDouble(dr["Price1"]);
                    retVal.Price2 = Convert.ToDouble(dr["Price2"]);
                    retVal.Price3 = Convert.ToDouble(dr["Price3"]);
					retVal.Image=Convert.ToString(dr["Image"]);
					retVal.CreatedDate=Convert.ToDateTime(dr["CreatedDate"]);
					retVal.IsActive=Convert.ToBoolean(dr["IsActive"]);
					retVal.FullDescription=Convert.ToString(dr["FullDescription"]);
					retVal.Priority=Convert.ToInt32(dr["Priority"]);
				}
				if (dr != null)	dr.Close();
			}
			finally
			{
				dbConn.Close();
			}
			return retVal;
		}
        /// <summary>
        /// insert, update, update with priority
        /// </summary>
        /// <param name="_menuItemInfo"></param>
        /// <returns></returns>
        public static int Insert(MenuItemInfo _menuItemInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuItem_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", _menuItemInfo.MenuCategoryID);
            dbCmd.Parameters.AddWithValue("@Name", _menuItemInfo.Name);
            dbCmd.Parameters.AddWithValue("@ShortDescription", _menuItemInfo.ShortDescription);
            dbCmd.Parameters.AddWithValue("@Views", _menuItemInfo.Views);
            dbCmd.Parameters.AddWithValue("@Price1", _menuItemInfo.Price1);
            dbCmd.Parameters.AddWithValue("@Price2", _menuItemInfo.Price2);
            dbCmd.Parameters.AddWithValue("@Price3", _menuItemInfo.Price3);
            dbCmd.Parameters.AddWithValue("@Image", _menuItemInfo.Image);
            dbCmd.Parameters.AddWithValue("@CreatedDate", _menuItemInfo.CreatedDate);
            dbCmd.Parameters.AddWithValue("@IsActive", _menuItemInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@FullDescription", _menuItemInfo.FullDescription);
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
        public static bool Update(MenuItemInfo _menuItemInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuItem_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _menuItemInfo.ID);
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", _menuItemInfo.MenuCategoryID);
            dbCmd.Parameters.AddWithValue("@Name", _menuItemInfo.Name);
            dbCmd.Parameters.AddWithValue("@ShortDescription", _menuItemInfo.ShortDescription);
            dbCmd.Parameters.AddWithValue("@Views", _menuItemInfo.Views);
            dbCmd.Parameters.AddWithValue("@Price1", _menuItemInfo.Price1);
            dbCmd.Parameters.AddWithValue("@Price2", _menuItemInfo.Price2);
            dbCmd.Parameters.AddWithValue("@Price3", _menuItemInfo.Price3);
            dbCmd.Parameters.AddWithValue("@Image", _menuItemInfo.Image);
            dbCmd.Parameters.AddWithValue("@CreatedDate", _menuItemInfo.CreatedDate);
            dbCmd.Parameters.AddWithValue("@IsActive", _menuItemInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@FullDescription", _menuItemInfo.FullDescription);
            dbCmd.Parameters.AddWithValue("@Priority", _menuItemInfo.Priority);
            try
            {
                dbConn.Open();
                if (dbCmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            finally
            {
                dbConn.Close();
            }
            return false;
        }
        public static bool UpdateDown(int menuItemID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuItem_Down]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuItemID);
            try
            {
                dbConn.Open();
                if (dbCmd.ExecuteNonQuery() < 0)
                {
                    return false;
                }
            }
            finally
            {
                dbConn.Close();
            }
            return true;
        }
        public static bool UpdateUp(int menuItemID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuItem_Up]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuItemID);
            try
            {
                dbConn.Open();
                if (dbCmd.ExecuteNonQuery() < 0)
                {
                    return false;
                }
            }
            finally
            {
                dbConn.Close();
            }
            return true;
        }
    }
}
