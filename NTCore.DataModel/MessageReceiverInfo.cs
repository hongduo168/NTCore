using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 信息接收人
    /// </summary>
    [Table("message_receiver")]
    public class MessageReceiverInfo : HotelEntity
    {
        /// <summary>
        /// MessageTemplateType
        /// </summary>
        [Required, DefaultValue(0), Column("message_center_id")]
        public int MessageCenterId { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// 发送事件
        /// </summary>
        [Required, DefaultValue("getdate()"), Column("send_time")]
        public DateTime SendTime { get; set; }
    }
}
