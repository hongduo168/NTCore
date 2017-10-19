using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("hotel_user")]
    public class HotelUserInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        [Required, DefaultValue(0), Column("roleid")]
        public int RoleId { get; set; }
    }
}
