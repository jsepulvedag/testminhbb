using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
    public class MenuItemInfo
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

        private int _menuCategoryID;
        public int MenuCategoryID
        {
            get
            {
                return _menuCategoryID;
            }
            set
            {
                _menuCategoryID = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string _shortDescription;
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }
            set
            {
                _shortDescription = value;
            }
        }

        private int _views;
        public int Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
            }
        }

        private double _price1;
        public double Price1
        {
            get
            {
                return _price1;
            }
            set
            {
                _price1 = value;
            }
        }

        private double _price2;
        public double Price2
        {
            get
            {
                return _price2;
            }
            set
            {
                _price2 = value;
            }
        }

        private double _price3;
        public double Price3
        {
            get
            {
                return _price3;
            }
            set
            {
                _price3 = value;
            }
        }

        private string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        private string _fullDescription;
        public string FullDescription
        {
            get
            {
                return _fullDescription;
            }
            set
            {
                _fullDescription = value;
            }
        }

        private int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

    }
}
