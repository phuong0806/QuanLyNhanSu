using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IChiTietDaoTapRepository, ChiTietDaoTaoRepository>();
            services.AddTransient<IChucVuRepository, ChucVuRepository>();
            services.AddTransient<IChuyenNganhRepository, ChuyenNganhRepository>();
            services.AddTransient<IDaoTaoChuyenNganhRepository, DaoTaoChuyenNganhRepository>();
            services.AddTransient<IDonViRepository, DonViRepository>();
            services.AddTransient<IHopDongRepository, HopDongRepository>();
            services.AddTransient<IKhenThuongRepository, KhenThuongRepository>();
            services.AddTransient<IKyLuatRepository, KyLuatRepository>();
            services.AddTransient<ILoaiDaoTaoRepository, LoaiDaoTaoRepository>();
            services.AddTransient<INhanVienRepository, NhanVienRepository>();
            services.AddTransient<IPhongBanRepository, PhongBanRepository>();
            services.AddTransient<IThanNhanRepository, ThanNhanRepository>();
            services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();

            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .WithOrigins("http://localhost:58861")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseMvc();
        }
    }
}
