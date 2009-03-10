using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Library.DAL
{
    public class MemberDAL
    {
        public static MemberInfo GetInfo(int memberId)
        {
            MemberInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetInfoByMemberId", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberId", memberId);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MemberInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]);
                    retVal.Birthday = Convert.ToDateTime(dr["Birthday"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.CountryID = Convert.ToInt32(dr["CountryID"]);
                    retVal.StateID = Convert.ToInt32(dr["StateID"]);
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                    retVal.ZipCode = Convert.ToString(dr["ZipCode"]);
                    retVal.Phone = Convert.ToString(dr["Phone"]);
                    retVal.Fax = Convert.ToString(dr["Fax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.RegisterDate = Convert.ToDateTime(dr["RegisterDate"]);
                    retVal.IsWantReciveMail = Convert.ToBoolean(dr["IsWantReciveMail"]);
                    retVal.LastRestaurantId = dr["LastRestaurantId"] != DBNull.Value ? Convert.ToInt32(dr["LastRestaurantId"]) : 0;
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static MemberInfo GetInfo_Email(string email)
        {
            MemberInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetInfo_Email", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Email", email);

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MemberInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]);
                    retVal.Birthday = Convert.ToDateTime(dr["Birthday"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.CountryID = Convert.ToInt32(dr["CountryID"]);
                    retVal.StateID = Convert.ToInt32(dr["StateID"]);
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                    retVal.ZipCode = Convert.ToString(dr["ZipCode"]);
                    retVal.Phone = Convert.ToString(dr["Phone"]);
                    retVal.Fax = Convert.ToString(dr["Fax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.RegisterDate = Convert.ToDateTime(dr["RegisterDate"]);
                    retVal.IsWantReciveMail = Convert.ToBoolean(dr["IsWantReciveMail"]);
                    retVal.LastRestaurantId = dr["LastRestaurantId"] != DBNull.Value ? Convert.ToInt32(dr["LastRestaurantId"]) : 0;
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
        public static MemberInfo GetInfo(string userName)
        {
            MemberInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetInfo_ByUserName", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", userName);
            
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new MemberInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]);
                    retVal.Birthday = Convert.ToDateTime(dr["Birthday"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.CountryID = Convert.ToInt32(dr["CountryID"]);
                    retVal.StateID = Convert.ToInt32(dr["StateID"]);
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                    retVal.ZipCode = Convert.ToString(dr["ZipCode"]);
                    retVal.Phone = Convert.ToString(dr["Phone"]);
                    retVal.Fax = Convert.ToString(dr["Fax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.RegisterDate = Convert.ToDateTime(dr["RegisterDate"]);
                    retVal.IsWantReciveMail = Convert.ToBoolean(dr["IsWantReciveMail"]);
                    retVal.LastRestaurantId = dr["LastRestaurantId"] != DBNull.Value ? Convert.ToInt32(dr["LastRestaurantId"]) : 0;
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
        public static MemberInfo GetInfo(string userName, string password, bool encrypt)
        {
            MemberInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", userName);
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
                    retVal = new MemberInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]);
                    retVal.Birthday = Convert.ToDateTime(dr["Birthday"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.CountryID = Convert.ToInt32(dr["CountryID"]);
                    retVal.StateID = Convert.ToInt32(dr["StateID"]);
                    retVal.CityID = Convert.ToInt32(dr["CityID"]);
                    retVal.ZipCode = Convert.ToString(dr["ZipCode"]);
                    retVal.Phone = Convert.ToString(dr["Phone"]);
                    retVal.Fax = Convert.ToString(dr["Fax"]);
                    retVal.Status = Convert.ToInt32(dr["Status"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    retVal.RegisterDate = Convert.ToDateTime(dr["RegisterDate"]);
                    retVal.IsWantReciveMail = Convert.ToBoolean(dr["IsWantReciveMail"]);
                    retVal.LastRestaurantId = dr["LastRestaurantId"] != DBNull.Value ? Convert.ToInt32(dr["LastRestaurantId"]) : 0;
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static int Insert(MemberInfo memberInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", memberInfo.UserName);
            dbCmd.Parameters.AddWithValue("@Password", MD5.Encrypt(memberInfo.Password));
            dbCmd.Parameters.AddWithValue("@Email", memberInfo.Email);
            dbCmd.Parameters.AddWithValue("@FirstName", memberInfo.FirstName);
            dbCmd.Parameters.AddWithValue("@LastName", memberInfo.LastName);
            dbCmd.Parameters.AddWithValue("@Address", memberInfo.Address);
            dbCmd.Parameters.AddWithValue("@Gender", memberInfo.Gender);
            dbCmd.Parameters.AddWithValue("@Phone", memberInfo.Phone);
            dbCmd.Parameters.AddWithValue("@Birthday", memberInfo.Birthday);
            dbCmd.Parameters.AddWithValue("@CountryID", memberInfo.CountryID);
            dbCmd.Parameters.AddWithValue("@StateID", memberInfo.StateID);
            dbCmd.Parameters.AddWithValue("@CityID", memberInfo.CityID);
            dbCmd.Parameters.AddWithValue("@ZipCode", memberInfo.ZipCode);
            dbCmd.Parameters.AddWithValue("@Fax", memberInfo.Fax);

            dbCmd.Parameters.AddWithValue("@IsWantReciveMail", memberInfo.IsWantReciveMail);

            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int UpdateMember(MemberInfo _memberInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", _memberInfo.ID);
            dbCmd.Parameters.AddWithValue("@Email", _memberInfo.Email);
            dbCmd.Parameters.AddWithValue("@FirstName", _memberInfo.FirstName);
            dbCmd.Parameters.AddWithValue("@LastName", _memberInfo.LastName);
            dbCmd.Parameters.AddWithValue("@Gender", _memberInfo.Gender);
             dbCmd.Parameters.AddWithValue("@Birthday", _memberInfo.Birthday);
             dbCmd.Parameters.AddWithValue("@Address", _memberInfo.Address);
             dbCmd.Parameters.AddWithValue("@CountryID", _memberInfo. CountryID);
             dbCmd.Parameters.AddWithValue("@StateID", _memberInfo.StateID);
             dbCmd.Parameters.AddWithValue("@CityID", _memberInfo.CityID);
             dbCmd.Parameters.AddWithValue("@Zipcode", _memberInfo.ZipCode);
             dbCmd.Parameters.AddWithValue("@Phone", _memberInfo.Phone);
             dbCmd.Parameters.AddWithValue("@IsActive", _memberInfo.IsActive);
             dbCmd.Parameters.AddWithValue("@Fax", _memberInfo.Fax);
             dbCmd.Parameters.AddWithValue("@IsWantReciveMail", _memberInfo.IsWantReciveMail);
            try
            {
                dbConn.Open();
                int ret = dbCmd.ExecuteNonQuery();
                return ret;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static MemberInfo GetByMemberID(int memberID)
        {
            MemberInfo reval = new MemberInfo();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetByMemberID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
            try
            {
                dbConn.Open();

                SqlDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    reval.ID = reader.GetInt32(0);
                    //reval.UserName =Convert.ToString( reader.GetInt32(1));
                    reval.Email = reader.GetString(3);
                    reval.FirstName = reader.GetString(4);
                    reval.LastName = reader.GetString(5);
                    reval.Gender = reader.GetString(6);
                    reval.Birthday =reader.GetDateTime(7);
                    reval.Address = reader.GetString(8);
                    reval.CountryID =reader.GetInt32(9);
                    reval.StateID = reader.GetInt32(10);
                    reval.CityID = reader.GetInt32(11);
                    reval.ZipCode = reader.GetString(12);
                    reval.Phone = reader.GetString(13);
                    reval.Fax = reader.GetString(14);
                    reval.Status = reader.GetInt32(15);
                    reval.IsActive =reader.GetBoolean(16);
                    reval.IsWantReciveMail = reader.GetBoolean(18);
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            finally
            {
                dbConn.Close();
            }
            return reval;
        }
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetAll", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
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
        public static int GetLastRestaurantId(int memberId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetLastRestaurantId", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberId);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    return Convert.ToInt32(dr["Id"]);
                }
            }
            finally
            {
                dbConn.Close();
            }
            return 0;
        }
        public static int UpdateLastRestaurantId(int memberId, int restaurantId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_UpdateLastRestaurantId", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberId);
            dbCmd.Parameters.AddWithValue("@RestaurantId", restaurantId);
            try
            {
                dbConn.Open();
                int ret = dbCmd.ExecuteNonQuery();
                return ret;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static int UpdateIsActive(MemberInfo _memberInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_UpdateIsActive", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", _memberInfo.ID);
            dbCmd.Parameters.AddWithValue("@IsActive", _memberInfo.IsActive);
            try
            {
                dbConn.Open();
                int ret = dbCmd.ExecuteNonQuery();
                return ret;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static void ChangePassword(int memberID, string newPassword)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_ChangePassword", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
            dbCmd.Parameters.AddWithValue("@Password", MD5.Encrypt(newPassword));
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
        public static void DeleteMember(int memberID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
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
        public static DataTable SearchMember(string keyword, string active, int pageIndex, int pageSize, ref int total)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_Search", dbConn);
            dbCmd.Parameters.AddWithValue("@keyword", keyword);
            dbCmd.Parameters.AddWithValue("@isActive", active);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.Add("@Total", SqlDbType.Int).Direction = ParameterDirection.Output;

            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                total = Convert.ToInt32(dbCmd.Parameters["@Total"].Value);
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

        public static MemberInfo GetByUserName(string usename)
        {
            MemberInfo reval = new MemberInfo();
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Member_GetByUserName", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@User", usename);
            try
            {
                dbConn.Open();

                SqlDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    reval.ID = reader.GetInt32(0);
                    //reval.UserName =Convert.ToString( reader.GetInt32(1));
                    reval.Email = reader.GetString(3);
                    reval.FirstName = reader.GetString(4);
                    reval.LastName = reader.GetString(5);
                    reval.Gender = reader.GetString(6);
                    reval.Birthday = reader.GetDateTime(7);
                    reval.Address = reader.GetString(8);
                    reval.CountryID = reader.GetInt32(9);
                    reval.StateID = reader.GetInt32(10);
                    reval.CityID = reader.GetInt32(11);
                    reval.ZipCode = reader.GetString(12);
                    reval.Phone = reader.GetString(13);
                    reval.Fax = reader.GetString(14);
                    reval.Status = reader.GetInt32(15);
                    reval.IsActive = reader.GetBoolean(16);
                    reval.IsWantReciveMail = reader.GetBoolean(18);
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
            finally
            {
                dbConn.Close();
            }
            return reval;
        }
    }
}
