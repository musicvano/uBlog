using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;
using uBlog.Core.Services;
using uBlog.Data;
using uBlog.Data.Entities;
using uBlog.Web.Helpers;

namespace uBlog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);
            services.AddMvc();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<BlogContext>();
            services.AddSingleton<IAppConfig, AppConfig>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IConfigService, ConfigService>();
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Admin",
                template: "admin",
                defaults: new { controller = "Account", action = "Login" });

            routeBuilder.MapRoute(
                name: "Help",
                template: "help",
                defaults: new { controller = "Help", action = "Index" });

            routeBuilder.MapRoute(
                name: "Errors",
                template: "errors/{code}",
                defaults: new { controller = "Errors", action = "Details" });

            routeBuilder.MapRoute(
                name: "Admin_",
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
                app.UseDeveloperExceptionPage();                
            }
            app.UseRuntimeInfoPage("/info");
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(ConfigureRoutes);
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}