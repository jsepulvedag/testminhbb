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
using Restaurant.Presentation.Management.Restaurant.UserControls;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Library;
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;

namespace Restaurant.Presentation.Management.UserControls
{
    public partial class Address : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool flag = (Authentication.CurrentAccountLogin.Type == PageConstant.MEMBER)?true:false;
            LoadScript(flag);
            if (!IsPostBack)
            {
                if (Authentication.CurrentAccountLogin.Type == PageConstant.RESTAURANT)
                {
                    lblName.Text = Authentication.CurrentRestaurantInfo.Name + " Restaurant";
                    lblAddress.Text = (Authentication.CurrentRestaurantInfo.Address != null && Authentication.CurrentRestaurantInfo.Address != "")?"Address: " + Authentication.CurrentRestaurantInfo.Address : "";
                    RestaurantAllowServiceInfo activeService = RestaurantAllowServiceBLL.GetInfo_ByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
                    if (activeService.AllowGiftCertificate && activeService.AllowOnlineOrder)
                    {
                        if (activeService.RestaurantSettingGiftParameter && activeService.RestaurantSettingOrderParameter)
                        {
                            lblAlert.Text = "";
                        }
                        else if (!activeService.RestaurantSettingGiftParameter && !activeService.RestaurantSettingOrderParameter)
                        {
                            lblAlert.Text = "Alert: Your restaurant need setting gift pamameter and order parameter for member user services";
                        }
                    }
                    else if (activeService.AllowGiftCertificate && !activeService.AllowOnlineOrder)
                    {
                        if (!activeService.RestaurantSettingGiftParameter)
                        {
                            lblAlert.Text = "Alert: Your restaurant need setting gift pamameter for member use GiftService";
                        }
                        else
                        {
                            lblAlert.Text = "";
                        }
                    }
                    else if (activeService.AllowOnlineOrder && !activeService.AllowGiftCertificate)
                    {
                        if (!activeService.RestaurantSettingOrderParameter)
                        {
                            lblAlert.Text = "Alert: Your restaurant need setting order pamameter for member use GiftService";
                        }
                        else
                        {
                            lblAlert.Text = "";
                        }
                    }
                    else
                    {
                        lblAlert.Text = "";
                    }
                }
            }
        }
        private void LoadScript(bool flag)
        {
            ltrScript.Text += "<script language=javascript>";
            ltrScript.Text += "checkAddress('" + flag + "')";
            ltrScript.Text += "</script>";
        }
    }
}