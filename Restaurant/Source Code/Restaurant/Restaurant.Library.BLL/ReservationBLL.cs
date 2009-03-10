using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class ReservationBLL
    {
        public static int Insert(ReservationInfo reservationInfo)
        {
            return ReservationDAL.Insert(reservationInfo);
        }
        public static DataTable GetAll_ByAdmin(int restaurantID,DateTime from, DateTime to, int status)
        {
            return ReservationDAL.GetAll_ByAdmin(restaurantID,from,to,status);
        }
        public static DataTable GetAll_ByMemberID(int memberID)
        {
            return ReservationDAL.GetAll_ByMemberID(memberID);
        }
        public static DataTable GetAll_ByRestaurantID(int restaurantID, DateTime from, DateTime to, int status)
        {
            return ReservationDAL.GetAll_ByRestaurantID(restaurantID,from,to,status);
        }
        public static void UpdateStatus(int id, Int16 status)
        {
            ReservationDAL.UpdateStatus(id, status);
        }
        public static void UpdateRealized(int id, bool realized)
        {
            ReservationDAL.UpdateRealized(id,realized);
        }
        public static ReservationInfo GetByTransactionID(int transactionID)
        {
            return ReservationDAL.GetByTransactionID(transactionID);
        }
    }
}
