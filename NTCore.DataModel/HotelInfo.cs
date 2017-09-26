using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("hotel")]
    public class HotelInfo : BaseEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("hotel_code", TypeName = "varchar(50)"), MaxLength(50)]
        public string HotelCode { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("hotel_name"), MaxLength(50)]
        public string HotelName { get; set; }

        [Required, DefaultValue(0), Column("product_id")]
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("pms_api", TypeName = "varchar(255)"), MaxLength(255)]
        public string PmsApi { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("background_image", TypeName = "varchar(255)"), MaxLength(255)]
        public string BackgroundImage { get; set; }
    }
}
