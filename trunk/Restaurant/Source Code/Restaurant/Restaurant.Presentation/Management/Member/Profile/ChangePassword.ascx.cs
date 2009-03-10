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
using Restaurant.Library.Utilities;
using Restaurant.Library.Utilities.Encrypt;

namespace Restaurant.Presentation.Management.Member.Profile
{
    public partial class ChangePassword : AuthenticateControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Authentication.CurrentAccountLogin.Password.Equals(MD5.Encrypt(txtOldPassword.Text.Trim())))
            {
                try
                {
                    MemberBLL.ChangePassword(Authentication.CurrentMemberInfo.ID, txtNewPassword.Text.Trim());
                    MessageBox.Show(AppEnv.UPDATEED_SUCCESS);
                    Authentication.Login(Authentication.CurrentAccountLogin.UserName, MD5.Encrypt(txtNewPassword.Text.Trim()), true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex);
                }
            }
            else
            {
                MessageBox.Show("Invalid old password");
                txtOldPassword.Focus();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}