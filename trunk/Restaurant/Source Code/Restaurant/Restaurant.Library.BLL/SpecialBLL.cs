using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class SpecialBLL
    {
        public static DataTable GetByRestaurantSpecial(int restaurantID)
        {
            try
            {
                return SpecialDAL.GetByRestaurantSpecial(restaurantID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetByAdmin()
        {
            return SpecialDAL.GetByAdmin();
        }
        public static DataTable GetAll()
        {
            try
            {
                return SpecialDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Delete(int _iD)
        {
            return SpecialDAL.Delete(_iD);
        }
        public static bool Update(SpecialInfo SpecialInfo)
        {
            return SpecialDAL.Update(SpecialInfo);
        }
        public static bool Insert(SpecialInfo SpecialInfo)
        {
            return SpecialDAL.Insert(SpecialInfo);
        }
    }
}
