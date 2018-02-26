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
        [Key, DefaultValue(0), Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[DataMember(Name = "create_time", EmitDefaultValue = true)]
        [Required, DefaultValue(DataEnum.DbDefaultDatetime), Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        //[DataMember(Name = "update_time")]
        [Required, DefaultValue(DataEnum.DbDefaultDatetime), Column("update_time")]

        public DateTime UpdateTime { get; set; }

        [Required, DefaultValue(0), Column("creator_id")]
        public int CreatorId { get; set; }


        [Required, DefaultValue(0), Column("updater_id")]
        public int UpdaterId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        //[DataMember(Name = "data_state", EmitDefaultValue = true)]
        [Required, DefaultValue(0), Column("data_state")]
        public DataStateType DataState { get; set; }
    }

    public partial class SiteEntity : BaseEntity
    {
        [Required, DefaultValue(0), Column("site_id")]
        public int SiteId { get; set; }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public enum DataStateType
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
