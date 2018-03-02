using System;
using System.Collections.Generic;

namespace NTCore.BizLogic
{
    public class ErrorCodeDefine
    {
        /// <summary>
        /// 系统繁忙
        /// </summary>
        public const int Error = -1;

        /// <summary>
        /// 请求成功
        /// </summary>
        public const int Success = 0;

        /// <summary>
        /// 系统繁忙
        /// </summary>
        public const int SystemBusy = 1001;


        public const int DbNotData = 1002;

        public readonly static Dictionary<int, string> Description = new Dictionary<int, string>
        {
            { Error, "System Error" },          //系统繁忙
            { Success, "Success" },             //请求成功
            { SystemBusy, "System Busy" },      //系统繁忙
            { DbNotData, "Database Not find data" },        //数据库未找到数据
        };
    }
}
