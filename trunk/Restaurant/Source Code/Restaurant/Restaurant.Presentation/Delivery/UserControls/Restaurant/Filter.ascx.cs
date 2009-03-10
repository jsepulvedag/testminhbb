using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities.DataBinder;
using System.Drawing;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity.Base;

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class Filter : System.Web.UI.UserControl
    {
        #region Properties
        string urlCuisine = "0";
        string urlFee = "-1";
        string urlMinimumPrice = "0";
        string urlScore = "";
        string urlDelivery = "";
        private string GetCityID
        {
            get
            {
                return Request.QueryString["cityId"].ToString() != null ? Request.QueryString["cityId"].ToString() : "0";
            }
        }
        private string GetCuisineID
        {
            get
            {
                //Request.Url.PathAndQuery
                string str = Request.Url.Query;

                if (Request.Url.PathAndQuery.Contains("&CuisineID="))
                {
                    return Request.QueryString["CuisineID"] != null ? Request.QueryString["CuisineID"].ToString() : "0";
                }
                else
                {
                    return "0";
                }
            }
        }
        private string GetFee
        {
            get
            {
                //Request.Url.PathAndQuery
                string str = Request.Url.Query;

                if (Request.Url.PathAndQuery.Contains("&Fee="))
                {
                    return Request.QueryString["Fee"] != "-1" ? Request.QueryString["Fee"].ToString() : "-1";
                }
                else
                {
                    return "-1";
                }
            }
            
        }
        private string GetMinimumPrice
        {
            get
            {
                //Request.Url.PathAndQuery
                string str = Request.Url.Query;

                if (Request.Url.PathAndQuery.Contains("&MinimumPrice="))
                {
                    return Request.QueryString["MinimumPrice"] != "0" ? Request.QueryString["MinimumPrice"].ToString() : "0";
                }
                else
                {
                    return "0";
                }
            }
        }
        private string GetRating
        {
            get
            {
                //Request.Url.PathAndQuery
                string str = Request.Url.Query;

                if (Request.Url.PathAndQuery.Contains("&Score="))
                {
                    return Request.QueryString["Score"] != null ? Request.QueryString["Score"].ToString() : "";
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCuisine();
                BindDelivery();
                BindMinimumOrder();
                BindRating();
            }
        }
        private string UnCheckURL(string urlSelect)
        {
            urlCuisine= urlSelect == "urlCuisine" ? "0":GetCuisineID;
            urlFee= urlSelect == "urlFee" ? "-1" : GetFee;
            urlMinimumPrice= urlSelect == "urlMinimumPrice" ? "0" : GetMinimumPrice;
            urlScore= urlSelect == "urlScore" ? "" : GetRating;
           
            urlDelivery = PageConstant.HOME_DELIVERY_URL + "&cityId=" +GetCityID + "&CuisineID=" + urlCuisine + "&Fee=" + urlFee + "&MinimumPrice=" + urlMinimumPrice + "&Score=" + urlScore;
            
            return urlDelivery;
        }
        private string CheckURL(string urlSelect, string valueSelect)
        {
            urlCuisine= urlSelect == "urlCuisine" ? valueSelect:GetCuisineID;
            urlFee= urlSelect == "urlFee" ? valueSelect : GetFee;
            urlMinimumPrice= urlSelect == "urlMinimumPrice" ? valueSelect : GetMinimumPrice;
            urlScore= urlSelect == "urlScore" ? valueSelect : GetRating;
           
            urlDelivery = PageConstant.HOME_DELIVERY_URL + "&cityId=" +GetCityID + "&CuisineID=" + urlCuisine + "&Fee=" + urlFee + "&MinimumPrice=" + urlMinimumPrice + "&Score=" + urlScore;
            
            return urlDelivery;
        }
        #region Bind data
        private void BindCuisine()
        {
            rptRestaurantInCuisine.DataSource = CuisineBLL.GetAllForHome();
            rptRestaurantInCuisine.DataBind();
        }
        private void BindDelivery()
        {
            string[] freename ={ "Fee", "No Fee" };
            string[] freeid ={ "1", "0" };
            rptDeliveryFee.DataSource = Utility.CreateTable(freename, freeid);
            rptDeliveryFee.DataBind();
        }
        private void BindMinimumOrder()
        {
            string[] minimum ={ "$5 and under", "$10 and under", "$15 and under", "$20 and under" };
            string[] order ={ "5", "10", "15", "20" };
            rptMinimumOrder.DataSource = Utility.CreateTable(minimum, order);
            rptMinimumOrder.DataBind();
        }
        private void BindRating()
        {
            string url = "~/Media/Delivery/";
            string[] values = new string[] { url + "5Star.jpg", url + "4Star.jpg", url + "3Star.jpg", url + "2Star.jpg" };
            string[] ids = new string[] { "5", "4", "3", "2" };

            rptRating.DataSource = Utility.CreateTable(values, ids);
            rptRating.DataBind();
        }
        #endregion

        #region Event
        protected void rptRestaurantInCuisine_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectCuisine")
            {
                urlDelivery = CheckURL("urlCuisine",e.CommandArgument.ToString());
                Response.Redirect(urlDelivery);
            }
            else
            {
                if (e.CommandName == "UnSelectCuisine")
                {
                    //LinkButton lnkCuisine = (LinkButton)e.Item.FindControl("lnkCuisine");
                    //lnkCuisine.BackColor = Color.Empty;
                    //lnkCuisine.CommandName = "lnkCuisine";

                    urlDelivery = UnCheckURL("urlCuisine");
                    Response.Redirect(urlDelivery);
                }
            }
        }
        protected void rptDeliveryFee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectDelivery")
            {
                urlDelivery = CheckURL("urlFee", e.CommandArgument.ToString());
                Response.Redirect(urlDelivery);
            }
            else
            {
                if (e.CommandName == "UnSelectDelivery")
                {
                    LinkButton lnkDeliveryFee = (LinkButton)e.Item.FindControl("lnkDeliveryFee");
                    lnkDeliveryFee.BackColor = Color.Empty;
                    lnkDeliveryFee.CommandName = "SelectDelivery";
                    
                    urlDelivery = UnCheckURL("urlFee");
                    Response.Redirect(urlDelivery);
                }
            }
        }
        protected void rptMinimumOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectMinimumOrder")
            {
                urlDelivery = CheckURL("urlMinimumPrice", e.CommandArgument.ToString());
                Response.Redirect(urlDelivery);
            }
            else
            {
                if (e.CommandName == "UnSelectMinimumOrder")
                {
                    string _urlCuisine = "0", _urlFee = "-1";
                    LinkButton lnkMinimumOrder = (LinkButton)e.Item.FindControl("lnkMinimumOrder");
                    lnkMinimumOrder.BackColor = Color.Empty;
                    lnkMinimumOrder.CommandName = "SelectMinimumOrder";
                    
                    urlDelivery = UnCheckURL("urlMinimumPrice");
                    Response.Redirect(urlDelivery);
                }
            }
        }
        protected void rptRating_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SelectRating")
            {
                urlDelivery = CheckURL("urlScore", e.CommandArgument.ToString());
                Response.Redirect(urlDelivery);

            }
            else
            {
                if (e.CommandName == "UnSelectRating")
                {
                    ImageButton lnkRating = (ImageButton)e.Item.FindControl("lnkRating");
                    lnkRating.BackColor = Color.Empty;
                    lnkRating.CommandName = "SelectRating";
                   
                    urlDelivery = UnCheckURL("urlScore");
                    Response.Redirect(urlDelivery);
                }
            }
        }

        #endregion

        #region Item Databound
        protected void rptRestaurantInCuisine_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if ((GetCuisineID != "") && (drv["ID"].ToString().Equals(GetCuisineID)))
            {
                LinkButton lnkCuisine = (LinkButton)e.Item.FindControl("lnkCuisine");

                lnkCuisine.BackColor = Color.Yellow;
                lnkCuisine.Text += " x";
                lnkCuisine.CommandName = "UnSelectCuisine";
            }
        }
        protected void rptDeliveryFee_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if ((GetFee != "-1") && (drv["value"].ToString().Equals(GetFee)))
            {
                LinkButton lnkDeliveryFee = (LinkButton)e.Item.FindControl("lnkDeliveryFee");
                lnkDeliveryFee.BackColor = Color.Yellow;
                lnkDeliveryFee.CommandName = "UnSelectDelivery";
            }
        }
        protected void rptMinimumOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if ((GetMinimumPrice != "") && (drv["value"].ToString().Equals(GetMinimumPrice)))
            {
                LinkButton lnkMinimumOrder = (LinkButton)e.Item.FindControl("lnkMinimumOrder");
                lnkMinimumOrder.BackColor = Color.Yellow;
                lnkMinimumOrder.CommandName = "UnSelectMinimumOrder";
            }
        }
        protected void rptRating_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if ((GetRating != "") && (drv["value"].ToString().Equals(GetRating)))
            {
                Label lblAndUp = (Label)e.Item.FindControl("lblAndUp");
                lblAndUp.ForeColor = Color.Red;
                lblAndUp.Visible = true;
            }
        }
        #endregion
    }
}