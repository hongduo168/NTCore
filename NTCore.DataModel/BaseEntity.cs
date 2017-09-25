using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NTCore.DataModel
{
    /// <summary>
    /// DB表基底
    /// </summary>
    //[Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        //[DataMember]
        [Column("id")]
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[DataMember(Name = "create_time", EmitDefaultValue = true)]
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        //[DataMember(Name = "update_time")]
        [Column("update_time")]
        public DateTime UpdateTime { get; set; }

        [Column("creator_id")]
        public int CreatorId { get; set; }

        [Column("updater_id")]
        public int UpdaterId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        //[DataMember(Name = "data_state", EmitDefaultValue = true)]
        [Column("data_state")]
        public EnumState DataState { get; set; }
    }

    public partial class HotelEntity : BaseEntity
    {
        [Column("hotel_id")]
        public int HotelId { get; set; }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumState
    {
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 0,

        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1,
    }
}
