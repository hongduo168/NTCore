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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    [Route("assign-room")]
    /// <summary>
    /// 排放
    /// </summary>
    public class AssignRoomController : MemberBaseController
    {
        public AssignRoomController(ILogger<AssignRoomController> logger, MainContext dbContext) : base(logger, dbContext)
        {
            //var list = dbContext.User.ToList();
            //var f = list.First();
            //f.AuthType = DataEnum.UserAuthType.Windows;
            //f.Id = 0;
            //dbContext.Entry(f).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //this.dbContext.User.Remove(f);
            //dbContext.SaveChanges();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var resp = new BaseReturn(false);
            var hotelRooms = this.dbContext.HotelRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();
            var assignRooms = this.dbContext.AssignRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();
            var data = from room in hotelRooms
                       join assign in assignRooms on room.RoomNumber equals assign.RoomNumber into temp
                       from tt in temp.DefaultIfEmpty(new AssignRoomInfo())
                       select new
                       {
                           room.RoomNumber,
                           room.DataSort,
                           room.HotelId,
                           room.IsChecked,
                           room.IsContradiction,
                           room.IsDueIn,
                           room.IsDueOut,
                           room.IsRush,
                           room.PmsRoomNumber,
                           room.RoomStatus,
                           room.RoomTypeCode,

                           tt.AssignTime,
                           tt.Coefficient,
                           AssignRoomStatus = tt.RoomStatus //排房时房态
                       };

            resp.Data = data;
            return Json(resp);
        }

        [HttpPost]
        public ActionResult Post([FromBody]AssignRoomPostInfo info)
        {
            var resp = new BaseReturn();
            foreach (var item in info.RoomNumber)
            {
                #region 执行排房

                var data = this.dbContext.AssignRoom.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == this.UserInfo.HotelId);
                if (data == null)
                {
                    data = new AssignRoomInfo()
                    {
                        AssignTime = DateTime.Now,
                        Coefficient = 1.0M,
                        CreateTime = DateTime.Now,
                        CreatorId = this.UserInfo.Id,
                        DataState = EnumState.Normal,
                        HotelId = this.UserInfo.HotelId,
                        RoomNumber = item,
                        RoomStatus = string.Empty, //TODO
                        UpdaterId = this.UserInfo.HotelId,
                        DataSort = 0,
                        UpdateTime = DateTime.Now,
                        UserId = info.UserId
                    };
                    this.dbContext.AssignRoom.Add(data);
                }
                else
                {
                    data.UserId = info.UserId;
                    //this.dbContext.AssignRoom.Update(data);
                }

                #endregion

                #region 填充排房结束时间

                var lastRecord = this.dbContext.AssignRoomHistory.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == this.UserInfo.HotelId && x.Deadline == DataDefine.NullDateTime);
                if (lastRecord != null)
                {
                    lastRecord.Deadline = DateTime.Now; ;
                    //this.dbContext.AssignRoomHistory.Update(lastRecord);
                }

                #endregion

                #region 增加历史记录

                var history = new AssignRoomHistoryInfo()
                {
                    Coefficient = 1.0M,
                    CreateTime = DateTime.Now,
                    CreatorId = this.UserInfo.Id,
                    DataState = EnumState.Normal,
                    HotelId = this.UserInfo.HotelId,
                    RoomNumber = item,
                    UpdaterId = this.UserInfo.HotelId,
                    UpdateTime = DateTime.Now,
                    UserId = info.UserId,
                    DataSort = 0,
                    FromTime = DateTime.Now,
                    Deadline = DataDefine.NullDateTime
                };
                this.dbContext.AssignRoomHistory.Add(history);

                #endregion
            }
            resp.IsError = this.dbContext.SaveChanges() < 1;
            return Json(resp);
        }

    }
}

