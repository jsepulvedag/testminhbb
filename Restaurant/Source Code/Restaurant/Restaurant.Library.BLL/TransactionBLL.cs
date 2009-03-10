using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;
using System.Data;

namespace Restaurant.Library.BLL
{
    public class TransactionBLL
    {
        public static int Insert(TransactionInfo obj)
        {
            return TransactionDAL.Insert(obj);
        }
        public static void Update_Status(int transactionID, Int16 status)
        {
            TransactionDAL.Update_Status(transactionID,status);
        }
        public static void Update(TransactionInfo obj)
        {
            TransactionDAL.Update(obj);
        }
        public static TransactionInfo GetInfo_ByRestaurantIDAndTypePackage(int restaurantID)
        {
            return TransactionDAL.GetInfo_ByRestaurantIDAndTypePackage(restaurantID);
        }
        public static TransactionInfo GetInfo_ByGiftID(int giftID)
        {
            return TransactionDAL.GetInfo_ByGiftID(giftID);
        }
        public static DataTable SearchByMemberID(int memberID, int type, int status, DateTime fromDate, DateTime toDate)
        {
            return TransactionDAL.SearchByMemberID(memberID, type, status, fromDate, toDate);
        }
    }
}
