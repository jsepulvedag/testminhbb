using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantAtmosphereList
    {
        private List<RestaurantAtmosphereInfo> _listRestaurantAtmosphere;
        public List<RestaurantAtmosphereInfo> ListRestaurantAtmosphere
        {
            get { return _listRestaurantAtmosphere; }
            set { _listRestaurantAtmosphere = value; }
        }
        public RestaurantAtmosphereList()
        {
            _listRestaurantAtmosphere = new List<RestaurantAtmosphereInfo>();
        }
        public void Add(RestaurantAtmosphereInfo item)
        {
            _listRestaurantAtmosphere.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantAtmosphereInfo item in _listRestaurantAtmosphere)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantAtmosphereInfo item)
        {
            _listRestaurantAtmosphere.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantAtmosphereInfo obj in _listRestaurantAtmosphere)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringAtmosphereID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantAtmosphereInfo obj in _listRestaurantAtmosphere)
                {
                    retVal += obj.AtmosphereID + ";";
                }
                return retVal;
            }
        }
    }
}
