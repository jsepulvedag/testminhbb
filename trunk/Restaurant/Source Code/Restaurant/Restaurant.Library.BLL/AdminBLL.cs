using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class AdminBLL
    {
        public static int Insert(AdminInfo adminInfo)
        {
            try
            {
                return AdminDAL.Insert(adminInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AdminInfo GetInfo(int id)
        {
            return AdminDAL.GetInfo(id);
        }
        public static bool Update(AdminInfo adminInfo)
        {
            try
            {
                return AdminDAL.Update(adminInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Delete(int iD)
        {
            try
            {
                return AdminDAL.Delete(iD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AdminInfo GetInfo(string userName, string password)
        {
            try
            {
                return AdminDAL.GetInfo(userName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAll()
        {
            try
            {
                return AdminDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
