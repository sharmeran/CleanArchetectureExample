using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CleanArchExample.Entity.Common.Helpers
{
    public static class DateHelper
    {
        public static DateTime FormatedGeregorian(string dateTime)
        {
            dateTime = string.IsNullOrEmpty(dateTime) ? DateTime.Now.ToString("dd-mm-yyyy") : dateTime;
            var splitDate = dateTime.Split('-');
            return new DateTime(Convert.ToInt32(splitDate[2]), Convert.ToInt32(splitDate[1]), Convert.ToInt32(splitDate[0]));
        }

        public static string GeregorianToHijri(DateTime date)
        {
            DateTimeFormatInfo dateTimeFormatInfo = new CultureInfo("ar-SA").DateTimeFormat;
            dateTimeFormatInfo.Calendar = new UmAlQuraCalendar();
            dateTimeFormatInfo.ShortDatePattern = "d/M/yyyy";
            return date.ToString("yyyy/M/d", dateTimeFormatInfo);
        }

        public static DateTime HijriToGeregorian(string date)
        {
            date = date.Replace('/', '-');
            string[] dateSplit = date.Split('-');
            if (dateSplit.Length == 3)
            {
                int yearIndex = (dateSplit[2].Length == 4 ? 2 : 0);
                int dayIndex = (yearIndex == 2 ? 0 : 2);

                DateTime umAlqura = new DateTime(Convert.ToInt32(dateSplit[yearIndex]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[dayIndex]), new UmAlQuraCalendar());
                return umAlqura;
            }
            else
            {
                return DateTime.Now;
            }
        }

        public static bool Is29DaysInMonth(int year, int month)
        {
            return (DateHelper.GetDaysInHijriMonth(year, month) == 30 ? false : true);
        }

        public static string GeregorianToHijriFormatted(DateTime date, string format = "yyyy/M/d")
        {
            DateTimeFormatInfo dateTimeFormatInfo = new CultureInfo("ar-SA").DateTimeFormat;
            dateTimeFormatInfo.Calendar = new UmAlQuraCalendar();
            dateTimeFormatInfo.ShortDatePattern = "d/M/yyyy";
            return date.ToString(format, dateTimeFormatInfo);
        }

        /// <summary>
        /// Gets the hijri month name in arabic
        /// </summary>
        /// <param name="HijriDate">hijri date in format yyyy/M/d</param>
        /// <returns></returns>
        public static string HijriGetMonthName(string HijriDate)
        {
            int MonthNumber = int.Parse(HijriDate.Split('/', '-')[1]);

            return HijriGetMonthName(MonthNumber);
        }

        /// <summary>
        /// Gets the hijri month name in arabic
        /// </summary>
        /// <param name="HijriDate">Geregorian date</param>
        /// <returns></returns>
        public static string HijriGetMonthName(DateTime date)
        {
            string HijriDate = GeregorianToHijri(date);
            return HijriGetMonthName(HijriDate);
        }

        /// <summary>
        /// Gets the hijri month name in arabic
        /// </summary>
        /// <param name="MonthNumber">Month Number 1~12</param>
        /// <returns></returns>
        public static string HijriGetMonthName(int MonthNumber)
        {
            string Name = "";
            switch (MonthNumber)
            {
                case 1:
                    Name = "محرم";
                    break;
                case 2:
                    Name = "صفر";
                    break;
                case 3:
                    Name = "ربيع الأول";
                    break;
                case 4:
                    Name = "ربيع الثاني";
                    break;
                case 5:
                    Name = "جمادى الأول";
                    break;
                case 6:
                    Name = "جمادى الآخرة";
                    break;
                case 7:
                    Name = "رجب";
                    break;
                case 8:
                    Name = "شعبان";
                    break;
                case 9:
                    Name = "رمضان";
                    break;
                case 10:
                    Name = "شوال";
                    break;
                case 11:
                    Name = "ذو القعده";
                    break;
                case 12:
                    Name = "ذو الحجة";
                    break;

            }
            return Name;
        }

        /// <summary>
        /// Gets the Greg month name in arabic
        /// </summary>
        /// <param name="GregDate">greg date in format yyyy/M/d</param>
        /// <returns></returns>
        public static string GregGetMonthName(string GregDate)
        {
            int MonthNumber = int.Parse(GregDate.Split('/', '-')[1]);

            return GregGetMonthName(MonthNumber);
        }

        /// <summary>
        /// Gets the Greg month name in arabic
        /// </summary>
        /// <param name="date">Geregorian date</param>
        /// <returns></returns>
        public static string GregGetMonthName(DateTime date)
        {
            return GregGetMonthName(date.Day);
        }

        /// <summary>
        /// Gets the Greg month name in arabic
        /// </summary>
        /// <param name="MonthNumber">Month Number 1~12</param>
        /// <returns></returns>
        public static string GregGetMonthName(int MonthNumber)
        {
            string Name = "";
            switch (MonthNumber)
            {
                case 1:
                    Name = "يناير";
                    break;
                case 2:
                    Name = "فبراير";
                    break;
                case 3:
                    Name = "مارس";
                    break;
                case 4:
                    Name = "ابريل";
                    break;
                case 5:
                    Name = "مايو";
                    break;
                case 6:
                    Name = "يونيو";
                    break;
                case 7:
                    Name = "يوليو";
                    break;
                case 8:
                    Name = "أغسطس";
                    break;
                case 9:
                    Name = "سبتمبر";
                    break;
                case 10:
                    Name = "أكتوبر";
                    break;
                case 11:
                    Name = "نوفمبر";
                    break;
                case 12:
                    Name = "ديسمبر";
                    break;

            }
            return Name;
        }

        public static string GetDayOfWeekName(DayOfWeek DayOfWeekNumber)
        {
            string Name = "";
            switch (DayOfWeekNumber)
            {
                case DayOfWeek.Sunday:
                    Name = "الأحد";
                    break;
                case DayOfWeek.Monday:
                    Name = "الاثنين";
                    break;
                case DayOfWeek.Tuesday:
                    Name = "الثلاثاء";
                    break;
                case DayOfWeek.Wednesday:
                    Name = "الأربعاء";
                    break;
                case DayOfWeek.Thursday:
                    Name = "الخميس";
                    break;
                case DayOfWeek.Friday:
                    Name = "الجمعة";
                    break;
                case DayOfWeek.Saturday:
                    Name = "السبت";
                    break;
            }
            return Name;
        }

        /// <summary>
        /// Gets the hijri year
        /// </summary>
        /// <param name="date">Geregorian date</param>
        /// <returns></returns>
        public static string HijriGetYear(DateTime date)
        {
            string HijriDate = GeregorianToHijri(date);
            return HijriDate.Split('/', '-')[0];
        }

        public static bool IsHijriDate(string date)
        {
            string[] value = date.Split('/', '-');
            int day = 0;
            int month = 0;
            int year = 0;

            int yearIndex = (value[2].Length == 4 ? 2 : 0);
            int dayIndex = (yearIndex == 2 ? 0 : 2);

            if (value.Length == 3)
            {
                bool isDay = int.TryParse(value[dayIndex], out day);
                if (isDay)
                {
                    if (day > 0 && day < 31)
                    {
                        bool isMonth = int.TryParse(value[1], out month);
                        if (isMonth)
                        {
                            if (month > 0 && month < 13)
                            {
                                bool isYear = int.TryParse(value[yearIndex], out year);
                                if (isYear)
                                {
                                    if (year > 0 && year < 1536)
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        public static int GetDaysInHijriMonth(int HijriYear, int HijriMonth)
        {
            UmAlQuraCalendar cal = new UmAlQuraCalendar();
            int daysInMonth = cal.GetDaysInMonth(HijriYear, HijriMonth, UmAlQuraCalendar.UmAlQuraEra);
            return daysInMonth;
        }
    }
}
