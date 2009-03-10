using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class PackageBLL
    {
        public static DataTable GetAll(bool isActive)
        {
            return PackageDAL.GetAll(isActive);           
        }
        public static DataTable GetFree(bool isActive)
        {
            return PackageDAL.GetFree(isActive);
        }
        public static DataTable GetNotFree(bool isActive)
        {
            return PackageDAL.GetNotFree(isActive);
        }
        public static int Insert(PackageInfo package)
        {
            return PackageDAL.Insert(package);
        }
        public static void Update(PackageInfo package)
        {
            PackageDAL.Update(package);
        }
        public static void Delete(int id)
        {
            PackageDAL.Delete(id);
        }
        public static PackageInfo GetInfo(int id)
        {
            return PackageDAL.GetInfo(id);
        }
    }
}
