using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
   public class MenuAddonGroupBLL
    {
        public static DataTable GetAll()
        {
            return MenuAddonGroupDAL.GetAll();
        }
       public static DataTable GetByMenuCategory(int menuCategoryId, int active)
       {
           return MenuAddonGroupDAL.GetByMenuCategory(menuCategoryId, active);
       }
       public static bool UpdatePriority(int menuCategoryId, int priority)
       {
           return MenuAddonGroupDAL.UpdatePriority(menuCategoryId, priority);
       }
       public static bool Insert(MenuAddonGroupInfo _menuAddonGroupInfo)
       {
           return MenuAddonGroupDAL.Insert(_menuAddonGroupInfo);
       }
       public static MenuAddonGroupInfo GetInfo(int menuCategoryID)
       {
           return MenuAddonGroupDAL.GetInfo(menuCategoryID);
       }
       public static bool Update(int ID,string Name)
       {
           return MenuAddonGroupDAL.Update(ID,Name);
       }
       public static bool Delete(int menuAddonGroupID,int MenuCategoryID)
       {
           return MenuAddonGroupDAL.Delete(menuAddonGroupID, MenuCategoryID);
       }
       public static bool Up(int menuAddonGroupID)
       {
           return MenuAddonGroupDAL.Up(menuAddonGroupID);
       }
       public static bool Down(int menuAddonGroupID)
       {
           return MenuAddonGroupDAL.Down(menuAddonGroupID);
       }
       public static bool UpdateIsActive(int menuAddonGroupId, int isActive)
       {
           return MenuAddonGroupDAL.UpdateIsActive(menuAddonGroupId, isActive);
       }
    }
}
