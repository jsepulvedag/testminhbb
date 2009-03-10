using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class AttireBLL
    {
        public static DataTable GetByRestaurantAttire(int restaurantID)
        {
            try
            {
                return AttireDAL.GetByRestaurantAttire(restaurantID);
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
                return AttireDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Delete(int _iD)
        {
            return AttireDAL.Delete(_iD);
        }
        public static bool Update(AttireInfo attireInfo)
        {
            return AttireDAL.Update(attireInfo);
        }
        public static bool Insert(AttireInfo attireInfo)
        {
            return AttireDAL.Insert(attireInfo);
        }
    }
}
