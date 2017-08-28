using System;
using System.Collections.Generic;

namespace NTCore.Utility
{
    public class ReturnValue<T>
    {
        public ReturnValue(T data, int isError = -1)
        {
            this.Error = Error;
            this.Data = data;
        }

        public int Error { get; set; }

        public T Data { get; set; }

    }
}
