using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.DataModel;
using NTCore.WebFront.Model;
using static NTCore.DataModel.DataEnum.MinibarConsumeFinishStatus;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    [Route("minibar")]
    public class MinibarController : MemberBaseController
    {
        protected MinibarController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        /// <summary>
        /// 消费记录
        /// 获取房间的minibar商品列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/0301
        [HttpGet("{id}")]
        public BaseReturn Get(string id)
        {
            var resp = new BaseReturn();

            var roomInfo = this.dbContext.HotelRoom.FirstOrDefault(x => x.RoomNumber == id && x.HotelId == this.UserInfo.HotelId);
            if (roomInfo != null)
            {
                var roomMinibarInfo = this.dbContext.RoomMinibar.FirstOrDefault(x => x.RoomNumber == roomInfo.RoomNumber && x.HotelId == this.UserInfo.HotelId);
                if (roomMinibarInfo != null)
                {
                    var products = this.dbContext.MinibarProduct.Where(x => x.MinibarId == roomMinibarInfo.MinibarId && x.HotelId == this.UserInfo.HotelId);
                    var orders = this.dbContext.MinibarConsume.Where(x => x.HotelId == this.UserInfo.HotelId && x.RoomNumber == roomInfo.RoomNumber && new DataEnum.MinibarConsumeFinishStatus[] { DataEnum.MinibarConsumeFinishStatus.Created, DataEnum.MinibarConsumeFinishStatus.Served }.Contains(x.FinishStatus));

                    resp.Data = new { Products = products, Orders = orders };

                    resp.IsError = false;
                }

            }

            return resp;
        }

        /// <summary>
        /// 消费记账
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public BaseReturn Post([FromBody]string value)
        {
            var resp = new BaseReturn();



            return resp;
        }

        /// <summary>
        /// 取消记账
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public BaseReturn Delete(int id)
        {
            var resp = new BaseReturn();



            return resp;
        }
    }
}
