using System;

namespace Restaurant.Library.Utilities
{
	public class ConvertHelper
	{
		public static string FormatTimeVn(DateTime dt, string defaultText)
		{
			if (ToDateTime(dt) != new DateTime(1900, 1, 1))
				return dt.ToString("dd-mm-yy");
			else
				return defaultText;
		}

		public static int ToInt32(object obj)
		{
			int retVal = 0;

			try
			{
				retVal = Convert.ToInt32(obj);
			}
			catch
			{
				retVal = 0;
			}

			return retVal;
		}

		public static int ToInt32(object obj, int defaultValue)
		{
			int retVal = defaultValue;

			try
			{
				retVal = Convert.ToInt32(obj);
			}
			catch
			{
				retVal = defaultValue;
			}

			return retVal;
		}

		public static string ToString(object obj)
		{
			string retVal;

			try
			{
				retVal = Convert.ToString(obj);
			}
			catch
			{
				retVal = String.Empty;
			}

			return retVal;
		}

		public static DateTime ToDateTime(object obj)
		{
			DateTime retVal;
			try
			{
				retVal = Convert.ToDateTime(obj);
			}
			catch
			{
				retVal = DateTime.Now;
			}
			if (retVal == new DateTime(1, 1, 1)) return DateTime.Now;

			return retVal;
		}

		public static DateTime ToDateTime(object obj, DateTime defaultValue)
		{
			DateTime retVal;
			try
			{
				retVal = Convert.ToDateTime(obj);
			}
			catch
			{
				retVal = DateTime.Now;
			}
			if (retVal == new DateTime(1, 1, 1)) return defaultValue;

			return retVal;
		}

		public static bool ToBoolean(object obj)
		{
			bool retVal;

			try
			{
				retVal = Convert.ToBoolean(obj);
			}
			catch
			{
				retVal = false;
			}

			return retVal;
		}

		public static double ToDouble(object obj)
		{
			double retVal;

			try
			{
				retVal = Convert.ToDouble(obj);
			}
			catch
			{
				retVal = 0;
			}

			return retVal;
		}

		public static double ToDouble(object obj, double defaultValue)
		{
			double retVal;

			try
			{
				retVal = Convert.ToDouble(obj);
			}
			catch
			{
				retVal = defaultValue;
			}

			return retVal;
		}
        public static string ConvertToMinute(object obj)
        {
            string retVal = "0.00";
            double value = obj.ToString() != "" ? Convert.ToDouble(obj.ToString()) : 0;
            string[] valueList = value.ToString(retVal).Split('.');

            double minutes = Convert.ToDouble("0." + valueList[1]) * 60;
            int second =(int) minutes%10;
            
            if(minutes==0)
            {
                retVal = valueList[0] + ".00";
            }
            else
            {
                if(minutes<10)
                {
                    retVal = valueList[0] + ".0" + Math.Round(minutes).ToString();
                }
                else
                {
                    retVal = valueList[0] + "." + Math.Round(minutes).ToString() ;
                }
            }
            return retVal;
        }

        public static string ConvertToReal(string input)
        {
            string retVal = "0.00";
            double value = input != "" ? Convert.ToDouble(input) : 0;
            string[] valueList = value.ToString(retVal).Split('.');

            double real = Convert.ToDouble(valueList[1]) / 60;
            retVal = String.Format("{0:0.00}", Convert.ToInt32(valueList[0]) + real);
            return retVal;
        }
	}
}