using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 
    /// </summary>
    [Table("welcome_plan")]
    public class WelcomePlanInfo : HotelEntity
    {
        /// <summary>
        /// WelcomePlanType
        /// </summary>
        [Required, DefaultValue(0), Column("data_type")]
        public int DataType { get; set; }

        /// <summary>
        /// 指定时间类型
        /// ShowDayType
        /// </summary>
        [Required, DefaultValue(0), Column("show_day_type")]
        public int ShowDayType { get; set; }

        [Required, DefaultValue(0), Column("specific_day")]
        public int SpecificDay { get; set; }

        [Required, DefaultValue("getdate()"), Column("fromtime")]
        public DateTime FromTime { get; set; }

        [Required, DefaultValue("getdate()"), Column("deadline")]
        public DateTime Deadline { get; set; }


        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("welcome_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string WelcomeText { get; set; }

    }
}
