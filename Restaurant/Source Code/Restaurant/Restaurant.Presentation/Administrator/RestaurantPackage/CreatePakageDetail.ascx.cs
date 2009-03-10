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
using Restaurant.Library.Entities;
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Administrator.RestaurantPackage
{
    public partial class CreatePakageDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Attributes.Add("onclick","return confirm('Are you sure delete this SubscriptionPlan')");
            if (!IsPostBack)
            {
                BindPackageID();
                BindExpiryMonth();
                BindPackageDetail();                
            }            
        }
        private PackageDetailInfo SelectedPackageDetail(int index)
        {
            PackageDetailInfo packageDetail = new PackageDetailInfo();
            GridViewRow row = gvPackageDetail.Rows[index];
            packageDetail.Description = row.Cells[7].Text.Trim();
            packageDetail.ExpiryMonth = Convert.ToInt32(row.Cells[3].Text.Trim());
            packageDetail.ID = Convert.ToInt32(row.Cells[0].Text.Trim());
            CheckBox chk = (CheckBox)row.Cells[6].Controls[0];
            packageDetail.IsActive = chk.Checked;
            packageDetail.Name = row.Cells[2].Text.Trim();
            packageDetail.PackageID = Convert.ToInt32(row.Cells[1].Text.Trim());
            packageDetail.Price = Convert.ToDouble(row.Cells[4].Text.Trim());
            packageDetail.Priority = Convert.ToInt16(row.Cells[5].Text.Trim());
            return packageDetail;
        }
        private void SetPackageDetail(PackageDetailInfo packageDetail)
        {
            txtDescription.Text = packageDetail.Description;
            txtID.Text = packageDetail.ID.ToString();
            txtName.Text = packageDetail.Name;
            txtPrice.Text = packageDetail.Price.ToString();
            drpExpiryMonth.SelectedValue = packageDetail.ExpiryMonth.ToString();
            drpPackageID.SelectedValue = packageDetail.PackageID.ToString();
            drpPriority.SelectedValue = packageDetail.Priority.ToString();
            if (packageDetail.IsActive)
            {
                rdYes.Checked = true;
            }
            else
            {
                rdNo.Checked = true;
            }
        }
        private PackageDetailInfo SetPackageDetail()
        {
            PackageDetailInfo packageDetail = new PackageDetailInfo();
            packageDetail.Description = txtDescription.Text;
            packageDetail.ID = Convert.ToInt32((txtID.Text == "" || txtID.Text == null) ? "0" : txtID.Text.Trim());
            packageDetail.Name = txtName.Text;
            packageDetail.Price = Convert.ToDouble(txtPrice.Text.Trim());
            packageDetail.ExpiryMonth = Convert.ToInt32(drpExpiryMonth.SelectedValue.ToString());
            packageDetail.PackageID = Convert.ToInt32(drpPackageID.SelectedValue.ToString());
            packageDetail.Priority = Convert.ToInt16(drpPriority.SelectedValue.ToString());
            packageDetail.IsActive = rdYes.Checked;

            return packageDetail;
        }
        private void SetEnable(bool flag)
        {
            txtDescription.ReadOnly = !flag;
            txtName.ReadOnly = !flag;
            txtPrice.ReadOnly = !flag;
            drpExpiryMonth.Enabled = flag;
            drpPackageID.Enabled = flag;
            drpPriority.Enabled = flag;
            rdNo.Enabled = flag;
            rdYes.Enabled = flag;
        }
        private void BindPackageDetail()
        {
            gvPackageDetail.DataSource = PackageDetailBLL.GetAll(false);
            gvPackageDetail.DataBind();
            if (gvPackageDetail.SelectedIndex < 0)
            {
                gvPackageDetail.SelectedIndex = 0;
            }
            if (gvPackageDetail.SelectedIndex >= gvPackageDetail.Rows.Count)
            {
                gvPackageDetail.SelectedIndex = gvPackageDetail.Rows.Count - 1;
            }
            if (gvPackageDetail.Rows.Count > 0)
            {
                SetPackageDetail(SelectedPackageDetail(gvPackageDetail.SelectedIndex));
            }
        }
        private void SetSelectedRow(int id)
        {
            int j = -1;
            for (int index = 0; index < gvPackageDetail.PageCount; index++)
            {
                gvPackageDetail.PageIndex = index;
                BindPackageDetail();
                int i = 0;
                foreach (GridViewRow row in gvPackageDetail.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Text) == id)
                    {
                        gvPackageDetail.SelectedIndex = i;
                        SetPackageDetail(SelectedPackageDetail(i));
                        j = index;
                        break;
                    }
                    i++;
                }
                if (j != -1)
                {
                    break;
                }
            }
        }
        private void BindPackageID()
        {
            Utility.BindingDropDowList(PackageBLL.GetAll(false),drpPackageID);
        }
        private void BindExpiryMonth()
        {
            string[] months = new string[48];
            for (int i = 0; i < 48; i++)
            {
                months[i] = Convert.ToString(i + 1);
            }
            Utility.BindingDropDowList(Utility.CreateTable(months, months), drpExpiryMonth);
        }
        protected void gvPackageDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPackageDetail.PageIndex = e.NewPageIndex;
            BindPackageDetail();
            SetEnable(false);
        }
        protected void gvPackageDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnInsert.Text = "Insert";
            btnEdit.Enabled = true;
            btnEdit.Text = "Edit";
            btnDelete.Enabled = true;
            btnDelete.Text = "Delete";
            SetPackageDetail(SelectedPackageDetail(gvPackageDetail.SelectedIndex));
            SetEnable(false);
            btnInsert.CausesValidation = false;
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                btnInsert.Text = "Ok";
                txtName.Text = "";
                txtPrice.Text = "";
                txtID.Text = "";
                txtDescription.Text = "";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                SetEnable(true);
                btnInsert.CausesValidation = true;
            }
            else
            {
                btnInsert.Text = "Insert";
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                SetEnable(false);
                btnInsert.CausesValidation = false;
                int id = 0;
                try
                {
                    id = PackageDetailBLL.Insert(SetPackageDetail());
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                SetSelectedRow(id);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Ok";
                btnInsert.Enabled = false;
                btnDelete.Enabled = false;
                SetEnable(true);
            }
            else
            {
                btnEdit.Text = "Edit";
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                try
                {
                    PackageDetailBLL.Update(SetPackageDetail());
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                BindPackageDetail();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PackageDetailBLL.Delete(Convert.ToInt32(txtID.Text.Trim()));
                BindPackageDetail();
            }
            catch
            {
                MessageBox.Show(AppEnv.CANNOT_DELETE);
            }            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnInsert.Text = "Insert";
            btnEdit.Enabled = false;
            btnEdit.Text = "Edit";
            btnDelete.Enabled = false;
            btnDelete.Text = "Delete";
            SetEnable(false);
            btnInsert.CausesValidation = false;
            BindPackageDetail();
        }
    }
}