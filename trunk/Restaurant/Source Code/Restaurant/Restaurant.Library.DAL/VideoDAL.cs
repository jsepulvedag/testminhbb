using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using System.Data.SqlClient;
using System.Data;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
   public class VideoDAL
    {
       public static DataTable GetByVideoID(int ID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Video_GetByVideoID", dbConn);
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
        public static bool DeleteVideo(int _iD)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Video_Delete", dbConn);
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
       public static DataTable GetByRestaurantID(int restaurantID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Video_GetByRestaurantID", dbConn);
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
        public static bool InsertVideo( VideoInfo _videoInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Video_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", _videoInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@Title", _videoInfo.Title);
            dbCmd.Parameters.AddWithValue("@Description", _videoInfo.Description);
            dbCmd.Parameters.AddWithValue("@Picture", _videoInfo.Picture);
            dbCmd.Parameters.AddWithValue("@VideoPath", _videoInfo.VideoPath);
            dbCmd.Parameters.AddWithValue("@UploadedDate", _videoInfo.UploadedDate);
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

        public static bool UpdateVideo(VideoInfo _videoInfo)
        {
            bool retVal = false;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Video_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _videoInfo.ID);
            dbCmd.Parameters.AddWithValue("@Title", _videoInfo.Title);
            dbCmd.Parameters.AddWithValue("@Description", _videoInfo.Description);
            dbCmd.Parameters.AddWithValue("@Picture", _videoInfo.Picture);
            dbCmd.Parameters.AddWithValue("@VideoPath", _videoInfo.VideoPath);
            dbCmd.Parameters.AddWithValue("@UploadedDate", _videoInfo.UploadedDate);
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

        public static VideoInfo GetInfo(int _iD)
        {
            VideoInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Video_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _iD);
            SqlDataReader dr = null;

            try
            {
                dbConn.Open();
                dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new VideoInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.Title = Convert.ToString(dr["Title"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.Picture = Convert.ToString(dr["Picture"]);
                    retVal.VideoPath = Convert.ToString(dr["VideoPath"]);
                    retVal.Views = Convert.ToInt32(dr["Views"]);
                 
                    retVal.UploadedDate = Convert.ToDateTime(dr["UploadedDate"]);
                 
                }
            }
            finally
            {
                if (dr != null) dr.Close();
                dbConn.Close();
            }
            return retVal;
        }



        public static DataTable GetTopVideo(int id)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Video_GetTopVideo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", id);
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
    }
}
