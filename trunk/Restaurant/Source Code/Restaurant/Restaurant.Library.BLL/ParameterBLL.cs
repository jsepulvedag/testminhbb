using System;
using System.Data;
using Restaurant.Library.Entities;
using Restaurant.Library.DAL;
using System.Collections;
using System.Collections.Generic;

namespace Restaurant.Library.BLL
{
    public class ParameterBLL
    {
        public static int Insert(ParameterInfo parameterInfo)
        {
            return ParameterDAL.Insert(parameterInfo);
        }
        public static Parameters GetHashtableByGroupName(string groupName)
        {
            return ParameterDAL.GetHashtableByGroupName(groupName);
        }
        public static DataTable GetTableByGroupName(string groupName)
        {
            return ParameterDAL.GetTableByGroupName(groupName);
        }
        public static ParameterInfo GetInfo(string key)
        {
            return ParameterDAL.GetInfo(key);
        }
        public static void Update(ParameterInfo parameter)
        {
            ParameterDAL.Update(parameter);
        }
        public static void Delete(int id)
        {
            ParameterDAL.Delete(id);        
        }
        public static DataTable GetMailServerParameter(string mailServerGroupName, string host, string port, string username, string password)
        {
            return ParameterDAL.GetMailServerParameter(mailServerGroupName, host, port, username, password);
        }
        public static DataTable GetPaypalParameter(string paypalGroupName, string username, string password, string signature)
        {
            return ParameterDAL.GetPaypalParameter(paypalGroupName,username,password,signature);
        }
        public static void UpdateGroupParameter(List<ParameterInfo> paras)
        {
            ParameterDAL.UpdateGroupParameter(paras);
        }
    }
}
