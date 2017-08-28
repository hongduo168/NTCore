using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;
using NTCore.Extensions.MvcFilter;
using NTCore.RedisAccess;

namespace NTCore.WebFront.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            logger.LogError("BBBBBBBBBBBBBBBBBBBB", new AggregateException());
            return new string[] { "value1", "value2", RedisConfig.Get() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ValidationArray("name")]
        public string Get(int id, User user)
        {
            return "value" + id;
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

    public class User
    {
        [Required]
        public string name { get; set; }
    }
}
