using System;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;

namespace Restaurant.Library.BLL
{
    public class MemberBLL
    {
        public static MemberInfo GetInfo(string userName)
        {
            return MemberDAL.GetInfo(userName);
        }
        public static MemberInfo GetInfo_Email(string email)
        {
            return MemberDAL.GetInfo_Email(email);
        }
        public static int Insert(MemberInfo userInfo)
        {
                return MemberDAL.Insert(userInfo);
        }
        public static MemberInfo GetInfo(int memberId)
        {
            return MemberDAL.GetInfo(memberId);
        }
        public static MemberInfo GetInfo(string userName, string password,bool encrypt)
        {
                return MemberDAL.GetInfo(userName, password,encrypt);
        }
        public static int UpdateMember(MemberInfo _memberInfo)
        {
            return MemberDAL.UpdateMember(_memberInfo);
        }
        public static int UpdateIsActive(MemberInfo _memberInfo)
        {
            return MemberDAL.UpdateIsActive(_memberInfo);
        }
        public static int GetLatestRestaurantId(int memberId)
        {
            return MemberDAL.GetLastRestaurantId(memberId);
        }
        public static int UpdateLastRestaurantId(int memberId, int restaurantId)
        {
            return MemberDAL.UpdateLastRestaurantId(memberId, restaurantId);
        }
        public static MemberInfo GetByMemberID(int memberID)
        {
            return MemberDAL.GetByMemberID(memberID);
        }
        public static MemberInfo GetByUserName(string usename)
        {
            return MemberDAL.GetByUserName(usename);
        }
        public static DataTable GetAll()
        {
            return MemberDAL.GetAll();
        }
        public static void DeleteMember(int memberID)
        {
           MemberDAL.DeleteMember(memberID);
           
        }
        public static DataTable SearchMember(string keyword, string active, int pageIndex, int pageSize, ref int total)
        {
            return MemberDAL.SearchMember(keyword, active, pageIndex, pageSize, ref  total);
        }
        public static void ChangePassword(int memberID, string newPassword)
        {
            MemberDAL.ChangePassword(memberID, newPassword);
        }
    }
}
