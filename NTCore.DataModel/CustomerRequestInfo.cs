using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 客需数据
    /// </summary>
    [Table("customer_request")]
    public class CustomerRequestInfo : HotelEntity
    {

        [Required, DefaultValue(0), Column("data_type")]
        public CustomerRequestDefineType DataType { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("message_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string MessageText { get; set; }

        [Required, DefaultValue(0), Column("finish_status")]
        public CustomerRequestFinishStatus FinishStatus { get; set; }

        [Required, DefaultValue(0), Column("assign_userid")]
        public int AssignUserId { get; set; }

        /// <summary>
        /// 期望完成时间
        /// </summary>
        [Required, DefaultValue("getdate()"), Column("expect_time")]
        public DateTime ExpectTime { get; set; }

    }
}
