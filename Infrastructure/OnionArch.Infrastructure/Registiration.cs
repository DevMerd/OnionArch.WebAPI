using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Infrastructure.Tokens;

namespace OnionArch.Infrastructure
{
    public static class Registiration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("Jwt"));
        }

    }
}
