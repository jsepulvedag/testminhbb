using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
  public  class MenuAddonDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddon_GetAll", dbConn);
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
      public static DataTable GetByMenuAddonGroup(int menuAddonGroupId, int active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddon_GetByMenuAddonGroup", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuAddonGroupID", menuAddonGroupId);
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
      public static bool UpdatePriority(int menuAddonId, int priority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddon_UpdatePriority]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuAddonID", menuAddonId);
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
      public static MenuAddonInfo GetInfo(int menuAddonGroupID)
        {
            MenuAddonInfo reval = new MenuAddonInfo();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddon_GetInfo]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonGroupID);
            try
            {
                dbConn.Open();

                SqlDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    reval.ID = reader.GetInt32(0);
                    reval.MenuAddonGroupID = reader.GetInt32(1);
                    reval.Name = reader.GetString(2);
                    reval.Price = reader.GetString(3);
                    reval.Priority = reader.GetInt32(4);
                    reval.IsActive = reader.GetInt32(5);
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            finally
            {
                dbConn.Close();
            }
            return reval;        
        }

        public static bool Insert(MenuAddonInfo _menuAddonInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddon_Insert]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuAddonGroupID", _menuAddonInfo.MenuAddonGroupID);
            dbCmd.Parameters.AddWithValue("@Name", _menuAddonInfo.Name);
            dbCmd.Parameters.AddWithValue("@IsActive", _menuAddonInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@Price", _menuAddonInfo.Price);
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

        public static bool Update(int ID, string Name)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddon_Update]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.Parameters.AddWithValue("@Name", Name);
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

        public static bool Delete(int menuAddonID, int menuAddonGroupID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddon_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonID);
            dbCmd.Parameters.AddWithValue("@MenuAddonGroupID", menuAddonGroupID);
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

        public static bool Up(int menuAddonID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddon_Up", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonID);
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

        public static bool Down(int menuAddonID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddon_Down", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonID);
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

        public static bool UpdateIsActive(int menuAddonId, int isActive)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddon_UpdateIsActive", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuAddonID", menuAddonId);
            dbCmd.Parameters.AddWithValue("@IsActive", isActive);
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
    }
}
