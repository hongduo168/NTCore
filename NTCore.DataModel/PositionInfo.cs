using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("position")]
    public class PositionInfo : SiteEntity
    {
        [Required, Column("relation_type", TypeName = "tinyint")]
        public DataEnum.PositionRelationType RelationType { get; set; }

        [Required, Column("relation_id")]
        public int RelationId { get; set; }

        [Required, Column("show_type", TypeName = "tinyint")]
        public DataEnum.PositionShowType ShowType { get; set; }

        [Required(AllowEmptyStrings = false), Column("text_content", TypeName = "nvarchar(max)")]
        public string TextContent { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Required(AllowEmptyStrings = false), Column("start_time")]
        public DateTime StartTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 下架时间
        /// </summary>
        [Required(AllowEmptyStrings = false), Column("down_time")]
        public DateTime DownTime { get; set; } = DateTime.Now.AddDays(1);
    }
}
