using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model.Api;
using NTCore.WebFront.Model;
using NTCore.BizLogic.DbAccess;

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 上班管理
    /// </summary>
    [Route("work-ready")]
    public class WorkReadyController : MemberBaseController
    {
        protected ActionRecordRepository action;
        protected WorkReadyController(ILogger<MemberBaseController> logger, MainContext dbContext, ActionRecordRepository actionRecordRepository) : base(logger, dbContext)
        {
        }

        /// <summary>
        /// 上下班管理
        /// 如果参数没有UserId，则修改当前登录用户上班状态
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public BaseReturn Post([FromBody]WorkReadyPostInfo info)
        {
            var resp = new BaseReturn();
            if (info.UserId == 0)
            {
                info.UserId = this.UserInfo.Id;
            }

            if (info.UserId > 0)
            {
                var model = this.dbContext.User.FirstOrDefault(x => x.Id == info.UserId);
                if (model != null)
                {
                    action.Logger(this.UserInfo, string.Format("User WorkReady({0} to {1})", model.WorkReady, info.WorkReady), model.Id.ToString(), false);
                    model.WorkReady = info.WorkReady;
                }
            }

            resp.IsError = this.dbContext.SaveChanges() < 1;
            return resp;
        }



    }
}
