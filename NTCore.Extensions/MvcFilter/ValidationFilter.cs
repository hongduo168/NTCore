using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NTCore.Utility;

namespace NTCore.Extensions.MvcFilter
{
    /// <summary>
    /// 输入验证
    /// 仅支持实体类参数
    /// </summary>
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //do something before the action executes
            var action = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var attrs = action.MethodInfo.GetCustomAttributes(typeof(ValidationArray), false);
            if (attrs != null && attrs.Length > 0)
            {
                var names = ((ValidationArray)attrs[0]).Names;
                if (names != null && names.Length > 0)
                {
                    foreach (var item in context.ModelState.ToArray())
                    {
                        if (!names.Contains(item.Key))
                        {
                            context.ModelState.Remove(item.Key);
                        }
                    }
                }

                if (!context.ModelState.IsValid)
                {
                    var model = new ReturnValue<ModelStateDictionary>(false, string.Empty, context.ModelState);
                    context.Result = new BadRequestObjectResult(model);
                }
            }


        }


    }
}
