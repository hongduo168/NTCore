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
        [Required, DefaultValue(0), Column("supply_type")]
        public DataEnum.CustomerRequestDefineType SupplyType { get; set; }

        /// <summary>
        /// 第三方系统对接mapping
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("supply_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string SupplyCode { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("supply_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string SupplyName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("supply_note", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string SupplyNote { get; set; }

    }
}
