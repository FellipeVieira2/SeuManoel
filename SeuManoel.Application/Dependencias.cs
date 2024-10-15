using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
namespace SeuManoel.Application
{
    public static class Dependencias
    {
        public static IServiceCollection ApplicationAdd(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            var serviceProvider = services.BuildServiceProvider();
            services.AddFluentValidationRulesToSwagger();
            return services;
        }
    }
}
