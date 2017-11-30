using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Exceptional;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTCore.WebFront.Controllers
{
    [Route("exceptions")]
    public class ExceptionsController : Controller
    {
        /// <summary>
        /// This lets you access the error handler via a route in your application, secured by whatever
        /// mechanisms are already in place.
        /// </summary>
        /// <remarks>If mapping via RouteAttribute: [Route("errors/{path?}/{subPath?}")]</remarks>
        [Route("index/{path?}/{subPath?}")]
        public async Task Index() => await ExceptionalMiddleware.HandleRequestAsync(HttpContext).ConfigureAwait(false);
    }
}
