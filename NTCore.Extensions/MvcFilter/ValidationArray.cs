using System;
namespace NTCore.Extensions.MvcFilter
{
    public class ValidationArray : Attribute
    {
        public string[] Names { get; set; }

        public ValidationArray(params string[] names)
        {
            this.Names = names;
        }
    }
}
