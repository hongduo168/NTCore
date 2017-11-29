using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace NTCore.Utility
{
    public static class Assister
    {
        #region 微信时间处理

        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间

        /// <summary>
        /// 转换微信DateTime时间到C#时间
        /// </summary>
        /// <param name="unixStramp">微信DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromUnixStramp(long unixStramp)
        {
            return BaseTime.AddTicks((unixStramp + 8 * 60 * 60) * 10000000);
        }

        /// <summary>
        /// 获取微信DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetUnixDateTime(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }
        /// <summary>
        /// 获取微信DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetUnixDateTimeWithMilionSecond(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000 - 8 * 60 * 60 * 1000;
        }
        #endregion

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(i.ToString("x2"));
            }
            return builder.ToString();
        }


        #region enum

        /// <summary>
        /// 获取DescriptionAttribute
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameInstead"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute == null && nameInstead)
            {
                return name;
            }
            return attribute?.Description;

        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <param name="funcGetName">获得值得文本</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        public static Dictionary<int, string> EnumToDictionary(Type enumType, Func<Enum, string> funcGetName)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Parameter type must be enumerated", nameof(enumType));
            }
            Dictionary<int, string> enumDict = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                int key = Convert.ToInt32(enumValue);
                string value = funcGetName(enumValue);
                enumDict.Add(key, value);
            }
            return enumDict;
        }

        /// <summary>
        /// 字符转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ConvertToEnum<T>(string s) where T : struct, IComparable, IConvertible, IFormattable
        {
            T e = default(T);
            try
            {
                e = (T)Enum.Parse(typeof(T), s);
            }
            catch (Exception ex)
            {
                return e;
            }

            return e;
        }

        #endregion


    }
}
