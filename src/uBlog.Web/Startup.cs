﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using uBlog.Core.Services;
using uBlog.Data;

namespace uBlog
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("project.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ISettingService, SettingService>();
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Errors",
                template: "errors/{code}",
                defaults: new { controller = "Errors", action = "Details" });

            routeBuilder.MapRoute(
                name: "Admin",
                template: "{area:exists}/{controller}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}",
                defaults: new { controller = "Posts", action = "Index" });

            routeBuilder.MapRoute(
                name: "Details",
                template: "{controller}/{slug}",
                defaults: new { controller = "Posts", action = "Details" });

            routeBuilder.MapRoute(
                name: "Page",
                template: "posts/page/{page}",
                defaults: new { controller = "Posts", action = "Index" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseIISPlatformHandler();
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();                
            }
            app.UseRuntimeInfoPage("/info");
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

            var projConfig = new ConfigurationBuilder().AddJsonFile("project.json").Build();
            var appVersion = projConfig["version"]; //Output version number
            var mvcVersion = projConfig["dependencies:Microsoft.AspNet.Mvc"]; // Output MVC version

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}