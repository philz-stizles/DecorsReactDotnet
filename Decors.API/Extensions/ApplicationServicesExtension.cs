using Decors.API.Filters;
using Decors.Application.Contracts.Services;
using Decors.Application.Mappers;
using Decors.Application.Services.Auth;
using Decors.Infrastructure.Services.Security;
using Decors.Infrastructure.Services.Storage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Decors.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JWTService>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();

            services.AddScoped<AuditFilterAttribute>();

            services.AddAutoMapper(typeof(UserProfile).Assembly);
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // services.AddAutoMapper(typeof(Startup));

            // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(RegisterVendor.Handler).Assembly);

            services.AddSignalR();

            return services;
        }
    }
}
