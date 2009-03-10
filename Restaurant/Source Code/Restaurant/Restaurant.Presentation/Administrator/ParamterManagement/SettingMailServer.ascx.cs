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
using Restaurant.Presentation.Library;
using System.Collections.Generic;
using Restaurant.Library.Entities;

namespace Restaurant.Presentation.Administrator.ParamterManagement
{
    public partial class SettingMailServer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMailServer();
            }
        }
        private void BindMailServer()
        {
            gvMailServer.DataSource = ParameterBLL.GetMailServerParameter(PageConstant.GROUP_EMAIL_SERVER_PARAMETER,PageConstant.PARAMETER_MAIL_SERVER_HOST,PageConstant.PARAMETER_MAIL_SERVER_PORT,PageConstant.PARAMETER_MAIL_SERVER_USERNAME,PageConstant.PARAMETER_MAIL_SERVER_PASSWORD);
            gvMailServer.DataBind();
            if (gvMailServer.Rows.Count > 0)
            {
                BindTextBox(0);
            }            
        }
        private void BindTextBox(int index)
        {
            GridViewRow row = gvMailServer.Rows[index];
            txtHost.Text = row.Cells[0].Text;
            txtPort.Text = row.Cells[1].Text;
            txtUserName.Text = row.Cells[2].Text;
            txtPassword.Text = row.Cells[3].Text;

            lblHost.Text = PageConstant.PARAMETER_MAIL_SERVER_HOST;
            lblPort.Text = PageConstant.PARAMETER_MAIL_SERVER_PORT;
            lblUserName.Text = PageConstant.PARAMETER_MAIL_SERVER_USERNAME;
            lblPassword.Text = PageConstant.PARAMETER_MAIL_SERVER_PASSWORD;
        }
        private List<ParameterInfo> OnSetMailServer()
        {
            List<ParameterInfo> list = new List<ParameterInfo>();
            ParameterInfo host = new ParameterInfo();
            host.Key = lblHost.Text.Trim();
            host.GroupName = PageConstant.GROUP_EMAIL_SERVER_PARAMETER;
            host.Value = txtHost.Text.Trim();
            host.Unit = 0;
            host.IsActive = true;
            list.Add(host);

            ParameterInfo port = new ParameterInfo();
            port.Key = lblPort.Text.Trim();
            port.GroupName = PageConstant.GROUP_EMAIL_SERVER_PARAMETER;
            port.Value = txtPort.Text.Trim();
            port.Unit = 0;
            port.IsActive = true;
            list.Add(port);

            ParameterInfo username = new ParameterInfo();
            username.Key = lblUserName.Text.Trim();
            username.GroupName = PageConstant.GROUP_EMAIL_SERVER_PARAMETER;
            username.Value = txtUserName.Text.Trim();
            username.Unit = 0;
            username.IsActive = true;
            list.Add(username);

            ParameterInfo password = new ParameterInfo();
            password.Key = lblPassword.Text.Trim();
            password.GroupName = PageConstant.GROUP_EMAIL_SERVER_PARAMETER;
            password.Value = txtPassword.Text.Trim();
            password.Unit = 0;
            password.IsActive = true;
            list.Add(password);

            return list;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterBLL.UpdateGroupParameter(OnSetMailServer());
                BindMailServer();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}