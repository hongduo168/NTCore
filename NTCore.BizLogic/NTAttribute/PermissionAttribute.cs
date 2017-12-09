using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTCore.BizLogic.NTAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionAttribute : Attribute
    {
        public PermissionAttribute(string id, string title, Type type = null, string icon = "", string desc = "")
        {
            this.Id = id;
            this.ParentId = string.Empty;
            this.Description = desc;
            this.MenuIcon = icon;
            this.MenuTitle = title;
            if (type != null)
            {
                var attr = (PermissionAttribute)type.GetCustomAttributes(typeof(PermissionAttribute), false)?.FirstOrDefault();
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
