using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("rule")]
    public class RuleInfo : SiteEntity
    {
        [Required, DefaultValue(0), Column("roleid")]
        public int RoleId { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// 访问权限
        /// 
        /// </summary>
        [Required, DefaultValue(0), Column("request_model")]
        public DataEnum.RequestModel RequestModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("email", TypeName = "varchar(100)"), MaxLength(100)]
        public string ViewCode { get; set; }
    }
}
