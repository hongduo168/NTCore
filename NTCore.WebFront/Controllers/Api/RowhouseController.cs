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
    public class RowhouseController : MemberBaseController
    {
        public RowhouseController(ILogger<RowhouseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            var resp = new BaseReturn(false);
            var rowhouseList = this.dbContext.Rowhouse.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();
            resp.Data = rowhouseList;
            return Json(resp);
        }

        [HttpPost]
        public ActionResult Post([FromBody]RowhousePostInfo info)
        {
            var resp = new BaseReturn();
            foreach (var item in info.RoomNumber)
            {
                var data = this.dbContext.Rowhouse.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == this.UserInfo.HotelId);
                if (data == null)
                {
                    data = new RowhouseInfo()
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
                    this.dbContext.Rowhouse.Add(data);
                }
                else
                {
                    data.UserId = info.UserId;
                    this.dbContext.Rowhouse.Update(data);
                }
            }
            resp.IsError = this.dbContext.SaveChanges() > -1;
            return Json(resp);
        }
        
    }
}

