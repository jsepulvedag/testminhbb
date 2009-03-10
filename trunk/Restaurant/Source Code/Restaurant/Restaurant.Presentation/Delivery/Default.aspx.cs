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

namespace Restaurant.Presentation.Delivery
{
    public partial class Default : AuthenticatePage
    {
        private Restaurant.Presentation.Library.PageEnvironment env;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            env = new Restaurant.Presentation.Library.PageEnvironment(Server.MapPath(PageConstant.DELIVERY_XML_FILE_CONFIG));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["did"] != null)
            {
                aphDelivery.Controls.Add(LoadControl(env.Controls[Request.QueryString["did"].ToLower()].ToString()));
            }
            else
            {
                aphDelivery.Controls.Add(LoadControl(env.Controls["choosecity"].ToString()));
            }
        }
    }
}
