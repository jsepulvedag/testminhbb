using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;
using System.Data;

namespace Restaurant.Library.BLL
{
    public class MenuAddonBLL
    {
        public static DataTable GetAll()
        {
            return MenuAddonDAL.GetAll();
        }
        public static DataTable GetByMenuAddonGroup(int menuAddonGroupId, int active)
        {
            return MenuAddonDAL.GetByMenuAddonGroup(menuAddonGroupId, active);
        }
        public static bool UpdatePriority(int menuAddonId, int priority)
        {
            return MenuAddonDAL.UpdatePriority(menuAddonId, priority);
        }
        public static MenuAddonInfo GetInfo(int menuAddonGroupID)
        {
            return MenuAddonDAL.GetInfo(menuAddonGroupID);
        }
        public static bool Insert(MenuAddonInfo _menuAddonInfo)
        {
            return MenuAddonDAL.Insert(_menuAddonInfo);
        }
        public static bool Update(int ID,string Name)
        {
            return MenuAddonDAL.Update(ID,Name);
        }
        public static bool Delete(int menuAddonID, int menuAddonGroupID)
        {
            return MenuAddonDAL.Delete(menuAddonID, menuAddonGroupID);
        }
        public static bool Up(int menuAddonID)
        {
            return MenuAddonDAL.Up(menuAddonID);
        }
        public static bool Down(int menuAddonID)
        {
            return MenuAddonDAL.Down(menuAddonID);
        }
        public static bool UpdateIsActive(int menuAddonId, int isActive)
        {
            return MenuAddonDAL.UpdateIsActive(menuAddonId, isActive);
        }
    }
}
