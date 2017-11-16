using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 客用品
    /// 客需
    /// </summary>
    [Table("hotel_supply_define")]
    public class HotelSupplyDefineInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("data_type")]
        public CustomerRequestDefineType DataType { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string DataCode { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string DataName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_note", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string DataNote { get; set; }

    }
}
