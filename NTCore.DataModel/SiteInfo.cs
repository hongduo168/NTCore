using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("site")]
    public class SiteInfo : BaseEntity
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("site_name", TypeName = "nvarchar(255)"), MaxLength(255)]
        public string SiteName { get; set; } = string.Empty;

        /// <summary>
        /// 站点地址
        /// </summary>
        [Required, DefaultValue(""), Column("site_url", TypeName = "varchar(255)"), MaxLength(255)]
        public string SiteUrl { get; set; } = string.Empty;

        /// <summary>
        /// 站点状态
        /// </summary>
        [Required, DefaultValue(1), Column("site_state", TypeName = "tinyint")]
        public DataEnum.SiteStateType SiteState { get; set; } = DataEnum.SiteStateType.Normal;

        /// <summary>
        /// 过期时间
        /// </summary>
        [Required, DefaultValue(DataEnum.DbDefaultDatetime), Column("expire_time")]
        public DateTime ExpireTime { get; set; } = DateTime.Now.AddYears(1);
    }
}
