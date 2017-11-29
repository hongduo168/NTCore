﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    /// <summary>
    /// 工作计件
    /// </summary>
    [Table("workload")]
    public class WorkloadInfo : HotelEntity
    {
        [Required, DefaultValue("getdate()"), Column("start_time")]
        public DateTime StarTime { get; set; }

        [Required, DefaultValue("getdate()"), Column("finish_time")]
        public DateTime FinishTime { get; set; }

        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("room_number", TypeName = "varchar(30)"), MaxLength(30)]
        public string RoomNumber { get; set; }

        [Required, DefaultValue(1.0), Column("coefficient", TypeName = "decimal(10,2)")]
        public decimal Coefficient { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("from_status", TypeName = "varchar(30)"), MaxLength(30)]
        public string FromStatus { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("to_status", TypeName = "varchar(30)"), MaxLength(30)]
        public string ToStatus { get; set; }

        /// <summary>
        /// 接收人/工作人
        /// </summary>
        [Required, DefaultValue(0), Column("receiver_userid")]
        public int ReceiverId { get; set; }


        [Required, DefaultValue(0), Column("work_seconds")]
        public int WorkSeconds { get; set; }

        /// <summary>
        /// 关联数据ID
        /// </summary>
        [Required, DefaultValue(0), Column("relation_id")]
        public int RaletionId { get; set; }


        [Required, DefaultValue("getdate()"), Column("check_time")]
        public DateTime CheckTime { get; set; }

        [Required, DefaultValue(0), Column("check_userid")]
        public int CheckUserId { get; set; }

        [Required, DefaultValue(0), Column("is_checked")]
        public bool IsChecked { get; set; }

        [Required, DefaultValue(0), Column("finish_status")]
        public DataEnum.WorkFinishStatus FinishStatus { get; set; }

        [Required(AllowEmptyStrings = true), DefaultValue(""), Column("message_text", TypeName = "nvarchar(2000)"), MaxLength(2000)]
        public string MessageText { get; set; }

        [Required, DefaultValue(0), Column("work_type")]
        public DataEnum.WorkloadType WorkType { get; set; }


    }
}
