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
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Delivery.UserControls.Common
{
    public partial class Header : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControls();
           
        }
        void InitControls()
        {
            lnkBtnHome.NavigateUrl = "~/Delivery/Default.aspx";
            if (Authentication.IsLogined && Authentication.CurrentAccountLogin != null)
            {
                lblHi.Text = "Welcome, " + Authentication.CurrentAccountLogin.FullName + "!";
                lnkBtnCreateAccount.Visible = false;
                lnkBtnSignIN.Text = "Logout |";
                lnkBtnSignIN.NavigateUrl = "~/Delivery/Default.aspx?did=Logout";
            }
            else
            {

                lnkBtnCreateAccount.NavigateUrl = "~/Delivery/Default.aspx?did=Register";
                lnkBtnSignIN.NavigateUrl = "~/Delivery/Default.aspx?did=Login";
            }
        }
        protected void imgPrevious_Click1(object sender, ImageClickEventArgs e)
        {
            txtAddress.Visible = false;
            txtZipCode.Visible = false;
            imgAddress.Visible = false;
            imgZipcode.Visible = false;
            lbAddress.Visible = true;
            lbZipCode.Visible = true;
            imgNext.Visible = true;
            imgPrevious.Visible = false;
        }

        protected void imgNext_Click1(object sender, ImageClickEventArgs e)
        {
            txtAddress.Visible = true;
            txtZipCode.Visible = true;
            imgAddress.Visible = true;
            imgZipcode.Visible = true;
            lbAddress.Visible = false;
            lbZipCode.Visible = false;
            imgNext.Visible = false;
            imgPrevious.Visible = true;
        }

        protected void imgSearch_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Cookies["Visitor"]["Address"] = txtAddress.Text;
            Response.Cookies["Visitor"]["ZipCode"] = txtZipCode.Text;
            Response.Cookies["Visitor"].Expires = DateTime.Now.AddDays(1);
        }
    }
}