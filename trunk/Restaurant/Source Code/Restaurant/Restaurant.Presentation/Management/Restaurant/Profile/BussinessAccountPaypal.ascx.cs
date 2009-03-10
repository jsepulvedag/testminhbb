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
using Restaurant.Library.Utilities;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Management.Restaurant.Profile
{
    public partial class BussinessAccountPaypal : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAccount();
            }
        }
        private void BindAccount()
        {
            gvPaypalAccount.DataSource = RestaurantBusinessAccountBLL.GetByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
            gvPaypalAccount.DataBind();
            if (gvPaypalAccount.Rows.Count > 0)
            { 
                GridViewRow row = gvPaypalAccount.Rows[0];
                txtUserName.Text = row.Cells[0].Text;
                txtPassword.Text = row.Cells[1].Text;
                txtSignature.Text = row.Cells[2].Text;
            }
        }
        private RestaurantBusinessAccountInfo OnSetAccount()
        {
            RestaurantBusinessAccountInfo obj = new RestaurantBusinessAccountInfo();
            obj.APIUserName = txtUserName.Text.Trim();
            obj.APIPassword = txtPassword.Text.Trim();
            obj.APISignature = txtSignature.Text.Trim();
            obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
            obj.SupplierPayment = PageConstant.SUPPLIER_PAYPAL;
            return obj;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                RestaurantBusinessAccountBLL.Update(OnSetAccount());
                BindAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RestaurantBusinessAccountBLL.Delete_ByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                BindAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex);
            }
        }
    }
}