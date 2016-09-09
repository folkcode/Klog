
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Klog.Models;
using AutoMapper;
using Klog.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace Klog {
    public class Startup {
        
        // public static IConfigurationRoot Configuration;
        public object env { get; private set; }

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json") //  , optional: true
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment()) {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                 builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddMvc(config => {
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
                .AddJsonOptions(
                    opt => {
                        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });

            var connectionString = Configuration["Data:BlogContextCon"];
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connectionString));
            services.AddEntityFramework();
            services.AddDbContext<BlogContext>();
         
            services.AddIdentity<BlogUser, IdentityRole>(config => {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents() {
                    OnRedirectToLogin = ctx => {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == (int)HttpStatusCode.OK) {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        } else {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
            })
          .AddEntityFrameworkStores<BlogContext>();

            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddTransient<BlogContextSeedData>();
            services.AddScoped<IBlogRepository, BlogRepository>();
        }

        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, BlogContextSeedData seeds) { //
            {
                 logger.AddConsole(Configuration.GetSection("Logging"));
                 logger.AddDebug();

             app.UseApplicationInsightsExceptionTelemetry();
            
                if (env.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();
                    // app.UseBrowserLink();
                } else {
                    app.UseExceptionHandler("/Home/Error");
                }
                
                
                app.UseDefaultFiles();
                app.UseStaticFiles();

                app.UseMvc(config => {
                    config.MapRoute(
                        name: "Default",
                        template: "{controller}/{action}/{id?}",
                        defaults: new { controller = "App", action = "Index" }
                        );
                }
            );

                Mapper.Initialize(config => {
                    config.CreateMap<Blogpost, BlogViewModel>().ReverseMap();
                    config.CreateMap<Comment, CommentViewModel>().ReverseMap();
                });

                await seeds.EnsureSeedDataAsync();
            }

        }
        
    }   
}


