using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTCore.WebFront.Model.Api
{
    public class CustomerRequestPostInfo
    {
        public string RoomNumber { get; set; }

        public DateTime? ExpectTime { get; set; }

        /// <summary>
        /// 指定时长
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// 指定服务员
        /// </summary>
        public int UserId { get; set; }

        public SupplyInfo[] Supply { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        public class SupplyInfo
        {
            /// <summary>
            /// ID
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            public int Count { get; set; }
        }
    }

}
