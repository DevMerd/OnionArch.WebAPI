using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Interfaces.AutoMapper;

namespace OnionArch.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
