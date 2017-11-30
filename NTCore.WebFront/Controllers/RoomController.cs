﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTCore.DataAccess;
using StackExchange.Exceptional;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers
{
    [Route("room")]
    public class RoomController : BaseController
    {
        public RoomController(ILogger<RoomController> logger, MainContext dbContext) : base(logger, dbContext)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


    }
}
