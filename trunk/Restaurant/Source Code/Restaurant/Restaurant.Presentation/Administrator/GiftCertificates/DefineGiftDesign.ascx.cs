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
using Restaurant.Library.Utilities.DataBinder;
using Restaurant.Library.Entities;
using System.IO;
using Restaurant.Library.Utilities.GenerateThumbnailImage;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Administrator.GiftCertificates
{
    public partial class DefineGiftDesign : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDelete.Attributes.Add("onclick", "return confirm('Are you sure delete this GiftDesign ?')");
            if (!IsPostBack)
            {
                BindFilterGiftDesign();
                BindGiftDesign();                                
            }
        }
        private void BindGiftDesign()
        {
            gvGiftDesign.DataSource = GiftCertificateImageBLL.GetGetAllByGiftTypeID(Convert.ToInt32(drpFilterGiftDesign.SelectedValue.ToString()));            
            gvGiftDesign.DataBind();
            if (gvGiftDesign.SelectedIndex < 0)
            {
                gvGiftDesign.SelectedIndex = 0;
            }
            else if (gvGiftDesign.SelectedIndex >= gvGiftDesign.Rows.Count)
            {
                gvGiftDesign.SelectedIndex = gvGiftDesign.Rows.Count-1;
            }
            if (gvGiftDesign.Rows.Count > 0)
            {
                SetGiftDesign(SelectedRow(gvGiftDesign.SelectedIndex));
            }
        }
        private GiftCertificateImageInfo SelectedRow(int index)
        {
            GiftCertificateImageInfo obj = new GiftCertificateImageInfo();
            GridViewRow row = gvGiftDesign.Rows[index];
            LinkButton lnkBtn = (LinkButton)row.FindControl("lnkBtnGiftType");
            if (lnkBtn != null)
            {
                obj.ID = Convert.ToInt32(lnkBtn.CommandArgument.ToString().Trim());
                obj.Title = lnkBtn.Text.Trim();
            }
            HiddenField hd = (HiddenField)row.FindControl("hdGiftTypeID");
            if (hd != null)
            {
                obj.GiftTypeID = Convert.ToInt32(hd.Value.ToString().Trim());
            }
            obj.ToX = Convert.ToInt32(row.Cells[3].Text.Trim());
            obj.ToY = Convert.ToInt32(row.Cells[4].Text.Trim());
            obj.FromX = Convert.ToInt32(row.Cells[5].Text.Trim());
            obj.FromY = Convert.ToInt32(row.Cells[6].Text.Trim());
            obj.MsgX = Convert.ToInt32(row.Cells[7].Text.Trim());
            obj.MsgY = Convert.ToInt32(row.Cells[8].Text.Trim());
            obj.RestaurantX = Convert.ToInt32(row.Cells[9].Text.Trim());
            obj.RestaurantY = Convert.ToInt32(row.Cells[10].Text.Trim());
            obj.SignatureX = Convert.ToInt32(row.Cells[11].Text.Trim());
            obj.SignatureY = Convert.ToInt32(row.Cells[12].Text.Trim());
            obj.PriceX = Convert.ToInt32(row.Cells[13].Text.Trim());
            obj.PriceY = Convert.ToInt32(row.Cells[14].Text.Trim());
            obj.AddressX = Convert.ToInt32(row.Cells[15].Text.Trim());
            obj.AddressY = Convert.ToInt32(row.Cells[16].Text.Trim());
            obj.ExpiredDateX = Convert.ToInt32(row.Cells[17].Text.Trim());
            obj.ExpiredDateY = Convert.ToInt32(row.Cells[18].Text.Trim());
            obj.ColorText = row.Cells[19].Text.Trim();
            CheckBox chk = (CheckBox)row.Cells[20].Controls[0];
            if (chk != null)
            {
                obj.IsActive = chk.Checked;
            }
            return obj;
        }
        private void BindFilterGiftDesign()
        {
            Utility.BindingDropDowList(GiftCertificateTypeBLL.GetAll(false),drpFilterGiftDesign,drpGiftDesign);
            ListItem item = new ListItem("All","0");
            drpFilterGiftDesign.Items.Insert(0,item);
            drpFilterGiftDesign.SelectedIndex = 0;
        }
        private GiftCertificateImageInfo SetGiftDesign(string thumbnailURL, string largeURL)
        {
            GiftCertificateImageInfo info = new GiftCertificateImageInfo();
            info.ID = Convert.ToInt32((txtID.Text == "" || txtID.Text == null)?"0":txtID.Text);
            info.Title = txtTitle.Text;
            info.ToX = Convert.ToInt32(txtToX.Text);
            info.ToY = Convert.ToInt32(txtToY.Text);
            info.AddressX = Convert.ToInt32(txtAddressX.Text);
            info.AddressY = Convert.ToInt32(txtAddressY.Text);
            info.ExpiredDateX = Convert.ToInt32(txtExpiryDateX.Text);
            info.ExpiredDateY = Convert.ToInt32(txtExpiryDateY.Text);
            info.FromX = Convert.ToInt32(txtFromX.Text);
            info.FromY = Convert.ToInt32(txtFromY.Text);
            info.MsgX = Convert.ToInt32(txtMessageX.Text);
            info.MsgY = Convert.ToInt32(txtMessageY.Text);
            info.PriceX = Convert.ToInt32(txtPriceX.Text);
            info.PriceY = Convert.ToInt32(txtPriceY.Text);
            info.RestaurantX = Convert.ToInt32(txtRestaurantX.Text);
            info.RestaurantY = Convert.ToInt32(txtRestaurantY.Text);
            info.SignatureX = Convert.ToInt32(txtSignatureX.Text);
            info.SignatureY = Convert.ToInt32(txtSignatureY.Text);
            info.IsActive = rdYes.Checked;
            info.GiftTypeID = Convert.ToInt32(drpGiftDesign.SelectedValue);
            info.ColorText = colorText.Color;
            info.ImageSmallURL = thumbnailURL;
            info.ImageLargeURL = largeURL;
            return info;
        }
        private void SetGiftDesign(GiftCertificateImageInfo info)
        {
            txtID.Text = info.ID.ToString();
            txtTitle.Text = info.Title;
            txtToX.Text = info.ToX.ToString();
            txtToY.Text = info.ToY.ToString();
            txtAddressX.Text = info.AddressX.ToString();
            txtAddressY.Text = info.AddressY.ToString();
            txtExpiryDateX.Text = info.ExpiredDateX.ToString();
            txtExpiryDateY.Text = info.ExpiredDateY.ToString();
            txtFromX.Text = info.FromX.ToString();
            txtFromY.Text = info.FromY.ToString();
            txtMessageX.Text = info.MsgX.ToString();
            txtMessageY.Text = info.MsgY.ToString();
            txtPriceX.Text = info.PriceX.ToString();
            txtPriceY.Text = info.PriceY.ToString();
            txtRestaurantX.Text = info.RestaurantX.ToString();
            txtRestaurantY.Text = info.RestaurantY.ToString();
            txtSignatureX.Text = info.SignatureX.ToString();
            txtSignatureY.Text = info.SignatureY.ToString();
            rdYes.Checked = info.IsActive;
            rdNo.Checked = !info.IsActive;
            colorText.Color = info.ColorText;
            drpGiftDesign.SelectedValue = info.GiftTypeID.ToString();
        }
        private void SetEnable(bool flag)
        {
            txtAddressX.ReadOnly = !flag;
            txtAddressY.ReadOnly = !flag;
            txtExpiryDateX.ReadOnly = !flag;
            txtExpiryDateY.ReadOnly = !flag;
            txtFromX.ReadOnly = !flag;
            txtFromY.ReadOnly = !flag;
            txtMessageX.ReadOnly = !flag;
            txtMessageY.ReadOnly = !flag;
            txtPriceX.ReadOnly = !flag;
            txtPriceY.ReadOnly = !flag;
            txtRestaurantX.ReadOnly = !flag;
            txtRestaurantY.ReadOnly = !flag;
            txtSignatureX.ReadOnly = !flag;
            txtSignatureY.ReadOnly = !flag;
            txtTitle.ReadOnly = !flag;
            txtToX.ReadOnly = !flag;
            txtToY.ReadOnly = !flag;
            rdNo.Enabled = flag;
            rdYes.Enabled = flag;
            drpGiftDesign.Enabled = flag;
        }
        private void ClearText()
        {
            txtAddressX.Text = "";
            txtAddressY.Text = "";
            txtExpiryDateX.Text = "";
            txtExpiryDateY.Text = "";
            txtFromX.Text = "";
            txtFromY.Text = "";
            txtMessageX.Text = "";
            txtMessageY.Text = "";
            txtPriceX.Text = "";
            txtPriceY.Text = "";
            txtRestaurantX.Text = "";
            txtRestaurantY.Text = "";
            txtSignatureX.Text = "";
            txtSignatureY.Text = "";
            txtTitle.Text = "";
            txtToX.Text = "";
            txtToY.Text = "";            
        }
        private void SetSelectedRow(int id)
        {
            int j = -1;
            for (int index = 0; index < gvGiftDesign.PageCount; index++)
            {
                gvGiftDesign.PageIndex = index;
                BindGiftDesign();
                int i = 0;
                foreach (GridViewRow row in gvGiftDesign.Rows)
                {
                    LinkButton lnkBtn = (LinkButton)row.FindControl("lnkBtnGiftType");
                    if (lnkBtn != null && Convert.ToInt32(lnkBtn.CommandArgument.ToString()) == id)
                    {
                        gvGiftDesign.SelectedIndex = i;
                        SetGiftDesign(SelectedRow(gvGiftDesign.SelectedIndex));
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
        private void Cancel()
        {
            btnEdit.Text = "Edit";
            btnInsert.Text = "Insert";
            btnDelete.Text = "Delete";
            btnInsert.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnInsert.CausesValidation = false;
            SetEnable(false);
            BindGiftDesign();
        }
        protected void gvGiftDesign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiftDesign.PageIndex = e.NewPageIndex;            
            Cancel();
        }
        protected void gvGiftDesign_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkBtnGiftType")
            {
                foreach (GridViewRow row in gvGiftDesign.Rows)
                {
                    LinkButton lnkBtn = (LinkButton)row.FindControl("lnkBtnGiftType");
                    if (lnkBtn.CommandArgument.ToString() == e.CommandArgument.ToString())
                    {
                        gvGiftDesign.SelectedIndex = row.RowIndex;
                        break;
                    }
                }
                SetGiftDesign(SelectedRow(gvGiftDesign.SelectedIndex));
                btnEdit.Text = "Edit";
                btnInsert.Text = "Insert";
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnInsert.CausesValidation = false;
                SetEnable(false);                
            }
        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnInsert.Text = "Ok";
                SetEnable(true);
                ClearText();
                btnInsert.CausesValidation = true;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnInsert.Text = "Insert";
                SetEnable(false);
                btnInsert.CausesValidation = false;   
                int id = 0;
                try
                {
                    string sourceUrl = "~/Media/Gift/Large/" + drpGiftDesign.SelectedValue.ToString() + "/" + fuImage.PostedFile.FileName;
                    string saveUrl = "~/Media/Gift/Thumbnail/" + drpGiftDesign.SelectedValue.ToString() + "/" + fuImage.PostedFile.FileName;
                    Generator thumbnail = new Generator(124, 91, Server.MapPath(sourceUrl), Server.MapPath(saveUrl));
                    id = GiftCertificateImageBLL.Insert(SetGiftDesign(saveUrl, sourceUrl));
                    fuImage.SaveAs(Server.MapPath(sourceUrl));
                    thumbnail.SaveThumbnail();                                                                    
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
                btnInsert.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Text = "Ok";
                SetEnable(true);
                try
                {
                    GiftCertificateImageBLL.Update(SetGiftDesign(null, null));
                    BindGiftDesign();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GiftCertificateImageBLL.Delete(Convert.ToInt32(txtID.Text.Trim()));
                BindGiftDesign();
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
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            BindGiftDesign();
        }               
    }
}