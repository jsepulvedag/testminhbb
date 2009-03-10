using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantCuisineInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private int _restaurantID;
        public int RestaurantID
        {
            get { return _restaurantID; }
            set { _restaurantID = value; }
        }

        private int _cuisineID;
        public int CuisineID
        {
            get { return _cuisineID; }
            set { _cuisineID = value; }
        }

    }
}
