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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.BLL;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Delivery.UserControls.Common
{
    public partial class ChooseCity : System.Web.UI.UserControl
    {
        int ctID;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCity();
        }
        void BindCity()
        {
            
            Utility.BindingDropDowList(CityBLL.GetAll(ref ctID),drpCity);
            ListItem it= new ListItem("--All City--","0");
            drpCity.Items.Insert(0,it);

            drpCity.SelectedValue = ctID.ToString();
            if (Request.Url.PathAndQuery.Contains("cityId"))
            {
                drpCity.SelectedValue= Request.QueryString["cityId"].ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(PageConstant.HOME_DELIVERY_URL +"&cityId=" + drpCity.SelectedValue.ToString());
        }
    }
}