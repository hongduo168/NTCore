using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("verification_code")]
    public class VerificationCodeInfo : SiteEntity
    {
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("mobile_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string MobileNumber { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("verify_code", TypeName = "varchar(30)"), MaxLength(30)]
        public string VerifyCode { get; set; } = string.Empty;

        /// <summary>
        /// 唯一标识
        /// </summary>
        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("request_id", TypeName = "varchar(30)"), MaxLength(30)]
        public string RequestId { get; set; } = string.Empty;

        [Required(), DefaultValue(0), Column("send_status")]
        public DataEnum.VerificationCodeSendStatus SendStatus { get; set; } = DataEnum.VerificationCodeSendStatus.Send;
    }
}