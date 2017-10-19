using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("customer_request_item")]
    public class CustomerRequestItemInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("customer_request_id")]
        public int CustomerRequestId { get; set; }

        [Required, DefaultValue(0), Column("customer_request_define_id")]
        public int CustomerRequestDefineId { get; set; }

        [Required, DefaultValue(0), Column("quantity")]
        public int Quantity { get; set; }
    }
}
