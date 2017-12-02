using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 客需用品/客用品
    /// </summary>
    [Route("supply")]
    public class SupplyController : MemberBaseController
    {
        protected SupplyController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        // GET: api/values
        [HttpGet]
        public BaseReturn Get()
        {
            var resp = new BaseReturn(false);

            resp.Data = this.dbContext.HotelSupplyDefine.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            return resp;
        }

        /// <summary>
        /// 获取具体类型的消耗品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public BaseReturn Get(int id)
        {
            var resp = new BaseReturn(false);

            resp.Data = this.dbContext.HotelSupplyDefine.Where(x => x.HotelId == this.UserInfo.HotelId && x.DataType == (DataModel.DataEnum.CustomerRequestDefineType)id).ToList();

            return resp;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
