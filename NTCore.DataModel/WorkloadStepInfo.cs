using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NTCore.DataModel
{
    [Table("workload_step")]
    /// <summary>
    /// 工作步骤（暂停，开始）
    /// </summary>
    public class WorkloadStepInfo : HotelEntity
    {
        /// <summary>
        /// 操作人ID
        /// </summary>
        [Required, DefaultValue(0), Column("userid")]
        public int UserId { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>
        [Required, DefaultValue(0), Column("workload_id")]
        public int WorkloadId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [Required, DefaultValue(0), Column("step_type")]
        public DataEnum.WorkloadStepType StepType { get; set; }
    }
}
