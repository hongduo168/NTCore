using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("assign_room_history")]
    public class AssignRoomHistoryInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        [Required, DefaultValue(1.0), Column("coefficient", TypeName = "decimal(10,2)")]
        public decimal Coefficient { get; set; }

        [Required, DefaultValue("getdate()"), Column("fromtime")]
        public DateTime FromTime { get; set; }

        [Required, DefaultValue("getdate()"), Column("deadline")]
        public DateTime Deadline { get; set; }
    }
}
