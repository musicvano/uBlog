using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Security.Claims;
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

            // Configure logger
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.RollingFile(Path.Combine(rootPath, AppSettings.LoggerPath))
            .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbPath = Path.Combine(rootPath, AppSettings.DatabasePath);
            services.AddScoped<IBlogContext>(p => new BlogContext(dbPath));
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITagService, TagService>();

            // Configure authentication
            services.AddAuthentication();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });

            });
            services.AddRouting(routeOptions => routeOptions.LowercaseUrls = true);
            services.AddMvc();
        }

        // Configure routes
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                name: "Admin",
                template: "{area:exists}/{controller=Home}/{action=Index}");

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

            routeBuilder.MapRoute(
                name: "Error",
                template: "errors/{code}",
                defaults: new { controller = "Errors", action = "Index" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/errors/500");
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseStaticFiles();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            //app.UseMiddleware<AuthMiddleware>();
            app.UseMvc(ConfigureRoutes);

        }
    }
}