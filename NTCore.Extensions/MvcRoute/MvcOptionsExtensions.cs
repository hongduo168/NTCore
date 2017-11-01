using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.Extensions.MvcRoute
{
    public static class MvcOptionsExtensions
    {
        public static void UseCentralRoutePrefix(this MvcOptions opts, IRouteTemplateProvider apiRouteAttribute, IRouteTemplateProvider mvcRouteAttribute)
        {
            // 添加我们自定义 实现IApplicationModelConvention的RouteConvention
            opts.Conventions.Insert(0, new ApiRouteConvention(apiRouteAttribute));
            //opts.Conventions.Insert(1, new MvcRouteConvention(mvcRouteAttribute));
        }
    }

}
