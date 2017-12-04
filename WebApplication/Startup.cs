using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Data;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Use for dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext<WebApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RestaurantContent")));
            services.AddScoped<IRestaurantDataService, SQLRestaurantDataService>();
            //services.AddSingleton<IRestaurantDataService, InMemoryRestaurantDataService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Middlewear setup

            //app.Use(next =>
            //    {
            //        // Once per http request, middlewear setup
            //        return async context =>
            //        {
            //            logger.LogInformation("Request incoming");
            //            if (context.Request.Path.StartsWithSegments("/mym"))
            //            {
            //                await context.Response.WriteAsync("Hit!");
            //                logger.LogInformation("Request Handled");
            //            }
            //            else
            //            {
            //                await next(context);
            //                logger.LogInformation("Response ongoing");
            //            }
            //        };
            //    }
            //);

            #endregion

            #region Static file display

            //// Respond with index.html as default
            //app.UseDefaultFiles();

            // Gives wwwroot\index.html response after browsing index.html page
            app.UseStaticFiles();

            #endregion

            //// Take case of UseDefaultFiles & UseStaticFiles
            //app.UseFileServer();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(ConfigureRoutes);

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = greeter.GetWelcomeMessage();
                await context.Response.WriteAsync($"Not Found");
                //await context.Response.WriteAsync($"{greeting}-{env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("Default", "{controller}/{action}");

            // id is optional
            //routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
