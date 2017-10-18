using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NTCore.DataModel
{
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

        [Description("一般客需耗材")] //客用品
        CustomerSupply1 = 2,

        [Description("特殊客需耗材")] //客用品
        CustomerSupply2 = 3,
    }
}
