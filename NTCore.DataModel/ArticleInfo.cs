using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("article")]
    public class ArticleInfo : SiteEntity
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        [Required, DefaultValue(0), Column("channel_id")]
        public int ChannelId { set; get; }

        /// <summary>
        /// 类别ID
        /// </summary>
        [Required, DefaultValue(0), Column("category_id")]
        public int CategoryId { set; get; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("title"), MaxLength(255)]
        public string Title { set; get; } = string.Empty;

        /// <summary>
        /// 外部链接
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("link_url", TypeName = "varchar(255)"), MaxLength(255)]
        public string LinkUrl { set; get; } = string.Empty;

        /// <summary>
        /// 图片地址
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("title_image", TypeName = "varchar(255)"), MaxLength(255)]
        public string TitleImage { set; get; } = string.Empty;

        /// <summary>
        /// SEO标题
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("seo_title"), MaxLength(255)]
        public string SEOTitle { set; get; } = string.Empty;

        /// <summary>
        /// SEO关健字
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("seo_keywords"), MaxLength(255)]
        public string SEOKeywords { set; get; } = string.Empty;

        /// <summary>
        /// SEO描述
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("seo_description"), MaxLength(255)]
        public string SEODescription { set; get; } = string.Empty;

        /// <summary>
        /// 内容摘要
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("summary"), MaxLength(4000)]
        public string Summary { set; get; } = string.Empty;

        /// <summary>
        /// 详细内容
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("text_content")]
        public string TextContent { set; get; } = string.Empty;

        /// <summary>
        /// 浏览次数
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(0), Column("click_count")]
        public int ClickCount { set; get; }

        [Required(AllowEmptyStrings = true), DefaultValue(0), Column("base_click")]
        public int BaseClick { set; get; }

        /// <summary>
        /// 状态0正常1未审核2锁定
        /// </summary> 
        [Required(AllowEmptyStrings = true), DefaultValue(0), Column("publish_status", TypeName = "tinyint")]
        public DataEnum.ArticlePublishStatus PublishStatus { set; get; }

        /// <summary>
        /// 是否允许评论
        /// </summary>
        [Required, DefaultValue(false), Column("allow_comment")]
        public bool AllowComment { set; get; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        [Required, DefaultValue(false), Column("is_top")]
        public bool IsTop { set; get; }

        /// <summary>
        /// 标题颜色
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("title_color", TypeName = "varchar(10)"), MaxLength(10)]
        public string TitleColor { set; get; } = string.Empty;

        /// <summary>
        /// 是否热门
        /// </summary>
        [Required, DefaultValue(false), Column("is_hot")]
        public bool IsHot { set; get; }

        /// <summary>
        /// 是否幻灯片
        /// </summary>
        [Required, DefaultValue(false), Column("is_slide")]
        public bool IsSlide { set; get; }


        /// <summary>
        /// 是否管理员发布0不是1是
        /// </summary>
        [Required, DefaultValue(false), Column("is_system")]
        public bool IsSystem { set; get; }
        
    }
}
