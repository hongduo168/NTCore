using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 酒店的角色
    /// </summary>
    [Table("hotel_role")]
    public class HotelRoleInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("role_name")]
        public int RoleName { get; set; }
    }
}
