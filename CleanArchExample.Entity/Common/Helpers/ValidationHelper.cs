using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchExample.Entity.Common.Helpers
{
    public static class ValidationHelper
    {

        public static bool CheckIsValidEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }



        //public static  bool IsValidEmail(string email)
        //  {
        //      try
        //      {
        //          var addr = new System.Net.Mail.MailAddress(email);
        //          return addr.Address == email;
        //      }
        //      catch
        //      {
        //          return false;
        //      }
        //  }

        public static bool CheckIsValidMobileNumber(string mobileNumber)
        {
            if (mobileNumber.Length <= 16 || mobileNumber.Length >= 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ConvertArabicDigitsToEnglishDigits(string arabicNumber)
        {
            string EnglishNumbers = string.Empty;

            for (int i = 0; i < arabicNumber.Length; i++)
            {
                if (Char.IsDigit(arabicNumber[i]))
                {
                    EnglishNumbers += char.GetNumericValue(arabicNumber, i);
                }
                else
                {
                    EnglishNumbers += arabicNumber[i].ToString();
                }
            }
            return EnglishNumbers;

        }

        public static string ValidateMobileNumber(string mobileNumber)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(mobileNumber))
            {
                mobileNumber = ConvertArabicDigitsToEnglishDigits(mobileNumber);


                switch (mobileNumber.Length)
                {
                    case 9:
                        {
                            if (mobileNumber.StartsWith("5"))
                            { result = mobileNumber; }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                    case 10:
                        {
                            if (mobileNumber.StartsWith("05"))
                            { result = mobileNumber.TrimStart('0'); }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                    case 12:
                        {
                            if (mobileNumber.StartsWith("9665"))
                            { result = mobileNumber.TrimStart("966".ToCharArray()); }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                    case 13:
                        {
                            if (mobileNumber.StartsWith("+9665"))
                            {
                                result = mobileNumber.TrimStart("+966".ToCharArray());
                            }
                            else if (mobileNumber.StartsWith("96605"))
                            {
                                result = mobileNumber.TrimStart("9660".ToCharArray());
                            }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                    case 14:
                        {
                            if (mobileNumber.StartsWith("009665"))
                            {
                                result = mobileNumber.TrimStart("00966".ToCharArray());
                            }
                            else if (mobileNumber.StartsWith("+96605"))
                            {
                                result = mobileNumber.TrimStart("+9660".ToCharArray());
                            }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                    case 15:
                        {
                            if (mobileNumber.StartsWith("0096605"))
                            { result = mobileNumber.TrimStart("009660".ToCharArray()); }
                            else
                            {
                                result = string.Empty;
                            }
                            break;
                        }
                }
            }

            return result;
        }

    }
}
