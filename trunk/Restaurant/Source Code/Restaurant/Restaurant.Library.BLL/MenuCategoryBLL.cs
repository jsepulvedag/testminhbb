using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class MenuCategoryBLL
    {
        public static DataTable GetAll()
        {
            return MenuCategoryDAL.GetAll();
        }
        public static DataTable GetByCategory(int categoryID)
        {
            return MenuCategoryDAL.GetByCategory(categoryID);
        }
        public static DataTable GetByRestaurant(int restaurantID, int active)
        {
            return MenuCategoryDAL.GetByRestaurant(restaurantID, active);
        }
        public static bool UpdatePriority(int menuCategoryID, int priority)
        {
            return MenuCategoryDAL.UpdatePriority(menuCategoryID, priority);
        }
        public static MenuCategoryInfo GetInfo(int menuCategoryID)
        {
            return MenuCategoryDAL.GetInfo(menuCategoryID);
        }
        public static bool Delete(int _iD)
        {
            return MenuCategoryDAL.Delete(_iD);
        }
        public static bool Update(MenuCategoryInfo _menuCategoryInfo)
        {
            return MenuCategoryDAL.Update(_menuCategoryInfo);
        }
        public static bool Insert(MenuCategoryInfo _menuCategoryInfo)
        {
            return MenuCategoryDAL.Insert(_menuCategoryInfo);
        }
        public static bool Up(int menuCategoryID)
        {
            return MenuCategoryDAL.Up(menuCategoryID);
        }
        public static bool Down(int menuCategoryID)
        {
            return MenuCategoryDAL.Down(menuCategoryID);
        }
    }
}
