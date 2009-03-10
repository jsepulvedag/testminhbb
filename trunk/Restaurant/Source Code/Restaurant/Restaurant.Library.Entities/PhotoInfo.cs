using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
   public class PhotoInfo
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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
            get {return _Name; }
            set { _Name = value;  }
        }
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
    }
}
