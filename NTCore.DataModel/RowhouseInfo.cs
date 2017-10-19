using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 排房
    /// </summary>
    [Table("rowhouse")]
    public class RowhouseInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        [Required, DefaultValue(1.0), Column("coeffcient", TypeName = "decimal(10,2)")]
        public decimal Coeffcient { get; set; }


        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_status", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomStatus { get; set; }

        [Required, DefaultValue("getdate()"), Column("assign_time")]
        public DateTime AssignTime { get; set; }
    }
}
