using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTime(this DateTime date)
        {

            var timeSpan = (date - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        public static DateTime UnixTimestampToDateTime(this double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }

        public static double DateTimeToUnixTimestamp(this DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }

        public static DateTime UnixTimestampToLocalDateTimeLong(this long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static long LocalDateTimeToUnixTimestampLong(this DateTime dateTime)
        {
            return (long)(TimeZoneInfo.ConvertTimeToUtc(dateTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime ChangeTime(this DateTime dateTime, int hours, int minutes)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                0,
                0,
                dateTime.Kind);
        }

        public static DateTime? ToViDate(this string input)
        {
            DateTime dt;
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null,
                                   DateTimeStyles.None,
                out dt))
            {
                //valid date
                return dt;
            }
            else
            {

                if (DateTime.TryParseExact(input, "d/M/yyyy", null,
                                   DateTimeStyles.None,
                out dt))
                {
                    //valid date
                    return dt;
                }
                //invalid date
            }
            return null;
        }

        public static DateTime? ToViDate2(this string input)
        {
            DateTime dt;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy", null,
                                   DateTimeStyles.None,
                out dt))
            {
                //valid date
                return dt;
            }
            else
            {

                if (DateTime.TryParseExact(input, "d-M-yyyy", null,
                                   DateTimeStyles.None,
                out dt))
                {
                    //valid date
                    return dt;
                }
                //invalid date
            }
            return null;
        }
        public static string ToViDate(this DateTime date)
        {
            return string.Format("{0:dd/MM/yyyy}", date);
        }

        public static string ToViDate2(this DateTime date)
        {
            return string.Format("{0:dd-MM-yyyy}", date);
        }

        public static string ToViDateTime(this DateTime date)
        {

            return string.Format("{0: HH:mm dd/MM/yyyy}", date);
            //return string.Format("{0} giờ {1} phút ngày {2} tháng {3} năm {4}", date.Hour, date.Minute, date.Day, date.Month, date.Year);
        }

        public static DateTime? ToViDate3(this string input)
        {
            DateTime dt;
            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss", null,
                                   DateTimeStyles.None,
                out dt))
            {
                //valid date
                return dt;
            }

            return null;
        }

        public static string ToViDate3(this DateTime date)
        {
            return string.Format("{0:yyyy-MM-dd}", date);
        }

        public static string ToViHour3(this DateTime dateTime)
        {
            return $"{dateTime.Hour.ToString("00")}:{dateTime.Minute.ToString("00")}";
        }

        public static string ToViHour4(this DateTime dateTime)
        {
            return dateTime.ToString("h tt");
        }

        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public static int GetWorkDays(int year, int month)
        {
            List<DayOfWeek> weekOffDays = new List<DayOfWeek>() { DayOfWeek.Sunday, DayOfWeek.Saturday };
            //DateTime dateToday = DateTime.Today;
            var firstDayOfMonth = new DateTime(year, month, 1); // will give you the First day of this month
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var businessDaysOfMonth = 0;
            for (var dateObject = firstDayOfMonth; dateObject <= lastDayOfMonth; dateObject = dateObject.AddDays(1))
            {
                if (!weekOffDays.Contains(dateObject.DayOfWeek))
                    businessDaysOfMonth++;
            }

            return businessDaysOfMonth;
        }
    }
}
