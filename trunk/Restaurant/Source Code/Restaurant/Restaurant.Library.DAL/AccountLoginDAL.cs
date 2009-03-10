using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Library.DAL
{
    public class AccountLoginDAL
    {
        public static AccountLoginInfo GetInfo(string userName, string password, bool encrypt)
        {
            AccountLoginInfo retVal = null;

            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("AccountLogin_GetInfo", dbConn);
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
                    retVal = new AccountLoginInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.UserName = Convert.ToString(dr["UserName"]);
                    retVal.Password = Convert.ToString(dr["Password"]);
                    retVal.FullName = Convert.ToString(dr["FullName"]);
                    retVal.Type = Convert.ToInt32(dr["Type"]);
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
