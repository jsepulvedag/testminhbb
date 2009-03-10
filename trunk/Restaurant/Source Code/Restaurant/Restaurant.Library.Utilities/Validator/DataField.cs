using System;
using System.Text.RegularExpressions;

namespace Restaurant.Library.Utilities.Validator
{
    public class DataField
    {
        public static bool CheckLength(string input, int minLength)
        {
            if (input.Trim().Length < minLength)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 1111-2323-2312-3434 
        /// 1234343425262837
        /// 1111 2323 2312 3434
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool CheckValidCreditCard(string input)
        {
            Regex r = new Regex(@"^(\d{4}-){3}\d{4}$|^(\d{4} ){3}\d{4}$|^\d{16}$");
            Match m = r.Match(input);
            if (m.Success)
            {
                input = input.Replace("-", "").Replace(" ", "");
                int[] digits = new int[input.Length];
                for (int len = 0; len < input.Length; len++)
                {
                    digits[len] = Int32.Parse(input.Substring(len, 1));
                }
                int sum = 0;
                bool alt = false;
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    int curDigit = digits[i];
                    if (alt)
                    {
                        curDigit *= 2;
                        if (curDigit > 9)
                        {
                            curDigit -= 9;
                        }
                    }
                    sum += curDigit;
                    alt = !alt;
                }
                return sum % 10 == 0;
            }
            return false;
        }
        /// <summary>
        /// Password validator Requires 6-20 characters including at least 1 upper or lower alpha, and 1 digit.
        /// abc123 
        /// BA99342bob
        /// 1232z123311
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckPassword(string input)
        {
            Regex r = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?!.*[\W_\x7B-\xFF]).{6,15}$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// must be alphanumeric with at least one number, one letter, and be between 6-15 character in length
        /// C2dfeed 
        /// sporttrak1 
        /// 11223a
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool CheckUserName(string input)
        {
            Regex r = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,20})$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        public static bool CheckFullName(string input)
        {
            Regex r = new Regex(@"^[a-zA-Z''-'\s]{1,30}$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        public static bool CheckEmail(string input)
        {
            Regex r = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        public static bool CheckPhoneNumber(string input)
        {
            Regex r = new Regex(@"((\(\d{3,4}\)|\d{3,4}-)\d{4,9}(-\d{1,5}|\d{0}))|(\d{4,12})");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        public static bool CheckInteger(string input)
        {
            Regex r = new Regex(@"^\d+$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
        public static bool CheckDouble(string input)
        {
            Regex r = new Regex(@"^([+/-]?((([0-9]+(\.)?)|([0-9]*\.[0-9]+))([eE][+\-]?[0-9]+)?))$");
            Match m = r.Match(input);
            if (m.Success)
            {
                return true;
            }
            return false;
        }
    }
}
