using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.DataModel
{
    public class DataEnum
    {
        /// <summary>
        /// 数据库空置
        /// </summary>
        public static readonly DateTime DbNullDatetime = new DateTime(1970, 1, 1);

        /// <summary>
        /// 全局日期格式
        /// </summary>
        public static readonly string DatetimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 数据库默认值
        /// </summary>
        public const string DbDefaultDatetime = ("1970-01-01 00:00:00");


        #region model枚举

        public enum SiteStateType
        {
            /// <summary>
            /// 正常访问
            /// </summary>
            Normal = 0,


            /// <summary>
            /// 暂停服务
            /// </summary>
            PauseService = 10,


            /// <summary>
            /// 停止服务
            /// </summary>
            StopService = 20,
        }

        #endregion

    }
}
