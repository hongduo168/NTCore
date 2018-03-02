using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NTCore.DataModel
{
    public class DataEnum
    {
        /// <summary>
        /// 数据库空置
        /// </summary>
        public static readonly DateTime DbNullDatetime = new DateTime(1970, 1, 1);

        /// <summary>
        /// 全局日期格式
        /// </summary>
        public static readonly string DatetimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 数据库默认值
        /// </summary>
        public const string DbDefaultDatetime = ("1970-01-01 00:00:00");


        #region model枚举

        public enum RequestModel
        {
            [Description("允许访问")]
            Allowed = 1,

            [Description("拒绝访问")]
            Refused = 0
        }

        public enum SiteStateType
        {
            /// <summary>
            /// 正常访问
            /// </summary>
            [Description("正常访问")]
            Normal = 0,


            /// <summary>
            /// 暂停服务
            /// </summary>
            [Description("暂停服务")]
            PauseService = 10,


            /// <summary>
            /// 停止服务
            /// </summary>
            [Description("停止服务")]
            StopService = 20,
        }

        public enum ChannelLinkType
        {

            [Description("内部链接")]
            InsideLink = 0,


            [Description("外部链接")]
            OutsideLink = 1,

        }

        public enum ChannelClassType
        {
            [Description("单页栏目")]
            InsideLink = 1,


            [Description("列表栏目")]
            OutsideLink = 2,
        }


        public enum ArticlePublishStatus
        {
            [Description("正常")]
            Normal = 0,

            [Description("未审核")]
            Unaudited = 1,

            [Description("锁定")]
            Lock = 2,
        }

        public enum ActionRecordType
        {
            [Description("请求记录")]
            Request = 10,

            [Description("修改数据")]
            Modify = 20,

            [Description("删除数据")]
            Delete = 30,
        }


        /// <summary>
        /// 附件关联数据的类型
        /// </summary>
        public enum AttachmentRelationType
        {
            [Description("文章")]
            Article = 10,

            [Description("分类")]
            Category = 20,

            [Description("栏目")]
            Channel = 30,

        }

        public enum VerificationCodeSendStatus
        {
            [Description("已发送")]
            Send = 1,

            [Description("已成功")]
            Success = 2,
        }

        public enum PositionRelationType
        {
            [Description("文章")]
            Article = 1,
        }


        public enum PositionShowType
        {
            [Description("图片")]
            Picture = 1,

            [Description("文字")]
            Text = 2,

            [Description("网页")]
            Page = 1,
        }
        #endregion

    }
}
