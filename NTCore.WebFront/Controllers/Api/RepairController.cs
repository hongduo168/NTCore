using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.WebFront.Model;

namespace NTCore.WebFront.Controllers.Api
{
    [Route("repair")]
    public class RepairController : MemberBaseController
    {
        protected RepairController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        /// <summary>
        /// 获取房间维修记录
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id?}")]
        public BaseReturn Get(string id)
        {
            var resp = new BaseReturn();

            

            return resp;
        }

        /// <summary>
        /// 上报维修
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseReturn Post()
        {
            var resp = new BaseReturn();



            return resp;
        }


        /// <summary>
        /// 维修开始/暂停/完成/检查
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public BaseReturn Put()
        {
            var resp = new BaseReturn();



            return resp;
        }


        /// <summary>
        /// 撤销
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public BaseReturn Delete()
        {
            var resp = new BaseReturn();



            return resp;
        }

    }
}
