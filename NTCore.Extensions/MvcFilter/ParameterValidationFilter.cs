using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NTCore.Extensions.MvcFilter
{
    /// <summary>
    /// 输入验证
    /// </summary>
    public class ParameterValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //do something before the action executes
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //do something after the action executes
            throw new NotImplementedException();
        }
    }
}
