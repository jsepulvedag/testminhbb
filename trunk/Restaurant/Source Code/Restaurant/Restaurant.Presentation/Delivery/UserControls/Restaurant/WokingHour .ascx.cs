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

namespace Restaurant.Presentation.Delivery.UserControls.Restaurant
{
    public partial class WokingHour : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            BindOrderTime();

        }
        void BindOrderTime()
        {
           // int restaurantID = Convert.ToInt32(Request.QueryString["restaurantID"]);
            rptOrderTime.DataSource = BusinessTimeBLL.GetHoursByRestaurant(12);
            rptOrderTime.DataBind();
        }
        public static string HourFormat(int hour)
        {
            if (hour == -1)
                return "closed";
            if (hour < 13)
                return hour.ToString() + " am";
            else
                return (hour - 12).ToString() + " pm";
           
        }
        protected void rptOrderTime_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltDayOfWeek = (Literal)e.Item.FindControl("ltDayOfWeek");
                Literal ltBusinessHour = (Literal)e.Item.FindControl("ltBusinessHour");
                Literal ltDeliveryHour = (Literal)e.Item.FindControl("ltDeliveryHour");

                DataRowView drv = (DataRowView)e.Item.DataItem;
                int day = Convert.ToInt32( drv["DayOfWeek"]);
                ltDayOfWeek.Text = DayOfWeek(day);
                ltBusinessHour.Text = HourFormat(Convert.ToInt32( drv["BusinessStart"])) + " - " +
                                        HourFormat(Convert.ToInt32(drv["BusinessEnd"]));
                ltDeliveryHour.Text = HourFormat(Convert.ToInt32(drv["DeliveryStart"])) + " - " +
                                        HourFormat(Convert.ToInt32(drv["DeliveryEnd"]));

                ltBusinessHour.Text = ltBusinessHour.Text.Replace(" - closed", "");
                ltDeliveryHour.Text = ltDeliveryHour.Text.Replace(" - closed", "");
            }
        }
        private string DayOfWeek(int day)
        {
            switch (day)
            { 
                case 1: 
                    return "Sun" ;
                case 2:
                    return "Mon";
                case 3:
                    return "Tue";
                case 4:
                    return "Wed";
                case 5:
                    return "Thu";
                case 6:
                    return "Fri";
                case 7:
                    return "Sat";
                default: return " ";
            }
        }
    }
}