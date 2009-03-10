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
using Restaurant.Presentation.Library.Sercurity;
using Restaurant.Presentation.Management.Restaurant.UserControls;
using Restaurant.Library.Utilities;

namespace Restaurant.Presentation.Management.Restaurant.GiftCertificates
{
    public partial class GiftParameter : CheckRestaurant
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGiftParameter();
            }
        }
        private void BindGiftParameter()
        {
            gvGiftParameter.DataSource = RestaurantGiftCertificateParameterBLL.GetAllByRestaurantID(Authentication.CurrentRestaurantInfo.ID);
            gvGiftParameter.DataBind();
            if (gvGiftParameter.Rows.Count > 0)
            {
                SetGiftParameter(SelectedRow(0));
            }
        }

        private bool CheckValid()
        {
            double min = Convert.ToDouble(txtMinPrice.Text.Trim());
            double max = Convert.ToDouble(txtMaxPrice.Text.Trim());
            if (min > max)
            {
                return false;
            }
            return true;
        }
        private void SetGiftParameter(RestaurantGiftCertificateParameterInfo giftParameter)
        {
            txtExpirydays.Text = giftParameter.ExpiryDate.ToString();
            txtMinPrice.Text = giftParameter.MinimunGiftCertificate.ToString();
            txtMaxPrice.Text = giftParameter.MaximunGiftCertificate.ToString();
        }
        private RestaurantGiftCertificateParameterInfo SetGiftParameter()
        {
            RestaurantGiftCertificateParameterInfo giftPara = new RestaurantGiftCertificateParameterInfo();
            giftPara.ExpiryDate = Convert.ToInt32(txtExpirydays.Text.Trim());
            giftPara.MinimunGiftCertificate = Convert.ToInt32(txtMinPrice.Text.Trim());
            giftPara.MaximunGiftCertificate = Convert.ToInt32(txtMaxPrice.Text.Trim());
            giftPara.RestaurantID = Authentication.CurrentRestaurantInfo.ID;
            return giftPara;
        }
        private RestaurantGiftCertificateParameterInfo SelectedRow(int index)
        {
            GridViewRow row = gvGiftParameter.Rows[index];
            RestaurantGiftCertificateParameterInfo giftPara = new RestaurantGiftCertificateParameterInfo();
            giftPara.MinimunGiftCertificate = Convert.ToInt32(row.Cells[0].Text.Trim());
            giftPara.MaximunGiftCertificate = Convert.ToInt32(row.Cells[1].Text.Trim());
            giftPara.ExpiryDate = Convert.ToInt32(row.Cells[2].Text.Trim());
            giftPara.CreatedDate = Convert.ToDateTime(row.Cells[3].Text.Trim());
            giftPara.ModifiedDate = Convert.ToDateTime(row.Cells[4].Text.Trim());
            return giftPara;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
            {
                MessageBox.Show("Invalid min price and max price !");
                txtMinPrice.Focus();
                return;
            }
            try
            {
                RestaurantGiftCertificateParameterBLL.Update(SetGiftParameter());
                BindGiftParameter();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}