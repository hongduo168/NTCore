using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace NTCore.DataModel
{
    [Table("user")]
    public class UserInfo : HotelEntity
    {
        [Column("username"), MaxLength(50)]
        public string Username { get; set; }

        [Column("password"), StringLength(50)]
        public string Password { get; set; }

        [Column("nickname"), StringLength(50)]
        public string Nickname { get; set; }

        [Column("avatar"), StringLength(255)]
        public string Avatar { get; set; }

        [Column("mobile_number"), StringLength(50)]
        public string MobileNumber { get; set; }

        [Column("email"), StringLength(50)]
        public string Email { get; set; }

        [Column("confirmed"), StringLength(50)]
        public bool Confirmed { get; set; }

    }
}
