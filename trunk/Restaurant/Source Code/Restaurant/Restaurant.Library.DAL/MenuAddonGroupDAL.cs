using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using System.Data;
using Restaurant.Library.Entities;



namespace Restaurant.Library.DAL
{
   public class MenuAddonGroupDAL
    {
        public static System.Data.DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddonGroup_GetAll", dbConn);
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
            SqlCommand dbCmd = new SqlCommand("MenuAddonGroup_GetByMenuCategory", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", menuCategoryId);
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
            SqlCommand dbCmd = new SqlCommand("[MenuAddonGroup_UpdatePriority]", dbConn);
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
        public static bool Insert(MenuAddonGroupInfo _menuAddonGroupInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddonGroup_Insert]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", _menuAddonGroupInfo.MenuCategoryID);
            dbCmd.Parameters.AddWithValue("@Name", _menuAddonGroupInfo.Name);
            dbCmd.Parameters.AddWithValue("@IsActive", _menuAddonGroupInfo.IsActive);
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
        public static MenuAddonGroupInfo GetInfo(int menuCategoryID)
        {
            MenuAddonGroupInfo reval = new MenuAddonGroupInfo();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddonGroup_GetInfo]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuCategoryID);
            try
            {
                dbConn.Open();

                SqlDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    reval.Id = reader.GetInt32(0);
                    reval.MenuCategoryID = reader.GetInt32(1);
                    reval.Name = reader.GetString(2);
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

        public static bool Update(int ID,string Name)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddonGroup_Update]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", ID);
            dbCmd.Parameters.AddWithValue("@Name",Name);
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
        public static bool Delete(int menuAddonGroupID,int menuCategoryID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuAddonGroup_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Id", menuAddonGroupID);
            dbCmd.Parameters.AddWithValue("@MenuCategoryID", menuCategoryID);
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

        public static bool Up(int menuAddonGroupID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("AddonGroup_Up", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonGroupID);
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

        public static bool Down(int menuAddonGroupID)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("AddonGroup_Down", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonGroupID);
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

        public static bool UpdateIsActive(int menuAddonGroupId, int isActive)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuAddonGroup_UpdateIsActive", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuAddonGroupId);
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
