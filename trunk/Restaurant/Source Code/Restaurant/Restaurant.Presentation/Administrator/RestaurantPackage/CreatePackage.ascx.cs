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
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Administrator.RestaurantPackage
{
    public partial class CreatePackage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Attributes.Add("onclick", "return confirm ('Are you sure to delete this Package?');");
            if (!IsPostBack)
            {
                BindPackage();
                SetEnable(false);                
            }
        }
        private void BindPackage()
        {
            gvPackage.DataSource = PackageBLL.GetAll(false);
            gvPackage.DataBind();
            if (gvPackage.SelectedIndex < 0)
            {
                gvPackage.SelectedIndex = 0;
            }
            else if (gvPackage.SelectedIndex >= gvPackage.Rows.Count)
            {
                gvPackage.SelectedIndex = gvPackage.Rows.Count - 1;
            }            
            if (gvPackage.Rows.Count > 0)
            {
                SetPackage(SelectedPackage(gvPackage.SelectedIndex));
            }
        }
        private PackageInfo SelectedPackage(int index)
        {
            GridViewRow row = gvPackage.Rows[index];
            PackageInfo tmp = new PackageInfo();
            tmp.ID = Convert.ToInt32(row.Cells[0].Text.Trim());
            tmp.Name = row.Cells[1].Text.Trim();
            tmp.Priority = Convert.ToInt16(row.Cells[12].Text.Trim());
            CheckBox chk = (CheckBox)row.Cells[2].Controls[0];
            tmp.AllowOnlineOrder = chk.Checked;
            chk = (CheckBox)row.Cells[3].Controls[0];
            tmp.AllowGiftCertificate = chk.Checked;
            chk = (CheckBox)row.Cells[4].Controls[0];
            tmp.AllowReservation = chk.Checked;
            chk = (CheckBox)row.Cells[5].Controls[0];
            tmp.AllowMap = chk.Checked;
            chk = (CheckBox)row.Cells[6].Controls[0];
            tmp.AllowVideo = chk.Checked;
            chk = (CheckBox)row.Cells[7].Controls[0];
            tmp.AllowPhoto = chk.Checked;
            chk = (CheckBox)row.Cells[8].Controls[0];
            tmp.AllowEvent = chk.Checked;
            chk = (CheckBox)row.Cells[9].Controls[0];
            tmp.AllowJobPortal = chk.Checked;
            chk = (CheckBox)row.Cells[10].Controls[0];
            tmp.AllowMenu = chk.Checked;
            tmp.Description = row.Cells[14].Text.Trim();
            chk = (CheckBox)row.Cells[11].Controls[0];
            tmp.AllowSponsored = chk.Checked;
            chk = (CheckBox)row.Cells[13].Controls[0];
            tmp.IsActive = chk.Checked;
            return tmp;
        }
        private void SetRadioButton(RadioButtonList radio, bool flag)
        {
            if (flag)
            {
                radio.Items[0].Selected = true;
                radio.Items[1].Selected = false;
            }
            else
            {
                radio.Items[0].Selected = false;
                radio.Items[1].Selected = true;
            }
        }
        private void SetPackage(PackageInfo package)
        {
            txtID.Text = package.ID.ToString();
            txtName.Text = package.Name.ToString();
            txtDescription.Text = package.Description;
            SetRadioButton(rdEvent, package.AllowEvent);
            SetRadioButton(rdGift, package.AllowGiftCertificate);
            SetRadioButton(rdJobportal, package.AllowJobPortal);
            SetRadioButton(rdMap, package.AllowMap);
            SetRadioButton(rdMenu, package.AllowMenu);
            SetRadioButton(rdOrder, package.AllowOnlineOrder);
            SetRadioButton(rdPhoto, package.AllowPhoto);
            SetRadioButton(rdReservation, package.AllowReservation);
            SetRadioButton(rdVideo, package.AllowVideo);
            SetRadioButton(rdSponsored, package.AllowSponsored);
            SetRadioButton(rdIsActive, package.IsActive);
            drpPriority.SelectedValue = package.Priority.ToString();
        }
        private bool GetValueRadiobutton(RadioButtonList radio)
        {
            if (radio.Items[0].Selected)
            {
                return Convert.ToBoolean((radio.Items[0].Value == "Yes")?"true":"false");
            }
            else
            {
                return Convert.ToBoolean((radio.Items[1].Value == "No")?"false":"true");
            }
        }
        private void SetEnable(bool flag)
        {
            txtName.ReadOnly = !flag;
            txtDescription.ReadOnly = !flag;
            rdEvent.Enabled = flag;
            rdGift.Enabled = flag;
            rdIsActive.Enabled = flag;
            rdJobportal.Enabled = flag;
            rdMap.Enabled = flag;
            rdMenu.Enabled = flag;
            rdOrder.Enabled = flag;
            rdPhoto.Enabled = flag;
            rdReservation.Enabled = flag;
            rdSponsored.Enabled = flag;
            rdVideo.Enabled = flag;
            drpPriority.Enabled = flag;
        }
        private PackageInfo SetPackage()
        {
            PackageInfo package = new PackageInfo();
            package.AllowEvent = GetValueRadiobutton(rdEvent);
            package.AllowGiftCertificate = GetValueRadiobutton(rdGift);
            package.AllowJobPortal = GetValueRadiobutton(rdJobportal);
            package.AllowMap = GetValueRadiobutton(rdMap);
            package.AllowMenu = GetValueRadiobutton(rdMenu);
            package.AllowOnlineOrder = GetValueRadiobutton(rdOrder);
            package.AllowPhoto = GetValueRadiobutton(rdPhoto);
            package.AllowReservation = GetValueRadiobutton(rdReservation);
            package.AllowSponsored = GetValueRadiobutton(rdSponsored);
            package.AllowVideo = GetValueRadiobutton(rdVideo);
            package.Description = txtDescription.Text.Trim();
            package.ID = Convert.ToInt32((txtID.Text == "" || txtID.Text == null) ? "0" : txtID.Text.Trim());
            package.IsActive = GetValueRadiobutton(rdIsActive);
            package.Name = txtName.Text.Trim();
            package.Priority = Convert.ToInt16(drpPriority.SelectedValue.ToString());
            
            return package;
        }
        private void SetSelectedRow(int packageID)
        {
            int j = -1;
            for (int index = 0; index < gvPackage.PageCount; index++)
            {
                gvPackage.PageIndex = index;
                BindPackage();
                int i = 0;
                foreach (GridViewRow row in gvPackage.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Text) == packageID)
                    {
                        gvPackage.SelectedIndex = i;
                        SetPackage(SelectedPackage(i));
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
        protected void gvPackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInsert.Enabled = true;
            btnInsert.Text = "Insert";
            btnEdit.Enabled = true;
            btnEdit.Text = "Edit";
            btnDelete.Enabled = true;
            btnDelete.Text = "Delete";
            btnInsert.CausesValidation = false;
            SetPackage(SelectedPackage(gvPackage.SelectedIndex));
            SetEnable(false);
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
            BindPackage();
            btnInsert.CausesValidation = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {         
            try
            {
                PackageBLL.Delete(Convert.ToInt32(txtID.Text.Trim()));
                BindPackage();
            }
            catch
            {
                MessageBox.Show(AppEnv.CANNOT_DELETE);
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
                SetEnable(false);
                int index = gvPackage.SelectedIndex;
                try
                {
                    PackageBLL.Update(SetPackage());
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                BindPackage();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                btnInsert.Text = "Ok";
                txtID.Text = "";
                txtName.Text = "";
                txtDescription.Text = "";
                drpPriority.SelectedValue = "1";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                SetRadioButton(rdEvent, false);
                SetRadioButton(rdGift, false);
                SetRadioButton(rdJobportal, false);
                SetRadioButton(rdMap, false);
                SetRadioButton(rdMenu, false);
                SetRadioButton(rdOrder, false);
                SetRadioButton(rdPhoto, false);
                SetRadioButton(rdReservation, false);
                SetRadioButton(rdVideo, false);
                SetRadioButton(rdSponsored, false);
                SetRadioButton(rdIsActive, false);
                SetEnable(true);
                btnInsert.CausesValidation = true;
            }
            else
            {
                int id = 0;
                btnInsert.CausesValidation = false;
                btnInsert.Text = "Insert";
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                SetEnable(false);
                try
                {
                   id = PackageBLL.Insert(SetPackage());                   
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }                
                SetSelectedRow(id);
            }
        }
        protected void gvPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPackage.PageIndex = e.NewPageIndex;
            BindPackage();
            SetEnable(false);
        }
    }
}