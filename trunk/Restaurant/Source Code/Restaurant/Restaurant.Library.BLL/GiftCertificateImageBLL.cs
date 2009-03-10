using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class GiftCertificateImageBLL
    {
        public static DataTable GetGetAllByGiftTypeID(int giftTypeID)
        {
            return GiftCertificateImageDAL.GetAllByGiftTypeID(giftTypeID);
        }
        public static DataTable GetAll()
        {
            return GiftCertificateImageDAL.GetAll();
        }
        public static int Insert(GiftCertificateImageInfo info)
        {
            return GiftCertificateImageDAL.Insert(info);
        }
        public static void Update(GiftCertificateImageInfo info)
        {
            GiftCertificateImageDAL.Update(info);
        }
        public static void Delete(int id)
        {
            GiftCertificateImageDAL.Delete(id);
        }
        public static GiftCertificateImageInfo GetInfo(int id)
        {
            return GiftCertificateImageDAL.GetInfo(id);
        }
        public static GiftCertificateImageInfo GetInfo_ByGiftID(int giftID)
        {
            return GiftCertificateImageDAL.GetInfo_ByGiftID(giftID);
        }
    }
}
