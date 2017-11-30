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
    /// <summary>
    /// 大清房
    /// </summary>
    [Route("deep-clean")]
    public class DeepCleanController : MemberBaseController
    {
        protected HotelRoomRepository hotelRoomRepository;
        protected DeepCleanController(ILogger<MemberBaseController> logger, MainContext dbContext, HotelRoomRepository hotelRoomRepository) : base(logger, dbContext)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        /// <summary>
        /// 取消大清房
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete]
        public BaseReturn Delete([FromBody]DeepCleanPostInfo value)
        {
            var resp = new BaseReturn();

            if (value != null && value.WorkLoadId != 0)
            {
                resp.IsError = !this.hotelRoomRepository.SetNormalClean(value.WorkLoadId, this.UserInfo);
            }

            return resp;
        }


        /// <summary>
        /// 设置大清房
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpPost]
        public BaseReturn Post([FromBody]DeepCleanPostInfo value)
        {
            var resp = new BaseReturn();

            if (value != null && value.WorkLoadId != 0)
            {
                resp.IsError = !this.hotelRoomRepository.SetDeepClean(value.WorkLoadId, this.UserInfo);
            }

            return resp;
        }


    }
}
