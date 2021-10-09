using Decors.Application.Contracts.Repositories;
using Decors.Infrastructure.Persistence.Context;
using Decors.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Decors.Infrastructure
{
    public static class InfrastructureServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration configuration
        )
        {
            services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();

            // services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            // services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
