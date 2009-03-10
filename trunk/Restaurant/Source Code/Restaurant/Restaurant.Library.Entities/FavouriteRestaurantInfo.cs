using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class FavouriteRestaurantInfo
    {
        private int _iD;
		public int ID
		{
			get { return _iD; }
			set { _iD = value; }
		}

		private int _memberID;
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value; }
		}

		private int _restaurantID;
		public int RestaurantID
		{
			get { return _restaurantID; }
			set { _restaurantID = value; }
		}

    }
}
