using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantAttireList
    {
        private List<RestaurantAttireInfo> _listRestaurantAttire;
        public List<RestaurantAttireInfo> ListRestaurantAttire
        {
            get { return _listRestaurantAttire; }
            set { _listRestaurantAttire = value; }
        }
        public RestaurantAttireList()
        {
            _listRestaurantAttire = new List<RestaurantAttireInfo>();
        }
        public void Add(RestaurantAttireInfo item)
        {
            _listRestaurantAttire.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantAttireInfo item in _listRestaurantAttire)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantAttireInfo item)
        {
            _listRestaurantAttire.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantAttireInfo obj in _listRestaurantAttire)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringAttireID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantAttireInfo obj in _listRestaurantAttire)
                {
                    retVal += obj.AttireID + ";";
                }
                return retVal;
            }
        }
    }
}
