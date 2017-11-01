using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;

namespace NTCore.WebFront.Controllers.Api
{
    [Route("repair")]
    public class RepairController : MemberBaseController
    {
        protected RepairController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }


    }
}
