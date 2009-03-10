using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantNeighbourhoodList
    {
        private List<RestaurantNeighbourhoodInfo> _listRestaurantNeighbourhood;
        public List<RestaurantNeighbourhoodInfo> ListRestaurantNeighbourhood
        {
            get { return _listRestaurantNeighbourhood; }
            set { _listRestaurantNeighbourhood = value; }
        }
        public RestaurantNeighbourhoodList()
        {
            _listRestaurantNeighbourhood = new List<RestaurantNeighbourhoodInfo>();
        }
        public void Add(RestaurantNeighbourhoodInfo item)
        {
            _listRestaurantNeighbourhood.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantNeighbourhoodInfo item in _listRestaurantNeighbourhood)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantNeighbourhoodInfo item)
        {
            _listRestaurantNeighbourhood.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantNeighbourhoodInfo obj in _listRestaurantNeighbourhood)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringNeighbourhoodID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantNeighbourhoodInfo obj in _listRestaurantNeighbourhood)
                {
                    retVal += obj.NeighbourhoodID + ";";
                }
                return retVal;
            }
        }    
    }
}
