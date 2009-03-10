using System;
using System.Configuration;

namespace Restaurant.Library.Utilities
{
    public class AppEnv
    {
        public static string ConnectionString
        {
            get { return (ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString); }
        }
        public static string API_PASSWORD
        {
            get { return ConfigurationManager.AppSettings["APIPassword"].ToString(); }
        }
        public static string API_SIGNATURE
        {
            get { return ConfigurationManager.AppSettings["APISignature"].ToString(); }
        }
        public static string API_USERNAME
        {
            get { return ConfigurationManager.AppSettings["APIUserName"].ToString(); }
        }
        public const string USERNAME_EXIST = "The UserName is exist !";
        public const string EMAIL_EXIST = "The Mail is exist !";
        public const string INSERTED_SUCCESS = "Inserted success !";
        public const string INSERTED_FAILURE = "Inserted unsuccess !";
        public const string UPDATEED_SUCCESS = "Updated success !";
        public const string UPDATEED_FAILURE = "Updated unsuccess !";
        public const string DELETED_SUCCESS = "Deleted success !";
        public const string DELETED_FAILURE = "Deleted unsuccess !";
        public const string CANNOT_DELETE = "You can't delete because this data has been used by another process";
    }
}
