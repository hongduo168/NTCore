using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;
using NTCore.WebFront.Model.Api;
using NTCore.BizLogic.NTAttribute;

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 客需
    /// </summary>
    [Route("customer-request"), Permission("customer-request", "客需相关")]
    public class CustomerRequestController : MemberBaseController
    {
        protected CustomerRequestController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {

        }

        private const int CustomerRequestDays = 30;
        /// <summary>
        /// 获取全部客需
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Permission("customer-request-get", "客需列表", typeof(CustomerRequestController))]
        public BaseReturn Get()
        {
            var resp = new BaseReturn(false);

            var supply = this.dbContext.HotelSupplyDefine.Where(x => x.HotelId == this.UserInfo.HotelId && x.DataType == DataModel.DataEnum.CustomerRequestDefineType.CustomerRequest).ToList();
            var request = this.dbContext.CustomerRequest.Where(x => x.HotelId == this.UserInfo.HotelId &&
                (x.CreateTime > DateTime.Now.AddDays(-CustomerRequestDays) || (x.FinishStatus != DataModel.DataEnum.CustomerRequestFinishStatus.Finish && x.FinishStatus != DataModel.DataEnum.CustomerRequestFinishStatus.Cancel))).ToList();

            var requestId = request.Select(x => x.Id);
            var requestItem = this.dbContext.CustomerRequestItem.Where(x => x.HotelId == this.UserInfo.HotelId && requestId.Contains(x.CustomerRequestId)).ToList();

            var userId = request.Select(x => x.AssignUserId);
            var users = this.dbContext.User.Where(x => userId.Contains(x.Id)).ToList();


            resp.Data = new { CustomerRequest = request, CustomerRequestItem = requestItem, User = users, supply };

            return resp;

        }

        /// <summary>
        /// 新增客需
        /// </summary>
        /// <returns></returns>
        [HttpPost, Permission("customer-request-post", "新增客需", typeof(CustomerRequestController))]
        public BaseReturn Post([FromBody]CustomerRequestPostInfo info)
        {
            var resp = new BaseReturn();



            return resp;

        }

        /// <summary>
        /// 修改客需
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}"), Permission("customer-request-put", "更新客需", typeof(CustomerRequestController))]
        public BaseReturn Put(string id)
        {
            var resp = new BaseReturn();



            return resp;

        }

        /// <summary>
        /// 关闭客需
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Permission("customer-request-close", "关闭客需", typeof(CustomerRequestController))]
        public BaseReturn Delete(string id)
        {
            var resp = new BaseReturn();



            return resp;
        }





    }
}
