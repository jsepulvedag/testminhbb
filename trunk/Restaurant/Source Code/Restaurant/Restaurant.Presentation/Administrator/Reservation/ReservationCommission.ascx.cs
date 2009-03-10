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

namespace Restaurant.Presentation.Administrator.Reservation
{
    public partial class ReservationCommission : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindReservationCommission();
                txtGroup.Text = PageConstant.GROUP_RESERVATION_PARAMETER;
                txtKey.Text = PageConstant.PARAMETER_RESERVATION_COMMISSION;
                if (gvCommission.Rows.Count <= 0)
                {
                    MessageBox.Show("You need define ReservationCommission for restaurant use your ReservationService !");
                    txtCommission.Focus();
                }
            }
        }
        private void BindReservationCommission()
        {
            gvCommission.DataSource = ParameterBLL.GetTableByGroupName(PageConstant.GROUP_RESERVATION_PARAMETER);
            gvCommission.DataBind();
            if (gvCommission.Rows.Count > 0)
            {
                SetCommission(SelectedRow(0));
            }
        }
        private ParameterInfo SelectedRow(int index)
        {
            ParameterInfo para = new ParameterInfo();
            GridViewRow row = gvCommission.Rows[index];
            para.GroupName = row.Cells[0].Text.Trim();
            para.Key = row.Cells[1].Text.Trim();
            para.Value = row.Cells[2].Text.Trim();
            if (row.Cells[3].Text == "Fixed Amount")
            {
                para.Unit = 2;
            }
            else if (row.Cells[3].Text == "Percentage")
            {
                para.Unit = 1;
            }
            para.CreatedDate = Convert.ToDateTime(row.Cells[4].Text);
            para.ModifiedDate = Convert.ToDateTime(row.Cells[5].Text);
            return para;
        }
        private ParameterInfo SetCommission()
        {
            ParameterInfo para = new ParameterInfo();
            para.GroupName = txtGroup.Text.Trim();
            para.Key = txtKey.Text.Trim();
            para.Value = txtCommission.Text.Trim();
            para.Unit = Convert.ToInt16(drpType.SelectedValue.ToString());
            para.IsActive = true;
            return para;
        }
        private void SetCommission(ParameterInfo para)
        {
            txtGroup.Text = para.GroupName;
            txtKey.Text = para.Key;
            txtCommission.Text = para.Value;
            drpType.SelectedValue = para.Unit.ToString();
        }                
        protected void btnEdit_Click(object sender, EventArgs e)
        {            
            try
            {
                if (Convert.ToInt32(txtCommission.Text.Trim()) < 100)
                {
                    ParameterBLL.Update(SetCommission());
                    BindReservationCommission();
                    lblMess.Visible = false;
                }
                else
                {
                    lblMess.Visible=true;
                    lblMess.Text=" max: 99";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }    
        }
    }
}