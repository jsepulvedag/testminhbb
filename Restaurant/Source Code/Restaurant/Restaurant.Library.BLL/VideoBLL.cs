using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;
using System.Data;

namespace Restaurant.Library.BLL
{
   public class VideoBLL
    {
       public static bool UpdateVideo(VideoInfo _videoInfo)
        {
            return VideoDAL.UpdateVideo(_videoInfo);
        }
       public static bool DeleteVideo(int id)
        {

            return VideoDAL.DeleteVideo(id);
          
        }
       public static bool InsertVideo(VideoInfo _videoInfo)
        {
            return VideoDAL.InsertVideo(_videoInfo);
        }
       public static DataTable GetByRestaurantID(int id)
       {
           return VideoDAL.GetByRestaurantID(id);
       }
       public static DataTable GetTopVideo(int id)
       {
           return VideoDAL.GetTopVideo(id);
       }

       public static DataTable GetByVideoID(int ID)
       {
           return VideoDAL.GetByVideoID(ID);
       }
    }
}
