using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library.Entities
{
   public class OrderItemAddonInfo
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
        private int _orderItemID;
        public int OrderItemID
        {
            get
            {
                return _orderItemID;
            }
            set
            {
                _orderItemID = value;
            }
        }
        private int _menuItemAddon;
        public int MenuItemAddon
        {
            get
            {
                return _menuItemAddon;
            }
            set
            {
                _menuItemAddon = value;
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
