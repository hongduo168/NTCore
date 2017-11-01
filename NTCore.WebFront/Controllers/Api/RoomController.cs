using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    [Route("rooms")]
    public class RoomController : MemberBaseController
    {

        /// <summary>
        /// 所有房间
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        public BaseReturn Get()
        {
            var resp = new BaseReturn(false);

            var hotelRooms = this.dbContext.HotelRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            var assignRooms = this.dbContext.AssignRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            var userid = assignRooms.Select(x => x.UserId);
            var hotelUsers = this.dbContext.User.Where(x => x.HotelId == this.UserInfo.HotelId && userid.Contains(x.Id));

            resp.Data = new { HotelRooms = hotelRooms, AssignRooms = assignRooms, HotelUsers = hotelUsers };


            return resp;
        }

        /// <summary>
        /// 单个房间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public BaseReturn Get(int id)
        {
            var resp = new BaseReturn();

            var roomInfo = this.dbContext.HotelRoom.FirstOrDefault(x => x.Id == id && x.HotelId == this.UserInfo.HotelId);
            if (roomInfo == null)
            {
                return resp;
            }

            var assignRoom = this.dbContext.AssignRoom.FirstOrDefault(x => x.RoomNumber == roomInfo.RoomNumber);

            var userInfo = this.dbContext.User.Where(x => x.Id == assignRoom.UserId && x.HotelId == this.UserInfo.HotelId);

            resp.Data = new { RoomInfo = roomInfo, AssignRoom = assignRoom, UserInfo = userInfo };
            resp.IsError = false;

            return resp;
        }

        /// <summary>
        /// 修改房态
        /// </summary>
        /// <param name="roomInfo"></param>
        // POST api/values
        [HttpPost]
        public BaseReturn Post([FromBody]RoomPostInfo roomInfo)
        {
            var resp = new BaseReturn();

            //TODO 调用接口修改房态
            var model = this.dbContext.HotelRoom.FirstOrDefault(x => x.Id == roomInfo.Id && x.HotelId == this.UserInfo.HotelId);
            if (model != null)
            {
                model.RoomStatus = roomInfo.RoomStatus;
                this.dbContext.HotelRoom.Update(model);
                resp.IsError = this.dbContext.SaveChanges() < 1;
            }

            return resp;
        }


        public RoomController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
