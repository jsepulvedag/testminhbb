using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Restaurant.Library.DAL;
using Restaurant.Library.Entities;


namespace Restaurant.Library.BLL
{
    public class RestaurantBLL
    {
        public static DataTable GetInfoByRestaurant(int restaurantID)
        {
            return RestaurantDAL.GetInfoByRestaurant(restaurantID);
        }
        public static DataTable GetName()
        {
            return RestaurantDAL.GetName();
        }
        public static PackageInfo GetPackage(int restaurantID)
        {
            return RestaurantDAL.GetPackage(restaurantID);
        }
        public static int Insert(RestaurantInfo restaurantInfo)
        {
            return RestaurantDAL.Insert(restaurantInfo);
        }
        public static bool Update(RestaurantInfo restaurantInfo)
        {
            return RestaurantDAL.Update(restaurantInfo);
        }
        public static RestaurantInfo GetInfo(string username, string password, bool encrypt)
        {
            return RestaurantDAL.GetInfo(username, password, encrypt);
        }
        public static RestaurantInfo GetInfo(int restaurantID)
        {
            return RestaurantDAL.GetInfo(restaurantID);
        }
        public static RestaurantInfo GetInfoByAdmin(int restaurantID)
        {
            return RestaurantDAL.GetInfoByAdmin(restaurantID);
        }
        public static DataTable GetAll()
        {
            return RestaurantDAL.GetAll();
        }
        public static NeighbourhoodInfo GetNeighbourhoodInfo(int restaurantID)
        {
            return RestaurantDAL.GetNeighbourhoodInfo(restaurantID);
        }
        public static DataTable ListByCriterias(string keyword, int cityId, int StateId, int countryId, string cuisineIds, int neighborhoodId, string zipCode, int pageIndex, int pageSize, ref int total)
        {
            //return RestaurantDAL.GetAll();
            DataTable retVal = RestaurantDAL.ListByCriterias(keyword, cityId, StateId, countryId, cuisineIds, neighborhoodId, zipCode, pageIndex, pageSize, ref total);

            retVal.Columns.Add("Neighbourhood");
            retVal.Columns.Add("Cuisine");
            retVal.Columns.Add("Review");
            retVal.Columns.Add("FoodPoint");
            retVal.Columns.Add("PricePoint");
            retVal.Columns.Add("ServicePoint");
            retVal.Columns.Add("DecorPoint");
            retVal.Columns.Add("Score");

            foreach (DataRow drRestaurant in retVal.Rows)
            {
                int restaurantId = Convert.ToInt32(drRestaurant["Id"]);

                string neighbourhood = "";
                DataTable dtNeighbourhood = GetNeighbourhood(restaurantId);
                foreach (DataRow drNeighbourhood in dtNeighbourhood.Rows)
                    neighbourhood += drNeighbourhood["Name"].ToString() + "<br>";

                string cuisine = "";
                DataTable dtCuisine = GetCuisine(restaurantId);
                foreach (DataRow drCuisine in dtCuisine.Rows)
                    cuisine += drCuisine["Name"].ToString() + "<br>";

                string[] rating = ReviewDAL.GetRatingByRestaurant(restaurantId);
                int food = rating[0] != "" ? Convert.ToInt32(rating[0]) : 0;
                int price = rating[1] != "" ? Convert.ToInt32(rating[1]) : 0;
                int service = rating[2] != "" ? Convert.ToInt32(rating[2]) : 0;
                int decor = rating[3] != "" ? Convert.ToInt32(rating[3]) : 0;
                float score = (float)(food + price + service + decor) / 4;

                drRestaurant["Neighbourhood"] = neighbourhood;
                drRestaurant["Cuisine"] = cuisine;
                drRestaurant["Review"] = ReviewBLL.GetCountByRestaurant(restaurantId);
                drRestaurant["FoodPoint"] = food != 0 ? food.ToString() : "-";
                drRestaurant["PricePoint"] = price != 0 ? price.ToString() : "-";
                drRestaurant["ServicePoint"] = service != 0 ? service.ToString() : "-";
                drRestaurant["DecorPoint"] = decor != 0 ? decor.ToString() : "-";
                drRestaurant["Score"] = score != 0 ? score.ToString("0.0") : "-";
            }

            return retVal;
        }
        public static DataTable Admin_ListByCriterias(string keyword, int cityId, int StateId, int countryId, string cuisineIds, string zipCode, int pageIndex, int pageSize, ref int total)
        {
            //return RestaurantDAL.GetAll();
            DataTable retVal = RestaurantDAL.Admin_ListByCriterias(keyword, cityId, StateId, countryId, cuisineIds, zipCode, pageIndex, pageSize, ref total);

            retVal.Columns.Add("Neighbourhood");
            retVal.Columns.Add("Cuisine");
            retVal.Columns.Add("Review");
            retVal.Columns.Add("FoodPoint");
            retVal.Columns.Add("PricePoint");
            retVal.Columns.Add("ServicePoint");
            retVal.Columns.Add("Score");

            foreach (DataRow drRestaurant in retVal.Rows)
            {
                int restaurantId = Convert.ToInt32(drRestaurant["Id"]);

                string neighbourhood = "";
                DataTable dtNeighbourhood = GetNeighbourhood(restaurantId);
                foreach (DataRow drNeighbourhood in dtNeighbourhood.Rows)
                    neighbourhood += drNeighbourhood["Name"].ToString() + "<br>";

                string cuisine = "";
                DataTable dtCuisine = GetCuisine(restaurantId);
                foreach (DataRow drCuisine in dtCuisine.Rows)
                    cuisine += drCuisine["Name"].ToString() + "<br>";

                string[] rating = ReviewBLL.GetRatingByRestaurant(restaurantId);
                int food = rating[0] != "" ? Convert.ToInt32(rating[0]) : 0;
                int price = rating[1] != "" ? Convert.ToInt32(rating[1]) : 0;
                int service = rating[2] != "" ? Convert.ToInt32(rating[2]) : 0;
                float score = (float)(food + price + service) / 3;

                drRestaurant["Neighbourhood"] = neighbourhood;
                drRestaurant["Cuisine"] = cuisine;
                drRestaurant["Review"] = ReviewBLL.GetCountByRestaurant(restaurantId);
                drRestaurant["FoodPoint"] = food != 0 ? food.ToString() : "-";
                drRestaurant["PricePoint"] = price != 0 ? price.ToString() : "-";
                drRestaurant["ServicePoint"] = service != 0 ? service.ToString() : "-";
                drRestaurant["Score"] = score != 0 ? score.ToString("0.0") : "-";
            }

            return retVal;
        }
        public static DataTable AddDataTable(DataRow[] foundRows)
        {
            int len = foundRows.Length;
            DataTable dt1 = new DataTable();
            DataColumn dc = new DataColumn();
            DataRow dr;
            int ColCnt = 0;
            foreach (DataRow r in foundRows)
            {
                foreach (DataColumn c in r.Table.Columns)
                {
                    dc = c;
                    dt1.Columns.Add(c);
                    ColCnt = r.Table.Columns.IndexOf(c);
                }
                //dt1.ImportRow(r);
            }
            dr = dt1.NewRow();
            dr[ColCnt] = dc;
            dt1.ImportRow(dr);
            return dt1;
        }
        public static DataTable DeliverySearch(string keyword, string cuisineId, string zipCode, string address,int cityId, int fee, int minimumPrice, string scoreUp, int pageSize, int pageIndex, ref int total)
        {

            DataTable retVal = RestaurantDAL.DeliverySearch(keyword, cuisineId, zipCode, address,cityId, fee, minimumPrice, pageSize, pageIndex, ref total);

            retVal.Columns.Add("Neighbourhood");
            retVal.Columns.Add("Cuisine");
            retVal.Columns.Add("Review");
            retVal.Columns.Add("FoodPoint");
            retVal.Columns.Add("PricePoint");
            retVal.Columns.Add("ServicePoint");
            retVal.Columns.Add("DecorPoint");
            retVal.Columns.Add("Score");

            foreach (DataRow drRestaurant in retVal.Rows)
            {
                int restaurantId = Convert.ToInt32(drRestaurant["Id"]);

                string neighbourhood = "";
                DataTable dtNeighbourhood = GetNeighbourhood(restaurantId);
                foreach (DataRow drNeighbourhood in dtNeighbourhood.Rows)
                    neighbourhood += drNeighbourhood["Name"].ToString() + "<br>";

                string cuisine = "";
                DataTable dtCuisine = GetCuisine(restaurantId);
                foreach (DataRow drCuisine in dtCuisine.Rows)
                    cuisine += drCuisine["Name"].ToString() + "<br>";

                string[] rating = ReviewDAL.GetRatingByRestaurant(restaurantId);
                int food = rating[0] != "" ? Convert.ToInt32(rating[0]) : 0;
                int price = rating[1] != "" ? Convert.ToInt32(rating[1]) : 0;
                int service = rating[2] != "" ? Convert.ToInt32(rating[2]) : 0;
                int decor = rating[3] != "" ? Convert.ToInt32(rating[3]) : 0;
                int score = Convert.ToInt32(Math.Round((double)(food + price + service + decor) / 4));

                drRestaurant["Neighbourhood"] = neighbourhood;
                drRestaurant["Cuisine"] = cuisine;
                drRestaurant["Review"] = ReviewBLL.GetCountByRestaurant(restaurantId);
                drRestaurant["FoodPoint"] = food != 0 ? food.ToString() : "-";
                drRestaurant["PricePoint"] = price != 0 ? price.ToString() : "-";
                drRestaurant["ServicePoint"] = service != 0 ? service.ToString() : "-";
                drRestaurant["DecorPoint"] = decor != 0 ? decor.ToString() : "-";
                drRestaurant["Score"] = score != 0 ? score.ToString() : "0";
            }
            if (scoreUp != "")
            {
                DataRow[] dr = retVal.Select("Score='" + scoreUp + "'");
                DataTable dt = new DataTable();
                dt = retVal.Clone();
                foreach (DataRow r in dr)
                {
                    //DataRow newrow = r;
                    if ( Convert.ToInt32(r["Score"].ToString()) >= Convert.ToInt32(scoreUp))
                    {
                        dt.ImportRow(r);
                    }
                }
                retVal=dt;
            }
            return retVal;            
        }

