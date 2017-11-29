using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("user_group")]
    public class UserGroupInfo : HotelEntity
    {

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("group_name", TypeName = "nvarchar(30)"), MaxLength(30)]
        public string GroupName { get; set; }

    }
}
