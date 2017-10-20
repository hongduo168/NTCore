using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NTCore.Utility;

namespace NTCore.WebFront.Model
{
    public class BaseReturn : ReturnValue<object>
    {
        public BaseReturn(bool isError = true, string message = "", object data = null) : base(isError, message, data)
        {
        }
    }
}
