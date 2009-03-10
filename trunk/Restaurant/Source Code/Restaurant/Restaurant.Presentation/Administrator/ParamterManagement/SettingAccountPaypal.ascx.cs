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
using Restaurant.Library.Entities;
using System.Collections.Generic;

namespace Restaurant.Presentation.Administrator.ParamterManagement
{
    public partial class SettingAccountPaypal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPaypalParameter();
            }
        }
        private void BindPaypalParameter()
        {
            gvPaypalParameter.DataSource = ParameterBLL.GetPaypalParameter(PageConstant.GROUP_PAYPAL_PARAMETER,PageConstant.PARAMETER_PAYPAL_USERNAME,PageConstant.PARAMETER_PAYPAL_PASSWORD,PageConstant.PARAMETER_PAYPAL_SIGNATURE);
            gvPaypalParameter.DataBind();
            if (gvPaypalParameter.Rows.Count > 0)
            {
                BindTextBox(0);
            }
        }
        private void BindTextBox(int index)
        {
            GridViewRow row = gvPaypalParameter.Rows[index];
            txtUserName.Text = row.Cells[0].Text;
            txtPassword.Text = row.Cells[1].Text;
            txtSignature.Text = row.Cells[2].Text;

            lblUserName.Text = PageConstant.PARAMETER_PAYPAL_USERNAME;
            lblPassword.Text = PageConstant.PARAMETER_PAYPAL_PASSWORD;
            lblSignature.Text = PageConstant.PARAMETER_PAYPAL_SIGNATURE;
        }
        private List<ParameterInfo> OnSetPaypalParameter()
        {
            List<ParameterInfo> list = new List<ParameterInfo>();
            ParameterInfo username = new ParameterInfo();
            username.Key = lblUserName.Text.Trim();
            username.GroupName = PageConstant.GROUP_PAYPAL_PARAMETER;
            username.Value = txtUserName.Text.Trim();
            username.Unit = 0;
            username.IsActive = true;
            list.Add(username);            

            ParameterInfo password = new ParameterInfo();
            password.Key = lblPassword.Text.Trim();
            password.GroupName = PageConstant.GROUP_PAYPAL_PARAMETER;
            password.Value = txtPassword.Text.Trim();
            password.Unit = 0;
            password.IsActive = true;
            list.Add(password);

            ParameterInfo signature = new ParameterInfo();
            signature.Key = lblSignature.Text.Trim();
            signature.GroupName = PageConstant.GROUP_PAYPAL_PARAMETER;
            signature.Value = txtSignature.Text.Trim();
            signature.Unit = 0;
            signature.IsActive = true;
            list.Add(signature);

            return list;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterBLL.UpdateGroupParameter(OnSetPaypalParameter());
                BindPaypalParameter();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}