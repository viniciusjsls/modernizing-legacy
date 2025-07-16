using LegacyModernization.Application.Abstractions.Repositories;
using LegacyModernization.Application.Abstractions.Services;
using LegacyModernization.Application.Services;
using LegacyModernization.Application.UseCases.CreateOrder;
using LegacyModernization.Infrastructure.Data;
using LegacyModernization.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LegacyModernization.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppDbContext>(options
             => options.UseSqlServer());
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
