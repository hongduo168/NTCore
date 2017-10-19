using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("minibar_type")]
    public class MinibarTypeInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("minibar_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string MinibarName { get; set; }

    }
}
