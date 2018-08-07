using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHopDongRepository, HopDongRepository>();
            services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();
            services.AddMvc();
            services.AddMvcCore().AddRazorViewEngine();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                
                    routes.MapRoute(
                      name: "Defaults",
                      template: "{controller=Home}/{action=Index}/{id?}"
                    );

                //routes.MapRoute(
                //   name: "Create",
                //   template: "Create",
                //   defaults: new { controller = "Home", action = "Create" });


                //routes.MapRoute(

                //    name: "Details",
                //    template: "Details/{id?}"
                //    //defaults: new { controller = "HopDongController", action = "Details", id="1"}
                //                );
                //routes.MapRoute(

                //    name: "Create",
                //    template: "CreateIndex"
                //  //  defaults: new { controller = "HopDongController", action = "CreateIndex" }

                //);
                //routes.MapRoute(

                //    name: "Delete",
                //    template: "Delete/{id?}"
                //                //defaults: new { controller = "HopDongController", action = "Details", id="1"}
                //                );


            });

        }
    }
}
