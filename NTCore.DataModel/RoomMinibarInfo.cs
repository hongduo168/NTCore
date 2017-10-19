using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("room_minibar")]
    public class RoomMinibarInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("minibar_id"), MaxLength(30)]
        public int MinibarId { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }
    }
}
