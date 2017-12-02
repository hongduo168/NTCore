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
    [Route("hotel-user")]
    public class HotelUserController : MemberBaseController
    {
        protected HotelUserController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        // GET: api/values
        [HttpGet]
        public BaseReturn Get()
        {
            var resp = new BaseReturn(false);

            resp.Data = this.dbContext.User.Where(x => x.HotelId == this.UserInfo.HotelId).ToList();

            return resp;
        }

        // GET api/values/5
        [HttpGet("{id?}")]
        public string Get(int id)
        {
            return "value";
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
