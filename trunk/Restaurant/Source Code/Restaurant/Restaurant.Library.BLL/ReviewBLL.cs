using System;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;

namespace Restaurant.Library.BLL
{
    public class ReviewBLL
    {
        #region GetAll, GetInfo
        public static int GetCountByRestaurant(int restaurantId)
        {
            return ReviewDAL.GetCountByRestaurant(restaurantId);
        }
        public static DataTable GetByRestaurant(int restaurantID, int reviewID)
        {
            return ReviewDAL.GetByRestaurant(restaurantID, reviewID);
        }
        public static string[] GetRatingByRestaurant(int restaurantID)
        {
            return ReviewDAL.GetRatingByRestaurant(restaurantID);
        }
        public static ReviewInfo GetInfo(int reviewID, int restaurantID, int memberID)
        {
            return ReviewDAL.GetInfo(reviewID, restaurantID, memberID);
        }
        public static DataTable GetByMemberRestaurant(int memberID, int reviewID, int restaurantID)
        {
            return ReviewDAL.GetByMemberRestaurant(memberID, reviewID, restaurantID);
        }
        public static DataTable GetByAdmin(int filter)
        {
            return ReviewDAL.GetByAdmin(filter);
        }
        public static DataTable MemberListReview(int memberID)
        {
            return ReviewDAL.MemberListReview(memberID);
        }
        #endregion

        #region Insert, Update, Delete
        public static int Insert(ReviewInfo reviewInfo)
        {
            try
            {
                return ReviewDAL.Insert(reviewInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Update(ReviewInfo reviewInfo)
        {
            return ReviewDAL.Update(reviewInfo);
        }
        public static bool Delete(int reviewID)
        {
            return ReviewDAL.Delete(reviewID);
        }
        #endregion
    }
}
