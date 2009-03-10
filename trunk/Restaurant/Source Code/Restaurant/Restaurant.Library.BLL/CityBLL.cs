using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;


namespace Restaurant.Library.BLL
{
    public class CityBLL
    {
        public static DataTable GetByStateID(int stateID)
        {
            return CityDAL.GetByStateID(stateID);
        }
        public static DataTable GetAll( ref int id)
        {
            return CityDAL.GetAll(ref id);
        }
        public static DataTable GetByStatePriority()
        {
            return CityDAL.GetByStatePriority();
        }
        public static DataTable GetByStateID(int stateID, bool active)
        {
            return CityDAL.GetByStateID(stateID, active);
        }
        public static bool Delete(int _iD, int StateID)
        {
            return CityDAL.Delete(_iD, StateID);
        }
        public static bool Update(CityInfo cityInfo)
        {
            return CityDAL.Update(cityInfo);
        }
        public static bool Insert(CityInfo cityInfo)
        {
            return CityDAL.Insert(cityInfo);
        }
        public static bool Up(int ID, int StateID)
        {
            return CityDAL.Up(ID, StateID);
        }
        public static bool Down(int ID, int StateID)
        {
            return CityDAL.Down(ID, StateID);
        }
    }
}
