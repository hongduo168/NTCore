using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NTCore.Utility
{
    public class ReturnValue<T> where T : class, new()
    {
        protected Stopwatch sw = new Stopwatch();
        public ReturnValue(bool isError = true, string message = "", T data = null)
        {
            sw.Start();
            this.IsError = isError;
            this.Message = message;
            this.Data = data ?? new T();
        }

        public bool IsError { get; set; }

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
