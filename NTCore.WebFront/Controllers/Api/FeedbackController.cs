using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;
using NTCore.DataModel;

namespace NTCore.WebFront.Controllers.Api
{
    [Route("feedback")]
    public class FeedbackController : MemberBaseController
    {
        protected FeedbackController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {

        }

        /// <summary>
        /// 用户反馈
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody]FeedbackPostInfo info)
        {
            var resp = new BaseReturn();

            if (!string.IsNullOrEmpty(info.Content))
            {
                var model = new ActionRecordInfo()
                {
                    CreateTime = DateTime.Now,
                    CreatorId = this.UserInfo.Id,
                    DataSort = 0,
                    DataState = EnumState.Normal,
                    DataType = DataEnum.ActionRecordType.Feedback,
                    HotelId = this.UserInfo.HotelId,
                    Text = info.Content,
                    TypeId = this.UserInfo.Id.ToString(),
                    UpdaterId = this.UserInfo.Id,
                    UpdateTime = DateTime.Now,
                };
                //this.dbContext.Add(model);
                this.dbContext.ActionRecord.Add(model);
            }

            resp.IsError = this.dbContext.SaveChanges() < 1;
            return Json(resp);
        }


    }
}
