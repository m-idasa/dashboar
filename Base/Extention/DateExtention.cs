using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsetmc.Base.Extention
{
    public static class DateExtention
    {

        public static string ToPersianDateTime(this DateTime dt)
        {
            try
            {
                var dateTime = dt;
                PersianCalendar persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dateTime).ToString();
                string month = persianCalendar.GetMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string hour = dateTime.Hour.ToString().PadLeft(2, '0');
                string minute = dateTime.Minute.ToString().PadLeft(2, '0');
                string second = dateTime.Second.ToString().PadLeft(2, '0');
                return String.Format("{0}/{1}/{2} {3}:{4}:{5}", year, month, day, hour, minute, second);
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToPersianDateTime");
            }
        }
        public static string ToPersianDate(this DateTime dt)
        {
            try
            {
                var dateTime = dt;
                PersianCalendar persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dateTime).ToString();
                string month = persianCalendar.GetMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                return String.Format("{0}/{1}/{2}", year, month, day);
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToPersianDate");
            }
        } 
        public static string ToPersianDateAndWeek(this DateTime dt)
        {
            try
            {
                var dateTime = dt;
                PersianCalendar persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dateTime).ToString();
                string month = persianCalendar.GetMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                return String.Format("{0}/{1}/{2}  {3}", year, month, day, DayOfPersianWeek((int)dt.DayOfWeek));
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToPersianDate");
            }
        }
        public static string ToPersianDateAndWeekTime(this DateTime dt)
        {
            try
            {
                var dateTime = dt;
                PersianCalendar persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dateTime).ToString();
                string month = persianCalendar.GetMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string hour = dateTime.Hour.ToString().PadLeft(2, '0');
                string minute = dateTime.Minute.ToString().PadLeft(2, '0');
                string second = dateTime.Second.ToString().PadLeft(2, '0');
                return String.Format("{0}/{1}/{2} {4}:{5}:{6}  {3}", year, month, day, DayOfPersianWeek((int)dt.DayOfWeek), hour, minute, second);
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToPersianDate");
            }
        }
        public static string ToPersianDate(this string dt)
        {
            try
            {
                var dateTime = Convert.ToDateTime(dt);
                PersianCalendar persianCalendar = new PersianCalendar();
                string year = persianCalendar.GetYear(dateTime).ToString();
                string month = persianCalendar.GetMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                string day = persianCalendar.GetDayOfMonth(dateTime).ToString()
                               .PadLeft(2, '0');
                return String.Format("{0}/{1}/{2}", year, month, day);
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToPersianDate");
            }
        }
        public static DateTime ToMiladiDateTime(this string persianDateTime)
        {
            try
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int year = Convert.ToInt32(persianDateTime.Substring(0, 4));
                int month = Convert.ToInt32(persianDateTime.Substring(5, 2));
                int day = Convert.ToInt32(persianDateTime.Substring(8, 2));
                int hour = 0;
                int minute = 0;
                hour = Convert.ToInt32(persianDateTime.Substring(11, 2));
                minute = Convert.ToInt32(persianDateTime.Substring(14, 2));
                return pc.ToDateTime(year, month, day, hour, minute, 0, 0);

            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToMiladiDateTime");
            }

        }
        public static DateTime ToMiladiDate(this string persianDate)
        {
            try
            {
                PersianCalendar pc = new PersianCalendar();
                int year = Convert.ToInt32(persianDate.Substring(0, 4));
                int month = Convert.ToInt32(persianDate.Substring(5, 2));
                int day = Convert.ToInt32(persianDate.Substring(8, 2));
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch
            {
                throw new Exception("Error Convert datetime Mehtod:ToMiladiDateTime");
            }

        }
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static string DayOfPersianWeek(DateTime dateTime)
        {
            int DayNum = (int)dateTime.DayOfWeek;
            return DayOfPersianWeek(DayNum);
        }
        public static string DayOfPersianWeek(int DayNum)
        {
            string Name = string.Empty;
            switch (DayNum)
            {
                case 0:
                    Name = "یک شنبه";
                    break;
                case 1:
                    Name = "دو شنبه";
                    break;
                case 2:
                    Name = "سه شنبه";
                    break;
                case 3:
                    Name = "چهار شنبه";
                    break;
                case 4:
                    Name = "پنج شنبه";
                    break;
                case 5:
                    Name = "جمعه";
                    break;
                case 6:
                    Name = "شنبه";
                    break;

            }
            return Name;
        }


        public static Boolean CheckVaidl_INTDATE(this int persianDateTime)
        {
            try
            {
                var str = persianDateTime.ToString();
                if (str.Length != 8)
                    return false;
                if(int.Parse(str.Substring(0,4))<2000)
                    return false;
                if (int.Parse(str.Substring(4, 2)) <1 && int.Parse(str.Substring(4, 2))>12 )
                    return false;
                if (int.Parse(str.Substring(6, 2)) < 1 && int.Parse(str.Substring(6, 2)) > 31)
                    return false;

                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int year = Convert.ToInt32(str.Substring(0, 4));
                int month = Convert.ToInt32(str.Substring(4, 2));
                int day = Convert.ToInt32(str.Substring(6, 2));
                int hour = 0;
                int minute = 0;
                var date= pc.ToDateTime(year, month, day, hour, minute, 0, 0);
                return date != null;
            }
            catch
            {
                return false;
            }

        }


    }
}
