using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;
using System.Data;

namespace Restaurant.Library.BLL
{
    public class MenuItemBLL
    {
        public static DataTable GetAll()
        {
            return MenuItemDAL.GetAll();
        }
        public static bool UpdateDown(int menuItemID)
        {
            return MenuItemDAL.UpdateDown(menuItemID);
        }
        public static bool UpdateUp(int menuItemID)
        {
            return MenuItemDAL.UpdateUp(menuItemID);
        }
        public static DataTable GetByMenuCategory(int menuCategoryId, int active)
        {
            return MenuItemDAL.GetByMenuCategory(menuCategoryId, active);
        }
        public static bool UpdatePriority(int menuCategoryId, int priority)
        {
            return MenuItemDAL.UpdatePriority(menuCategoryId, priority);
        }
        public static MenuItemInfo GetInfo(int id)
        {
            return MenuItemDAL.GetInfo(id);
        }
        public static bool Update(MenuItemInfo menuItemInfo)
        {
            return MenuItemDAL.Update(menuItemInfo);
        }
        public static int Insert(MenuItemInfo menuItemInfo)
        {
            return MenuItemDAL.Insert(menuItemInfo);
        }
    }
}
