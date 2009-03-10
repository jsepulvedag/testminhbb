using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.Utilities;
using System.Data.SqlClient;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
   public class GiftCertificatesDAL
    {
       public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftPurchase_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
       public static int Insert(GiftCertificateInfo giftCertificateInfo)
       {
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("GiftCertificate_Insert", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@TransactionID", giftCertificateInfo.TransactionID);
           dbCmd.Parameters.AddWithValue("@GiftCertificateImageID", giftCertificateInfo.GiftCertificateImageID);
           dbCmd.Parameters.AddWithValue("@GiftImageURL", giftCertificateInfo.GiftImageURL);
           dbCmd.Parameters.AddWithValue("@ExpiredDate", giftCertificateInfo.ExpiredDate);
           dbCmd.Parameters.AddWithValue("@SignatureMsg", giftCertificateInfo.SignatureMsg);
           dbCmd.Parameters.AddWithValue("@ToMsg", giftCertificateInfo.ToMsg);
           dbCmd.Parameters.AddWithValue("@FromMsg", giftCertificateInfo.FromMsg);
           dbCmd.Parameters.AddWithValue("@Message", giftCertificateInfo.Message);
           dbCmd.Parameters.AddWithValue("@SendGift", giftCertificateInfo.SendGift);
           dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
           try
           {
               dbConn.Open();
               dbCmd.ExecuteNonQuery();
               return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
           }
           finally
           {
               dbConn.Close();
           }
       }
       public static DataTable GetAllByMemberID(int memberID)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Gift_GetAll_ByMemberID", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@MemberID",memberID);
           try
           {
               retVal = new DataTable();
               SqlDataAdapter da = new SqlDataAdapter(dbCmd);
               da.Fill(retVal);
           }
           finally
           {
               dbConn.Close();
           }
           return retVal;
       }
       public static DataTable GetAllByRestaurantID(int restaurantID, int status, DateTime from, DateTime to)
       {
           DataTable retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("Gift_GetAll_ByRestaurantID", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
           dbCmd.Parameters.AddWithValue("@Status",status);
           dbCmd.Parameters.AddWithValue("@FromDate",from);
           dbCmd.Parameters.AddWithValue("@ToDate", to);
           try
           {
               retVal = new DataTable();
               SqlDataAdapter da = new SqlDataAdapter(dbCmd);
               da.Fill(retVal);
           }
           finally
           {
               dbConn.Close();
           }
           return retVal;
       }
       public static GiftCertificateInfo GetInfo(int iD)
       {
           GiftCertificateInfo retVal = null;
           SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
           SqlCommand dbCmd = new SqlCommand("GiftCertificate_GetInfo", dbConn);
           dbCmd.CommandType = CommandType.StoredProcedure;
           dbCmd.Parameters.AddWithValue("@ID", iD);
           try
           {
               dbConn.Open();
               SqlDataReader dr = dbCmd.ExecuteReader();
               if (dr.Read())
               {
                   retVal = new GiftCertificateInfo();
                   retVal.ID = Convert.ToInt32(dr["ID"]);
                   retVal.TransactionID = Convert.ToInt32(dr["TransactionID"]);
                   retVal.GiftCertificateImageID = Convert.ToInt32(dr["GiftCertificateImageID"]);
                   retVal.GiftImageURL = Convert.ToString(dr["GiftImageURL"]);
                   retVal.ExpiredDate = Convert.ToDateTime(dr["ExpiredDate"]);
                   retVal.SignatureMsg = Convert.ToString(dr["SignatureMsg"]);
                   retVal.ToMsg = Convert.ToString(dr["ToMsg"]);
                   retVal.FromMsg = Convert.ToString(dr["FromMsg"]);
                   retVal.Message = Convert.ToString(dr["Message"]);
                   retVal.SendGift = Convert.ToString(dr["SendGift"]);
               }
               if (dr != null) dr.Close();
           }
           finally
           {
               dbConn.Close();
           }
           return retVal;
       }
    }
}
