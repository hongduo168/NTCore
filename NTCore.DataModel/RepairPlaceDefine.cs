using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 维修地点定义
    /// </summary>
    [Table("repair_place_define")]
    public class RepairPlaceDefine : HotelEntity
    {

        [Required, DefaultValue(0), Column("parent_id")]
        public int ParentId { get; set; }


        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("place_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string PlaceName { get; set; }

    }
}
