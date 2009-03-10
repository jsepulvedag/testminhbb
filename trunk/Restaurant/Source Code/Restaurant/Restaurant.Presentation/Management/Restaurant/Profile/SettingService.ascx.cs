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
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Management.Restaurant.Profile
{
    public partial class SettingService : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindActive();
            }
        }
        private void BindActive()
        {
            gvActive.DataSource = ActiveServiceBLL.GetInfoDetail_ByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
            gvActive.DataBind();
            if (gvActive.Rows.Count > 0)
            {
                OnSetActiveService(SelectedRow(0));
                CheckEnable();
            }
        }
        private void CheckEnable()
        {
            PackageInfo package = RestaurantBLL.GetPackage(Authentication.CurrentRestaurantInfo.ID);
            if (!package.AllowGiftCertificate)
            {
                rdGNo.Enabled = false;
                rdGYes.Enabled = false;
            }
            if (!package.AllowOnlineOrder)
            {
                rdONo.Enabled = false;
                rdOYes.Enabled = false;
            }
            if (!package.AllowReservation)
            {
                rdRNo.Enabled = false;
                rdRYes.Enabled = false;
            }
        }
        private void OnSetActiveService(ActiveServiceInfo obj)
        {
            rdGYes.Checked = obj.AllowGiftCertificate;
            rdGNo.Checked = !obj.AllowGiftCertificate;
            rdONo.Checked = !obj.AllowOnlineOrder;
            rdOYes.Checked = obj.AllowOnlineOrder;
            rdRNo.Checked = !obj.AllowOnlineReservation;
            rdRYes.Checked = obj.AllowOnlineReservation;
        }
        private ActiveServiceInfo OnSetActiveService()
        {
            ActiveServiceInfo obj = new ActiveServiceInfo();
            obj.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
            obj.AllowGiftCertificate = (rdGYes.Checked == true && rdGYes.Enabled) ? true : false;
            obj.AllowOnlineOrder = (rdOYes.Checked == true && rdOYes.Enabled) ? true : false;
            obj.AllowOnlineReservation = (rdRYes.Checked == true && rdOYes.Enabled) ? true : false;
            
            return obj;
        }
        private ActiveServiceInfo SelectedRow(int index)
        {
            ActiveServiceInfo obj = new ActiveServiceInfo();
            GridViewRow row = gvActive.Rows[index];
            obj.AllowGiftCertificate = (row.Cells[0].Text.Trim() == "Actived") ? true : false;
            obj.AllowOnlineOrder = (row.Cells[1].Text.Trim() == "Actived") ? true : false;
            obj.AllowOnlineReservation = (row.Cells[2].Text.Trim() == "Actived") ? true : false;

            return obj;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveServiceBLL.Update(OnSetActiveService());
                BindActive();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}