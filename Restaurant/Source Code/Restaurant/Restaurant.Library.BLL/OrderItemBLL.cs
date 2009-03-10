using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
   public class OrderItemBLL
    {
       public static bool Delete(int id)
       {
           return OrderItemDAL.Delete(id);
       }
       public static bool Insert(OrderItemInfo _orderItemsInfo)
       {
           return OrderItemDAL.Insert(_orderItemsInfo);
       }
       public static OrderItemInfo GetInfo(int _iD)
       {
           return OrderItemDAL.GetInfo(_iD);
       }
    }
}
