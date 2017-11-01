using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;

namespace NTCore.WebFront.Controllers.Api
{
    /// <summary>
    /// 上班管理
    /// </summary>
    [Route("work-ready")]
    public class WorkReadyController : MemberBaseController
    {
        protected WorkReadyController(ILogger<MemberBaseController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
