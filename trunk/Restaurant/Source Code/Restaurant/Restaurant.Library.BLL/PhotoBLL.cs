using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class PhotoBLL
    {
        public static DataTable GetAll()
        {
                return PhotoDAL.GetAll();
        }
        public static PhotoInfo GetInfo(int photoID)
        {
            return PhotoDAL.GetInfo(photoID);
        }
        public static DataTable GetByPhotoID(int ID)
        {
            try
            {
                return PhotoDAL.GetByPhotoID(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            try
            {
                return PhotoDAL.GetByRestaurantID(restaurantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdatePhoto(PhotoInfo _photoInfo)
        {
            try
            {
                return PhotoDAL.UpdatePhoto(_photoInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeletePhoto(int photoID)
        {
            try
            {
                 PhotoDAL.DeletePhoto(photoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int InsertPhoto(PhotoInfo photoInfo)
        {
            try
            {
                return PhotoDAL.InsertPhoto(photoInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}