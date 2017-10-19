using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("minibar_consume")]
    public class MinibarConsumeInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required, DefaultValue(0), Column("total_price", TypeName = "decimal(12,2)")]
        public decimal TotalPrice { get; set; }

        [Required, DefaultValue(0), Column("finish_status")]
        public int FinishStatus { get; set; }

        /// <summary>
        /// 房间关闭会无法抛帐，账务会记录到假房
        /// </summary>
        [Required, DefaultValue(0), Column("is_closed")]
        public bool IsClosed { get; set; }
    }
}
