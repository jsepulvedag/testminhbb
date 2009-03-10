using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Restaurant.Library.Utilities
{
    public class UrlUtilities
    {
        public static string UpdateQueryStringItem(string pathAndQuery, string queryString, string value)
        {
            string retVal = pathAndQuery.ToLower();

            Regex rex = new Regex(queryString.ToLower() + "=[^\\?&]*");
            Match m = rex.Match(pathAndQuery.ToLower());

            if (m.Success)
                retVal = retVal.Replace(m.Value, queryString + "=" + value);
            else
                retVal += retVal.IndexOf("?") >= 0 ?
                          "&" + queryString + "=" + value :
                          "?" + queryString + "=" + value;

            return retVal;
        }
    }
}
