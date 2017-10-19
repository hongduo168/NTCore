﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("customer_request")]
    public class CustomerRequestInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("message_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string MessageText { get; set; }

        [Required, DefaultValue(0), Column("finish_status")]
        public int FinishStatus { get; set; }

        [Required, DefaultValue(0), Column("assign_userid")]
        public int AssignUserId { get; set; }

        [Required, DefaultValue("getdate()"), Column("expect_time")]
        public DateTime ExpectTime { get; set; }

    }
}
