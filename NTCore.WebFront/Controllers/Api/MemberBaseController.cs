using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using NTCore.DataModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers.Api
{
    public class MemberBaseController : Controller
    {
        protected ILogger<MemberBaseController> logger;
        protected MainContext dbContext;

        protected MemberBaseController(ILogger<MemberBaseController> logger, MainContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }


        private UserInfo userinfo = null;

        public UserInfo UserInfo
        {
            get
            {
                if (this.userinfo == null)
                {
                    //var name = HttpContext.User.Identity.Name;
                    var name = "hongduo168";
                    if (!string.IsNullOrEmpty(name))
                    {
                        this.userinfo = this.dbContext.User.FirstOrDefault(x => x.Username == name && x.Confirmed);
                    }

                }


                return userinfo;
            }
        }
    }
}
