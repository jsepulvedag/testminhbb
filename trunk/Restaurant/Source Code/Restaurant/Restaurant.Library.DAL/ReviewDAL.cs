using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.DAL
{
    public class ReviewDAL
    {
        public static DataTable MemberListReview(int memberID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_MyReview", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
            
            retVal = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }

            return retVal;
        }

        public static string[] GetRatingByRestaurant(int restaurantId)
        {
            string[] retVal = new string[4];
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetRatingByRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantId);

            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(dt);

                retVal[0] = dt.Rows[0]["FoodPoint"].ToString();
                retVal[1] = dt.Rows[0]["PricePoint"].ToString();
                retVal[2] = dt.Rows[0]["ServicePoint"].ToString();
                retVal[3] = dt.Rows[0]["DecorPoint"].ToString();
            }
            finally
            {
                dbConn.Close();
            }

            return retVal;
        }

        public static int GetCountByRestaurant(int restaurantId)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetCountByRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantId", restaurantId);

            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(dt);
            }
            finally
            {
                dbConn.Close();
            }

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static DataTable GetByRestaurant(int restaurantID, int reviewID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetByRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
            dbCmd.Parameters.AddWithValue("@ReviewID", reviewID);
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

        public static ReviewInfo GetInfo(int _reviewID, int _restaurantID, int _memberID)
        {
            ReviewInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ReviewID", _reviewID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", _restaurantID);
            dbCmd.Parameters.AddWithValue("@MemberID", _memberID);

            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ReviewInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.RestaurantID = Convert.ToInt32(dr["RestaurantID"]);
                    retVal.MemberID = Convert.ToInt32(dr["MemberID"]);
                    retVal.Title = Convert.ToString(dr["Title"]);
                    retVal.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    retVal.RateFood = Convert.ToInt32(dr["RateFood"]);
                    retVal.RatePrice = Convert.ToInt32(dr["RatePrice"]);
                    retVal.RateService = Convert.ToInt32(dr["RateService"]);
                    retVal.IsActive = Convert.ToInt32(dr["IsActive"]);
                    retVal.TableOrderService = Convert.ToString(dr["TableOrderService"]);
                    retVal.VisitAgain = Convert.ToString(dr["VisitAgain"]);
                    retVal.PartySize = Convert.ToString(dr["PartySize"]);
                    retVal.PriceRange = Convert.ToString(dr["PriceRange"]);
                    retVal.Description = Convert.ToString(dr["Description"]);
                    retVal.Age = Convert.ToString(dr["Age"]);
                    retVal.RateDecor=Convert.ToInt32(dr["RateDecor"]);
                }
                if (dr != null)
                    dr.Close();
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
        public static DataTable GetByAdmin(int filter)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetByAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;            
            dbCmd.Parameters.AddWithValue("@Filter", filter);
            //dbCmd.Parameters.AddWithValue("@pass", pass);
            retVal = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(dbCmd);
            da.Fill(retVal);
            dbConn.Close();
            return retVal;
        }
        public static DataTable GetByMemberRestaurant(int memberID, int reviewID, int restaurantID)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_GetByMemberRestaurant", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@MemberID", memberID);
            dbCmd.Parameters.AddWithValue("@ReviewID", reviewID);
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
        public static int Insert(ReviewInfo _reviewInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@RestaurantID", _reviewInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MemberID", _reviewInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@Title", _reviewInfo.Title);
            dbCmd.Parameters.AddWithValue("@CreatedDate", _reviewInfo.CreatedDate);
            dbCmd.Parameters.AddWithValue("@RateFood", _reviewInfo.RateFood);
            dbCmd.Parameters.AddWithValue("@RatePrice", _reviewInfo.RatePrice);
            dbCmd.Parameters.AddWithValue("@RateService", _reviewInfo.RateService);
            dbCmd.Parameters.AddWithValue("@IsActive", _reviewInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@TableOrderService", _reviewInfo.TableOrderService);
            dbCmd.Parameters.AddWithValue("@VisitAgain", _reviewInfo.VisitAgain);
            dbCmd.Parameters.AddWithValue("@PartySize", _reviewInfo.PartySize);
            dbCmd.Parameters.AddWithValue("@PriceRange", _reviewInfo.PriceRange);
            dbCmd.Parameters.AddWithValue("@Description", _reviewInfo.Description);
            //dbCmd.Parameters.AddWithValue("@Age", _reviewInfo.Age);
            dbCmd.Parameters.AddWithValue("@RateDecor", _reviewInfo.RateDecor);
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
        public static bool Update(ReviewInfo _reviewInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_UpdateByAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _reviewInfo.ID);
            dbCmd.Parameters.AddWithValue("@RestaurantID", _reviewInfo.RestaurantID);
            dbCmd.Parameters.AddWithValue("@MemberID", _reviewInfo.MemberID);
            dbCmd.Parameters.AddWithValue("@Title", _reviewInfo.Title);
            dbCmd.Parameters.AddWithValue("@CreatedDate", _reviewInfo.CreatedDate);
            dbCmd.Parameters.AddWithValue("@RateFood", _reviewInfo.RateFood);
            dbCmd.Parameters.AddWithValue("@RatePrice", _reviewInfo.RatePrice);
            dbCmd.Parameters.AddWithValue("@RateService", _reviewInfo.RateService);
            dbCmd.Parameters.AddWithValue("@IsActive", _reviewInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@TableOrderService", _reviewInfo.TableOrderService);
            dbCmd.Parameters.AddWithValue("@VisitAgain", _reviewInfo.VisitAgain);
            dbCmd.Parameters.AddWithValue("@PartySize", _reviewInfo.PartySize);
            dbCmd.Parameters.AddWithValue("@PriceRange", _reviewInfo.PriceRange);
            dbCmd.Parameters.AddWithValue("@Description", _reviewInfo.Description);
            //dbCmd.Parameters.AddWithValue("@Age", _reviewInfo.Age);
            dbCmd.Parameters.AddWithValue("@RateDecor", _reviewInfo.RateDecor);
            
            dbConn.Open();
            int retVal = dbCmd.ExecuteNonQuery();
            if (retVal <= 0)
            {
                throw new Exception(AppEnv.UPDATEED_FAILURE);
            }            
            dbConn.Close();
            return true;
        }
        public static bool Delete(int _reviewID)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Review_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", _reviewID);
            try
            {
                dbConn.Open();
                int retVal= dbCmd.ExecuteNonQuery();
                if (retVal <= 0)
                {
                    throw new Exception(AppEnv.DELETED_FAILURE);
                }
                return true;
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}
