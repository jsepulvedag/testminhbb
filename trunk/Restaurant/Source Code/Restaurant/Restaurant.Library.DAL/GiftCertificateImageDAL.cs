using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;

namespace Restaurant.Library.DAL
{
    public class GiftCertificateImageDAL
    {
        public static DataTable GetAllByGiftTypeID(int giftTypeID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_GetAllByTypeID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GiftTypeID", giftTypeID);
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
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_GetAll", dbConn);
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
        public static void Delete(int id)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int Insert(GiftCertificateImageInfo giftCertificateImageInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GiftTypeID", giftCertificateImageInfo.GiftTypeID);
            dbCmd.Parameters.AddWithValue("@ImageSmallURL", giftCertificateImageInfo.ImageSmallURL);
            dbCmd.Parameters.AddWithValue("@Title", giftCertificateImageInfo.Title);
            dbCmd.Parameters.AddWithValue("@ImageLargeURL", giftCertificateImageInfo.ImageLargeURL);
            dbCmd.Parameters.AddWithValue("@ToX", giftCertificateImageInfo.ToX);
            dbCmd.Parameters.AddWithValue("@ToY", giftCertificateImageInfo.ToY);
            dbCmd.Parameters.AddWithValue("@FromX", giftCertificateImageInfo.FromX);
            dbCmd.Parameters.AddWithValue("@FromY", giftCertificateImageInfo.FromY);
            dbCmd.Parameters.AddWithValue("@MsgX", giftCertificateImageInfo.MsgX);
            dbCmd.Parameters.AddWithValue("@MsgY", giftCertificateImageInfo.MsgY);
            dbCmd.Parameters.AddWithValue("@RestaurantX", giftCertificateImageInfo.RestaurantX);
            dbCmd.Parameters.AddWithValue("@RestaurantY", giftCertificateImageInfo.RestaurantY);
            dbCmd.Parameters.AddWithValue("@SignatureX", giftCertificateImageInfo.SignatureX);
            dbCmd.Parameters.AddWithValue("@SignatureY", giftCertificateImageInfo.SignatureY);
            dbCmd.Parameters.AddWithValue("@PriceX", giftCertificateImageInfo.PriceX);
            dbCmd.Parameters.AddWithValue("@PriceY", giftCertificateImageInfo.PriceY);
            dbCmd.Parameters.AddWithValue("@AddressX", giftCertificateImageInfo.AddressX);
            dbCmd.Parameters.AddWithValue("@AddressY", giftCertificateImageInfo.AddressY);
            dbCmd.Parameters.AddWithValue("@ExpiredDateX", giftCertificateImageInfo.ExpiredDateX);
            dbCmd.Parameters.AddWithValue("@ExpiredDateY", giftCertificateImageInfo.ExpiredDateY);
            dbCmd.Parameters.AddWithValue("@ColorText", giftCertificateImageInfo.ColorText);
            dbCmd.Parameters.AddWithValue("@IsActive", giftCertificateImageInfo.IsActive);
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
        public static void Update(GiftCertificateImageInfo giftCertificateImageInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", giftCertificateImageInfo.ID);
            dbCmd.Parameters.AddWithValue("@GiftTypeID", giftCertificateImageInfo.GiftTypeID);
            dbCmd.Parameters.AddWithValue("@Title", giftCertificateImageInfo.Title);
            dbCmd.Parameters.AddWithValue("@ToX", giftCertificateImageInfo.ToX);
            dbCmd.Parameters.AddWithValue("@ToY", giftCertificateImageInfo.ToY);
            dbCmd.Parameters.AddWithValue("@FromX", giftCertificateImageInfo.FromX);
            dbCmd.Parameters.AddWithValue("@FromY", giftCertificateImageInfo.FromY);
            dbCmd.Parameters.AddWithValue("@MsgX", giftCertificateImageInfo.MsgX);
            dbCmd.Parameters.AddWithValue("@MsgY", giftCertificateImageInfo.MsgY);
            dbCmd.Parameters.AddWithValue("@RestaurantX", giftCertificateImageInfo.RestaurantX);
            dbCmd.Parameters.AddWithValue("@RestaurantY", giftCertificateImageInfo.RestaurantY);
            dbCmd.Parameters.AddWithValue("@SignatureX", giftCertificateImageInfo.SignatureX);
            dbCmd.Parameters.AddWithValue("@SignatureY", giftCertificateImageInfo.SignatureY);
            dbCmd.Parameters.AddWithValue("@PriceX", giftCertificateImageInfo.PriceX);
            dbCmd.Parameters.AddWithValue("@PriceY", giftCertificateImageInfo.PriceY);
            dbCmd.Parameters.AddWithValue("@AddressX", giftCertificateImageInfo.AddressX);
            dbCmd.Parameters.AddWithValue("@AddressY", giftCertificateImageInfo.AddressY);
            dbCmd.Parameters.AddWithValue("@ExpiredDateX", giftCertificateImageInfo.ExpiredDateX);
            dbCmd.Parameters.AddWithValue("@ExpiredDateY", giftCertificateImageInfo.ExpiredDateY);
            dbCmd.Parameters.AddWithValue("@ColorText", giftCertificateImageInfo.ColorText);
            dbCmd.Parameters.AddWithValue("@IsActive", giftCertificateImageInfo.IsActive);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static GiftCertificateImageInfo GetInfo(int id)
        {
            GiftCertificateImageInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new GiftCertificateImageInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.GiftTypeID = Convert.ToInt32(dr["GiftTypeID"]);
                    retVal.ImageSmallURL = Convert.ToString(dr["ImageSmallURL"]);
                    retVal.Title = Convert.ToString(dr["Title"]);
                    retVal.ImageLargeURL = Convert.ToString(dr["ImageLargeURL"]);
                    retVal.ToX = Convert.ToInt32(dr["ToX"]);
                    retVal.ToY = Convert.ToInt32(dr["ToY"]);
                    retVal.FromX = Convert.ToInt32(dr["FromX"]);
                    retVal.FromY = Convert.ToInt32(dr["FromY"]);
                    retVal.MsgX = Convert.ToInt32(dr["MsgX"]);
                    retVal.MsgY = Convert.ToInt32(dr["MsgY"]);
                    retVal.RestaurantX = Convert.ToInt32(dr["RestaurantX"]);
                    retVal.RestaurantY = Convert.ToInt32(dr["RestaurantY"]);
                    retVal.SignatureX = Convert.ToInt32(dr["SignatureX"]);
                    retVal.SignatureY = Convert.ToInt32(dr["SignatureY"]);
                    retVal.PriceX = Convert.ToInt32(dr["PriceX"]);
                    retVal.PriceY = Convert.ToInt32(dr["PriceY"]);
                    retVal.AddressX = Convert.ToInt32(dr["AddressX"]);
                    retVal.AddressY = Convert.ToInt32(dr["AddressY"]);
                    retVal.ExpiredDateX = Convert.ToInt32(dr["ExpiredDateX"]);
                    retVal.ExpiredDateY = Convert.ToInt32(dr["ExpiredDateY"]);
                    retVal.ColorText = Convert.ToString(dr["ColorText"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static GiftCertificateImageInfo GetInfo_ByGiftID(int giftID)
        {
            GiftCertificateImageInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("GiftCertificateImage_GetInfo_ByGiftID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GiftID", giftID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new GiftCertificateImageInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.GiftTypeID = Convert.ToInt32(dr["GiftTypeID"]);
                    retVal.ImageSmallURL = Convert.ToString(dr["ImageSmallURL"]);
                    retVal.Title = Convert.ToString(dr["Title"]);
                    retVal.ImageLargeURL = Convert.ToString(dr["ImageLargeURL"]);
                    retVal.ToX = Convert.ToInt32(dr["ToX"]);
                    retVal.ToY = Convert.ToInt32(dr["ToY"]);
                    retVal.FromX = Convert.ToInt32(dr["FromX"]);
                    retVal.FromY = Convert.ToInt32(dr["FromY"]);
                    retVal.MsgX = Convert.ToInt32(dr["MsgX"]);
                    retVal.MsgY = Convert.ToInt32(dr["MsgY"]);
                    retVal.RestaurantX = Convert.ToInt32(dr["RestaurantX"]);
                    retVal.RestaurantY = Convert.ToInt32(dr["RestaurantY"]);
                    retVal.SignatureX = Convert.ToInt32(dr["SignatureX"]);
                    retVal.SignatureY = Convert.ToInt32(dr["SignatureY"]);
                    retVal.PriceX = Convert.ToInt32(dr["PriceX"]);
                    retVal.PriceY = Convert.ToInt32(dr["PriceY"]);
                    retVal.AddressX = Convert.ToInt32(dr["AddressX"]);
                    retVal.AddressY = Convert.ToInt32(dr["AddressY"]);
                    retVal.ExpiredDateX = Convert.ToInt32(dr["ExpiredDateX"]);
                    retVal.ExpiredDateY = Convert.ToInt32(dr["ExpiredDateY"]);
                    retVal.ColorText = Convert.ToString(dr["ColorText"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
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
