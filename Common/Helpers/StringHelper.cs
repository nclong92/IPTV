using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class StringHelper
    {
        #region Random
        //Function to get random number
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }

        #endregion

        #region GenerateKey

        public static string UniqueNumber(int maxSize)
        {
            var chars = "1234567890".ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
        public static string UniqueKey(int maxSize)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }


        #endregion

        public static string UnicodeUnSign(string s)
        {
            const string uniChars = "àáảãạâầấẩẫậăằắẳẵặèéẻẽẹêềếểễệđìíỉĩịòóỏõọôồốổỗộơờớởỡợùúủũụưừứửữựỳýỷỹỵÀÁẢÃẠÂẦẤẨẪẬĂẰẮẲẴẶÈÉẺẼẸÊỀẾỂỄỆĐÌÍỈĨỊÒÓỎÕỌÔỒỐỔỖỘƠỜỚỞỠỢÙÚỦŨỤƯỪỨỬỮỰỲÝỶỸỴÂĂĐÔƠƯ";
            const string koDauChars = "aaaaaaaaaaaaaaaaaeeeeeeeeeeediiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAAEEEEEEEEEEEDIIIOOOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYAADOOU";

            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            string retVal = String.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                int pos = uniChars.IndexOf(s[i].ToString());
                if (pos >= 0)
                    retVal += koDauChars[pos];
                else
                    retVal += s[i];
            }
            return retVal;
        }

        public static string GetPathbyDate()
        {
            return DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
        }

        public static string FormatNumber(string input, char commaDelimiter = '.')
        {
            //if(isNaN(input)) return ;
            const string pattern = "(-?[0-9]+)([0-9]{3})";
            var regex = new Regex(pattern);
            while (Regex.IsMatch(input, pattern))
            {
                input = regex.Replace(input, "$1" + commaDelimiter + "$2");
            }
            return input;
        }

        public static string GetHexTime()
        {
            return GetHexTime(DateTime.Now);
        }

        public static string GetHexTime(DateTime date)
        {
            var date2 = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            var epochTime = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan diff = date2 - epochTime;
            return ((long)diff.TotalSeconds).ToString();
        }

        public static T[] GetEnumArray<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }

        #region Helper
        public static string GetStringFromObj(object obj)
        {
            try
            {

                var str = Convert.ToString(obj);// (string)obj;
                return str;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public static int GetIntFromObj(object obj)
        {
            try
            {

                var str = obj.ToString();
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }

        }

        #endregion

        public static string ExtractString(string source, int length)
        {
            if (string.IsNullOrEmpty(source))
                return "";
            source = source.Trim();
            string dest = String.Empty;
            if (length == 0 || source.Length == 0)
                return dest;
            if (source.Length < length)
                dest = source;
            else
            {
                string tmp = source.Substring(0, length);
                int nSub = tmp.Length - 1;
                while (tmp[nSub] != ' ')
                {
                    nSub--;
                    if (nSub == 0) break;
                }
                dest = tmp.Substring(0, nSub);
            }
            return dest;
        }
    }
}
