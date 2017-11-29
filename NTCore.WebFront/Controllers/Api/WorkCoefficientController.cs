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
    [Route("work-coefficient")]
    public class WorkCoefficientController : MemberBaseController
    {
        protected ActionRecordRepository action;
        protected WorkCoefficientController(ILogger<MemberBaseController> logger, MainContext dbContext, ActionRecordRepository actionRecordRepository) : base(logger, dbContext)
        {
            this.action = actionRecordRepository;
        }

        /// <summary>
        /// 修改计件系数
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReturn Post([FromBody]WorkCoefficientPostInfo info)
        {
            var resp = new BaseReturn();

            if (info.Coefficient != 0)
            {
                foreach (var item in info.RoomNumber)
                {
                    var model = this.dbContext.HotelRoom.FirstOrDefault(x => x.RoomNumber == item && x.HotelId == this.UserInfo.HotelId);
                    if (model != null)
                    {
                        //记录日志
                        action.Logger(this.UserInfo, string.Format("Coefficient Changed({0} to {1})", model.Coefficient, info.Coefficient), model.Id.ToString(), false);
                        model.Coefficient = info.Coefficient;
                    }
                }
            }

            resp.IsError = this.dbContext.SaveChanges() < 1;
            return resp;
        }



    }
}
