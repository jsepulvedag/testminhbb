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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Management.Restaurant.UserControls;

namespace Restaurant.Presentation.Management.Restaurant.ListRestaurant
{
    public partial class ListRestaurant : CheckRestaurant
    {
        public int GetMemberID
        {
            get
            {
                return Authentication.CurrentMemberInfo.ID;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RestaurantBLL.GetByMemberID(GetMemberID).Rows.Count > 0)
                {
                    repeaterListRestaurant.DataSource = RestaurantBLL.GetByMemberID(10);
                    repeaterListRestaurant.DataBind();
                    Response.Write("not mess");
                }
                else
                {
                    Response.Write("Error");
                }
            }
        }
    }
}