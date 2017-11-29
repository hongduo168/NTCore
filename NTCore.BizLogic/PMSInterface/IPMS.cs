using NTCore.BizLogic.PMSInterface.ResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NTCore.BizLogic.PMSInterface
{
    public interface IPMS
    {
        RequestInfo Request { get; set; }

        /// <summary>
        /// 成功标志
        /// </summary>
        string SuccessCode { get; }

        /// <summary>
        /// PMS支持类型
        /// </summary>
        SupportType Supported { get; }

        OrderModel GetOrderInfo(string roomNumber);
        RoomStatusModel GetRoomStatus(string roomNumber = "");
        BaseResponseModel ModifyRoomStatus(string roomNumber, string username, string fromStatus, string toStatus);

        BaseResponseModel InsertMiniBar(string roomNumber, string transferCode, decimal price, string description);
    }

    /// <summary>
    /// 功能列表
    /// </summary>
    public class SupportType
    {
        /// <summary>
        /// OC检查
        /// </summary>
        public bool RoomCheck { get; set; }
    }
}
