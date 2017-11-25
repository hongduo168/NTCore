using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 消息中心
    /// 
    /// </summary>
    [Table("message_center")]
    public class MessageCenterInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("template_text", TypeName = "nvarchar(max)")]
        public string MessageText { get; set; }
    }
}
