using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Library.DAL
{
    public class AdminDAL
    {
        public static DataTable GetAll()
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_GetAll", dbConn);
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
        public static bool Delete(int iD)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", iD);
            try
            {
                dbConn.Open();
                int retVal = dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    throw new Exception(AppEnv.DELETED_FAILURE);
                }
                return true;
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
        public static int Insert(AdminInfo adminInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", adminInfo.UserName);
            dbCmd.Parameters.AddWithValue("@Password", MD5.Encrypt(adminInfo.Password));
            dbCmd.Parameters.AddWithValue("@FirstName", adminInfo.FirstName);
            dbCmd.Parameters.AddWithValue("@LastName", adminInfo.LastName);
            dbCmd.Parameters.AddWithValue("@BirthDate", adminInfo.BirthDate);
            dbCmd.Parameters.AddWithValue("@MobilePhone", adminInfo.MobilePhone);
            dbCmd.Parameters.AddWithValue("@HomePhone", adminInfo.HomePhone);
            dbCmd.Parameters.AddWithValue("@Gender", adminInfo.Gender);
            dbCmd.Parameters.AddWithValue("@Email", adminInfo.Email);
            dbCmd.Parameters.AddWithValue("@Address", adminInfo.Address);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                int retVal = (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
                if (retVal == -1)
                {
                    throw new Exception(AppEnv.USERNAME_EXIST);
                }
                else if (retVal == 0)
                {
                    throw new Exception(AppEnv.INSERTED_FAILURE);
                }
                return retVal;
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
        public static bool Update(AdminInfo adminInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_Update", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", adminInfo.ID);
            dbCmd.Parameters.AddWithValue("@FirstName", adminInfo.FirstName);
            dbCmd.Parameters.AddWithValue("@LastName", adminInfo.LastName);
            dbCmd.Parameters.AddWithValue("@BirthDate", adminInfo.BirthDate);
            dbCmd.Parameters.AddWithValue("@MobilePhone", adminInfo.MobilePhone);
            dbCmd.Parameters.AddWithValue("@HomePhone", adminInfo.HomePhone);
            dbCmd.Parameters.AddWithValue("@Gender", adminInfo.Gender);
            dbCmd.Parameters.AddWithValue("@Email", adminInfo.Email);
            dbCmd.Parameters.AddWithValue("@Address", adminInfo.Address);
            try
            {
                dbConn.Open();
                int retVal = dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    throw new Exception(AppEnv.UPDATEED_FAILURE);
                }
                return true;
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
        public static AdminInfo GetInfo(string userName, string password)
        {
            AdminInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@UserName", userName);
            dbCmd.Parameters.AddWithValue("@Password", MD5.Encrypt(password));
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new AdminInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    retVal.MobilePhone = Convert.ToString(dr["MobilePhone"]);
                    retVal.HomePhone = Convert.ToString(dr["HomePhone"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]);
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null) dr.Close();
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
         public static AdminInfo GetInfo(int id)
        {
            AdminInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Admin_GetInfoByID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new AdminInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.FirstName = Convert.ToString(dr["FirstName"]);
                    retVal.LastName = Convert.ToString(dr["LastName"]);
                    retVal.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                    retVal.MobilePhone = Convert.ToString(dr["MobilePhone"]);
                    retVal.HomePhone = Convert.ToString(dr["HomePhone"]);
                    retVal.Gender = Convert.ToString(dr["Gender"]).Trim();
                    retVal.Email = Convert.ToString(dr["Email"]);
                    retVal.Address = Convert.ToString(dr["Address"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null) dr.Close();
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
    }
}
