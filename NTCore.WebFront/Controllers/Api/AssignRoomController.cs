using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.DataModel;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;
using NTCore.BizLogic.DbAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    [Route("assign-room")]
    public class AssignRoomController : MemberBaseController
    {
        protected HotelRoomRepository hotelRoomRepository;
        public AssignRoomController(ILogger<AssignRoomController> logger, MainContext dbContext, HotelRoomRepository hotelRoomRepository) : base(logger, dbContext)
        {
            //var list = dbContext.User.ToList();
            //var f = list.First();
            //f.AuthType = DataEnum.UserAuthType.Windows;
            //f.Id = 0;
            //dbContext.Entry(f).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //this.dbContext.User.Remove(f);
            //dbContext.SaveChanges();
            this.hotelRoomRepository = hotelRoomRepository;
        }

        /// <summary>
        /// 获取单个房间排房信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var resp = new BaseReturn(false);
            var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.HotelId == this.UserInfo.HotelId && x.RoomNumber == id);
            var assign = this.dbContext.AssignRoom.FirstOrDefault(x => x.HotelId == this.UserInfo.HotelId && x.RoomNumber == id);

            UserInfo user = null;
            if (assign != null && assign.UserId != 0)
            {
                user = this.dbContext.User.FirstOrDefault(x => x.Id == assign.UserId);
            }

            resp.Data = new { room, assign, user };
            return Json(resp);
        }

        /// <summary>
        /// 排房
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody]AssignRoomPostInfo info)
        {
            var resp = new BaseReturn();
            resp.IsError = !this.hotelRoomRepository.AssignRoom(info.UserId, info.RoomNumber, this.UserInfo);
            return Json(resp);
        }

    }
}

