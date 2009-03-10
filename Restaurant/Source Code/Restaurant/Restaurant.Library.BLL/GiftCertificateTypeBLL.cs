using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class GiftCertificateTypeBLL
    {
        public static DataTable GetAll(bool isActive)
        {
            return GiftCertificateTypeDAL.GetAll(isActive);
        }
        public static int Insert(GiftCertificateTypeInfo info)
        {
            return GiftCertificateTypeDAL.Insert(info);
        }
        public static void Update(GiftCertificateTypeInfo info)
        {
            GiftCertificateTypeDAL.Update(info);
        }
        public static void Delete(int id)
        {
            GiftCertificateTypeDAL.Delete(id);
        }
    }
}
