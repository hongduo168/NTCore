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
using NTCore.Extensions.MvcFilter;
using NTCore.Utility;

namespace NTCore.WebFront
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("SqlServer");
            services.AddEntityFrameworkSqlServer().AddDbContext<MainContext>(options => options.UseSqlServer(connection));

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

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidationFilter));

                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();


            loggerFactory.AddLog4Net();
        }
    }
}

