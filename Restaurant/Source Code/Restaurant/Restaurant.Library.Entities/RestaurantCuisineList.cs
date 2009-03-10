using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantCuisineList
    {
        private List<RestaurantCuisineInfo> _listRestaurantCuisine;
        public List<RestaurantCuisineInfo> ListRestaurantCuisine
        {
            get { return _listRestaurantCuisine; }
            set { _listRestaurantCuisine = value; }
        }
        public RestaurantCuisineList()
        {
            _listRestaurantCuisine = new List<RestaurantCuisineInfo>();
        }
        public void Add(RestaurantCuisineInfo item)
        {
            _listRestaurantCuisine.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantCuisineInfo item in _listRestaurantCuisine)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantCuisineInfo item)
        {
            _listRestaurantCuisine.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantCuisineInfo obj in _listRestaurantCuisine)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringCuisineID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantCuisineInfo obj in _listRestaurantCuisine)
                {
                    retVal += obj.CuisineID + ";";
                }
                return retVal;
            }
        }
    }
}
