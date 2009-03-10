using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Library.DAL
{
    public class RestaurantDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = new DataTable();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(dbCmd);
            da.Fill(retVal);
            dbConn.Close();
            return retVal;
        }
        public static DataTable GetName()
        {
            DataTable retVal = new DataTable();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetName", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(dbCmd);
            da.Fill(retVal);
            dbConn.Close();
            return retVal;
        }
        public static DataTable ListByCriterias(string keyword, int cityId, int StateId, int countryId, string cuisineIds, int neighborhoodId, string zipCode, int pageIndex, int pageSize, ref int total)
        {
            DataTable retVal = new DataTable();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_ListByCriterias", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@Keyword", keyword);
            dbCmd.Parameters.AddWithValue("@CityId", cityId);
            dbCmd.Parameters.AddWithValue("@StateId", StateId);
            dbCmd.Parameters.AddWithValue("@CountryId", countryId);
            dbCmd.Parameters.AddWithValue("@CuisineId", cuisineIds);
            dbCmd.Parameters.AddWithValue("@NeighborhoodId", neighborhoodId);
            dbCmd.Parameters.AddWithValue("@ZipCode", zipCode);
            dbCmd.Parameters.AddWithValue("@Pagesize", pageSize);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.Add("@Total", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);

                total = Convert.ToInt32(dbCmd.Parameters["@Total"].Value);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable Admin_ListByCriterias(string keyword, int cityId, int StateId, int countryId, string cuisineIds, string zipCode, int pageIndex, int pageSize, ref int total)
        {
            DataTable retVal = new DataTable();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_Admin_ListByCriterias", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@Keyword", keyword);
            dbCmd.Parameters.AddWithValue("@CityId", cityId);
            dbCmd.Parameters.AddWithValue("@StateId", StateId);
            dbCmd.Parameters.AddWithValue("@CountryId", countryId);
            dbCmd.Parameters.AddWithValue("@CuisineId", cuisineIds);
            dbCmd.Parameters.AddWithValue("@ZipCode", zipCode);
            dbCmd.Parameters.AddWithValue("@Pagesize", pageSize);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.Add("@Total", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);

                total = Convert.ToInt32(dbCmd.Parameters["@Total"].Value);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable DeliverySearch(string keyword, string cuisineId, string zipCode, string address,int cityId, int fee, int minimumPrice, int pageSize, int pageIndex, ref int total)
        {
            DataTable retVal = new DataTable();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_DeliverySearch", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@Keyword", keyword);
            dbCmd.Parameters.AddWithValue("@CuisineId", cuisineId);
            dbCmd.Parameters.AddWithValue("@ZipCode", zipCode);
            dbCmd.Parameters.AddWithValue("@Address", address);
            dbCmd.Parameters.AddWithValue("@CityId", cityId);
            dbCmd.Parameters.AddWithValue("@Fee", fee);
            dbCmd.Parameters.AddWithValue("@MinimumPrice", minimumPrice);
            dbCmd.Parameters.AddWithValue("@Pagesize", pageSize);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.Add("@Total", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);

                total = Convert.ToInt32(dbCmd.Parameters["@Total"].Value);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static RestaurantInfo GetInfo(int id)
        {
            RestaurantInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.MemberID = ConvertHelper.ToInt32(dr["MemberID"]);
                    retVal.Name = ConvertHelper.ToString(dr["Name"]);
                    retVal.DateOpened = ConvertHelper.ToDateTime(dr["DateOpened"]);
                    retVal.Address = ConvertHelper.ToString(dr["Address"]);
                    retVal.ZipCode = ConvertHelper.ToString(dr["ZipCode"]);
                    retVal.CountryID = ConvertHelper.ToInt32(dr["CountryID"]);
                    retVal.StateID = ConvertHelper.ToInt32(dr["StateID"]);
                    retVal.CityID = ConvertHelper.ToInt32(dr["CityID"]);
                    retVal.Phone1 = ConvertHelper.ToString(dr["Phone1"]);
                    retVal.Phone2 = ConvertHelper.ToString(dr["Phone2"]);
                    retVal.Fax = ConvertHelper.ToString(dr["Fax"]);
                    retVal.Email = ConvertHelper.ToString(dr["Email"]);
                    retVal.Website = ConvertHelper.ToString(dr["Website"]);
                    retVal.Image = ConvertHelper.ToString(dr["Image"]);
                    retVal.AcceptCreditCard = ConvertHelper.ToBoolean(dr["AcceptCreditCard"]);
                    retVal.Description = ConvertHelper.ToString(dr["Description"]);
                    retVal.ExpiryDate = ConvertHelper.ToDateTime(dr["ExpiryDate"]);
                    retVal.LuckyNo = ConvertHelper.ToString(dr["LuckyNo"]);
                    retVal.FirstNameContact = ConvertHelper.ToString(dr["FirstNameContact"]);
                    retVal.LastNameContact = ConvertHelper.ToString(dr["LastNameContact"]);
                    retVal.GenderContact = ConvertHelper.ToString(dr["GenderContact"]);
                    retVal.BirthdayContact = ConvertHelper.ToDateTime(dr["BirthdayContact"]);
                    retVal.AddressContact = ConvertHelper.ToString(dr["AddressContact"]);
                    retVal.CountryIDContact = ConvertHelper.ToInt32(dr["CountryIDContact"]);
                    retVal.StateIDContact = ConvertHelper.ToInt32(dr["StateIDContact"]);
                    retVal.CityIDContact = ConvertHelper.ToInt32(dr["CityIDContact"]);
                    retVal.ZipcodeContact = ConvertHelper.ToString(dr["ZipcodeContact"]);
                    retVal.PhoneContact = ConvertHelper.ToString(dr["PhoneContact"]);
                    retVal.FaxContact = ConvertHelper.ToString(dr["FaxContact"]);
                    retVal.EmailContact = ConvertHelper.ToString(dr["EmailContact"]);
                    retVal.CreatedByAdmin = ConvertHelper.ToBoolean(dr["CreatedByAdmin"]);
                    retVal.IsActive = ConvertHelper.ToBoolean(dr["IsActive"]);
                    retVal.PackageDetailID = Convert.ToInt32(dr["PackageDetailID"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static RestaurantInfo GetInfo_ByGiftID(int giftID)
        {
            RestaurantInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetInfo_ByGiftID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GiftID", giftID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.MemberID = ConvertHelper.ToInt32(dr["MemberID"]);
                    retVal.Name = ConvertHelper.ToString(dr["Name"]);
                    retVal.DateOpened = ConvertHelper.ToDateTime(dr["DateOpened"]);
                    retVal.Address = ConvertHelper.ToString(dr["Address"]);
                    retVal.ZipCode = ConvertHelper.ToString(dr["ZipCode"]);
                    retVal.CountryID = ConvertHelper.ToInt32(dr["CountryID"]);
                    retVal.StateID = ConvertHelper.ToInt32(dr["StateID"]);
                    retVal.CityID = ConvertHelper.ToInt32(dr["CityID"]);
                    retVal.Phone1 = ConvertHelper.ToString(dr["Phone1"]);
                    retVal.Phone2 = ConvertHelper.ToString(dr["Phone2"]);
                    retVal.Fax = ConvertHelper.ToString(dr["Fax"]);
                    retVal.Email = ConvertHelper.ToString(dr["Email"]);
                    retVal.Website = ConvertHelper.ToString(dr["Website"]);
                    retVal.Image = ConvertHelper.ToString(dr["Image"]);
                    retVal.AcceptCreditCard = ConvertHelper.ToBoolean(dr["AcceptCreditCard"]);
                    retVal.Description = ConvertHelper.ToString(dr["Description"]);
                    retVal.ExpiryDate = ConvertHelper.ToDateTime(dr["ExpiryDate"]);
                    retVal.LuckyNo = ConvertHelper.ToString(dr["LuckyNo"]);
                    retVal.FirstNameContact = ConvertHelper.ToString(dr["FirstNameContact"]);
                    retVal.LastNameContact = ConvertHelper.ToString(dr["LastNameContact"]);
                    retVal.GenderContact = ConvertHelper.ToString(dr["GenderContact"]);
                    retVal.BirthdayContact = ConvertHelper.ToDateTime(dr["BirthdayContact"]);
                    retVal.AddressContact = ConvertHelper.ToString(dr["AddressContact"]);
                    retVal.CountryIDContact = ConvertHelper.ToInt32(dr["CountryIDContact"]);
                    retVal.StateIDContact = ConvertHelper.ToInt32(dr["StateIDContact"]);
                    retVal.CityIDContact = ConvertHelper.ToInt32(dr["CityIDContact"]);
                    retVal.ZipcodeContact = ConvertHelper.ToString(dr["ZipcodeContact"]);
                    retVal.PhoneContact = ConvertHelper.ToString(dr["PhoneContact"]);
                    retVal.FaxContact = ConvertHelper.ToString(dr["FaxContact"]);
                    retVal.EmailContact = ConvertHelper.ToString(dr["EmailContact"]);
                    retVal.CreatedByAdmin = ConvertHelper.ToBoolean(dr["CreatedByAdmin"]);
                    retVal.IsActive = ConvertHelper.ToBoolean(dr["IsActive"]);
                    retVal.PackageDetailID = Convert.ToInt32(dr["PackageDetailID"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static RestaurantInfo GetInfoByAdmin(int id)
        {
            RestaurantInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetInfoByAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.MemberID = ConvertHelper.ToInt32(dr["MemberID"]);
                    retVal.Name = ConvertHelper.ToString(dr["Name"]);
                    retVal.DateOpened = ConvertHelper.ToDateTime(dr["DateOpened"]);
                    retVal.Address = ConvertHelper.ToString(dr["Address"]);
                    retVal.ZipCode = ConvertHelper.ToString(dr["ZipCode"]);
                    retVal.CountryID = ConvertHelper.ToInt32(dr["CountryID"]);
                    retVal.StateID = ConvertHelper.ToInt32(dr["StateID"]);
                    retVal.CityID = ConvertHelper.ToInt32(dr["CityID"]);
                    retVal.Phone1 = ConvertHelper.ToString(dr["Phone1"]);
                    retVal.Phone2 = ConvertHelper.ToString(dr["Phone2"]);
                    retVal.Fax = ConvertHelper.ToString(dr["Fax"]);
                    retVal.Email = ConvertHelper.ToString(dr["Email"]);
                    retVal.Website = ConvertHelper.ToString(dr["Website"]);
                    retVal.Image = ConvertHelper.ToString(dr["Image"]);
                    retVal.AcceptCreditCard = ConvertHelper.ToBoolean(dr["AcceptCreditCard"]);
                    retVal.Description = ConvertHelper.ToString(dr["Description"]);
                    retVal.ExpiryDate = ConvertHelper.ToDateTime(dr["ExpiryDate"]);
                    retVal.LuckyNo = ConvertHelper.ToString(dr["LuckyNo"]);
                    retVal.FirstNameContact = ConvertHelper.ToString(dr["FirstNameContact"]);
                    retVal.LastNameContact = ConvertHelper.ToString(dr["LastNameContact"]);
                    retVal.GenderContact = ConvertHelper.ToString(dr["GenderContact"]);
                    retVal.BirthdayContact = ConvertHelper.ToDateTime(dr["BirthdayContact"]);
                    retVal.AddressContact = ConvertHelper.ToString(dr["AddressContact"]);
                    retVal.CountryIDContact = ConvertHelper.ToInt32(dr["CountryIDContact"]);
                    retVal.StateIDContact = ConvertHelper.ToInt32(dr["StateIDContact"]);
                    retVal.CityIDContact = ConvertHelper.ToInt32(dr["CityIDContact"]);
                    retVal.ZipcodeContact = ConvertHelper.ToString(dr["ZipcodeContact"]);
                    retVal.PhoneContact = ConvertHelper.ToString(dr["PhoneContact"]);
                    retVal.FaxContact = ConvertHelper.ToString(dr["FaxContact"]);
                    retVal.EmailContact = ConvertHelper.ToString(dr["EmailContact"]);
                    retVal.CreatedByAdmin = ConvertHelper.ToBoolean(dr["CreatedByAdmin"]);
                    retVal.IsActive = ConvertHelper.ToBoolean(dr["IsActive"]);
                    retVal.PackageDetailID = Convert.ToInt32(dr["PackageDetailID"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetInfoByRestaurant(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetInfoByRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static RestaurantInfo GetInfo(string username, string password, bool encrypt)
        {
            RestaurantInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetInfo_By_UserNameAndPassword", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", username);
            if (encrypt)
            {
                dbCmd.Parameters.AddWithValue("@Password", MD5.Encrypt(password));
            }
            else
            {
                dbCmd.Parameters.AddWithValue("@Password", password);
            }
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new RestaurantInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.MemberID = Convert.ToInt32(dr["MemberID"]);
                    retVal.Name = Convert.ToString(dr["Name"]);
                    retVal.DateOpened = Convert.ToDateTime(dr["DateOpened"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.ZipCode = Convert.ToString(dr["ZipCode"]);
                    retVal.CountryID = Convert.ToInt32(dr["CountryID"]);
                    retVal.StateID = Convert.ToInt32(dr["StateID"]);
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                    retVal.Phone1 = Convert.ToString(dr["Phone1"]);
                    retVal.Phone2 = Convert.ToString(dr["Phone2"]);
                    retVal.Fax = Convert.ToString(dr["Fax"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.Website = Convert.ToString(dr["Website"]);
                    retVal.Image = Convert.ToString(dr["Image"]);
                    retVal.AcceptCreditCard = Convert.ToBoolean(dr["AcceptCreditCard"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                    retVal.LuckyNo = Convert.ToString(dr["LuckyNo"]);
                    retVal.FirstNameContact = Convert.ToString(dr["FirstNameContact"]);
                    retVal.LastNameContact = Convert.ToString(dr["LastNameContact"]);
                    retVal.GenderContact = Convert.ToString(dr["GenderContact"]);
                    retVal.BirthdayContact = Convert.ToDateTime(dr["BirthdayContact"]);
                    retVal.AddressContact = Convert.ToString(dr["AddressContact"]);
                    retVal.CountryIDContact = Convert.ToInt32(dr["CountryIDContact"]);
                    retVal.StateIDContact = Convert.ToInt32(dr["StateIDContact"]);
                    retVal.CityIDContact = Convert.ToInt32(dr["CityIDContact"]);
                    retVal.ZipcodeContact = Convert.ToString(dr["ZipcodeContact"]);
                    retVal.PhoneContact = Convert.ToString(dr["PhoneContact"]);
                    retVal.FaxContact = Convert.ToString(dr["FaxContact"]);
                    retVal.EmailContact = Convert.ToString(dr["EmailContact"]);
                    retVal.CreatedByAdmin = Convert.ToBoolean(dr["CreatedByAdmin"]);
                    retVal.PackageDetailID = Convert.ToInt32(dr["PackageDetailID"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static PackageInfo GetPackage(int restaurantID)
        {
            PackageInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetPackage", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new PackageInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.Name = Convert.ToString(dr["Name"]);
                    retVal.AllowOnlineOrder = Convert.ToBoolean(dr["AllowOnlineOrder"]);
                    retVal.AllowGiftCertificate = Convert.ToBoolean(dr["AllowGiftCertificate"]);
                    retVal.AllowReservation = Convert.ToBoolean(dr["AllowReservation"]);
                    retVal.AllowMap = Convert.ToBoolean(dr["AllowMap"]);
                    retVal.AllowVideo = Convert.ToBoolean(dr["AllowVideo"]);
                    retVal.AllowPhoto = Convert.ToBoolean(dr["AllowPhoto"]);
                    retVal.AllowEvent = Convert.ToBoolean(dr["AllowEvent"]);
                    retVal.AllowJobPortal = Convert.ToBoolean(dr["AllowJobPortal"]);
                    retVal.Priority = Convert.ToInt16(dr["Priority"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static int Insert(RestaurantInfo restaurantInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", restaurantInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@Name", restaurantInfo.Name);
            dbCmd.Parameters.AddWithValue("@DateOpened", restaurantInfo.DateOpened);
            dbCmd.Parameters.AddWithValue("@Address", restaurantInfo.Address);
            dbCmd.Parameters.AddWithValue("@ZipCode", restaurantInfo.ZipCode);
            dbCmd.Parameters.AddWithValue("@CountryID", restaurantInfo.CountryID);
            dbCmd.Parameters.AddWithValue("@StateID", restaurantInfo.StateID);
            dbCmd.Parameters.AddWithValue("@CityID", restaurantInfo.CityID);
            dbCmd.Parameters.AddWithValue("@Phone1", restaurantInfo.Phone1);
            dbCmd.Parameters.AddWithValue("@Phone2", restaurantInfo.Phone2);
            dbCmd.Parameters.AddWithValue("@Fax", restaurantInfo.Fax);
            dbCmd.Parameters.AddWithValue("@Email", restaurantInfo.Email);
            dbCmd.Parameters.AddWithValue("@Website", restaurantInfo.Website);
            dbCmd.Parameters.AddWithValue("@Image", restaurantInfo.Image);
            dbCmd.Parameters.AddWithValue("@AcceptCreditCard", restaurantInfo.AcceptCreditCard);
            dbCmd.Parameters.AddWithValue("@Description", restaurantInfo.Description);
            dbCmd.Parameters.AddWithValue("@ExpiryDate", restaurantInfo.ExpiryDate);
            dbCmd.Parameters.AddWithValue("@FirstNameContact", restaurantInfo.FirstNameContact);
            dbCmd.Parameters.AddWithValue("@LastNameContact", restaurantInfo.LastNameContact);
            dbCmd.Parameters.AddWithValue("@GenderContact", restaurantInfo.GenderContact);
            dbCmd.Parameters.AddWithValue("@BirthdayContact", restaurantInfo.BirthdayContact);
            dbCmd.Parameters.AddWithValue("@AddressContact", restaurantInfo.AddressContact);
            dbCmd.Parameters.AddWithValue("@CountryIDContact", restaurantInfo.CountryIDContact);
            dbCmd.Parameters.AddWithValue("@StateIDContact", restaurantInfo.StateIDContact);
            dbCmd.Parameters.AddWithValue("@CityIDContact", restaurantInfo.CityIDContact);
            dbCmd.Parameters.AddWithValue("@ZipcodeContact", restaurantInfo.ZipcodeContact);
            dbCmd.Parameters.AddWithValue("@PhoneContact", restaurantInfo.PhoneContact);
            dbCmd.Parameters.AddWithValue("@FaxContact", restaurantInfo.FaxContact);
            dbCmd.Parameters.AddWithValue("@EmailContact", restaurantInfo.EmailContact);
            dbCmd.Parameters.AddWithValue("@CreatedByAdmin", restaurantInfo.CreatedByAdmin);
            dbCmd.Parameters.AddWithValue("@IsActive", restaurantInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@PackageDetailID", restaurantInfo.PackageDetailID);
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
        public static bool Update(RestaurantInfo restaurantInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantInfo.ID);
            dbCmd.Parameters.AddWithValue("@MemberID", restaurantInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@Name", restaurantInfo.Name);
            dbCmd.Parameters.AddWithValue("@DateOpened", restaurantInfo.DateOpened);
            dbCmd.Parameters.AddWithValue("@Address", restaurantInfo.Address);
            dbCmd.Parameters.AddWithValue("@ZipCode", restaurantInfo.ZipCode);
            dbCmd.Parameters.AddWithValue("@CountryID", restaurantInfo.CountryID);
            dbCmd.Parameters.AddWithValue("@StateID", restaurantInfo.StateID);
            dbCmd.Parameters.AddWithValue("@CityID", restaurantInfo.CityID);
            dbCmd.Parameters.AddWithValue("@Phone1", restaurantInfo.Phone1);
            dbCmd.Parameters.AddWithValue("@Phone2", restaurantInfo.Phone2);
            dbCmd.Parameters.AddWithValue("@Fax", restaurantInfo.Fax);
            dbCmd.Parameters.AddWithValue("@Email", restaurantInfo.Email);
            dbCmd.Parameters.AddWithValue("@Website", restaurantInfo.Website);
            dbCmd.Parameters.AddWithValue("@Image", restaurantInfo.Image);
            dbCmd.Parameters.AddWithValue("@AcceptCreditCard", restaurantInfo.AcceptCreditCard);
            dbCmd.Parameters.AddWithValue("@Description", restaurantInfo.Description);
            dbCmd.Parameters.AddWithValue("@ExpiryDate", restaurantInfo.ExpiryDate);
            dbCmd.Parameters.AddWithValue("@FirstNameContact", restaurantInfo.FirstNameContact);
            dbCmd.Parameters.AddWithValue("@LastNameContact", restaurantInfo.LastNameContact);
            dbCmd.Parameters.AddWithValue("@GenderContact", restaurantInfo.GenderContact);
            dbCmd.Parameters.AddWithValue("@BirthdayContact", restaurantInfo.BirthdayContact);
            dbCmd.Parameters.AddWithValue("@AddressContact", restaurantInfo.AddressContact);
            dbCmd.Parameters.AddWithValue("@CountryIDContact", restaurantInfo.CountryIDContact);
            dbCmd.Parameters.AddWithValue("@StateIDContact", restaurantInfo.StateIDContact);
            dbCmd.Parameters.AddWithValue("@CityIDContact", restaurantInfo.CityIDContact);
            dbCmd.Parameters.AddWithValue("@ZipcodeContact", restaurantInfo.ZipcodeContact);
            dbCmd.Parameters.AddWithValue("@PhoneContact", restaurantInfo.PhoneContact);
            dbCmd.Parameters.AddWithValue("@FaxContact", restaurantInfo.FaxContact);
            dbCmd.Parameters.AddWithValue("@EmailContact", restaurantInfo.EmailContact);
            dbCmd.Parameters.AddWithValue("@CreatedByAdmin", restaurantInfo.CreatedByAdmin);
            dbCmd.Parameters.AddWithValue("@PackageDetailID", restaurantInfo.PackageDetailID);
            dbCmd.Parameters.AddWithValue("@IsActive", restaurantInfo.IsActive);
            try
            {               
                dbConn.Open();
                return (dbCmd.ExecuteNonQuery() > 0) ? true : false;
            }
            finally
            {
                dbConn.Close();
            }        
        }
        public static DataTable RestaurantDetail(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_Detail", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantID);
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
        public static string GetCuisineName(int restaurantID)
        {
            string retVal = "";
            DataTable tmpTable = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_Detail", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantID);
            try
            {
                tmpTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(tmpTable);
                if (tmpTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in tmpTable.Rows)
                    {
                        retVal += dr["Name"].ToString() + ",";
                    }
                }
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static DataTable GetDetail(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetDetail", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", restaurantID);
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
        public static DataTable GetGoodFor(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetGoodFor", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetAttire(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetAttire", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetMusic(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetMusic", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetCuisine(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetCuisine", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetNeighbourhood(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetNeighbourhood", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetSpecial(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetSpecial", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetAtmosphere(int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetAtmosphere", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
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
        public static DataTable GetByMemberID(int memberID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetByMemberID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@memberID", memberID);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static void UpdateMainPhoto(int restaurantID, string image)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_UpdateImage", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            dbCmd.Parameters.AddWithValue("@Image", image);
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
        public static NeighbourhoodInfo GetNeighbourhoodInfo(int restaurantID)
        {
            NeighbourhoodInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Restaurant_GetNeighbourhood", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new NeighbourhoodInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.Name = dr["Name"].ToString();
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.Description = dr["Description"].ToString();
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                }
                if (dr != null)
                    dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
    }
}
