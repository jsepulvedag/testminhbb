using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class GiftCertificatesBLL
    {
        public static DataTable GetAll()
        { 
            return GiftCertificatesDAL.GetAll();            
        }
        public static int Insert(GiftCertificateInfo giftCertificateInfo)
        {
            return GiftCertificatesDAL.Insert(giftCertificateInfo);
        }
        public static DataTable GetAllByMemberID(int memberID)
        {
            return GiftCertificatesDAL.GetAllByMemberID(memberID);
        }
        public static DataTable GetAllByRestaurantID(int restaurantID, int status, DateTime from, DateTime to)
        {
            return GiftCertificatesDAL.GetAllByRestaurantID(restaurantID, status, from,to);
        }
        public static GiftCertificateInfo GetInfo(int iD)
        {
            return GiftCertificatesDAL.GetInfo(iD);
        }
    }
}
