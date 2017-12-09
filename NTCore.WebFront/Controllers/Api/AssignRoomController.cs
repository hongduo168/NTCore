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
using NTCore.BizLogic.NTAttribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    [Route("assign-room"), Permission("assign-room", "排房相关")]
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

        /**
         * @api {get} /assign-room/:id 获取单个房间排房信息
         * @apiVersion 0.1.0
         * @apiName 排房数据
         * @apiGroup AssignRoom
         * @apiPermission none
         *
         * @apiDescription Compare Verison 0.3.0 with 0.2.0 and you will see the green markers with new items in version 0.3.0 and red markers with removed items since 0.2.0.
         *
         * @apiParam {String} id 房间号.
         *
         * @apiExample Example usage:
         * curl -i http://.../assign-room/1001
         *
         * @apiSuccess {Object}     room                    房间信息
         * @apiSuccess {string}     room.roomNumber         房间号
         * @apiSuccess {string}     room.roomTypeCode       房型
         * @apiSuccess {string}     room.roomStatus         房态
         * @apiSuccess {decimal}    room.coefficient        计件系数
         * @apiSuccess {bool}       room.isCleaning         是否正在打扫
         * @apiSuccess {bool}       room.isChecked          是否已检查
         * @apiSuccess {bool}       room.isDueOut           是否预离
         * @apiSuccess {bool}       room.isDueIn            是否预抵
         * @apiSuccess {bool}       room.isRush             是否赶房
         * @apiSuccess {bool}       room.isContradiction    是否矛盾房
         *  
         * @apiSuccess {Object}     assign                  排房信息.
         * @apiSuccess {Object}     user                    用户信息.
         *
         *
         * @apiErrorExample Response (example):
         *     HTTP/1.1
         *     {
         *       "isError": true,
         *       "data": null,
         *       "message": ""
         *     }
         */
        /// <summary>
        /// 获取单个房间排房信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), Permission("assign-room-get", "排房信息", typeof(AssignRoomController))]
        public BaseReturn<AssignRoomGetInfo> Get(string id)
        {
            var resp = new BaseReturn<AssignRoomGetInfo>(false);
            var room = this.dbContext.HotelRoom.FirstOrDefault(x => x.HotelId == this.UserInfo.HotelId && x.RoomNumber == id);
            var assign = this.dbContext.AssignRoom.FirstOrDefault(x => x.HotelId == this.UserInfo.HotelId && x.RoomNumber == id);

            UserInfo user = null;
            if (assign != null && assign.UserId != 0)
            {
                user = this.dbContext.User.FirstOrDefault(x => x.Id == assign.UserId);
            }

            var data = new AssignRoomGetInfo()
            {
                RoomNumber = room.RoomNumber,
                Coefficient = room.Coefficient,
                IsChecked = room.IsChecked,
                IsCleaning = room.IsCleaning,
                IsContradiction = room.IsContradiction,
                IsDueIn = room.IsDueIn,
                IsDueOut = room.IsDueOut,
                IsRush = room.IsRush,
                PmsRoomNumber = room.PmsRoomNumber,
                RoomStatus = room.RoomStatus,
                RoomTypeCode = room.RoomTypeCode,

                AssignTime = assign.AssignTime,
                UserId = assign.UserId,
                Username = user.Username,
                WorkReady = user.WorkReady,
                Avatar = user.Avatar,
                MobileNumber = user.MobileNumber,
                Nickname = user.Nickname,
                EmployeeNumber = user.EmployeeNumber
            };

            resp.Data = data;
            return resp;
        }

        /// <summary>
        /// 排房
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost, Permission("assign-room-post", "执行排房", typeof(AssignRoomController))]
        public BaseReturn Post([FromBody]AssignRoomPostInfo info)
        {
            var resp = new BaseReturn();
            resp.IsError = !this.hotelRoomRepository.AssignRoom(info.UserId, info.RoomNumber, this.UserInfo);
            return resp;
        }

    }
}

