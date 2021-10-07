using Decors.API.Extensions;
using Decors.API.Middlewares;
using Decors.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Decors.API
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
            // Add Application Settings.
            services.AddApplicationSettings(Configuration);

            // Add Swagger Documentation Service.
            services.AddSwaggerDocumentation();

            // Add Identity Service.
            services.AddIdentityServices();

            // Add Authentication & Authorization Service.
            services.AddAuthServices(Configuration);

            // Add Application Services.
            services.AddApplicationServices();

            services.AddInfrastructureServices(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Global exception handling
            app.UseMiddleware<GlobalExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();

                // Use Swagger Documentation in Pipeline (only in development environment).
                app.UseSwaggerDocumentation();
            }

            app.UseRouting();

            // Use Authentication & Authorization Services in Pipeline.
            app.UseAuthServices();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
