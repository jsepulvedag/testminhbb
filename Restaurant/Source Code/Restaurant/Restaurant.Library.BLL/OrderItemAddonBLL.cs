using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
   public class OrderItemAddonBLL
    {
       public static bool Delete(int id)
       {
           return OrderItemAddOnDAL.Delete(id);
       }
       public static bool Insert(OrderItemAddonInfo _orderItemAddonsInfo)
       {
           return OrderItemAddOnDAL.Insert(_orderItemAddonsInfo);
       }
       public static  OrderItemAddonInfo GetInfo(int _iD)
       {
           return OrderItemAddOnDAL.GetInfo(_iD);
       }
    }
}
