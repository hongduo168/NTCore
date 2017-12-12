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

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("hotel_name", TypeName = "nvarchar(50)"), MaxLength(50)]
        public string HotelName { get; set; }

        [Required, DefaultValue(0), Column("product_id")]
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("interface_url", TypeName = "varchar(255)"), MaxLength(255)]
        public string InterfaceUrl { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("background", TypeName = "varchar(255)"), MaxLength(255)]
        public string Background { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("appid", TypeName = "varchar(50)"), MaxLength(50)]
        public string Appid { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("appkey", TypeName = "varchar(50)"), MaxLength(50)]
        public string Appkey { get; set; }

        /// <summary>
        /// 入账代码
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("transfer_code", TypeName = "varchar(64)"), MaxLength(64)]
        public string TransferCode { get; set; }


        /// <summary>
        /// 假房房号
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("pseudo_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string PseudoNumber { get; set; }

    }
}
