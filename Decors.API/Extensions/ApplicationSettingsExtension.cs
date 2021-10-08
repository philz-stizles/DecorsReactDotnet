using Decors.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Decors.API.Extensions
{
    public static class ApplicationSettingsExtension
    {
        public static IServiceCollection AddApplicationSettings(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<SendGridSettings>(Configuration.GetSection("SendGridSettings"));


            return services;
        }
    }
}
