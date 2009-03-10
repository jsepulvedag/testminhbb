using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class RestaurantNeighbourhoodInfo
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

        private int _neighbourhoodID;
        public int NeighbourhoodID
        {
            get { return _neighbourhoodID; }
            set { _neighbourhoodID = value; }
        }
    }
}
