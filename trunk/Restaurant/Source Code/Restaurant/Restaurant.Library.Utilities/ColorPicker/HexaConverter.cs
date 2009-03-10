using System;

namespace Restaurant.Library.Utilities.ColorPicker
{
    public class HexaConverter
    {
        public static int ConvertFromString(string hexa)
        {
            ConvertHexa obj = new ConvertHexa();
            return obj.ConvertToInt(hexa);
        }
        public static int ConvertToRed(string hexa)
        {
            hexa = hexa.Substring(1, 2);
            ConvertHexa obj = new ConvertHexa();
            return obj.ConvertToInt(hexa);
        }
        public static int ConvertToGreen(string hexa)
        {
            hexa = hexa.Substring(3, 2);
            ConvertHexa obj = new ConvertHexa();
            return obj.ConvertToInt(hexa);
        }
        public static int ConvertToBlue(string hexa)
        {
            hexa = hexa.Substring(5, 2);
            ConvertHexa obj = new ConvertHexa();
            return obj.ConvertToInt(hexa);
        }
    }
    class ConvertHexa
    {
        private int FormatToInt(string c)
        {
            string tmp = c.ToLower();
            if (tmp.Equals("a"))
            {
                return 10;
            }
            else if (tmp.Equals("b"))
            {
                return 11;
            }
            else if (tmp.Equals("c"))
            {
                return 12;
            }
            else if (tmp.Equals("d"))
            {
                return 13;
            }
            else if (tmp.Equals("e"))
            {
                return 14;
            }
            else if (tmp.Equals("f"))
            {
                return 15;
            }
            else
            {
                return Convert.ToInt32(c);
            }
        }
        public int ConvertToInt(string hexa)
        {
            hexa = hexa.Replace("#","");
            int retVal = 0;
            for (int i = 0; i < hexa.Length; i++)
            {
                retVal += Convert.ToInt32(FormatToInt(hexa[i].ToString()) * Math.Pow(16, hexa.Length - 1 - i));
            }
            return retVal;
        }
    }
}
