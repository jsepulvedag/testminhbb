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

namespace Restaurant.Presentation.Home.Member.Video
{
    public partial class VideoManagement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // videoID=  ;
                BindVideo(2);
            }
        }
        public void BindVideo(int videoID)
        {
            DataTable tbl = VideoBLL.GetByVideoID(videoID);
            dtlVideo.DataSource = tbl;
            dtlVideo.DataBind();
        }
    }
}