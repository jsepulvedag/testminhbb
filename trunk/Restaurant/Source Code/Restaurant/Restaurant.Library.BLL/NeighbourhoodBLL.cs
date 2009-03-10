using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class NeighbourhoodBLL
    {
        public static DataTable GetAll()
        {
                return NeighbourhoodDAL.GetAll();            
        }
        public static DataTable GetByCitySearch(int cityID)
        {
            return NeighbourhoodDAL.GetByCitySearch(cityID);
        }
        public static DataTable GetByRestaurantID(int restaurantID)
        {
            return NeighbourhoodDAL.GetByRestaurantID(restaurantID);
        }
        public static DataTable GetByCityID(int cityID)
        {
            return NeighbourhoodDAL.GetByCityID(cityID);
        }
        public static DataTable GetByCityID(int cityID, bool active)
        {
            return NeighbourhoodDAL.GetByCityID(cityID,active);
        }
        public static bool Delete(int _iD)
        {
            return NeighbourhoodDAL.Delete(_iD);
        }
        public static bool Insert(NeighbourhoodInfo _neighbourhoodInfo)
        {
            return NeighbourhoodDAL.Insert(_neighbourhoodInfo);
        }
        public static bool Update(NeighbourhoodInfo _neighbourhoodInfo) 
        {
            return NeighbourhoodDAL.Update(_neighbourhoodInfo);
        
        }
        public static NeighbourhoodInfo GetInfo(int _iD)
        {
            return NeighbourhoodDAL.GetInfo(_iD);
        }
    }
}
