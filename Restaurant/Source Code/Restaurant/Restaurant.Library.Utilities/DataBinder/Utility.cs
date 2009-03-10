using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Telerik.WebControls;
using System.Web.UI.WebControls;
using Restaurant.Library.Utilities;

namespace Restaurant.Library.Utilities.DataBinder
{
    public class Utility
    {
        public static DataTable CreateTable(string[] members, string[] values)
        {
            DataTable tbl = new DataTable();

            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.ColumnName = "member";
            column.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "value";
            column.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(column);

            for (int i = 0; i < members.Length; i++)
            {
                row = tbl.NewRow();
                row["member"] = members[i];
                row["value"] = values[i];
                tbl.Rows.Add(row);
            }
            return tbl;
        }
        public static void BindComboBox(RadComboBox radComboBox, DataTable table)
        {
            radComboBox.Items.Clear();
            radComboBox.DataSource = table;
            radComboBox.DataTextField = table.Columns[1].ColumnName;
            radComboBox.DataValueField = table.Columns[0].ColumnName;
            radComboBox.DataBind();
            if (radComboBox.Items.Count > 0)
            {
                radComboBox.SelectedIndex = 0;
            }
        }
        public static void BindComboBox(DataTable table,RadComboBox radComboBox)
        {
            radComboBox.Items.Clear();
            radComboBox.DataSource = table;
            radComboBox.DataTextField = table.Columns[0].ColumnName;
            radComboBox.DataValueField = table.Columns[0].ColumnName;
            radComboBox.DataBind();
            if (radComboBox.Items.Count > 0)
            {
                radComboBox.SelectedIndex = 0;
            }
        }
        public static void BindingDropDowList(DataTable table, params DropDownList[] multiDropdownList)
        {
            foreach (DropDownList dropdownList in multiDropdownList)
            {
                dropdownList.Items.Clear();
                dropdownList.DataSource = table;
                dropdownList.DataTextField = table.Columns[1].ColumnName;
                dropdownList.DataValueField = table.Columns[0].ColumnName;
                dropdownList.DataBind();
                if (dropdownList.Items.Count > 0)
                {
                    dropdownList.SelectedIndex = 0;
                }
            }            
        }
        public static void BindingDropDowList(DropDownList dropdownList, DataTable table)
        {
            dropdownList.Items.Clear();
            dropdownList.DataSource = table;
            dropdownList.DataTextField = table.Columns[0].ColumnName;
            dropdownList.DataValueField = table.Columns[0].ColumnName;
            dropdownList.DataBind();
            if (dropdownList.Items.Count > 0)
            {
                dropdownList.SelectedIndex = 0;
            }
        }
        public static void BindingListBox(DataTable table, ListBox listBox)
        {
            listBox.Items.Clear();
            listBox.DataSource = table;
            listBox.DataTextField = table.Columns[1].ColumnName;
            listBox.DataValueField = table.Columns[0].ColumnName;
            listBox.DataBind();
        }
        public static void BindingListBox(ListBox listBox, DataTable table)
        {
            listBox.Items.Clear();
            listBox.DataSource = table;
            listBox.DataTextField = table.Columns[0].ColumnName;
            listBox.DataValueField = table.Columns[0].ColumnName;
            listBox.DataBind();
        }
        public static void BindingPageSizeDataList(PagedDataSource objPsrc, DataTable table, int pageSize, int pageCurrent)
        {            
            objPsrc.DataSource=table.DefaultView;
            objPsrc.AllowPaging = true ;
            objPsrc.PageSize = pageSize;
            objPsrc.CurrentPageIndex = pageCurrent -1;           
       }

      
   }
}
