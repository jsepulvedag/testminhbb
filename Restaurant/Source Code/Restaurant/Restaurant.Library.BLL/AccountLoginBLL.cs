using System;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class AccountLoginBLL
    {
        public static AccountLoginInfo GetInfo(string username, string password, bool encrypt)
        {
                return AccountLoginDAL.GetInfo(username, password, encrypt);
        }
    }
}
