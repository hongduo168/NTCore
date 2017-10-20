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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers
{
    [AllowAnonymous]
    public class PassportController : Controller
    {
        private ILogger<ValuesController> logger;
        private MainContext dbContext;
        protected PassportController(ILogger<ValuesController> logger, MainContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }


        public IActionResult Login(string username, string password, string backUrl)
        {
            return View();
            //var user = this.dbContext.User.FirstOrDefault(x => x.Username == username);
            //if (user != null)
            //{
            //    if (user.Confirmed)
            //    {
            //        if (user.Password == password)
            //        {
            //            var claims = new ClaimsIdentity(CookieKeys.AuthenticationScheme);
            //            claims.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            //            claims.AddClaim(new Claim(ClaimTypes.GroupSid, user.HotelId.ToString()));

            //            var cp = new ClaimsPrincipal(claims);
            //            await HttpContext.SignInAsync(CookieKeys.AuthenticationScheme, cp, new AuthenticationProperties
            //            {
            //                IsPersistent = true,
            //                ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180)),
            //            });
            //        }
            //    }
            //}




            //if (string.IsNullOrWhiteSpace(backUrl))
            //{
            //    backUrl = "/";
            //}
            //return Redirect(backUrl);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieKeys.AuthenticationCookie);
            return Redirect("/");
        }

        [Authorize]
        public IActionResult forbidden()
        {
            return View();
        }

    }
}
