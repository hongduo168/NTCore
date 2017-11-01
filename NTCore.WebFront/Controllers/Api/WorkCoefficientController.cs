using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;

namespace NTCore.WebFront.Controllers.Api
{
    [Route("work-coefficient")]
    public class WorkCoefficientController : MemberBaseController
    {
        protected WorkCoefficientController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
