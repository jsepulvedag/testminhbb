using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantSpecialList
    {
        private List<RestaurantSpecialInfo> _listRestaurantSpecial;
        public List<RestaurantSpecialInfo> ListRestaurantSpecial
        {
            get { return _listRestaurantSpecial; }
            set { _listRestaurantSpecial = value; }
        }
        public RestaurantSpecialList()
        {
            _listRestaurantSpecial = new List<RestaurantSpecialInfo>();
        }
        public void Add(RestaurantSpecialInfo item)
        {
            _listRestaurantSpecial.Add(item);
        }
        public void AddRestaurantID(int restaurantID)
        {
            foreach (RestaurantSpecialInfo item in _listRestaurantSpecial)
            {
                item.RestaurantID = restaurantID;
            }
        }
        public void Remove(RestaurantSpecialInfo item)
        {
            _listRestaurantSpecial.Remove(item);
        }
        public string StringRestaurantID
        {
            get 
            {
                string retVal = "";    
                foreach (RestaurantSpecialInfo obj in _listRestaurantSpecial)
                {
                    retVal += obj.RestaurantID + ";";
                }
                return retVal;
            }
        }
        public string StringSpecialID
        {
            get 
            {
                string retVal = "";
                foreach (RestaurantSpecialInfo obj in _listRestaurantSpecial)
                {
                    retVal += obj.SpecialID + ";";
                }
                return retVal;
            }
        }
    }
}
