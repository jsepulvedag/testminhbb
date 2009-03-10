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
using Restaurant.Library.Entities;
using Restaurant.Library.BLL;
using System.IO;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Administrator.GiftCertificates
{
    public partial class DefineGiftType : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete this Gift ?')");
            if (!IsPostBack)
            {
                BindGiftType();               
            }
        }
        private void BindGiftType()
        {
            gvGiftType.DataSource = GiftCertificateTypeBLL.GetAll(false);
            gvGiftType.DataBind();
            if (gvGiftType.SelectedIndex < 0)
            {
                gvGiftType.SelectedIndex = 0;
            }
            else if (gvGiftType.SelectedIndex >= gvGiftType.Rows.Count)
            {
                gvGiftType.SelectedIndex = gvGiftType.Rows.Count - 1;
            }            
            if (gvGiftType.Rows.Count > 0)
            {
                SetGiftType(SelectedGiftType(gvGiftType.SelectedIndex));
            }
        }
        private void SetEnable(bool flag)
        {
            txtGiftName.ReadOnly = !flag;
            rdYes.Enabled = flag;
            rdNo.Enabled = flag;
        }
        private void SetGiftType(GiftCertificateTypeInfo giftType)
        {
            txtID.Text = giftType.ID.ToString();
            txtGiftName.Text = giftType.Name;
            rdYes.Checked = giftType.IsActive;
        }
        private GiftCertificateTypeInfo SetGiftType()
        {
            GiftCertificateTypeInfo giftType = new GiftCertificateTypeInfo();
            giftType.ID = (txtID.Text == "" || txtID.Text == null) ? 0 : Convert.ToInt32(txtID.Text.Trim());
            giftType.Name = txtGiftName.Text.Trim();
            giftType.IsActive = rdYes.Checked;
            return giftType;
        }
        private GiftCertificateTypeInfo SelectedGiftType(int index)
        {
            GridViewRow row = gvGiftType.Rows[index];
            GiftCertificateTypeInfo giftType = new GiftCertificateTypeInfo();
            giftType.ID = Convert.ToInt32(row.Cells[0].Text.Trim());
            giftType.Name = row.Cells[1].Text.Trim();
            CheckBox chk = (CheckBox)row.Cells[2].Controls[0];
            giftType.IsActive = chk.Checked;
            return giftType;
        }
        private void SetSelectedRow(int giftTypeID)
        {
            int j = -1;
            for (int index = 0; index < gvGiftType.PageCount; index++)
            {
                gvGiftType.PageIndex = index;
                BindGiftType();
                int i = 0;
                foreach (GridViewRow row in gvGiftType.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Text) == giftTypeID)
                    {
                        gvGiftType.SelectedIndex = i;
                        SetGiftType(SelectedGiftType(gvGiftType.SelectedIndex));
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
        private void CreateFolderForGift(int giftTypeID)
        {
            DirectoryInfo directGift, directThumbnail, directLarge;
            string root = "~/Media/Gift/";
            directGift = new DirectoryInfo(Server.MapPath(root));
            if (!directGift.Exists)
            {
                directGift.Create();
            }
            directThumbnail = new DirectoryInfo(Server.MapPath(root + "Thumbnail/"));
            if (!directThumbnail.Exists)
            {
                directThumbnail.Create();
            }
            directLarge = new DirectoryInfo(Server.MapPath(root + "Large/"));
            if (!directLarge.Exists)
            {
                directLarge.Create();
            }
            DirectoryInfo directThumbnailGiftImage, directLagerGiftImage;
            directThumbnailGiftImage = new DirectoryInfo(Server.MapPath(root + "Thumbnail/" + giftTypeID + "/"));
            if (!directThumbnailGiftImage.Exists)
            {
                directThumbnailGiftImage.Create();
            }
            directLagerGiftImage = new DirectoryInfo(Server.MapPath(root + "Large/" + giftTypeID + "/"));
            if (!directLagerGiftImage.Exists)
            {
                directLagerGiftImage.Create();
            }
        }
        private void Cancel()
        {
            SetEnable(false);
            btnInsert.Text = "Insert";
            btnInsert.Enabled = true;
            btnEdit.Text = "Edit";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.CausesValidation = false;
            BindGiftType();
        }
        protected void gvGiftType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiftType.PageIndex = e.NewPageIndex;
            Cancel();
        }
        protected void gvGiftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGiftType(SelectedGiftType(gvGiftType.SelectedIndex));
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnEdit.Enabled = true;
            btnEdit.Text = "Edit";
            btnInsert.Text = "Insert";
            btnInsert.CausesValidation = false;
            SetEnable(false);
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                SetEnable(true);
                btnInsert.Text = "Ok";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtGiftName.Text = "";
                rdNo.Checked = true;
                btnInsert.CausesValidation = true;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                SetEnable(false);
                btnInsert.Text = "Insert";
                btnInsert.CausesValidation = false;
                int id = 0;
                try
                {
                   id = GiftCertificateTypeBLL.Insert(SetGiftType());
                   CreateFolderForGift(id);                   
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
                btnInsert.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Text = "Ok";
                SetEnable(true);
            }
            else
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                SetEnable(false);
                btnEdit.Text = "Edit";
                try
                {
                    GiftCertificateTypeBLL.Update(SetGiftType());

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                BindGiftType();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GiftCertificateTypeBLL.Delete(Convert.ToInt32(txtID.Text.Trim()));
                string root = "~/Media/Gift/";
                DirectoryInfo directThumbnail, directLager;
                directThumbnail = new DirectoryInfo(Server.MapPath(root + "Thumbnail/" + txtID.Text.Trim() + "/"));
                if (directThumbnail.Exists)
                {
                    directThumbnail.Delete();
                }
                directLager = new DirectoryInfo(Server.MapPath(root + "Lager/" + txtID.Text.ToString() + "/"));
                if (directLager.Exists)
                {
                    directLager.Delete();
                }
                BindGiftType();
            }
            catch
            {
                MessageBox.Show(AppEnv.CANNOT_DELETE);
            }            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}