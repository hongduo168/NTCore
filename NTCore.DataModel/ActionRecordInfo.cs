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
    public class ActionRecordInfo : HotelEntity
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        [Required, DefaultValue(0), Column("data_type")]
        public int DataType { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("typeid", TypeName = "varchar(30)"), MaxLength(30)]
        public string TypeId { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("content_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string Text { get; set; }
    }
}
