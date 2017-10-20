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

namespace NTCore.WebFront.Controllers
{
    public class AssignRoomController : MemberBaseController
    {
        public AssignRoomController(ILogger<AssignRoomController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            var resp = new BaseReturn(false);
            var assignRooms = this.dbContext.AssignRoom.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();
            resp.Data = assignRooms;
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
                        Coeffcient = 1.0M,
                        CreateTime = DateTime.Now,
                        CreatorId = this.UserInfo.Id,
                        DataState = EnumState.Normal,
                        HotelId = this.UserInfo.HotelId,
                        RoomNumber = item,
                        RoomStatus = string.Empty, //TODO
                        UpdaterId = this.UserInfo.HotelId,
                        UpdateTime = DateTime.Now,
                        UserId = info.UserId
                    };
                    this.dbContext.AssignRoom.Add(data);
                }
                else
                {
                    data.UserId = info.UserId;
                    this.dbContext.AssignRoom.Update(data);
                }

                #endregion

                #region 填充排房结束时间

                var lastRecord = this.dbContext.AssignRoomHistory.FirstOrDefault(x=>x.RoomNumber == item && x.HotelId == this.UserInfo.HotelId && x.Deadline == DataDefine.NullDateTime);
                if (lastRecord != null)
                {
                    lastRecord.Deadline = DateTime.Now;;
                    this.dbContext.AssignRoomHistory.Update(lastRecord);
                }

                #endregion

                #region 增加历史记录

                var history = new AssignRoomHistoryInfo()
                {
                    Coeffcient = 1.0M,
                    CreateTime = DateTime.Now,
                    CreatorId = this.UserInfo.Id,
                    DataState = EnumState.Normal,
                    HotelId = this.UserInfo.HotelId,
                    RoomNumber = item,
                    UpdaterId = this.UserInfo.HotelId,
                    UpdateTime = DateTime.Now,
                    UserId = info.UserId,
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

