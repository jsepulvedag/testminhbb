using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
  public  class OrderItemInfo
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
        private int _orderID;
        public int OrderID
        {
            get
            {
                return _orderID;
            }
            set
            {
                _orderID = value;
            }
        }
        private int _menuItemID;
        public int MenuItemID
        {
            get
            {
                return _menuItemID;
            }
            set
            {
                _menuItemID = value;
            }
        }
        private string _size;
        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

    }
}
