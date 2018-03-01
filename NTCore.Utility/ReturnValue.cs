using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NTCore.Utility
{
    public class ReturnValue<T>
    {
        protected Stopwatch sw = new Stopwatch();
        public ReturnValue(T data, int errorCode = -1, string message = "")
        {
            sw.Start();
            this.ErrorCode = errorCode;
            this.Message = message;
            this.Data = data;
        }
        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        /// <summary>
        /// 接口处理时间
        /// </summary>
        public long Milliseconds
        {
            get
            {
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }
    }
}
