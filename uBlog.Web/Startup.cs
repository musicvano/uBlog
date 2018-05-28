using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using uBlog.Core.Services;
using uBlog.Data;

namespace uBlog.Web
{
    public class Startup
    {
        private readonly string rootPath;

        public Startup(IHostingEnvironment env)
        {
            rootPath = env.ContentRootPath;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbPath = Path.Combine(rootPath, AppSettings.DatabasePath);
            services.AddScoped<IBlogContext>(p => new BlogContext(dbPath));
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IInstallService, InstallService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();
            services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);
            services.AddMvc();
        }

        // Configure routes
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Api",
                template: "{area:exists}/{controller}");

            routeBuilder.MapRoute(
                name: "Admin",
                template: "admin/{*url}",
                defaults: new { controller = "Admin", action = "Index" });

            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller}",
                defaults: new { controller = "Posts", action = "Index" });

            routeBuilder.MapRoute(
                name: "Post",
                template: "posts/{slug}",
                defaults: new { controller = "Posts", action = "Details" });

            routeBuilder.MapRoute(
                name: "Tag",
                template: "tags/{slug}",
                defaults: new { controller = "Tags", action = "Details" });

            routeBuilder.MapRoute(
                name: "Page",
                template: "posts/page/{page}",
                defaults: new { controller = "Posts", action = "Index" });

            /*routeBuilder.MapRoute(
                name: "Error",
                template: "errors/{code}",
                defaults: new { controller = "Errors", action = "Index" });*/

            /*routeBuilder.MapRoute(
                name: "NotFound",
                template: "{*url}",
                defaults: new { controller = "Errors", action = "Index", code = 404 });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/errors/500");
            }
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);
        }
    }
}