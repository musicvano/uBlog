using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Security.Claims;
using uBlog.Core.Services;
using uBlog.Data;
using uBlog.Web.Security;

namespace uBlog.Web
{
    public class Startup
    {
        private readonly string rootPath;

        // Contains settings from appsettings.json file
        public IConfigService Config { get; }

        public Startup(IHostingEnvironment env)
        {
            // Read appsettings.json file
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables().Build();
            Config = new ConfigService(configRoot, env.ContentRootPath);

            // Configure logger
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .WriteTo.RollingFile(Config.LoggerPath)
            .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddSingleton(Config);
            services.AddScoped<IBlogContext>(p => new BlogContext(Config.DatabasePath));
            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IInstallService, InstallService>();
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
            // If database doesn't exist, run install
            if (!File.Exists(Config.DatabasePath))
            {
                routeBuilder.MapRoute(
                    name: "Install",
                    template: "{controller=Install}/{action=Index}");
                return;
            }

            routeBuilder.MapRoute(
                name: "Admin",
                template: "{area:exists}/{controller=Home}/{action=Index}");

            routeBuilder.MapRoute(
                name: "Errors",
                template: "errors/{code}",
                defaults: new { controller = "Errors", action = "Details" });

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