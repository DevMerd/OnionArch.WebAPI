using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionArch.Application
{
    public static class Registiration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
