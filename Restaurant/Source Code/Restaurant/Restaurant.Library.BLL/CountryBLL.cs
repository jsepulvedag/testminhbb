using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;
using System.Data;

namespace Restaurant.Library.BLL
{
    public class CountryBLL
    {
        public static DataTable GetByPriority()
        {
            return CountryDAL.GetByPriority();
        }
        public static DataTable GetAll()
        {
            return CountryDAL.GetAll();
        }
        public static DataTable GetAll(bool active)
        {
            return CountryDAL.GetAll(active);
        }
        public static bool Delete(int _iD)
        {
            return CountryDAL.Delete(_iD);
        }
        public static bool Update(CountryInfo countryInfo)
        {
            return CountryDAL.Update(countryInfo);
        }
        public static bool Insert(CountryInfo countryInfo)
        {
            return CountryDAL.Insert(countryInfo);
        }
        public static bool Up(int ID)
        {
            return CountryDAL.Up(ID);
        }
        public static bool Down(int ID)
        {
            return CountryDAL.Down(ID);
        }
    }
}
