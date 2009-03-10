using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class ReviewInfo
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

		private int _memberID;
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value; }
		}

		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private DateTime _createdDate;
		public DateTime CreatedDate
		{
			get { return _createdDate; }
			set { _createdDate = value; }
		}

		private int _rateFood;
		public int RateFood
		{
			get { return _rateFood; }
			set { _rateFood = value; }
		}
        private int _rateDecor;
        public int RateDecor
        {
            get
            {
                return _rateDecor;
            }
            set
            {
                _rateDecor = value;
            }
        }
		private int _ratePrice;
		public int RatePrice
		{
			get { return _ratePrice; }
			set { _ratePrice = value; }
		}

		private int _rateService;
		public int RateService
		{
			get { return _rateService; }
			set { _rateService = value; }
		}

		private int _isActive;
		public int IsActive
		{
			get { return _isActive; }
			set { _isActive = value; }
		}

		private string _tableOrderService;
		public string TableOrderService
		{
			get { return _tableOrderService; }
			set { _tableOrderService = value; }
		}

		private string _visitAgain;
		public string VisitAgain
		{
			get { return _visitAgain; }
			set { _visitAgain = value; }
		}

		private string _partySize;
		public string PartySize
		{
			get { return _partySize; }
			set { _partySize = value; }
		}

		private string _priceRange;
		public string PriceRange
		{
			get { return _priceRange; }
			set { _priceRange = value; }
		}

		private string _description;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
        private string _age;
        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

	}
}
