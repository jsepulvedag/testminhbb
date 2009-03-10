using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;



namespace Restaurant.Library.DAL
{
   public class PhotoDAL
    {
       public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Photo_GetAll", dbConn);
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
       public static DataTable GetByPhotoID(int ID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_GetPhotoByID", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", ID);
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
       public static DataTable GetByRestaurantID(int restaurantID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_GetByRestaurantID", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
       public static bool UpdatePhoto(PhotoInfo photoInfo)
       {
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_Update", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@PhotoID", photoInfo.ID);
           dbCmd.Parameters.AddWithValue("@RestaurantID", photoInfo.RestaurantID);
           dbCmd.Parameters.AddWithValue("@PhotoName", photoInfo.Name);
           dbCmd.Parameters.AddWithValue("@Image", photoInfo.Image);

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
       public static void DeletePhoto(int photoID)
       {
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_Delete", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@PhotoID", photoID);
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
       public static int InsertPhoto(PhotoInfo photoInfo)
       {
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_Insert", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@PhotoName", photoInfo.Name);
           dbCmd.Parameters.AddWithValue("@Image", photoInfo.Image);
           dbCmd.Parameters.AddWithValue("@RestaurantID", photoInfo.RestaurantID);
           dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
           try
           {
               int @PhotoID = (int)dbCmd.Parameters["@RETURN_VALUE"].Value;

               dbConn.Open();
               dbCmd.ExecuteNonQuery();
               return @PhotoID;
           }
           finally
           {
               dbConn.Close();
           }
       }
       public static PhotoInfo GetInfo(int photoID)
       {
           PhotoInfo reval = new PhotoInfo();
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Photo_GetPhotoByID",dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID",photoID);
           try 
           {
               dbConn.Open();
              
                SqlDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    reval.ID = reader.GetInt32(0);
                    reval.RestaurantID=reader.GetInt32(1);
                    reval.Image=reader.GetString(3);
                    reval.Name=reader.GetString(2);
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
       }
   
}
