using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("message_template")]
    public class MessageTemplateInfo : HotelEntity
    {
        /// <summary>
        /// MessageTemplateType
        /// </summary>
        [Required, DefaultValue(0), Column("group_type")]
        public DataEnum.MessageTemplateType GroupType { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("template_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string TemplateName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("template_text", TypeName = "nvarchar(max)")]
        public string TemplateText { get; set; }
    }
}
