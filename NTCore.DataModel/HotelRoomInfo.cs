using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("hotel_room")]
    public class HotelRoomInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("pms_room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string PmsRoomNumber { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_type_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomTypeCode { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_status", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomStatus { get; set; }

        /// <summary>
        /// 计件系数
        /// </summary>
        [Required, DefaultValue(1.0), Column("coefficient", TypeName = "decimal(10,2)")]
        public decimal Coefficient { get; set; }

        [Required, DefaultValue(false), Column("is_cleaning", TypeName = "bit"), MaxLength(30)]
        public bool IsCleaning { get; set; }

        [Required, DefaultValue(false), Column("is_checked", TypeName = "bit"), MaxLength(30)]
        public bool IsChecked { get; set; }

        [Required, DefaultValue(false), Column("is_due_out", TypeName = "bit"), MaxLength(30)]
        public bool IsDueOut { get; set; }

        [Required, DefaultValue(false), Column("is_due_in", TypeName = "bit"), MaxLength(30)]
        public bool IsDueIn { get; set; }

        [Required, DefaultValue(false), Column("is_rush", TypeName = "bit"), MaxLength(30)]
        public bool IsRush { get; set; }

        /// <summary>
        /// 矛盾
        /// </summary>
        [Required, DefaultValue(false), Column("is_contradiction", TypeName = "bit"), MaxLength(30)]
        public bool IsContradiction { get; set; }

    }
}
