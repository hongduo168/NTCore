using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTCore.Extensions.NTAttribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PermissionFlagAttribute : Attribute
    {
        public PermissionFlagAttribute(string id, string title, Type type = null, string icon = "", string desc = "")
        {
            this.Id = id;
            this.ParentId = string.Empty;
            this.Description = desc;
            this.MenuIcon = icon;
            this.MenuTitle = title;
            if (type != null)
            {
                var attr = (PermissionFlagAttribute)type.GetCustomAttributes(typeof(PermissionFlagAttribute), false)?.FirstOrDefault();
                if (attr != null)
                {
                    this.ParentId = attr.Id;
                }
            }
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public string Description { get; set; }


        public string MenuTitle { get; set; }


        public string MenuIcon { get; set; }

    }
}
