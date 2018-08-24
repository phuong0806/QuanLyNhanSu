using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QLNS.Data.Interface;
using QLNS.Data.Repository;

namespace QLNS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
         
        }
        public static void Register(HttpConfiguration config)
        {
            // New code
            var corsAttr = new EnableCorsAttribute("http://localhost", "*", "*");
            config.EnableCors(corsAttr);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cors => cors.AddPolicy("Policy", builder => {
                builder.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin()
                 .AllowCredentials();
            }));

            services.AddTransient<IHopDongRepository, HopDongRepository>();
            services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();
            services.AddMvc();
            services.AddMvcCore().AddRazorViewEngine();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();

            //}
            //app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{

            //    routes.MapRoute(
            //      name: "Defaults",
            //      template: "{controller=Home}/{action=Index}/{id?}"
            //    );

            //});
            //app.UseCors(builder => {
            //    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            //});
            //app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .WithOrigins("http://localhost:50670")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                  name: "Defaults",
                  template: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
