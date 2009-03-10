using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class BusinessTimeInfo
    {
        private int _iD;
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        }

        private int _restaurantID;
        public int RestaurantID
        {
            get
            {
                return _restaurantID;
            }
            set
            {
                _restaurantID = value;
            }
        }

        private int _dayOfWeek;
        public int DayOfWeek
        {
            get
            {
                return _dayOfWeek;
            }
            set
            {
                _dayOfWeek = value;
            }
        }

        private int _businessStart;
        public int BusinessStart
        {
            get
            {
                return _businessStart;
            }
            set
            {
                _businessStart = value;
            }
        }

        private int _businessEnd;
        public int BusinessEnd
        {
            get
            {
                return _businessEnd;
            }
            set
            {
                _businessEnd = value;
            }
        }

        private int _deliveryStart;
        public int DeliveryStart
        {
            get
            {
                return _deliveryStart;
            }
            set
            {
                _deliveryStart = value;
            }
        }

        private int _deliveryEnd;
        public int DeliveryEnd
        {
            get
            {
                return _deliveryEnd;
            }
            set
            {
                _deliveryEnd = value;
            }
        }

        private string _mealServed;
        public string MealServed
        {
            get
            {
                return _mealServed;
            }
            set
            {
                _mealServed = value;
            }
        }

        private int _status;
        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

    }
}
