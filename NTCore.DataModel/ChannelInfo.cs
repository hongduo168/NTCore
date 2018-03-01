using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("channel")]
    public class ChannelInfo : SiteEntity
    {
        /// <summary>
        /// 频道名称
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("name"), MaxLength(30)]
        public string Name { set; get; }

        /// <summary>
        /// 频道标题
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("title"), MaxLength(255)]
        public string Title { set; get; }

        [Required, DefaultValue(0), Column("class_type", TypeName = "tinyint")]
        public DataEnum.ChannelClassType ClassType { get; set; }

        /// <summary>
        /// 排序数字
        /// </summary>
        [Required, DefaultValue(0), Column("data_sort")]
        public int DataSort { set; get; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("image_url", TypeName = "varchar(255)"), MaxLength(255)]
        public string ImageUrl { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("link_url", TypeName = "varchar(255)"), MaxLength(255)]
        public string LinkUrl { get; set; }

        [Required, DefaultValue(0), Column("link_type", TypeName = "tinyint")]
        public DataEnum.ChannelLinkType LinkType { get; set; }

        [Required, DefaultValue(""), Column("keywords"), MaxLength(255)]
        public string Keywords { get; set; }

        [Required, DefaultValue(""), Column("description"), MaxLength(255)]
        public string Description { get; set; }


        [Required, DefaultValue(0), Column("parent_id")]
        public int ParentId { get; set; }

        [Required, DefaultValue(""), Column("parent_path", TypeName = "varchar(255)"), MaxLength(255)]
        public string ParentPath { get; set; }

        [Required, DefaultValue(0), Column("parents_count")]
        public int ParentsCount { get; set; }

        [Required, DefaultValue(0), Column("children_count")]
        public int ChildrenCount { get; set; }

        [Required, DefaultValue(""), Column("template_code", TypeName = "varchar(50)"), MaxLength(50)]
        public string TemplateCode { get; set; }
    }
}
