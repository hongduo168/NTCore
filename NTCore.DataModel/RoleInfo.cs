using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("role")]
    public class RoleInfo : BaseEntity
    {

        [Required, DefaultValue(""), Column("role_name"), MaxLength(50)]
        public string RoleName { get; set; } = string.Empty;

    }
}
