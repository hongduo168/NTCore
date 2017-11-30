using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.Utility;
using StackExchange.Exceptional;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers
{
    [Route("passport")]
    [AllowAnonymous]
    public class PassportController : BaseController
    {
        public PassportController(ILogger<PassportController> logger, MainContext dbContext) : base(logger, dbContext)
        {
            throw new AggregateException("AAAAAAAAAAAAAAAAAAAAAA");
        }

        public async Task<IActionResult> Login(string username, string password, string backUrl)
        {
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
                    }
                }
            }




            if (string.IsNullOrWhiteSpace(backUrl))
            {
                backUrl = "/";
            }
            return Redirect(backUrl);
        }


        [Route("auto-login")]
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> AutoLogin()
        {
            var firstOrDefault = this.dbContext.User.FirstOrDefault();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, firstOrDefault?.Username ?? string.Empty) }, CookieKeys.AuthenticationScheme));
            await HttpContext.SignInAsync(CookieKeys.AuthenticationScheme, user, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
            });

            var nameValue = User.FindFirst(ClaimTypes.Name)?.Value;

            var isAuth = User.Identity.IsAuthenticated;
            var name = User.Identity.Name;

            return Json(new string[] { nameValue, isAuth.ToString() });
        }

        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieKeys.AuthenticationScheme);
            return Redirect("/");
        }

        [Authorize]
        public IActionResult forbidden()
        {
            return View();
        }



    }
}
