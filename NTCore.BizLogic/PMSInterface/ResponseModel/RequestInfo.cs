using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.BizLogic.PMSInterface.ResponseModel
{

    public class RequestInfo
    {
        /// <summary>
        /// PMS产品名称
        /// </summary>
        public string PmsName { get; set; }
        public string HostUrl { get; set; }
        public string AppKey { get; set; }
        public string AppSecret { get; set; }

        public string Source { get; set; }

        public int HotelId { get; set; }

        /// <summary>
        /// 第三方系统HotelCode
        /// </summary>
        public string HotelCode { get; set; }
    }
}
