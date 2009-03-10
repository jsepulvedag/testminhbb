using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Restaurant.Library.BLL;
using Restaurant.Library.Utilities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Web.Mail;
using Restaurant.Library.Entities;
using Restaurant.Presentation.Library;
using Restaurant.Presentation.Library.Sercurity.Base;

namespace Restaurant.Presentation
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["payment_Amt"] = 20;
        }
    }
}
