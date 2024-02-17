using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Exceptions;
using System.Reflection;

namespace OnionArch.Application
{
    public static class Registiration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
