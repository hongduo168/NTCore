using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("customer_request_define")]
    public class CustomerRequestDefineInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("data_type")]
        public int DataType { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string DataCode { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string DataName { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("data_note", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string DataNote { get; set; }

        [Required, DefaultValue(0), Column("data_sort")]
        public int DataSort { get; set; }
    }
}
