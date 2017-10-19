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

    public enum UserAuthType
    {
        [Description("系统验证")]
        System = 0,

        [Description("Windows")]
        Windows = 1,

        [Description("外部PMS")]
        PMS = 1,
    }

    public enum ActionRecordType
    {
        [Description("房态")]
        RoomStatus = 1,

        [Description("计件")]
        Workload = 2
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

    public enum WorkType
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
}
