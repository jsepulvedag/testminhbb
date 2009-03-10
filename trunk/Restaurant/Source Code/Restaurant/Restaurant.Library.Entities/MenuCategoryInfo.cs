using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
   public class MenuCategoryInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private int _RestaurantID;
        public int RestaurantID
        {
            get { return _RestaurantID; }
            set { _RestaurantID = value; }
        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        private DateTime _CreateDate;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        private Boolean _IsActive;
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        private string _PriceHeading1;
        public string PriceHeading1
        {
            get { return _PriceHeading1; }
            set { _PriceHeading1 = value; }
        }
        private string _PriceHeading2;
        public string PriceHeading2
        {
            get { return _PriceHeading2; }
            set { _PriceHeading2 = value; }
        }
        private string _PriceHeading3;
        public string PriceHeading3
        {
            get { return _PriceHeading3; }
            set { _PriceHeading3 = value; }
        }
        private int _Priority;
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

    }
}
