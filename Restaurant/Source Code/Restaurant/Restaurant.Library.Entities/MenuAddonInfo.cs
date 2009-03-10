using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
  public  class MenuAddonInfo
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
        private int _menuAddonGroupID;
        public int MenuAddonGroupID
        {
            get
            {
                return _menuAddonGroupID;
            }
            set
            {
                _menuAddonGroupID = value;
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
        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
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
        private int _isActive;
        public int IsActive
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

    }
}