        public static string[] Rating(int restaurantId)
        {
            return ReviewDAL.GetRatingByRestaurant(restaurantId);
        }
        public static DataTable RestaurantDetail(int restaurantID)
        {
            return RestaurantDAL.RestaurantDetail(restaurantID);
        }
        public static DataTable GetDetail(int restaurantID)
        {
            return RestaurantDAL.GetDetail(restaurantID);
        }
        public static DataTable GetGoodFor(int restaurantID)
        {
            return RestaurantDAL.GetGoodFor(restaurantID);
        }
        public static DataTable GetAttire(int restaurantID)
        {
            return RestaurantDAL.GetAttire(restaurantID);
        }
        public static DataTable GetMusic(int restaurantID)
        {
            return RestaurantDAL.GetMusic(restaurantID);
        }
        public static DataTable GetCuisine(int restaurantID)
        {
            return RestaurantDAL.GetCuisine(restaurantID);
        }
        public static DataTable GetNeighbourhood(int restaurantID)
        {
            return RestaurantDAL.GetNeighbourhood(restaurantID);
        }
        public static DataTable GetSpecial(int restaurantID)
        {
            return RestaurantDAL.GetSpecial(restaurantID);
        }
        public static DataTable GetAtmosphere(int restaurantID)
        {
            return RestaurantDAL.GetAtmosphere(restaurantID);
        }
        public static DataTable GetByMemberID(int memberID)
        {
            return RestaurantDAL.GetByMemberID(memberID);
        }
        public static void UpdateMainPhoto(int restaurantID, string image)
        {
            RestaurantDAL.UpdateMainPhoto(restaurantID, image);
        }
        public static RestaurantInfo GetInfo_ByGiftID(int giftID)
        {
            return RestaurantDAL.GetInfo_ByGiftID(giftID);
        }
    }
}
