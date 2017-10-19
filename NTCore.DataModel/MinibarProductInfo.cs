using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("minibar_product")]
    public class MinibarProductInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("minibar_id")]
        public int MinibarId { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("product_name", TypeName = "nvarchar(50)"), MaxLength(50)]
        public string ProductName { get; set; }

        [Required, DefaultValue(0), Column("product_price", TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        [Required, DefaultValue(0), Column("package_count")]
        public int PackageCount { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("unit_name", TypeName = "nvarchar(20)"), MaxLength(20)]
        public string UnitName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("product_code", TypeName = "varchar(20)"), MaxLength(20)]
        public string ProductCode { get; set; }
    }
}
