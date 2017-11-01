using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers
{
    public class BaseController : Controller
    {
        protected ILogger<BaseController> logger;
        protected MainContext dbContext;
        public BaseController(ILogger<BaseController> logger, MainContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }


    }
}
