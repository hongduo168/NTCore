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

            var rooms = this.dbContext.HotelRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            var allot = this.dbContext.AssignRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            var userid = allot.Select(x => x.UserId);
            var users = this.dbContext.User.Where(x => x.HotelId == this.UserInfo.HotelId && userid.Contains(x.Id));

            resp.Data = new { rooms, allot, users };


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

            var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.Id == id && x.HotelId == this.UserInfo.HotelId);
            if (room == null)
            {
                return resp;
            }

            var assign = this.dbContext.AssignRoom.FirstOrDefault(x => x.RoomNumber == room.RoomNumber);

            var user = this.dbContext.User.Where(x => x.Id == assign.UserId && x.HotelId == this.UserInfo.HotelId);

            resp.Data = new { room, assign, user };
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
