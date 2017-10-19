using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("user_group_member")]
    public class UserGroupMemberInfo : HotelEntity
    {
        [Required, DefaultValue(0), Column("group_id")]
        public int GroupId { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

    }
}
