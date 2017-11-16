using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("pms_product_define")]
    public class PmsProductDefineInfo : BaseEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("product_name", TypeName = "nvarchar(50)"), MaxLength(50)]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("appid", TypeName = "varchar(50)"), MaxLength(50)]
        public string Appid { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("appkey", TypeName = "varchar(50)"), MaxLength(50)]
        public string Appkey { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("source", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string Source { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("token", TypeName = "nvarchar(64)"), MaxLength(64)]
        public string Token { get; set; }

        /// <summary>
        /// Token有效期
        /// </summary>
        [Required, DefaultValue(0), Column("token_effective_second")]
        public int TokenEffectiveSecond { get; set; }
    }
}
