using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class ModelExtensions
    {
        public static List<int> ToListInt(this string str, char c = '|')
        {

            var result = new List<int>();

            foreach (var item in str.Split(c))
            {
                if (!string.IsNullOrEmpty(item))
                {

                    var tmp = 0;
                    if (int.TryParse(item, out tmp))
                    {
                        result.Add(tmp);
                    }
                }
            }

            return result;
        }
        public static string ToListInt(this List<int> list, char c = '|')
        {
            var result = string.Empty;

            if (list != null && list.Count > 0)
            {
                list = list.Distinct().ToList();
                foreach (int s in list)
                {
                    result += c + s.ToString();
                }
            }
            return result.Trim(c);
        }

        public static string ToListString(this List<string> list, char c = '|')
        {
            var result = string.Empty;

            if (list != null && list.Count > 0)
            {
                list = list.Distinct().ToList();
                foreach (string s in list)
                {
                    result += c + s.Trim();
                }

            }

            return result.Trim(c);
        }

        public static List<string> ToListString(this string input, char c = '|')
        {
            var result = new List<string>();
            foreach (var item in input.Split(c))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static string ToStringDisplay(this string input, char c = '|')
        {
            var result = string.Empty;
            foreach (var item in input.Split(c))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    result += $"{item}, ";
                }
            }

            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
