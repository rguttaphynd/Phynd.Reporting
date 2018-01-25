using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Phynd.Common.Interfaces;
using Phynd.Common.Services;
using Phynd.Reporting.Api.Authentication;
using Phynd.Reporting.Api.Middleware;
using Phynd.Reporting.BusinessService;
using Phynd.Reporting.DataService.Interfaces;
using Phynd.Reporting.DataService.Services;

namespace Phynd.Reporting.Api
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
            services.AddMvc();
            
            services.Add(new ServiceDescriptor(typeof(ChangeLogDataServiceWrite),
                new ChangeLogDataServiceWrite(Configuration.GetConnectionString("WriteConnection"))));
            services.Add(new ServiceDescriptor(typeof(ChangeLogDataServiceRead),
                new ChangeLogDataServiceRead(Configuration.GetConnectionString("ReadConnection"))));
           
            services.AddTransient<IChangeLogDataServiceWrite>(s=> new ChangeLogDataServiceWrite(Configuration.GetConnectionString("WriteConnection")));
            services.AddTransient<IChangeLogDataServiceRead>(s => new ChangeLogDataServiceRead(Configuration.GetConnectionString("ReadConnection")));
            services.AddTransient<IChangeLogBusinessService, ChangeLogBusinessService>();
			
            services.AddTransient<ILoggingManager, LoggingManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CustomAuthOptions.DefaultScheme;
                options.DefaultChallengeScheme = CustomAuthOptions.DefaultScheme;
            })
            // Call custom authentication extension method
            .AddCustomAuth(options =>
            {
                // Configure single or multiple passwords for authentication
                options.AuthKey = "custom auth key";
            });

            services.AddMvc(options =>
            {
                // All endpoints need authentication
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseGetToken();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
            
        }
    }
}
