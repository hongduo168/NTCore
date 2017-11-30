using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NTCore.DataAccess;
using NTCore.Extensions.HttpContext;
using NTCore.Extensions.MvcFilter;
using NTCore.Utility;
using MySQL.Data.EntityFrameworkCore.Extensions;
using NTCore.Extensions.MvcRoute;
using Microsoft.AspNetCore.Mvc;
using NTCore.DataModel;
using NTCore.DataAccess.DAL;
using NTCore.BizLogic.DbAccess;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace NTCore.WebFront
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("SqlServer");
            services.AddEntityFrameworkSqlServer().AddDbContext<MainContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("NTCore.WebFront")));

            //var connection = Configuration.GetConnectionString("MySQL");
            //services.AddEntityFrameworkSqlServer().AddDbContext<MainContext>(options => options.UseMySQL(connection, b => b.MigrationsAssembly("NTCore.WebFront")));

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieKeys.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieKeys.AuthenticationScheme;
                })
                .AddCookie(CookieKeys.AuthenticationScheme, options =>
                {
                    options.Cookie.Name = CookieKeys.AuthenticationCookie;
                    options.Cookie.Path = "/";

                    var path = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auth-ticket-keys"));
                    options.DataProtectionProvider = DataProtectionProvider.Create(path);

                    options.LoginPath = "/passport/login";
                    options.LogoutPath = "/passport/logout";
                    options.AccessDeniedPath = "/passport/forbidden";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                });


            //services.AddSingleton()
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidationFilter));
                //options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"), new RouteAttribute(""));

                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //不使用驼峰样式的key
                //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            //Exceptional
            services.AddExceptional(Configuration.GetSection("Exceptional"), settings =>
            {
                //settings.UseExceptionalPageOnThrow = Configuration.GetValue<bool>("ThrowException");
                settings.UseExceptionalPageOnThrow = HostingEnvironment.IsDevelopment();
            });


            //Biz
            services.AddSingleton<IRepository<ActionRecordInfo>, ActionRecordRepository>();
            services.AddSingleton<IRepository<HotelRoomInfo>, HotelRoomRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseExceptional();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStaticHttpContext();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });


            loggerFactory.AddLog4Net();
        }
    }
}

