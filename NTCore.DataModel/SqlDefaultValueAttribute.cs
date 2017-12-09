using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.DataModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
}
