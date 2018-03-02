using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;
using NTCore.BizLogic;
using NTCore.DataAccess;
using NTCore.Extensions.MvcFilter;
using NTCore.RedisAccess;
using NTCore.Utility;

namespace NTCore.WebFront.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger<ValuesController> logger;
        private MainContext dbContext;

        public ValuesController(ILogger<ValuesController> logger, MainContext dbContext)
        {
            
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [AllowAnonymous]
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var firstOrDefault = this.dbContext.User.FirstOrDefault();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "bob"), new Claim(ClaimTypes.Name, "bob222") }, CookieKeys.AuthenticationScheme));
            await HttpContext.SignInAsync(CookieKeys.AuthenticationScheme, user, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
            });

            var nameValue = User.FindFirst(ClaimTypes.Name)?.Value;

            var isAuth = User.Identity.IsAuthenticated;
            var name = User.Identity.Name;

            return new string[] { nameValue, isAuth.ToString(), RedisManager.Manager.GetDatabase(0).StringGet("aa") };
        }

        [Authorize]
        // GET api/values/5
        [HttpGet("{id}")]
        [ValidationArray("name")]
        public string Get(int id, User user)
        {
            return "value" + id;
        }

        // POST api/values
        [HttpPost]
        public ReturnValue<object> Post([FromBody]string value)
        {
            var rm = new ReturnValue<object>(null);
            return rm;
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
