using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{

    [Table("attachment")]
    public class AttachmentInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("full_url", TypeName = "nvarchar(255)"), MaxLength(255)]
        public string FullUrl { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("dir_path", TypeName = "nvarchar(255)"), MaxLength(255)]
        public string DirPath { get; set; }

        [Required, DefaultValue(0), Column("relation_Type")]
        /// <summary>
        /// AttachmentRelationType
        /// 关联数据的类型
        /// </summary>
        public int RelationType { get; set; }

        [Required, DefaultValue(0), Column("relation_id")]
        /// <summary>
        /// 关联数据ID
        /// </summary>
        public int RelationId { get; set; }
    }
}
