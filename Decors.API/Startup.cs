using Decors.API.Extensions;
using Decors.API.Filters;
using Decors.API.Middlewares;
using Decors.API.SignalR;
using Decors.Application.Services.Auth;
using Decors.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Decors.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // Read the configuration keys from the secret store.
                // Ensure to generate user secret id using "dotnet user-secrets init"
                builder.AddUserSecrets<Program>();
            }

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
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
            services.AddApplicationServices(Configuration);

            // Add Infrastructure Services.
            services.AddInfrastructureServices(Configuration);

            // Add Cors Services
            services.AddCorsServices(Configuration);

            // Add Elastic Search Services
            services.AddElasticSearchServices(Configuration);

            services.AddControllers(options => {
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<RegisterVendor.Handler>();
            });

            services.AddApiValidationService();
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

            app.UseApplicationServices();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCorsServices();

            // Use Authentication & Authorization Services in Pipeline.
            app.UseAuthServices();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*endpoints.MapHub<ChatHub>("/chathub");*/
            });
        }
    }
}
