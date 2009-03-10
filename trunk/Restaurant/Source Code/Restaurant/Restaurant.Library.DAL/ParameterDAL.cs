using System;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Library.Utilities;
using Restaurant.Library.Entities;
using System.Collections.Generic;

namespace Restaurant.Library.DAL
{
    public class ParameterDAL
    {
        public static int Insert(ParameterInfo parameterInfo)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Parameter_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GroupName", parameterInfo.GroupName);
            dbCmd.Parameters.AddWithValue("@Key", parameterInfo.Key);
            dbCmd.Parameters.AddWithValue("@Value", parameterInfo.Value);
            dbCmd.Parameters.AddWithValue("@IsActive", parameterInfo.IsActive);
            dbCmd.Parameters.AddWithValue("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
                return (int)dbCmd.Parameters["@RETURN_VALUE"].Value;
            }
            finally
            {
                dbConn.Close();
            }
        }
        public static Parameters GetHashtableByGroupName(string groupName)
        {
            Parameters parameters = new Parameters();
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Parameter_GetByGroupName_NotUnit", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GroupName", groupName);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                if (retVal.Rows.Count > 0)
                {
                    foreach (DataRow dr in retVal.Rows)
                    {
                        ParameterInfo para = new ParameterInfo();
                        para.ID = Convert.ToInt32(dr["ID"]);
                        para.GroupName = dr["GroupName"].ToString();
                        para.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        para.Key = dr["Key"].ToString();
                        para.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
                        para.Unit = Convert.ToInt16(dr["Unit"]);
                        para.Value = dr["Value"].ToString();
                        para.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        parameters.Add(dr["Key"].ToString(),para);
                    }
                }
            }
            finally
            {
                dbConn.Close();
            }
            return parameters;
        }
        public static DataTable GetMailServerParameter(string mailServerGroupName,string host,string port,string username,string password)
        {
            Parameters paras = GetHashtableByGroupName(mailServerGroupName);
            DataTable tbl = new DataTable();
            DataColumn col;
            DataRow row;

            col = new DataColumn();
            col.ColumnName = host;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = port;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = username;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = password;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "CreatedDate";
            col.DataType = System.Type.GetType("System.DateTime");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "ModifiedDate";
            col.DataType = System.Type.GetType("System.DateTime");
            tbl.Columns.Add(col);

            row = tbl.NewRow();
            if (paras.Count > 0)
            {
                row[host] = paras[host].ToString();
                row[port] = paras[port].ToString();
                row[username] = paras[username].ToString();
                row[password] = paras[password].ToString();
                ParameterInfo obj = paras[host] as ParameterInfo;
                row["CreatedDate"] = obj.CreatedDate;
                row["ModifiedDate"] = obj.ModifiedDate;
            }
            tbl.Rows.Add(row);

            return tbl;
        }
        public static DataTable GetPaypalParameter(string paypalGroupName, string username, string password, string signature)
        {
            Parameters paras = GetHashtableByGroupName(paypalGroupName);
            DataTable tbl = new DataTable();
            DataColumn col;
            DataRow row;

            col = new DataColumn();
            col.ColumnName = username;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = password;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = signature;
            col.DataType = System.Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "CreatedDate";
            col.DataType = System.Type.GetType("System.DateTime");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "ModifiedDate";
            col.DataType = System.Type.GetType("System.DateTime");
            tbl.Columns.Add(col);

            row = tbl.NewRow();
            if (paras.Count > 0)
            {
                row[username] = paras[username].ToString();
                row[password] = paras[password].ToString();
                row[signature] = paras[signature].ToString();
                ParameterInfo obj = paras[username] as ParameterInfo;
                row["CreatedDate"] = obj.CreatedDate;
                row["ModifiedDate"] = obj.ModifiedDate;
            }
            tbl.Rows.Add(row);

            return tbl;
        }
        public static DataTable GetTableByGroupName(string groupName)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Parameter_GetByGroupName", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@GroupName", groupName);
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }
        public static ParameterInfo GetInfo(string key)
        {
            ParameterInfo retVal = null;
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Parameter_GetInfo", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@Key", key);
            try
            {
                dbConn.Open();
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.Read())
                {
                    retVal = new ParameterInfo();
                    retVal.ID = Convert.ToInt32(dr["ID"]);
                    retVal.GroupName = Convert.ToString(dr["GroupName"]);
                    retVal.Key = Convert.ToString(dr["Key"]);
                    retVal.Value = Convert.ToString(dr["Value"]);
                    retVal.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                    retVal.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
                    retVal.Unit = Convert.ToInt16(dr["Unit"]);
                    retVal.IsActive = Convert.ToBoolean(dr["IsActive"]);
                }
                if (dr != null) dr.Close();
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;

        }
        public static void Update(ParameterInfo parameterInfo)
        { 
			SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
			SqlCommand dbCmd = new SqlCommand("Parameter_Update", dbConn);
			dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", parameterInfo.ID);
            dbCmd.Parameters.AddWithValue("@GroupName", parameterInfo.GroupName);
            dbCmd.Parameters.AddWithValue("@Key", parameterInfo.Key);
            dbCmd.Parameters.AddWithValue("@Value", parameterInfo.Value);
            dbCmd.Parameters.AddWithValue("@Unit",parameterInfo.Unit);
            dbCmd.Parameters.AddWithValue("@IsActive", parameterInfo.IsActive);
			try {
				dbConn.Open();
				dbCmd.ExecuteNonQuery();
			}
			finally
			{
				dbConn.Close();
			}
        }
        public static void UpdateGroupParameter(List<ParameterInfo> paras)
        {
            foreach (ParameterInfo obj in paras)
            {
                Update(obj);
            }
        }
        public static void Delete(int id)
        {
            SqlConnection dbConn = new SqlConnection(AppEnv.ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Parameter_Delete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.AddWithValue("@ID", id);
            try
            {
                dbConn.Open();
                dbCmd.ExecuteNonQuery();
            }
            finally
            {
                dbConn.Close();
            }
        }
    }
}
