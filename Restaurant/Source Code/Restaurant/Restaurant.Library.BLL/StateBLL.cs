using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class StateBLL
    {
        public static DataTable GetByCountryID(int countryID)
        {
            return StateDAL.GetByCountryID(countryID);   
        }
        public static DataTable GetByCountryID(int countryID, bool active)
        {
            return StateDAL.GetByCountryID(countryID, active);
        }
        public static DataTable GetByPriority()
        {
            return StateDAL.GetByPriority();
        }
        public static bool Delete(int _iD,int countryID)
        {
            return StateDAL.Delete(_iD, countryID);
        }
        public static bool Update(StateInfo stateinfo)
        {
            return StateDAL.Update(stateinfo);
        }
        public static bool Insert(StateInfo stateinfo)
        {
            return StateDAL.Insert(stateinfo);
        }
        public static bool Up(int ID, int countryID)
        {
            return StateDAL.Up(ID, countryID);
        }
        public static bool Down(int ID, int countryID)
        {
            return StateDAL.Down(ID, countryID);
        }
    }
}
