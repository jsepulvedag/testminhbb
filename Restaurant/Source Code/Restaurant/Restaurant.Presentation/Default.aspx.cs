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
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Library.Entities;
using Restaurant.Presentation.Library.Sercurity.Base;
namespace Restaurant.Presentation
{
    public partial class _Default : AuthenticatePage// System.Web.UI.Page
    {
        private Restaurant.Presentation.Library.PageEnvironment env;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
            env = new Restaurant.Presentation.Library.PageEnvironment(Server.MapPath(PageConstant.PAGE_XML_FILE_CONFIG));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] != null)
            {
                aphMain.Controls.Add(LoadControl(env.Controls[Request.QueryString["pid"].ToLower()].ToString()));
            }
            else
            {
                aphMain.Controls.Add(LoadControl(env.Controls["home"].ToString()));
            }            
        }    
    }
}
