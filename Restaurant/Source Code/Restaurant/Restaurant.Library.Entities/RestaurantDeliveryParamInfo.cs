using System;

namespace Restaurant.Library.Entities
{
    public class RestaurantDeliveryParamInfo
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

        private int _minimumPrice;
        public int MinimumPrice
        {
            get { return _minimumPrice; }
            set { _minimumPrice = value; }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        private DateTime _modifiedOn;
        public DateTime ModifiedOn
        {
            get { return _modifiedOn; }
            set { _modifiedOn = value; }
        }
    }
}
