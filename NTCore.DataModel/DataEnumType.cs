using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NTCore.DataModel
{
    public class DataDefine
    {
        public static readonly DateTime NullDateTime = new DateTime(1970, 1, 1);
    }

    public class DataEnum
    {

        public enum UserAuthType
        {
            [Description("系统验证")]
            System = 10,

            [Description("Windows")]
            Windows = 20,

            [Description("外部PMS")]
            PMS = 30,
        }

        public enum ActionRecordType
        {
            [Description("请求记录")]
            Request = 10,

            [Description("房态记录")]
            RoomStatus = 20,

            [Description("打扫计件")]
            Workload = 30,

            [Description("短信发送")]
            SMSSend = 40,

            [Description("邮件发送")]
            MailSend = 50,

            [Description("主管查房")]
            CleanCheck = 60,

            [Description("用户反馈")]
            Feedback = 100,

            [Description("操作记录")]
            DataUpdate = 200
        }

        public enum CustomerRequestDefineType
        {
            [Description("客需物品")]
            CustomerRequest = 1,

            [Description("一般客用品")] //客用品
            CustomerSupply1 = 2,

            [Description("易耗客用品")] //客用品
            CustomerSupply2 = 3,
        }

        public enum CustomerRequestFinishStatus
        {
            [Description("新增")]
            Create = 1,

            [Description("正在处理")]
            Handling = 10,

            [Description("完成")]
            Finish = 20,

            [Description("反馈")]
            Feedback = 30,
        }

        public enum WorkloadType
        {
            [Description("赶房")]
            RushRoom = 0x07,

            [Description("打扫")]
            CleanRoom = 0x01,

            [Description("大清")]
            DeepClean = 0x02,

            [Description("维修")]
            RepairRoom = 0x03,

            [Description("保养")]
            CuringRoom = 0x04,

            [Description("客需")]
            CustomerRequest = 0x05,

            [Description("检查")]
            CheckRoom = 0x06,
        }

        public enum RoomStatusType
        {
            [Description("OC")]
            OC = 1,

            [Description("OD")]
            OD = 2,

            [Description("OK")]
            OK = 3,

            [Description("VC")]
            VC = 4,

            //[Description("VD")]
            VD = 5,

            [Description("V_C")]
            V_C = 6, //空隔夜

            [Description("O_D")]
            O_D = 7, //换床单

            [Description("HS")]
            HS = 8, //占用放

            [Description("DK")]
            DK = 9 //差异房

        }

        public enum MinibarConsumeFinishStatus
        {
            [Description("已创建")]
            Created = 1,

            [Description("已送达")]
            Served = 2,

            [Description("已确定")]
            Confirmed = 3,

            [Description("已撤销")]
            Revoked = 4,

        }

        public enum VerificationCodeSendStatus
        {
            [Description("已发送")]
            Send = 1,

            [Description("已成功")]
            Success = 2,
        }

        /// <summary>
        /// 欢迎词指定时间类型
        /// </summary>
        public enum ShowDayType
        {
            [Description("每天")]
            Day = 10,

            [Description("每周")]
            Week = 20,

            [Description("每月")]
            Month = 30,

            [Description("每年")]
            Year = 40,
        }

        public enum WelcomePlanType
        {

            [Description("欢迎语")]
            Welcome = 10,


        }


        public enum MessageTemplateType
        {
            [Description("短信")]
            SMS = 10,

            [Description("邮件")]
            Mail = 20,

            [Description("App")]
            App = 30,

        }

        public enum WorkloadStepType
        {
            [Description("新建")]
            Created = 5,

            [Description("开始")]
            Start = 10,

            [Description("暂停")]
            Pause = 20,

            [Description("完成")]
            Finsh = 30,

            [Description("停止")]
            Stop = 40,

            [Description("恢复")]
            Restore = 50,

            [Description("切换类型")]
            Switch = 60,
        }

        /// <summary>
        /// 附件关联数据的类型
        /// </summary>
        public enum AttachmentRelationType
        {
            [Description("维修")]
            RepairRoom = 10,

            [Description("保养")]
            CuringRoom = 20,

        }


        public enum WorkFinishStatus
        {
            [Description("创建")]
            Created = 10,


            [Description("开始")]
            Start = 20,


            [Description("暂停")]
            Pause = 30,

            [Description("停止")]
            Stop = 40,

            [Description("完成")]
            Finsh = 50,

            [Description("未通过")]
            Failed = 60,

            [Description("检查通过")]
            Checked = 100,

            [Description("取消")]
            Cancel = 110,



        }


    }
}
