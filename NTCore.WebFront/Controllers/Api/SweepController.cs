using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;
using NTCore.BizLogic.DbAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 打扫
    /// </summary>
    [Route("sweep")]
    public class SweepController : MemberBaseController
    {
        protected HotelRoomRepository hotelRoomRepository;
        protected SweepController(ILogger<MemberBaseController> logger, MainContext dbContext, HotelRoomRepository hotelRoomRepository) : base(logger, dbContext)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }


        /// <summary>
        /// 开始打扫
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public BaseReturn Post([FromBody]SweepPostInfo value)
        {
            var resp = new BaseReturn();

            if (!string.IsNullOrEmpty(value?.RoomNumber))
            {
                resp.IsError = !this.hotelRoomRepository.SweepStart(value.RoomNumber, this.UserInfo);
            }

            return resp;
        }

        /// <summary>
        /// 结束打扫
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values
        [HttpPut]
        public BaseReturn Put([FromBody]SweepPostInfo value)
        {
            var resp = new BaseReturn();

            if (!string.IsNullOrEmpty(value?.RoomNumber))
            {
                resp.IsError = !this.hotelRoomRepository.SweepFinsh(value.RoomNumber, this.UserInfo);
                if (!resp.IsError)
                {
                    //TODO 改房态接口

                }
            }

            return resp;
        }

        /// <summary>
        /// 取消打扫
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete]
        public BaseReturn Delete([FromBody]SweepPostInfo value)
        {
            var resp = new BaseReturn();

            if (!string.IsNullOrEmpty(value?.RoomNumber))
            {
                resp.IsError = !this.hotelRoomRepository.SweepCancel(value.RoomNumber, this.UserInfo);
            }

            return resp;
        }
    }
}
