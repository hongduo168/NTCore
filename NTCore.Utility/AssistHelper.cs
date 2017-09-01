using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NTCore.Utility
{
    public static class AssistHelper
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

        
    }
}
