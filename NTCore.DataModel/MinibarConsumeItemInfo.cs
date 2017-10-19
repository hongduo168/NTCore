using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("minibar_cunsume_item")]
    public class MinibarConsumeItemInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("minibar_consume_id")]
        public int MinibarConsumeId { get; set; }

        [Required, DefaultValue(0), Column("minibar_product_id")]
        public int MinibarProductId { get; set; }

        [Required, DefaultValue(0), Column("product_price", TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        [Required, DefaultValue(0), Column("quantity")]
        public int Quantity { get; set; }
    }
}
