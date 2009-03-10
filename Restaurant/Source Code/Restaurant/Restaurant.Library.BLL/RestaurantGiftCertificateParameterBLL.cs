using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class RestaurantGiftCertificateParameterBLL
    {
        public static int Insert(RestaurantGiftCertificateParameterInfo restaurantGiftCertificateParameterInfo)
        {
            return RestaurantGiftCertificateParameterDAL.Insert(restaurantGiftCertificateParameterInfo);
        }
        public static void Update(RestaurantGiftCertificateParameterInfo restaurantGiftCertificateParameterInfo)
        {
            RestaurantGiftCertificateParameterDAL.Update(restaurantGiftCertificateParameterInfo);
        }
        public static void Delete(int id)
        {
            RestaurantGiftCertificateParameterDAL.Delete(id);
        }
        public static RestaurantGiftCertificateParameterInfo GetInfo(int id)
        {
            return RestaurantGiftCertificateParameterDAL.GetInfo(id);
        }
        public static RestaurantGiftCertificateParameterInfo GetInfo_ByRestaurantID(int restaurantID)
        {
            return RestaurantGiftCertificateParameterDAL.GetInfo_ByRestaurantID(restaurantID);
        }
        public static DataTable GetAllByRestaurantID(int restaurantID)
        {
            return RestaurantGiftCertificateParameterDAL.GetAllByRestaurantID(restaurantID);
        }
    }
}
