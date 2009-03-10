using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantGoodForList
    {
        private List<RestaurantGoodForInfo> _listRestaurantGoodFor;
        public List<RestaurantGoodForInfo> ListRestaurantGoodFor
        {
            get { return _listRestaurantGoodFor; }
            set { _listRestaurantGoodFor = value; }
        }
        public RestaurantGoodForList()
        {
            _listRestaurantGoodFor = new List<RestaurantGoodForInfo>();
        }
        public void Add(RestaurantGoodForInfo item)
        {
            _listRestaurantGoodFor.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantGoodForInfo item in _listRestaurantGoodFor)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantGoodForInfo item)
        {
            _listRestaurantGoodFor.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantGoodForInfo obj in _listRestaurantGoodFor)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringGoodForID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantGoodForInfo obj in _listRestaurantGoodFor)
                {
                    retVal += obj.GoodForID + ";";
                }
                return retVal;
            }
        }
    }
}
