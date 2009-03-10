using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
   public class MenuCategoryDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuCategory_GetAll", dbConn);
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
        public static DataTable GetByRestaurant(int restaurantID, int active)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("MenuCategory_GetByRestaurantID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
       public static DataTable GetByCategory(int categoryID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("MenuCategory_GetByCategoryID", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", categoryID);
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
       public static bool UpdatePriority(int menuCategoryID, int priority)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuCategory_UpdatePriority]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuCategoryID);
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
        public static MenuCategoryInfo GetInfo(int menuCategoryID)
        {
            MenuCategoryInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("[MenuCategory_GetInfo]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", menuCategoryID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MenuCategoryInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.Name = Convert.ToString(dr["Name"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.Image = Convert.ToString(dr["Image"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.PriceHeading1 = Convert.ToString(dr["PriceHeading1"]);
                    retVal.PriceHeading2 = Convert.ToString(dr["PriceHeading2"]);
                    retVal.PriceHeading3 = Convert.ToString(dr["PriceHeading3"]);
                    retVal.Priority = Convert.ToInt32(dr["priority"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
       public static bool Delete(int _iD)
       {
           bool retVal = false;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("MenuCategory_Delete", dbConn);
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
       public static bool Update(MenuCategoryInfo _menuCategoryInfo)
       {
           bool retVal = false;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("MenuCategory_Update", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", _menuCategoryInfo.ID);
           dbCmd.Parameters.AddWithValue("@Name", _menuCategoryInfo.Name);
           dbCmd.Parameters.AddWithValue("@Description", _menuCategoryInfo.Description);
           dbCmd.Parameters.AddWithValue("@Image", _menuCategoryInfo.Image);
           dbCmd.Parameters.AddWithValue("@PriceHeading1", _menuCategoryInfo.PriceHeading1);
           dbCmd.Parameters.AddWithValue("@PriceHeading2", _menuCategoryInfo.PriceHeading2);
           dbCmd.Parameters.AddWithValue("@PriceHeading3", _menuCategoryInfo.PriceHeading3);
         
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
       public static bool Insert(MenuCategoryInfo _menuCategoryInfo)
       {
           bool retVal = false;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("MenuCategory_Insert", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@RestaurantID", _menuCategoryInfo.RestaurantID);
           dbCmd.Parameters.AddWithValue("@Name", _menuCategoryInfo.Name);
           dbCmd.Parameters.AddWithValue("@Description", _menuCategoryInfo.Description);
           dbCmd.Parameters.AddWithValue("@Image", _menuCategoryInfo.Image);
           dbCmd.Parameters.AddWithValue("@IsActive", _menuCategoryInfo.IsActive);
           dbCmd.Parameters.AddWithValue("@PriceHeading1", _menuCategoryInfo.PriceHeading1);
           dbCmd.Parameters.AddWithValue("@PriceHeading2", _menuCategoryInfo.PriceHeading2);
           dbCmd.Parameters.AddWithValue("@PriceHeading3", _menuCategoryInfo.PriceHeading3);
           dbCmd.Parameters.AddWithValue("@Priority", _menuCategoryInfo.Priority);
           dbCmd.Parameters.AddWithValue("@CreatedDate", _menuCategoryInfo.CreateDate);
         
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




       public static bool Up(int menuCategoryID)
       {
           bool retVal = false;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Up", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", menuCategoryID);
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

       public static bool Down(int menuCategoryID)
       {
           bool retVal = false;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Down", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", menuCategoryID);
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
   }
}
