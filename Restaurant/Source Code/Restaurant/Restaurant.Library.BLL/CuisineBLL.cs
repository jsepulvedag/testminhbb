using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class CuisineBLL
    {
        public static DataTable GetAllForHome()
        {
            DataTable dt = GetAll();
            DataRow dr = dt.NewRow();
            dr["ID"] = "0";
            dr["Name"] = "All Cuisine";
            dr["Description"] = "";
            dr["IsActive"] = "True";
            dt.Rows.InsertAt(dr, 0);

            dt.Dispose();
            return dt;
        }
        public static DataTable GetAll()
        {
           return CuisineDAL.GetAll();
        }
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            return CuisineDAL.GetByRestaurantID(restaurantID);

        }
        public static bool Delete(int _iD)
        {
            return CuisineDAL.Delete(_iD);
        }
        public static bool Update(CuisineInfo cuisineInfo)
        {
            return CuisineDAL.Update(cuisineInfo);
        }
        public static bool Insert(CuisineInfo cuisineInfo)
        {
            return CuisineDAL.Insert(cuisineInfo);
        }
        public static CuisineInfo GetInfo(int _iD)
        {
            return CuisineDAL.GetInfo(_iD);
        }
    }
}
