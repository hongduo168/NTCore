using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.Utility;
using NTCore.WebFront.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 登录，退出
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILogger<LoginController> logger;
        private MainContext dbContext;
        protected LoginController(ILogger<LoginController> logger, MainContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string username, string password)
        {
            var resp = new BaseReturn();

            var user = this.dbContext.User.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                if (user.Confirmed)
                {
                    if (user.Password == password)
                    {
                        var claims = new ClaimsIdentity(CookieKeys.AuthenticationScheme);
                        claims.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                        claims.AddClaim(new Claim(ClaimTypes.GroupSid, user.HotelId.ToString()));

                        var cp = new ClaimsPrincipal(claims);
                        await HttpContext.SignInAsync(CookieKeys.AuthenticationScheme, cp, new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
                        });

                        resp.IsError = false;
                    }
                }
            }

            return Json(resp);


        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = new BaseReturn(false);
            await HttpContext.SignOutAsync(CookieKeys.AuthenticationCookie);
            return Json(resp);
        }



    }
}
