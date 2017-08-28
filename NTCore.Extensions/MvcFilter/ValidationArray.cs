using System;
namespace NTCore.Extensions.MvcFilter
{
    /// <summary>
    /// MVC验证Action参数验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidationArray : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] Names { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="names"></param>
        public ValidationArray(params string[] names)
        {
            this.Names = names;
        }
    }
}
