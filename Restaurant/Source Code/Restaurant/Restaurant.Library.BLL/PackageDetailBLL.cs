using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class PackageDetailBLL
    {
        public static DataTable GetByPackageID(int packageID)
        {
            return PackageDetailDAL.GetByPackageID(packageID);            
        }
        public static PackageDetailInfo GetInfo(int id)
        {
            return PackageDetailDAL.GetInfo(id);     
        }
        public static DataTable GetAll(bool active)
        {
            return PackageDetailDAL.GetAll(active);
        }
        public static DataTable GetFree(bool active)
        {
            return PackageDAL.GetFree(active);
        }
        public static int Insert(PackageDetailInfo packageDetailInfo)
        {
            return PackageDetailDAL.Insert(packageDetailInfo);
        }
        public static void Update(PackageDetailInfo packageDetailInfo)
        {
            PackageDetailDAL.Update(packageDetailInfo);
        }
        public static void Delete(int id)
        {
            PackageDetailDAL.Delete(id);
        }
    }
}
