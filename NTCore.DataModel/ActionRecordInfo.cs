using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 日志记录
    /// </summary>
    [Table("action_record")]
    public class ActionRecordInfo : SiteEntity
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        [Required, DefaultValue(0), Column("data_type")]
        public DataEnum.ActionRecordType DataType { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        [Required, DefaultValue(0), Column("typeid")]
        public int TypeId { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("content_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string Text { get; set; } = string.Empty;
    }
}