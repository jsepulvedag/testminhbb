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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.BLL;
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Management.Restaurant.Order
{
    public partial class OrderParameter : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParam();
            }
        }
        private void BindParam()
        {
            gvOrderParameter.DataSource = RestaurantDeliveryParamBLL.GetAll_ByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
            gvOrderParameter.DataBind();
            if (gvOrderParameter.Rows.Count > 0)
            {
                OnSetDeliveryParam(SelectedRow(0));
            }
        }
        private RestaurantDeliveryParamInfo SelectedRow(int index)
        {
            RestaurantDeliveryParamInfo obj = new RestaurantDeliveryParamInfo();
            GridViewRow row = gvOrderParameter.Rows[index];
            obj.MinimumPrice = Convert.ToInt16(row.Cells[0].Text.Trim());
            return obj;
        }
        private void OnSetDeliveryParam(RestaurantDeliveryParamInfo obj)
        {
            txtMinPrice.Text = obj.MinimumPrice.ToString();
        }
        private RestaurantDeliveryParamInfo OnSetDeliveryParam()
        {
            RestaurantDeliveryParamInfo obj = new RestaurantDeliveryParamInfo();
            obj.MinimumPrice = Convert.ToInt32(txtMinPrice.Text.Trim());
            obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
            return obj;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                RestaurantDeliveryParamBLL.Update(OnSetDeliveryParam());
                BindParam();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}