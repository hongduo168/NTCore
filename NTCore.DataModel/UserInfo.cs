using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace NTCore.DataModel
{
    [Table("user")]
    public class UserInfo : HotelEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("username", TypeName = "varchar(50)"), MaxLength(50)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("password", TypeName = "varchar(50)"), MaxLength(50)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("nickname"), MaxLength(50)]
        public string Nickname { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("avatar", TypeName = "varchar(255)"), MaxLength(255)]
        public string Avatar { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("mobile_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string MobileNumber { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("email", TypeName = "varchar(100)"), MaxLength(100)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("employee_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string EmployeeNumber { get; set; }

        [Required, DefaultValue(false), Column("confirmed")]
        public bool Confirmed { get; set; }

        /// <summary>
        /// UserAuthType
        /// 授权渠道
        /// </summary>
        [Required, DefaultValue(0), Column("auth_type", TypeName = "smallint")]
        public DataEnum.UserAuthType AuthType { get; set; }

    }
}
