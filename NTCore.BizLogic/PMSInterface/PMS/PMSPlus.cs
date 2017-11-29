using System;
using System.Collections.Generic;
using System.Text;
using NTCore.BizLogic.PMSInterface.ResponseModel;

namespace NTCore.BizLogic.PMSInterface.PMS
{
    public class PMSPlus : IPMS
    {
        public PMSPlus(RequestInfo request)
        {
            this.Request = request;
        }

        public RequestInfo Request { get; set; }

        public string SuccessCode => "1000";

        public SupportType Supported => new SupportType { RoomCheck = true };

        public OrderModel GetOrderInfo(string roomNumber)
        {
            throw new NotImplementedException();
        }

        public RoomStatusModel GetRoomStatus(string roomNumber = "")
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel InsertMiniBar(string roomNumber, string transferCode, decimal price, string description)
        {
            throw new NotImplementedException();
        }

        public BaseResponseModel ModifyRoomStatus(string roomNumber, string username, string fromStatus, string toStatus)
        {
            throw new NotImplementedException();
        }

        #region 私有方法

        #endregion
    }
}
