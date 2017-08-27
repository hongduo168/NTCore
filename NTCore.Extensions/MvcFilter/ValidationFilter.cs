using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NTCore.Extensions.MvcFilter
{
    /// <summary>
    /// 输入验证
    /// </summary>
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //do something before the action executes
            var action = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var attrs = action.MethodInfo.GetCustomAttributes(typeof(ValidationArray), false);
            if (attrs != null && attrs.Length > 0)
            {
                var names = ((ValidationArray)attrs[0]).Names;
                if (names != null && names.Length > 0)
                {

                }
            }

            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //do something after the action executes
            throw new NotImplementedException();
        }
    }
}
