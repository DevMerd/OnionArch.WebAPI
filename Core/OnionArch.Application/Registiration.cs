using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Exceptions;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using MediatR;
using OnionArch.Application.Behaviors;

namespace OnionArch.Application
{
    public static class Registiration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }
    }
}
