using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("room_product_package")]
    public class RoomProductPackageInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("package_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string PackageCode { get; set; }

        [Required, DefaultValue(0), Column("minibar_product_id")]
        public int MinibarProductId { get; set; }

        [Required, DefaultValue(0), Column("package_count")]
        public int PackageCount { get; set; }

        [Required, DefaultValue(0), Column("package_price", TypeName = "decimal(12,2)")]
        public decimal PackagePrice { get; set; }

    }
}
