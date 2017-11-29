using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;
using NTCore.BizLogic.DbAccess;

namespace NTCore.WebFront.Controllers.Api
{
    [Route("rush-room")]
    public class RushRoomController : MemberBaseController
    {
        protected HotelRoomRepository hotelRoomRepository;
        protected RushRoomController(
            ILogger<MemberBaseController> logger,
            MainContext dbContext,
            ActionRecordRepository actionRecordRepository,
            HotelRoomRepository hotelRoomRepository) : base(logger, dbContext)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }


        /// <summary>
        /// 赶房设置
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReturn Post([FromBody]RushRoomPostInfo info)
        {
            var resp = new BaseReturn();

            if (info.RoomNumber != null)
            {
                resp.IsError = !this.hotelRoomRepository.SetRushRoom(info.UserId, info.RoomNumber, this.UserInfo);
            }

            return resp;
        }


    }
}
